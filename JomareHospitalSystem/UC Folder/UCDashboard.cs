using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JomareHospitalSystem.UC_Folder
{
    public partial class UCDashboard : UserControl
    {
        public UCDashboard()
        {
            InitializeComponent();
            ShowTodayAppointments();
            ShowFutureAppointments();
            ShowTotalDoctors();
            ShowTotalPatients();
            ShowCompletedAppointments();
            ShowCanceledAppointments(); 
        }


        private void ShowTodayAppointments()
        {
            int todayAppointmentCount = GetTodayAppointmentsCount();
            lblTodaySession.Text = $"{todayAppointmentCount}";
        }

        private void ShowFutureAppointments()
        {
            int futureAppointmentCount = GetFutureAppointmentsCount();
            lblRequest.Text = $"{futureAppointmentCount}";
        }

        private void ShowTotalDoctors()
        {
            int totalDoctorCount = GetTotalDoctorsCount();
            lblDoctor.Text = $"{totalDoctorCount}";
        }

        private void ShowTotalPatients()
        {
            int totalPatientCount = GetTotalPatientsCount();
            lblPatient.Text = $"{totalPatientCount}";
        }
        private void ShowCompletedAppointments()
        {
            int completedAppointmentCount = GetCompletedAppointmentsCount();
            lblCompleted.Text = $"{completedAppointmentCount}";
        }

        private void ShowCanceledAppointments()
        {
            int canceledAppointmentCount = GetCanceledAppointmentsCount();
            lblCanceled.Text = $"{canceledAppointmentCount}";
        }

        private int GetTodayAppointmentsCount()
        {
            int count = 0;
            string query = "SELECT COUNT(*) FROM TBL_Appointment WHERE CONVERT(date, Date) = CONVERT(date, GETDATE()) AND Status NOT IN ('Completed', 'Cancelled')";

            using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        count = (int)command.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }

            return count;
        }

        private int GetFutureAppointmentsCount()
        {
            int count = 0;
            string query = "SELECT COUNT(*) FROM TBL_Appointment WHERE CONVERT(date, Date) > CONVERT(date, GETDATE()) AND Status NOT IN ('Completed', 'Cancelled')";

            using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        count = (int)command.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }

            return count;
        }




        private int GetTotalDoctorsCount()
        {
            int count = 0;
            string query = "SELECT COUNT(*) FROM [TBL_Doctor]";

            using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        count = (int)command.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }

            return count;
        }
   
        private int GetTotalPatientsCount()
        {
            int count = 0;
            string query = "SELECT COUNT(*) FROM [TBL_Patient]";

            using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        count = (int)command.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }

            return count;
        }

        private int GetCompletedAppointmentsCount()
        {
            int count = 0;
            string query = "SELECT COUNT(*) FROM TBL_Appointment WHERE Status = 'Completed'";

            using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        count = (int)command.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }

            return count;
        }

        private int GetCanceledAppointmentsCount()
        {
            int count = 0;
            string query = "SELECT COUNT(*) FROM TBL_Appointment WHERE Status = 'Cancelled'";

            using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        count = (int)command.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }

            return count;
        }





        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void UCDashboard_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void lblCompleted_Click(object sender, EventArgs e)
        {

        }

        private void lblCanceled_Click(object sender, EventArgs e)
        {

        }
    }
}
