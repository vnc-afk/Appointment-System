namespace JomareHospitalSystem.UC_Folder
{
    partial class UCDays
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
            this.lbdays = new System.Windows.Forms.Label();
            this.panelDays = new System.Windows.Forms.Panel();
            this.pnDays = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelDays.SuspendLayout();
            this.pnDays.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbdays
            // 
            this.lbdays.AutoSize = true;
            this.lbdays.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbdays.Location = new System.Drawing.Point(78, 0);
            this.lbdays.Name = "lbdays";
            this.lbdays.Size = new System.Drawing.Size(34, 25);
            this.lbdays.TabIndex = 2;
            this.lbdays.Text = "00";
            this.lbdays.Click += new System.EventHandler(this.lbdays_Click);
            // 
            // panelDays
            // 
            this.panelDays.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.panelDays.Controls.Add(this.lbdays);
            this.panelDays.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDays.Location = new System.Drawing.Point(0, 0);
            this.panelDays.Name = "panelDays";
            this.panelDays.Size = new System.Drawing.Size(115, 29);
            this.panelDays.TabIndex = 4;
            this.panelDays.Click += new System.EventHandler(this.panelDays_Click);
            // 
            // pnDays
            // 
            this.pnDays.AutoScroll = true;
            this.pnDays.AutoSize = true;
            this.pnDays.Controls.Add(this.panel2);
            this.pnDays.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnDays.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnDays.Location = new System.Drawing.Point(0, 29);
            this.pnDays.Name = "pnDays";
            this.pnDays.Size = new System.Drawing.Size(115, 69);
            this.pnDays.TabIndex = 5;
            this.pnDays.Click += new System.EventHandler(this.pnDays_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(0, 0);
            this.panel2.TabIndex = 0;
            // 
            // UCDays
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(193)))), ((int)(((byte)(173)))));
            this.Controls.Add(this.pnDays);
            this.Controls.Add(this.panelDays);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "UCDays";
            this.Size = new System.Drawing.Size(115, 98);
            this.panelDays.ResumeLayout(false);
            this.panelDays.PerformLayout();
            this.pnDays.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbdays;
        private System.Windows.Forms.Panel panelDays;
        private System.Windows.Forms.FlowLayoutPanel pnDays;
        private System.Windows.Forms.Panel panel2;
    }
}
