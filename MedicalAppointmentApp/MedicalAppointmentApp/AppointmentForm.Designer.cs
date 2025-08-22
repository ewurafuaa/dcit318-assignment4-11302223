namespace MedicalAppointmentApp
{
    partial class AppointmentForm
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
            this.cboDoctor = new System.Windows.Forms.ComboBox();
            this.cboPatient = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.btnBook = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboDoctor
            // 
            this.cboDoctor.FormattingEnabled = true;
            this.cboDoctor.Location = new System.Drawing.Point(70, 104);
            this.cboDoctor.Name = "cboDoctor";
            this.cboDoctor.Size = new System.Drawing.Size(297, 24);
            this.cboDoctor.TabIndex = 0;
            // 
            // cboPatient
            // 
            this.cboPatient.FormattingEnabled = true;
            this.cboPatient.Location = new System.Drawing.Point(423, 104);
            this.cboPatient.Name = "cboPatient";
            this.cboPatient.Size = new System.Drawing.Size(301, 24);
            this.cboPatient.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Doctor List";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(420, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Patient List";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(70, 34);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 22);
            this.dtpDate.TabIndex = 4;
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(70, 178);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(493, 22);
            this.txtNotes.TabIndex = 5;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(67, 159);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(102, 16);
            this.label.TabIndex = 6;
            this.label.Text = "Notes (optional)";
            // 
            // btnBook
            // 
            this.btnBook.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnBook.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnBook.Location = new System.Drawing.Point(317, 251);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(153, 23);
            this.btnBook.TabIndex = 7;
            this.btnBook.Text = "Book Appointment";
            this.btnBook.UseVisualStyleBackColor = false;
            // 
            // AppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBook);
            this.Controls.Add(this.label);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboPatient);
            this.Controls.Add(this.cboDoctor);
            this.Name = "AppointmentForm";
            this.Text = "AppointmentForm";
            this.Load += new System.EventHandler(this.AppointmentForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboDoctor;
        private System.Windows.Forms.ComboBox cboPatient;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button btnBook;
    }
}