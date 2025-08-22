using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicalAppointmentApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnDoctors_Click(object sender, EventArgs e)
        {
            new DoctorListForm().ShowDialog();
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            new AppointmentForm().ShowDialog();
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            new ManageAppointmentsForm().ShowDialog();
        }
    }
}
