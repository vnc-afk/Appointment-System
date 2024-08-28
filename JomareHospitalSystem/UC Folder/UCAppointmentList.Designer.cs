namespace JomareHospitalSystem.UC_Folder
{
    partial class UCAppointmentList
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgvAppointmentList = new System.Windows.Forms.DataGridView();
            this.AppointmentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Services = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tBLAppointmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.jomareClinicDBDataSet = new JomareHospitalSystem.jomareClinicDBDataSet();
            this.label1 = new System.Windows.Forms.Label();
            this.searchAppList = new System.Windows.Forms.TextBox();
            this.tBL_AppointmentTableAdapter = new JomareHospitalSystem.jomareClinicDBDataSetTableAdapters.TBL_AppointmentTableAdapter();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointmentList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBLAppointmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jomareClinicDBDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAppointmentList
            // 
            this.dgvAppointmentList.AllowUserToOrderColumns = true;
            this.dgvAppointmentList.AutoGenerateColumns = false;
            this.dgvAppointmentList.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvAppointmentList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppointmentList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AppointmentID,
            this.PatientName,
            this.Date,
            this.Services,
            this.timeDataGridViewTextBoxColumn,
            this.Status});
            this.dgvAppointmentList.DataSource = this.tBLAppointmentBindingSource;
            this.dgvAppointmentList.Location = new System.Drawing.Point(30, 59);
            this.dgvAppointmentList.Name = "dgvAppointmentList";
            this.dgvAppointmentList.ReadOnly = true;
            this.dgvAppointmentList.RowHeadersWidth = 51;
            this.dgvAppointmentList.RowTemplate.Height = 24;
            this.dgvAppointmentList.Size = new System.Drawing.Size(855, 362);
            this.dgvAppointmentList.TabIndex = 0;
            this.dgvAppointmentList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAppointmentList_CellContentClick);
            this.dgvAppointmentList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvAppointmentList_CellFormatting);
            // 
            // AppointmentID
            // 
            this.AppointmentID.DataPropertyName = "AppointmentID";
            this.AppointmentID.HeaderText = "AppointmentID";
            this.AppointmentID.MinimumWidth = 6;
            this.AppointmentID.Name = "AppointmentID";
            this.AppointmentID.ReadOnly = true;
            this.AppointmentID.Width = 125;
            // 
            // PatientName
            // 
            this.PatientName.DataPropertyName = "PatientName";
            this.PatientName.HeaderText = "PatientName";
            this.PatientName.MinimumWidth = 6;
            this.PatientName.Name = "PatientName";
            this.PatientName.ReadOnly = true;
            this.PatientName.Width = 125;
            // 
            // Date
            // 
            this.Date.DataPropertyName = "Date";
            this.Date.HeaderText = "Date";
            this.Date.MinimumWidth = 6;
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Width = 125;
            // 
            // Services
            // 
            this.Services.DataPropertyName = "Service";
            this.Services.HeaderText = "Service";
            this.Services.MinimumWidth = 6;
            this.Services.Name = "Services";
            this.Services.ReadOnly = true;
            this.Services.Width = 125;
            // 
            // timeDataGridViewTextBoxColumn
            // 
            this.timeDataGridViewTextBoxColumn.DataPropertyName = "Time";
            this.timeDataGridViewTextBoxColumn.HeaderText = "Time";
            this.timeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.timeDataGridViewTextBoxColumn.Name = "timeDataGridViewTextBoxColumn";
            this.timeDataGridViewTextBoxColumn.ReadOnly = true;
            this.timeDataGridViewTextBoxColumn.Width = 125;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.MinimumWidth = 6;
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 125;
            // 
            // tBLAppointmentBindingSource
            // 
            this.tBLAppointmentBindingSource.DataMember = "TBL_Appointment";
            this.tBLAppointmentBindingSource.DataSource = this.jomareClinicDBDataSet;
            // 
            // jomareClinicDBDataSet
            // 
            this.jomareClinicDBDataSet.DataSetName = "jomareClinicDBDataSet";
            this.jomareClinicDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(105)))), ((int)(((byte)(96)))));
            this.label1.Location = new System.Drawing.Point(326, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "Appointment List";
            // 
            // searchAppList
            // 
            this.searchAppList.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchAppList.Location = new System.Drawing.Point(683, 22);
            this.searchAppList.Name = "searchAppList";
            this.searchAppList.Size = new System.Drawing.Size(202, 25);
            this.searchAppList.TabIndex = 2;
            this.searchAppList.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // tBL_AppointmentTableAdapter
            // 
            this.tBL_AppointmentTableAdapter.ClearBeforeFill = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F);
            this.label2.Location = new System.Drawing.Point(603, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Search:";
            // 
            // UCAppointmentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.searchAppList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvAppointmentList);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "UCAppointmentList";
            this.Size = new System.Drawing.Size(904, 467);
            this.Load += new System.EventHandler(this.UCAppointmentList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointmentList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBLAppointmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jomareClinicDBDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAppointmentList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchAppList;
        private System.Windows.Forms.BindingSource tBLAppointmentBindingSource;
        private jomareClinicDBDataSet jomareClinicDBDataSet;
        private jomareClinicDBDataSetTableAdapters.TBL_AppointmentTableAdapter tBL_AppointmentTableAdapter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn AppointmentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Services;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
    }
}
