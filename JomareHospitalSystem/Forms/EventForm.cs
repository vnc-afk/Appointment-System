using JomareHospitalSystem.UC_Folder;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace JomareHospitalSystem.Forms
{
    public partial class EventForm : Form
    {
        private int previousSelectionStart = 0;
        private List<string> allPatientNames = new List<string>();
        private List<string> allDoctorNames = new List<string>();
        private int appointmentID = -1;

        public Action<object, object> AppointmentEdited { get; internal set; }

        public EventForm()
        {
            InitializeComponent();
        }

        public EventForm(int appointmentID, string patientName, string doctorName, string service, string time, DateTime date)
        {
            InitializeComponent();
            LoadPatientNames();
            LoadDoctorNames();
            this.appointmentID = appointmentID;
            cmbPatientName.Text = patientName;
            cmbDoctorName.Text = doctorName;
            cmbOldServices.Text = service;
            cmbOldTime.Text = time;
            txtOldDate.Text = date.ToShortDateString();
            LoadAvailableTimes(date, cmbOldTime);


        }

        public EventForm(DateTime date)
        {
            InitializeComponent();
            AssignKeyPressEvents();
            txtNewDate.Text = date.ToShortDateString();
            txtOldDate.Text = date.ToShortDateString();
            LoadPatientNames();
            LoadDoctorNames();
            LoadAvailableTimes(date, cmbOldTime);

        }
      
        private void AssignKeyPressEvents()
        {
            txtFirstName.KeyPress += TxtName_KeyPress;
            txtMiddleInitial.KeyPress += TxtName_KeyPress;
            txtLastName.KeyPress += TxtName_KeyPress;
            txtContactNO.KeyPress += TxtNumber_KeyPress;
        }

        public void showToast(string type, string message)
        {
            ToastFormcs toast = new ToastFormcs(type, message);
            toast.Show();
        }
        private List<string> GetBookedTimes(DateTime date)
        {
            List<string> bookedTimes = new List<string>();
            string query = "SELECT Time FROM TBL_Appointment WHERE Date = @date";

            using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@date", date.ToString("yyyy-MM-dd"));
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            bookedTimes.Add(reader["Time"].ToString().Trim());
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }

            return bookedTimes;
        }
        private void LoadAvailableTimes(DateTime date, ComboBox cmbTime)
        {
            List<string> allTimes = new List<string>
    {
        "08:00 AM", "09:00 AM", "10:00 AM", "11:00 AM",
        "01:00 PM", "02:00 PM", "03:00 PM", "04:00 PM"
    };

            List<string> bookedTimes = GetBookedTimes(date);

            List<string> availableTimes = allTimes.Except(bookedTimes).ToList();

            cmbTime.Items.Clear();
            cmbTime.Items.AddRange(availableTimes.ToArray());
        }

        private void LoadPatientNames()
        {
            string query = "SELECT firstName, middleInitial, lastName FROM TBL_Patient";

            using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            string firstName = reader["firstName"].ToString().Trim();
                            string middleInitial = reader["middleInitial"].ToString().Trim();
                            string lastName = reader["lastName"].ToString().Trim();
                            string fullName = $"{firstName} {middleInitial} {lastName}".Trim();

                            cmbPatientName.Items.Add(fullName);
                            allPatientNames.Add(fullName);
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void LoadDoctorNames()
        {
            string query = "SELECT firstName, middleInitial, lastName FROM TBL_Doctor";

            using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            string firstName = reader["firstName"].ToString().Trim();
                            string middleInitial = reader["middleInitial"].ToString().Trim();
                            string lastName = reader["lastName"].ToString().Trim();
                            string fullName = $" Dr. {firstName} {middleInitial} {lastName}".Trim();

                            cmbDoctorName.Items.Add(fullName);
                            allDoctorNames.Add(fullName);
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void btnNewClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOldClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOldSave_Click(object sender, EventArgs e)
        {
            if (cmbPatientName.SelectedItem == null)
            {
                showToast("ERROR", "Patient name is required.");
                return;
            }
            if (cmbDoctorName.SelectedItem == null)
            {
                showToast("ERROR", "Provider is required.");
                return;
            }
            if (cmbOldServices.SelectedItem == null)
            {
                showToast("ERROR", "Service is required.");
                return;
            }
            if (cmbOldTime.SelectedItem == null)
            {
                showToast("ERROR", "Time is required.");
                return;
            }

            // Simulate saving data
            string patientName = cmbPatientName.Text;
            string doctorName = cmbDoctorName.Text;
            string service = cmbOldServices.Text;
            string time = cmbOldTime.Text;
            string date = txtOldDate.Text;

            if (string.IsNullOrWhiteSpace(patientName))
            {
                showToast("WARNING", "Patient name is required.");
                return;
            }

            // Save data to the database
            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    connection.Open();
                    string query;

                    if (appointmentID > 0)
                    {
                        // Update the existing appointment
                        query = "UPDATE TBL_Appointment SET PatientName = @patientName, DoctorName = @doctorName, Date = @date, Service = @service, Time = @time WHERE AppointmentID = @appointmentID";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@appointmentID", appointmentID);
                            command.Parameters.AddWithValue("@patientName", patientName);
                            command.Parameters.AddWithValue("@doctorName", doctorName);
                            command.Parameters.AddWithValue("@date", DateTime.Parse(date).ToString("yyyy-MM-dd"));
                            command.Parameters.AddWithValue("@service", service);
                            command.Parameters.AddWithValue("@time", time);
                            command.ExecuteNonQuery();
                        }
                        showToast("SUCCESS", "Appointment updated successfully.");
                    }
                    else
                    {
                        // Insert a new appointment
                        query = "INSERT INTO TBL_Appointment (PatientName, DoctorName, Date, Service, Time) VALUES (@patientName, @doctorName, @date, @service, @time)";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@patientName", patientName);
                            command.Parameters.AddWithValue("@doctorName", doctorName);
                            command.Parameters.AddWithValue("@date", DateTime.Parse(date).ToString("yyyy-MM-dd"));
                            command.Parameters.AddWithValue("@service", service);
                            command.Parameters.AddWithValue("@time", time);
                            command.ExecuteNonQuery();
                        }

                        showToast("SUCCESS", "Appointment saved successfully.");
                    }
                }
                AppointmentEdited?.Invoke(this, EventArgs.Empty);
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving appointment: " + ex.Message);
            }
        }

        private void btnNewSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                showToast("ERROR", "First name is required.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                showToast("ERROR", "Last name is required.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                showToast("ERROR", "Address is required.");
                return;
            }
            if (cmbSex.SelectedItem == null)
            {
                showToast("ERROR", "Sex is required.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtContactNO.Text))
            {
                showToast("ERROR", "Contact number is required.");
                return;
            }
            if (cmbNewServices.SelectedItem == null)
            {
                showToast("ERROR", "Service is required.");
                return;
            }
            if (cmbNewTime.SelectedItem == null)
            {
                showToast("ERROR", "Time is required.");
                return;
            }


            // Simulate saving data
            string firstName = txtFirstName.Text;
            string middleInitial = txtMiddleInitial.Text;
            string lastName = txtLastName.Text;
            string address = txtAddress.Text;
            string sex = cmbSex.SelectedItem?.ToString();
            DateTime dateOfBirth = dtpDateOfBirth.Value;
            string contactNumber = txtContactNO.Text;
            string date = txtNewDate.Text;
            string service = cmbNewServices.Text;
            string time = cmbNewTime.Text;
            string patientName = $"{txtFirstName.Text} {txtMiddleInitial.Text} {txtLastName.Text}";

            // Save data to the database
            using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query;

                    // Insert a new patient
                    query = "INSERT INTO TBL_Patient (firstName, middleInitial, lastName, address, sex, dateOfBirth, contactNO) " +
                                "VALUES (@firstName, @middleInitial, @lastName, @address, @sex, @dateOfBirth, @contactNO)";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@firstName", firstName);
                        cmd.Parameters.AddWithValue("@middleInitial", middleInitial);
                        cmd.Parameters.AddWithValue("@lastName", lastName);
                        cmd.Parameters.AddWithValue("@address", address);
                        cmd.Parameters.AddWithValue("@gender", sex ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);
                        cmd.Parameters.AddWithValue("@contactNO", contactNumber);
                        cmd.ExecuteNonQuery();
                    }

                    // Insert a new appointment
                    query = @"INSERT INTO TBL_Appointment (PatientName, Date, Service, Time)
                              VALUES (@patientName, @date, @service, @time)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@patientName", patientName);
                        command.Parameters.AddWithValue("@date", DateTime.Parse(date).ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@service", service);
                        command.Parameters.AddWithValue("@time", time);
                        command.ExecuteNonQuery();
                    }

                    cmbPatientName.Text = patientName;

                    showToast("SUCCESS", "Appointment saved successfully.");
                    this.Close();

                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error saving appointment: " + ex.Message);
                }
            }
        }

        private void cmbPatientName_TextChanged(object sender, EventArgs e)
        {

            string searchText = cmbPatientName.Text.ToLower();;
            int cursorPosition = cmbPatientName.SelectionStart;

            cmbPatientName.Items.Clear();

            // Filter and add items that contain the entered text
            foreach (string fullName in allPatientNames)
            {
                if (fullName.ToLower().Contains(searchText))
                {
                    cmbPatientName.Items.Add(fullName);
                }
            }


            cmbPatientName.DroppedDown = !string.IsNullOrEmpty(searchText);


            cmbPatientName.SelectionStart = Math.Min(cursorPosition, cmbPatientName.Text.Length);
            previousSelectionStart = cmbPatientName.SelectionStart;
        }

        private void TxtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                showToast("ERROR", "Only letters are allowed.");
            }
        }

        // Event handler to restrict input to numbers and specific symbols
        private void TxtNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) &&
                e.KeyChar != '(' && e.KeyChar != ')' && e.KeyChar != '+' && e.KeyChar != '-')
            {
                e.Handled = true;
                showToast("ERROR", "Only numbers and (), +, - are allowed.");
            }
        }
    }
}