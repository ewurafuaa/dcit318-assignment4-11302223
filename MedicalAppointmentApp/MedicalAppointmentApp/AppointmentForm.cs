using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MedicalAppointmentApp
{
    public partial class AppointmentForm : Form
    {
        public AppointmentForm()
        {
            InitializeComponent();
            this.Load += AppointmentForm_Load;
            btnBook.Click += btnBook_Click;
        }

        private void AppointmentForm_Load(object sender, EventArgs e)
        {
            LoadDoctors();
            LoadPatients();
            dtpDate.Value = DateTime.Now.AddDays(1); // default date tomorrow
        }

        private void LoadDoctors()
        {
            var conn = Db.GetConn();
            try
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT DoctorID, FullName FROM Doctors WHERE Availability = 1", conn))
                using (var rdr = cmd.ExecuteReader())
                {
                    var dt = new DataTable();
                    dt.Load(rdr);
                    cboDoctor.DisplayMember = "FullName";
                    cboDoctor.ValueMember = "DoctorID";
                    cboDoctor.DataSource = dt;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading doctors: " + ex.Message); }
            finally { conn.Close(); }
        }

        private void LoadPatients()
        {
            var conn = Db.GetConn();
            try
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT PatientID, FullName FROM Patients", conn))
                using (var rdr = cmd.ExecuteReader())
                {
                    var dt = new DataTable();
                    dt.Load(rdr);
                    cboPatient.DisplayMember = "FullName";
                    cboPatient.ValueMember = "PatientID";
                    cboPatient.DataSource = dt;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading patients: " + ex.Message); }
            finally { conn.Close(); }
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            if (cboDoctor.SelectedValue == null || cboPatient.SelectedValue == null)
            {
                MessageBox.Show("Select a doctor and a patient.");
                return;
            }

            int doctorId = (int)cboDoctor.SelectedValue;
            int patientId = (int)cboPatient.SelectedValue;
            DateTime apptDate = dtpDate.Value;
            string notes = txtNotes.Text.Trim();

            var conn = Db.GetConn();
            try
            {
                conn.Open();

                // Check doctor availability
                using (var check = new SqlCommand("SELECT Availability FROM Doctors WHERE DoctorID=@d", conn))
                {
                    check.Parameters.Add(new SqlParameter("@d", SqlDbType.Int) { Value = doctorId });
                    bool available = (bool)check.ExecuteScalar();
                    if (!available)
                    {
                        MessageBox.Show("Selected doctor is not available.");
                        return;
                    }
                }

                // Insert appointment
                using (var cmd = new SqlCommand(
                    "INSERT INTO Appointments(DoctorID,PatientID,AppointmentDate,Notes) " +
                    "VALUES(@DoctorID,@PatientID,@AppointmentDate,@Notes)", conn))
                {
                    cmd.Parameters.AddWithValue("@DoctorID", doctorId);
                    cmd.Parameters.AddWithValue("@PatientID", patientId);
                    cmd.Parameters.AddWithValue("@AppointmentDate", apptDate);
                    cmd.Parameters.AddWithValue("@Notes", notes);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0) MessageBox.Show("Appointment booked successfully!");
                }
            }
            catch (Exception ex) { MessageBox.Show("Booking failed: " + ex.Message); }
            finally { conn.Close(); }
        }

        // Dummy methods so Designer stops complaining
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
    }
}
