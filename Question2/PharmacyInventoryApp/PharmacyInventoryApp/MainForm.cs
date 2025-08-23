using PharmacyInventoryApp.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PharmacyInventoryApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            // Hook up events (designer wiring is fine too)
            this.Load += (s, e) => LoadAllMedicines();
            btnViewAll.Click += (s, e) => LoadAllMedicines();
            btnAdd.Click += btnAdd_Click;
            btnSearch.Click += btnSearch_Click;
            btnUpdateStock.Click += btnUpdateStock_Click;
            btnRecordSale.Click += btnRecordSale_Click;
        }

        // === VIEW ALL ===
        private void LoadAllMedicines()
        {
            var dt = new DataTable();
            using (var conn = Db.GetConn())
            {
                try
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("GetAllMedicines", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;   // ExecuteReader for view
                        using (var rdr = cmd.ExecuteReader())
                        {
                            dt.Load(rdr);
                        }
                    }
                    dgvMedicines.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load medicines: " + ex.Message);
                }
            }
        }

        // === ADD MEDICINE ===
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Basic validation
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtCategory.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text) ||
                string.IsNullOrWhiteSpace(txtQuantity.Text))
            {
                MessageBox.Show("Please enter Name, Category, Price, and Quantity.");
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out var price) || price < 0)
            {
                MessageBox.Show("Invalid price.");
                return;
            }
            if (!int.TryParse(txtQuantity.Text, out var qty) || qty < 0)
            {
                MessageBox.Show("Invalid quantity.");
                return;
            }

            using (var conn = Db.GetConn())
            {
                try
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("AddMedicine", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;   // ExecuteNonQuery for add
                        cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Category", txtCategory.Text.Trim());
                        cmd.Parameters.AddWithValue("@Price", price);
                        cmd.Parameters.AddWithValue("@Quantity", qty);

                        var outId = new SqlParameter("@NewMedicineID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(outId);

                        cmd.ExecuteNonQuery();

                        int newId = (int)outId.Value;
                        MessageBox.Show($"Medicine added. New ID = {newId}");
                    }

                    LoadAllMedicines();
                    // Optional: clear inputs
                    // txtName.Clear(); txtCategory.Clear(); txtPrice.Clear(); txtQuantity.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Add failed: " + ex.Message);
                }
            }
        }

        // === SEARCH ===
        private void btnSearch_Click(object sender, EventArgs e)
        {
            var term = txtSearch.Text?.Trim() ?? string.Empty;

            var dt = new DataTable();
            using (var conn = Db.GetConn())
            {
                try
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("SearchMedicine", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;   // ExecuteReader for search
                        cmd.Parameters.AddWithValue("@SearchTerm", term);

                        using (var rdr = cmd.ExecuteReader())
                        {
                            dt.Load(rdr);
                        }
                    }
                    dgvMedicines.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Search failed: " + ex.Message);
                }
            }
        }

        // === UPDATE STOCK (absolute set) ===
        private void btnUpdateStock_Click(object sender, EventArgs e)
        {
            if (dgvMedicines.CurrentRow == null)
            {
                MessageBox.Show("Select a medicine in the list first.");
                return;
            }
            if (!int.TryParse(txtQuantity.Text, out var newQty) || newQty < 0)
            {
                MessageBox.Show("Enter a valid Quantity to set.");
                return;
            }

            int medId = Convert.ToInt32(dgvMedicines.CurrentRow.Cells["MedicineID"].Value);

            using (var conn = Db.GetConn())
            {
                try
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("UpdateStock", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;   // ExecuteNonQuery for update
                        cmd.Parameters.AddWithValue("@MedicineID", medId);
                        cmd.Parameters.AddWithValue("@Quantity", newQty);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Stock updated.");
                    LoadAllMedicines();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Update stock failed: " + ex.Message);
                }
            }
        }

        // === RECORD SALE (decrements stock) ===
        private void btnRecordSale_Click(object sender, EventArgs e)
        {
            if (dgvMedicines.CurrentRow == null)
            {
                MessageBox.Show("Select a medicine in the list first.");
                return;
            }
            if (!int.TryParse(txtSaleQty.Text, out var qtySold) || qtySold <= 0)
            {
                MessageBox.Show("Enter a valid sale quantity (> 0).");
                return;
            }

            int medId = Convert.ToInt32(dgvMedicines.CurrentRow.Cells["MedicineID"].Value);

            using (var conn = Db.GetConn())
            {
                try
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("RecordSale", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;   // ExecuteNonQuery for sale
                        cmd.Parameters.AddWithValue("@MedicineID", medId);
                        cmd.Parameters.AddWithValue("@QuantitySold", qtySold);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Sale recorded.");
                    LoadAllMedicines();
                }
                catch (SqlException sqlEx)
                {
                    // Friendly messages for throws from the proc
                    MessageBox.Show("Sale failed: " + sqlEx.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Sale failed: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }
    }
}
