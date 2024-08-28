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

namespace JomareHospitalSystem.Forms
{
    public partial class AddPatientForm : Form
    {
        
        private int patientID = -1;
        public AddPatientForm()
        {
            InitializeComponent();
            AssignKeyPressEvents();
        }

        public void showToast(string type, string message)
        {
            ToastFormcs toast = new ToastFormcs(type, message);
            toast.Show();
        }

        public AddPatientForm(int patientID, string firstName, string middleInitial, string lastName, string address, string gender, DateTime dateOfBirth, string contactNumber)
        {
            InitializeComponent();
            AssignKeyPressEvents();
            this.patientID = patientID;
            txtFirstName.Text = firstName;
            txtMiddleInitial.Text = middleInitial;
            txtLastName.Text = lastName;
            txtAddress.Text = address;
            cmbSex.SelectedItem = gender;
            dtpDateOfBirth.Value = dateOfBirth;
            txtContactNO.Text = contactNumber;
        }

        private void AssignKeyPressEvents()
        {
            txtFirstName.KeyPress += TxtName_KeyPress;
            txtMiddleInitial.KeyPress += TxtName_KeyPress;
            txtLastName.KeyPress += TxtName_KeyPress;
            txtContactNO.KeyPress += TxtNumber_KeyPress;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                showToast("ERROR", "First name is required.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtMiddleInitial.Text))
            {
                showToast("ERROR", "Middle name is required.");
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

            // Simulate saving data
            string firstName = txtFirstName.Text;
            string middleInitial = txtMiddleInitial.Text;
            string lastName = txtLastName.Text;
            string address = txtAddress.Text;
            string sex = cmbSex.SelectedItem.ToString();
            DateTime dateOfBirth = dtpDateOfBirth.Value;
            string contactNumber = txtContactNO.Text;

            // Save data to the database
            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    connection.Open();
                    string query;

                    if (patientID == -1)
                    {
                        // Insert new patient
                        query = "INSERT INTO TBL_Patient (firstName, middleInitial, lastName, address, sex, dateOfBirth, contactNO) " +
                                "VALUES (@firstName, @middleInitial, @lastName, @address, @sex, @dateOfBirth, @contactNO)";
                    }
                    else
                    {
                        // Update existing patient
                        query = "UPDATE TBL_Patient SET firstName = @firstName, middleInitial = @middleInitial, lastName = @lastName, " +
                                "address = @address, sex = @sex, dateOfBirth = @dateOfBirth, contactNO = @contactNO WHERE PatientID = @patientID";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@firstName", firstName);
                        cmd.Parameters.AddWithValue("@middleInitial", middleInitial);
                        cmd.Parameters.AddWithValue("@lastName", lastName);
                        cmd.Parameters.AddWithValue("@address", address);
                        cmd.Parameters.AddWithValue("@gender", sex);
                        cmd.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);
                        cmd.Parameters.AddWithValue("@contactNO", contactNumber);

                        if (patientID != -1)
                        {
                            cmd.Parameters.AddWithValue("@patientID", patientID);
                        }

                        cmd.ExecuteNonQuery();
                    }
                }

                // Clear fields after saving
                txtFirstName.Clear();
                txtMiddleInitial.Clear();
                txtLastName.Clear();
                txtAddress.Clear();
                cmbSex.SelectedIndex = -1;
                dtpDateOfBirth.Value = DateTime.Today;
                txtContactNO.Clear();

                showToast("SUCCESS", "Patient added successfully.");

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving the data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler to restrict input to letters only
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

