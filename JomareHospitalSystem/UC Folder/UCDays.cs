using JomareHospitalSystem.Forms;
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
using static JomareHospitalSystem.Forms.EventForm;
using static System.Windows.Forms.AxHost;

namespace JomareHospitalSystem.UC_Folder
{
    public partial class UCDays : UserControl
    {
       
        private DateTime _date;

        public UCDays()
        {
            InitializeComponent();
            LoadAppointments();
        }

        public void days(int day, int month, int year)
        {
            lbdays.Text = day.ToString();
            _date = new DateTime(year, month, day);

            LoadAppointments();
        }

        private void pnDays_Click(object sender, EventArgs e)
        {
            EventForm eventForm = new EventForm(_date);
            eventForm.FormClosed += (s, args) => LoadAppointments();// Refresh data after closing
            eventForm.Show();

        }

        private void LoadAppointments()
        {
            pnDays.Controls.Clear(); 
            using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                string query = "SELECT AppointmentId, PatientName, DoctorName, Service, Time, Date FROM TBL_Appointment WHERE Date = @date";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@date", _date.ToString("yyyy-MM-dd"));
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                     
                        while (reader.Read())
                        {
                            int appointmentId = (int)reader["AppointmentId"];
                            string patientName = reader["PatientName"].ToString();
                            string doctorName = reader["DoctorName"].ToString();
                            string service = reader["Service"].ToString();
                            string time = reader["Time"].ToString();
                            DateTime date = (DateTime)reader["Date"];

                            AddNewPanel(appointmentId, patientName, doctorName, service, time, date);
                        }
                        reader.Close();
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading appointments: " + ex.Message);
                    }
                }
            }
        }

        private void AddNewPanel(int appointmentID, string patientName,string doctorName, string service, string time, DateTime date)
        {
            UCAddAppointment appointmentProfile = new UCAddAppointment();
            appointmentProfile.SetAppointmentProfile(appointmentID, patientName, doctorName, service, time, date);
            appointmentProfile.AppointmentEdited += (s, args) => LoadAppointments(); 
            pnDays.Controls.Add(appointmentProfile);
        }
       
        private void panelDays_Click(object sender, EventArgs e)
        {
            EventForm eventForm = new EventForm(_date);
            eventForm.FormClosed += (s, args) => LoadAppointments();
            eventForm.Show();
        }

        private void lbdays_Click(object sender, EventArgs e)
        {
            EventForm eventForm = new EventForm(_date);
            eventForm.FormClosed += (s, args) => LoadAppointments();
            eventForm.Show();
        }

    }
 }

