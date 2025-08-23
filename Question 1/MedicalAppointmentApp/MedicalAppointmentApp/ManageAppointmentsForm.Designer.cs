namespace MedicalAppointmentApp
{
    partial class ManageAppointmentsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvAppts = new System.Windows.Forms.DataGridView();
            this.dtpNewDate = new System.Windows.Forms.DateTimePicker();
            this.btnUpdateDate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppts)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAppts
            // 
            this.dgvAppts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppts.Location = new System.Drawing.Point(75, 164);
            this.dgvAppts.Name = "dgvAppts";
            this.dgvAppts.RowHeadersWidth = 51;
            this.dgvAppts.RowTemplate.Height = 24;
            this.dgvAppts.Size = new System.Drawing.Size(725, 243);
            this.dgvAppts.TabIndex = 0;
            // 
            // dtpNewDate
            // 
            this.dtpNewDate.Location = new System.Drawing.Point(75, 101);
            this.dtpNewDate.Name = "dtpNewDate";
            this.dtpNewDate.Size = new System.Drawing.Size(254, 22);
            this.dtpNewDate.TabIndex = 1;
            // 
            // btnUpdateDate
            // 
            this.btnUpdateDate.Location = new System.Drawing.Point(678, 428);
            this.btnUpdateDate.Name = "btnUpdateDate";
            this.btnUpdateDate.Size = new System.Drawing.Size(122, 37);
            this.btnUpdateDate.TabIndex = 2;
            this.btnUpdateDate.Text = "Update Date";
            this.btnUpdateDate.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnDelete.Location = new System.Drawing.Point(497, 428);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(175, 37);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete Appointment";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click_1);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(75, 132);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(277, 22);
            this.txtSearch.TabIndex = 4;
            this.txtSearch.Text = "Search by Doctor or Patient";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(333, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Manage Appointments";
            // 
            // ManageAppointmentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 491);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdateDate);
            this.Controls.Add(this.dtpNewDate);
            this.Controls.Add(this.dgvAppts);
            this.Name = "ManageAppointmentsForm";
            this.Text = "ManageAppointmentsForm";
            this.Load += new System.EventHandler(this.ManageAppointmentsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAppts;
        private System.Windows.Forms.DateTimePicker dtpNewDate;
        private System.Windows.Forms.Button btnUpdateDate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
    }
}