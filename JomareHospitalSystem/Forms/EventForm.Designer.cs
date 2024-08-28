namespace JomareHospitalSystem.Forms
{
    partial class EventForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbOldPatient = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDoctorName = new System.Windows.Forms.ComboBox();
            this.cmbPatientName = new System.Windows.Forms.ComboBox();
            this.txtOldDate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOldClose = new System.Windows.Forms.Button();
            this.btnOldSave = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbOldTime = new System.Windows.Forms.ComboBox();
            this.cmbOldServices = new System.Windows.Forms.ComboBox();
            this.tbNewPatient = new System.Windows.Forms.TabPage();
            this.txtNewDate = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.btnNewClose = new System.Windows.Forms.Button();
            this.btnNewSave = new System.Windows.Forms.Button();
            this.dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.cmbNewTime = new System.Windows.Forms.ComboBox();
            this.cmbNewServices = new System.Windows.Forms.ComboBox();
            this.cmbSex = new System.Windows.Forms.ComboBox();
            this.txtContactNO = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtMiddleInitial = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblServices = new System.Windows.Forms.Label();
            this.lblContactNO = new System.Windows.Forms.Label();
            this.lblDateOfBirth = new System.Windows.Forms.Label();
            this.lblSex = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblMiddleInitial = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tbOldPatient.SuspendLayout();
            this.tbNewPatient.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbOldPatient);
            this.tabControl1.Controls.Add(this.tbNewPatient);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(450, 509);
            this.tabControl1.TabIndex = 1;
            // 
            // tbOldPatient
            // 
            this.tbOldPatient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(160)))), ((int)(((byte)(176)))));
            this.tbOldPatient.Controls.Add(this.label4);
            this.tbOldPatient.Controls.Add(this.label3);
            this.tbOldPatient.Controls.Add(this.label2);
            this.tbOldPatient.Controls.Add(this.cmbDoctorName);
            this.tbOldPatient.Controls.Add(this.cmbPatientName);
            this.tbOldPatient.Controls.Add(this.txtOldDate);
            this.tbOldPatient.Controls.Add(this.label1);
            this.tbOldPatient.Controls.Add(this.btnOldClose);
            this.tbOldPatient.Controls.Add(this.btnOldSave);
            this.tbOldPatient.Controls.Add(this.label10);
            this.tbOldPatient.Controls.Add(this.cmbOldTime);
            this.tbOldPatient.Controls.Add(this.cmbOldServices);
            this.tbOldPatient.Location = new System.Drawing.Point(4, 26);
            this.tbOldPatient.Name = "tbOldPatient";
            this.tbOldPatient.Padding = new System.Windows.Forms.Padding(3);
            this.tbOldPatient.Size = new System.Drawing.Size(442, 479);
            this.tbOldPatient.TabIndex = 1;
            this.tbOldPatient.Text = "Old Patient";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 17);
            this.label4.TabIndex = 33;
            this.label4.Text = "Service Selected:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 17);
            this.label3.TabIndex = 32;
            this.label3.Text = "Provider\'s Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 17);
            this.label2.TabIndex = 31;
            this.label2.Text = "Patient\'s Name:";
            // 
            // cmbDoctorName
            // 
            this.cmbDoctorName.FormattingEnabled = true;
            this.cmbDoctorName.Location = new System.Drawing.Point(57, 149);
            this.cmbDoctorName.Name = "cmbDoctorName";
            this.cmbDoctorName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbDoctorName.Size = new System.Drawing.Size(322, 25);
            this.cmbDoctorName.TabIndex = 30;
            this.cmbDoctorName.Text = "-Select Doctor-";
            // 
            // cmbPatientName
            // 
            this.cmbPatientName.FormattingEnabled = true;
            this.cmbPatientName.Location = new System.Drawing.Point(57, 77);
            this.cmbPatientName.Name = "cmbPatientName";
            this.cmbPatientName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbPatientName.Size = new System.Drawing.Size(322, 25);
            this.cmbPatientName.TabIndex = 29;
            this.cmbPatientName.Text = "-Select Patient-";
            this.cmbPatientName.TextChanged += new System.EventHandler(this.cmbPatientName_TextChanged);
            // 
            // txtOldDate
            // 
            this.txtOldDate.Location = new System.Drawing.Point(169, 10);
            this.txtOldDate.Name = "txtOldDate";
            this.txtOldDate.Size = new System.Drawing.Size(98, 25);
            this.txtOldDate.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(102, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 27;
            this.label1.Text = "Date:";
            // 
            // btnOldClose
            // 
            this.btnOldClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.btnOldClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOldClose.Location = new System.Drawing.Point(235, 321);
            this.btnOldClose.Name = "btnOldClose";
            this.btnOldClose.Size = new System.Drawing.Size(85, 41);
            this.btnOldClose.TabIndex = 25;
            this.btnOldClose.Text = "Close";
            this.btnOldClose.UseVisualStyleBackColor = false;
            this.btnOldClose.Click += new System.EventHandler(this.btnOldClose_Click);
            // 
            // btnOldSave
            // 
            this.btnOldSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(193)))), ((int)(((byte)(173)))));
            this.btnOldSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOldSave.Location = new System.Drawing.Point(117, 321);
            this.btnOldSave.Name = "btnOldSave";
            this.btnOldSave.Size = new System.Drawing.Size(85, 41);
            this.btnOldSave.TabIndex = 24;
            this.btnOldSave.Text = "Save";
            this.btnOldSave.UseVisualStyleBackColor = false;
            this.btnOldSave.Click += new System.EventHandler(this.btnOldSave_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(110, 270);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 17);
            this.label10.TabIndex = 20;
            this.label10.Text = "Time:";
            // 
            // cmbOldTime
            // 
            this.cmbOldTime.FormattingEnabled = true;
            this.cmbOldTime.Items.AddRange(new object[] {
            "8:00-9:00",
            "10:00-11:00",
            "1:00-2:00",
            "3:00-4:00",
            "5:00-6:00"});
            this.cmbOldTime.Location = new System.Drawing.Point(169, 266);
            this.cmbOldTime.Name = "cmbOldTime";
            this.cmbOldTime.Size = new System.Drawing.Size(125, 25);
            this.cmbOldTime.TabIndex = 19;
            this.cmbOldTime.Text = "-Select Time-";
            // 
            // cmbOldServices
            // 
            this.cmbOldServices.FormattingEnabled = true;
            this.cmbOldServices.Items.AddRange(new object[] {
            "Panda Check Up",
            "Panda Follow Up"});
            this.cmbOldServices.Location = new System.Drawing.Point(56, 221);
            this.cmbOldServices.Name = "cmbOldServices";
            this.cmbOldServices.Size = new System.Drawing.Size(322, 25);
            this.cmbOldServices.TabIndex = 17;
            this.cmbOldServices.Text = "-Select Services-";
            // 
            // tbNewPatient
            // 
            this.tbNewPatient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(160)))), ((int)(((byte)(176)))));
            this.tbNewPatient.Controls.Add(this.txtNewDate);
            this.tbNewPatient.Controls.Add(this.lblDate);
            this.tbNewPatient.Controls.Add(this.btnNewClose);
            this.tbNewPatient.Controls.Add(this.btnNewSave);
            this.tbNewPatient.Controls.Add(this.dtpDateOfBirth);
            this.tbNewPatient.Controls.Add(this.cmbNewTime);
            this.tbNewPatient.Controls.Add(this.cmbNewServices);
            this.tbNewPatient.Controls.Add(this.cmbSex);
            this.tbNewPatient.Controls.Add(this.txtContactNO);
            this.tbNewPatient.Controls.Add(this.txtAddress);
            this.tbNewPatient.Controls.Add(this.txtLastName);
            this.tbNewPatient.Controls.Add(this.txtMiddleInitial);
            this.tbNewPatient.Controls.Add(this.txtFirstName);
            this.tbNewPatient.Controls.Add(this.lblTime);
            this.tbNewPatient.Controls.Add(this.lblServices);
            this.tbNewPatient.Controls.Add(this.lblContactNO);
            this.tbNewPatient.Controls.Add(this.lblDateOfBirth);
            this.tbNewPatient.Controls.Add(this.lblSex);
            this.tbNewPatient.Controls.Add(this.lblAddress);
            this.tbNewPatient.Controls.Add(this.lblLastName);
            this.tbNewPatient.Controls.Add(this.lblMiddleInitial);
            this.tbNewPatient.Controls.Add(this.lblFirstName);
            this.tbNewPatient.Location = new System.Drawing.Point(4, 26);
            this.tbNewPatient.Name = "tbNewPatient";
            this.tbNewPatient.Padding = new System.Windows.Forms.Padding(3);
            this.tbNewPatient.Size = new System.Drawing.Size(442, 479);
            this.tbNewPatient.TabIndex = 0;
            this.tbNewPatient.Text = "New Patient";
            // 
            // txtNewDate
            // 
            this.txtNewDate.Location = new System.Drawing.Point(128, 6);
            this.txtNewDate.Name = "txtNewDate";
            this.txtNewDate.Size = new System.Drawing.Size(98, 25);
            this.txtNewDate.TabIndex = 26;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(61, 9);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(43, 17);
            this.lblDate.TabIndex = 25;
            this.lblDate.Text = "Date:";
            // 
            // btnNewClose
            // 
            this.btnNewClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.btnNewClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewClose.Location = new System.Drawing.Point(241, 431);
            this.btnNewClose.Name = "btnNewClose";
            this.btnNewClose.Size = new System.Drawing.Size(85, 41);
            this.btnNewClose.TabIndex = 24;
            this.btnNewClose.Text = "Close";
            this.btnNewClose.UseVisualStyleBackColor = false;
            this.btnNewClose.Click += new System.EventHandler(this.btnNewClose_Click);
            // 
            // btnNewSave
            // 
            this.btnNewSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(193)))), ((int)(((byte)(173)))));
            this.btnNewSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewSave.Location = new System.Drawing.Point(128, 431);
            this.btnNewSave.Name = "btnNewSave";
            this.btnNewSave.Size = new System.Drawing.Size(85, 41);
            this.btnNewSave.TabIndex = 23;
            this.btnNewSave.Text = "Save";
            this.btnNewSave.UseVisualStyleBackColor = false;
            this.btnNewSave.Click += new System.EventHandler(this.btnNewSave_Click);
            // 
            // dtpDateOfBirth
            // 
            this.dtpDateOfBirth.Location = new System.Drawing.Point(128, 274);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new System.Drawing.Size(200, 25);
            this.dtpDateOfBirth.TabIndex = 17;
            // 
            // cmbNewTime
            // 
            this.cmbNewTime.FormattingEnabled = true;
            this.cmbNewTime.Items.AddRange(new object[] {
            "8:00-9:00",
            "10:00-11:00",
            "1:00-2:00",
            "3:00-4:00",
            "5:00-6:00"});
            this.cmbNewTime.Location = new System.Drawing.Point(128, 390);
            this.cmbNewTime.Name = "cmbNewTime";
            this.cmbNewTime.Size = new System.Drawing.Size(125, 25);
            this.cmbNewTime.TabIndex = 16;
            this.cmbNewTime.Text = "-Select Time-";
            // 
            // cmbNewServices
            // 
            this.cmbNewServices.FormattingEnabled = true;
            this.cmbNewServices.Items.AddRange(new object[] {
            "Panda Check Up",
            "Panda Follow Up"});
            this.cmbNewServices.Location = new System.Drawing.Point(128, 350);
            this.cmbNewServices.Name = "cmbNewServices";
            this.cmbNewServices.Size = new System.Drawing.Size(200, 25);
            this.cmbNewServices.TabIndex = 15;
            this.cmbNewServices.Text = "-Select Services-";
            // 
            // cmbSex
            // 
            this.cmbSex.FormattingEnabled = true;
            this.cmbSex.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cmbSex.Location = new System.Drawing.Point(128, 234);
            this.cmbSex.Name = "cmbSex";
            this.cmbSex.Size = new System.Drawing.Size(156, 25);
            this.cmbSex.TabIndex = 14;
            this.cmbSex.Text = "-Select Sex-";
            // 
            // txtContactNO
            // 
            this.txtContactNO.Location = new System.Drawing.Point(128, 312);
            this.txtContactNO.Name = "txtContactNO";
            this.txtContactNO.Size = new System.Drawing.Size(182, 25);
            this.txtContactNO.TabIndex = 13;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(128, 175);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(182, 43);
            this.txtAddress.TabIndex = 12;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(128, 133);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(182, 25);
            this.txtLastName.TabIndex = 11;
            // 
            // txtMiddleInitial
            // 
            this.txtMiddleInitial.Location = new System.Drawing.Point(128, 91);
            this.txtMiddleInitial.Name = "txtMiddleInitial";
            this.txtMiddleInitial.Size = new System.Drawing.Size(182, 25);
            this.txtMiddleInitial.TabIndex = 10;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(128, 49);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(182, 25);
            this.txtFirstName.TabIndex = 9;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(60, 393);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(44, 17);
            this.lblTime.TabIndex = 8;
            this.lblTime.Text = "Time:";
            // 
            // lblServices
            // 
            this.lblServices.AutoSize = true;
            this.lblServices.Location = new System.Drawing.Point(38, 353);
            this.lblServices.Name = "lblServices";
            this.lblServices.Size = new System.Drawing.Size(69, 17);
            this.lblServices.TabIndex = 7;
            this.lblServices.Text = "Services:";
            // 
            // lblContactNO
            // 
            this.lblContactNO.AutoSize = true;
            this.lblContactNO.Location = new System.Drawing.Point(25, 315);
            this.lblContactNO.Name = "lblContactNO";
            this.lblContactNO.Size = new System.Drawing.Size(85, 17);
            this.lblContactNO.TabIndex = 6;
            this.lblContactNO.Text = "Contact No.";
            // 
            // lblDateOfBirth
            // 
            this.lblDateOfBirth.AutoSize = true;
            this.lblDateOfBirth.Location = new System.Drawing.Point(19, 276);
            this.lblDateOfBirth.Name = "lblDateOfBirth";
            this.lblDateOfBirth.Size = new System.Drawing.Size(93, 17);
            this.lblDateOfBirth.TabIndex = 5;
            this.lblDateOfBirth.Text = "Date of Birth:";
            // 
            // lblSex
            // 
            this.lblSex.AutoSize = true;
            this.lblSex.Location = new System.Drawing.Point(60, 237);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(37, 17);
            this.lblSex.TabIndex = 4;
            this.lblSex.Text = "Sex:";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(40, 178);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(66, 17);
            this.lblAddress.TabIndex = 3;
            this.lblAddress.Text = "Address:";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(29, 135);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(83, 17);
            this.lblLastName.TabIndex = 2;
            this.lblLastName.Text = "Last Name:";
            // 
            // lblMiddleInitial
            // 
            this.lblMiddleInitial.AutoSize = true;
            this.lblMiddleInitial.Location = new System.Drawing.Point(17, 92);
            this.lblMiddleInitial.Name = "lblMiddleInitial";
            this.lblMiddleInitial.Size = new System.Drawing.Size(89, 17);
            this.lblMiddleInitial.TabIndex = 1;
            this.lblMiddleInitial.Text = "Middle Initial:";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(26, 49);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(84, 17);
            this.lblFirstName.TabIndex = 0;
            this.lblFirstName.Text = "First Name:";
            // 
            // EventForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 509);
            this.Controls.Add(this.tabControl1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(600, 300);
            this.Name = "EventForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "EventForm";
            this.TopMost = true;
            this.tabControl1.ResumeLayout(false);
            this.tbOldPatient.ResumeLayout(false);
            this.tbOldPatient.PerformLayout();
            this.tbNewPatient.ResumeLayout(false);
            this.tbNewPatient.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbNewPatient;
        private System.Windows.Forms.TabPage tbOldPatient;
        private System.Windows.Forms.ComboBox cmbNewTime;
        private System.Windows.Forms.ComboBox cmbNewServices;
        private System.Windows.Forms.ComboBox cmbSex;
        private System.Windows.Forms.TextBox txtContactNO;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtMiddleInitial;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblServices;
        private System.Windows.Forms.Label lblContactNO;
        private System.Windows.Forms.Label lblDateOfBirth;
        private System.Windows.Forms.Label lblSex;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblMiddleInitial;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Button btnNewClose;
        private System.Windows.Forms.Button btnNewSave;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbOldTime;
        private System.Windows.Forms.ComboBox cmbOldServices;
        private System.Windows.Forms.Button btnOldClose;
        private System.Windows.Forms.Button btnOldSave;
        private System.Windows.Forms.TextBox txtNewDate;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDateOfBirth;
        private System.Windows.Forms.TextBox txtOldDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPatientName;
        private System.Windows.Forms.ComboBox cmbDoctorName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}