using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MedicalAppointmentApp
{
    public partial class DoctorListForm : Form
    {
        public DoctorListForm()
        {
            InitializeComponent();
            // when form loads, call LoadDoctors
            this.Load += DoctorListForm_Load;
            // also, hook search box
            txtSearch.TextChanged += (s, e) => LoadDoctors(txtSearch.Text);
        }

        // Run when the form opens
        private void DoctorListForm_Load(object sender, EventArgs e)
        {
            LoadDoctors();   // populate DataGridView at startup
        }

        private void LoadDoctors(string filter = "")
        {
            var dt = new DataTable();
            var conn = Db.GetConn();
            try
            {
                conn.Open();
                string sql = "SELECT DoctorID, FullName, Specialty, Availability FROM Doctors";
                if (!string.IsNullOrWhiteSpace(filter))
                    sql += " WHERE FullName LIKE @f OR Specialty LIKE @f";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    if (!string.IsNullOrWhiteSpace(filter))
                        cmd.Parameters.AddWithValue("@f", "%" + filter + "%");

                    using (var rdr = cmd.ExecuteReader())
                    {
                        dt.Load(rdr);
                    }
                }
                dgvDoctors.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading doctors: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        // This event is optional – leave empty unless you need to handle cell clicks
        private void dgvDoctors_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
