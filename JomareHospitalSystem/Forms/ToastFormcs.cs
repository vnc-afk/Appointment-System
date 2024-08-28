using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JomareHospitalSystem.Forms
{
    public partial class ToastFormcs : Form
    {
        

        public ToastFormcs(string type, string message)
        {
            InitializeComponent();
            lblType.Text = type;
            lblMessage.Text = message;


            switch (type) {
                case "SUCCESS":
                    toastBorder.BackColor = Color.Green;
                    pictureBox.Image = Properties.Resources.Check_Mark;
                    break;
                case "ERROR":
                    toastBorder.BackColor = Color.Red;
                    pictureBox.Image = Properties.Resources.Cancel;
                    break;
                case "INFO":
                    toastBorder.BackColor = Color.LightBlue;
                    pictureBox.Image = Properties.Resources.Info;
                    break;
                case "WARNING":
                    toastBorder.BackColor = Color.Yellow;
                    pictureBox.Image = Properties.Resources.Error;
                    break;

                    
            }
         
        }

        private void ToastFormcs_Load(object sender, EventArgs e)
        {

            toastTimer.Start();

        }

        private void toastTimer_Tick(object sender, EventArgs e)
        {
            toastTimer.Stop();
            this.Close();
        }    
    }
}
