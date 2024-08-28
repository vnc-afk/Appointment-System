using JomareHospitalSystem.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace JomareHospitalSystem.UC_Folder
{
    public partial class UCAddAppointment : UserControl
    {
        public int AppointmentID { get; private set; }
        public string PatientName { get; private set; }
        public string DoctorName { get; private set; }
        public string Service { get; private set; }
        public string Time { get; private set; }
        public DateTime Date { get; private set; }

        public event EventHandler AppointmentEdited;


        public UCAddAppointment()
        {
            InitializeComponent();
        }

        public void SetAppointmentProfile(int appointmentID, string patientName, string doctorName, string service, string time, DateTime date)
        {
            AppointmentID = appointmentID;
            PatientName = patientName;
            DoctorName = doctorName;
            Service = service;
            Time = time;
            Date = date;

            lblTime.Text = time;
            if (Date.Date == DateTime.Today)
            {
                this.BackColor = Color.FromArgb(255, 140, 66); 
            }
            else
            {
                this.BackColor = Color.FromArgb(255, 193, 7); 
            }
        }

        private void UCAppointmentProfile_Click(object sender, EventArgs e)
        {
            // Open the EventForm with the appointment details
            EventForm eventForm = new EventForm(AppointmentID, PatientName, DoctorName, Service, Time, Date);
            eventForm.FormClosed += (s, args) => OnAppointmentEdited(EventArgs.Empty);
            eventForm.ShowDialog();
        }

        private void lblTime_Click(object sender, EventArgs e)
        {
             EventForm eventForm = new EventForm(AppointmentID, PatientName, DoctorName, Service, Time, Date);
            eventForm.FormClosed += (s, args) => OnAppointmentEdited(EventArgs.Empty);
            eventForm.ShowDialog();
        }

        protected virtual void OnAppointmentEdited(EventArgs e)
        {
            AppointmentEdited?.Invoke(this, e);
        }
    }
}
