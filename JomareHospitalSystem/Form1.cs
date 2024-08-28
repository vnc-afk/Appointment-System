using JomareHospitalSystem.Forms;
using JomareHospitalSystem.UC_Folder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace JomareHospitalSystem
{
    public partial class form : Form
    {
        private string loggedInUsername;

        public form(string username)
        {
            InitializeComponent();
            loggedInUsername = username;
            lblUsername.Text = "Logged in as: " + loggedInUsername;
        }
        public void showToast(string type, string message)
        {
            ToastFormcs toast = new ToastFormcs(type, message);
            toast.Show();
        }

        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }

        bool menuExpand = false;

        private void menuTransition_Tick(object sender, EventArgs e)
        {
            if(menuExpand == false) {

                menuContainer.Height += 10;

                if(menuContainer.Height >= 177) {
                menuTransition.Stop();
                    menuExpand = true;
                
                }
            }
            else
            {
                menuContainer.Height -= 10;
                if (menuContainer.Height <= 50)
                {
                    menuTransition.Stop();
                    menuExpand = false;
                }
                {
                }
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            menuTransition.Start(); 
        }

        bool sidebarExpand = true;

        private void sidebarTransition_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 10;
                if (sidebar.Width <= 60)
                {
                    sidebarExpand = false;
                    sidebarTransition.Stop();
                    pnDashboard.Width = sidebar.Width;
                    pnAppointment.Width = sidebar.Width;
                    pnSettings.Width = sidebar.Width;
                    pnLogout.Width = sidebar.Width;
                    menuContainer.Width = sidebar.Width;
                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width >= 150)
                {
                    sidebarExpand = true;
                    sidebarTransition.Stop();
                    pnDashboard.Width = sidebar.Width;
                    pnAppointment.Width = sidebar.Width;
                    pnSettings.Width = sidebar.Width;
                    pnLogout.Width = sidebar.Width;
                    menuContainer.Width = sidebar.Width;
                }
            }
        }

        private void btnHam_Click(object sender, EventArgs e)
        {
            sidebarTransition.Start();
        }

        private void form_Load(object sender, EventArgs e)
        {

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            UCDashboard dashboard = new UCDashboard();
            addUserControl(dashboard);
        }

        private void btnAppointment_Click(object sender, EventArgs e)
        {
            UCAppointment appointment = new UCAppointment();
            addUserControl(appointment);
        }

        private void btnPatient_Click(object sender, EventArgs e)
        {
            UCPatient patient = new UCPatient();
            addUserControl(patient);
        }

        private void btnSubmenu1_Click(object sender, EventArgs e)
        {
            UCUser user = new UCUser();
            addUserControl(user);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            UCDoctor doctor = new UCDoctor();
            addUserControl(doctor);
        }

        private void btnAppointmentList_Click(object sender, EventArgs e)
        {
            UCAppointmentList appointmentlist = new UCAppointmentList();
            addUserControl(appointmentlist);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            showToast("SUCCESS", "You Logout successfully.");
            LoginForm login = new LoginForm();
            login.Show();
        }   
    }
}
