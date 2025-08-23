using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MedicalAppointmentApp
{
    public partial class ManageAppointmentsForm : Form
    {
        private DataSet _ds = new DataSet();
        private SqlDataAdapter _da;
        private string _baseSql =
            @"SELECT A.AppointmentID, D.FullName AS Doctor, P.FullName AS Patient,
                     A.AppointmentDate, A.Notes, A.DoctorID, A.PatientID
              FROM Appointments A
              JOIN Doctors D ON D.DoctorID = A.DoctorID
              JOIN Patients P ON P.PatientID = A.PatientID";

        public ManageAppointmentsForm()
        {
            InitializeComponent();
            btnUpdateDate.Click += btnUpdateDate_Click;
            btnDelete.Click += btnDelete_Click;
            if (txtSearch != null) txtSearch.TextChanged += (s, e) => LoadAppointments(txtSearch.Text);
        }

        // 👇 This fixes your error
        private void ManageAppointmentsForm_Load(object sender, EventArgs e)
        {
            LoadAppointments();
        }

        private void LoadAppointments(string filter = "")
        {
            _ds = new DataSet();
            var conn = Db.GetConn();
            try
            {
                conn.Open();
                string sql = _baseSql;
                if (!string.IsNullOrWhiteSpace(filter))
                    sql += " WHERE D.FullName LIKE @f OR P.FullName LIKE @f";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    if (!string.IsNullOrWhiteSpace(filter))
                        cmd.Parameters.AddWithValue("@f", "%" + filter + "%");

                    _da = new SqlDataAdapter(cmd);
                    _da.Fill(_ds, "AppointmentsView");
                    dgvAppts.DataSource = _ds.Tables["AppointmentsView"];
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading appointments: " + ex.Message); }
            finally { conn.Close(); }
        }

        private void btnUpdateDate_Click(object sender, EventArgs e)
        {
            if (dgvAppts.CurrentRow == null) { MessageBox.Show("Select a row."); return; }
            int apptId = Convert.ToInt32(dgvAppts.CurrentRow.Cells["AppointmentID"].Value);
            DateTime newDate = dtpNewDate.Value;

            var conn = Db.GetConn();
            try
            {
                conn.Open();
                using (var cmd = new SqlCommand("UPDATE Appointments SET AppointmentDate=@d WHERE AppointmentID=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@d", newDate);
                    cmd.Parameters.AddWithValue("@id", apptId);
                    cmd.ExecuteNonQuery();
                }
                LoadAppointments();
                MessageBox.Show("Appointment date updated.");
            }
            catch (Exception ex) { MessageBox.Show("Update failed: " + ex.Message); }
            finally { conn.Close(); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvAppts.CurrentRow == null) { MessageBox.Show("Select a row."); return; }
            int apptId = Convert.ToInt32(dgvAppts.CurrentRow.Cells["AppointmentID"].Value);

            var conn = Db.GetConn();
            try
            {
                conn.Open();
                using (var cmd = new SqlCommand("DELETE FROM Appointments WHERE AppointmentID=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", apptId);
                    cmd.ExecuteNonQuery();
                }
                LoadAppointments();
                MessageBox.Show("Appointment deleted.");
            }
            catch (Exception ex) { MessageBox.Show("Delete failed: " + ex.Message); }
            finally { conn.Close(); }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {

        }
    }
}
