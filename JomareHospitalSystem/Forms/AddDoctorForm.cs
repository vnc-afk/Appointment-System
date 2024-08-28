using JomareHospitalSystem.UC_Folder;
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
    public partial class AddDoctorForm : Form
    {
       
        private int doctorID = -1; 

        public AddDoctorForm()
        {
            InitializeComponent();

            AssignKeyPressEvents();

        }

        public void showToast(string type, string message)
        {
            ToastFormcs toast = new ToastFormcs(type, message);
            toast.Show();
        }

        public AddDoctorForm(int doctorID, string firstName, string middleInitial, string lastName, string address, string gender, DateTime dateOfBirth, string contactNumber, string specialization, string boardCertified, string medicalLicenseNumber, string medicalSchool, string description)
        {
            InitializeComponent();
            AssignKeyPressEvents();
            this.doctorID = doctorID;
            txtFirstName.Text = firstName;
            txtMiddleInitial.Text = middleInitial;
            txtLastName.Text = lastName;
            txtAddress.Text = address;
            cmbSex.SelectedItem = gender;
            dtpDateOfBirth.Value = dateOfBirth;
            txtContactNO.Text = contactNumber;
            cmbSpecialization.SelectedItem = specialization;
            cmbBoardCertified.SelectedItem = boardCertified;
            txtMedicalLicenseNumber.Text = medicalLicenseNumber;
            txtMedicalSchool.Text = medicalSchool;
            txtDescription.Text = description;

        
        }
        private void AssignKeyPressEvents()
        {
            txtFirstName.KeyPress += TxtName_KeyPress;
            txtMiddleInitial.KeyPress += TxtName_KeyPress;
            txtLastName.KeyPress += TxtName_KeyPress;
            txtContactNO.KeyPress += TxtNumber_KeyPress;
            txtMedicalLicenseNumber.KeyPress += TxtNumber_KeyPress;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void btnSave_Click(object sender, EventArgs e)
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
            if (string.IsNullOrWhiteSpace(txtContactNO.Text))
            {
                showToast("ERROR", "Contact number is required.");
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
            string specialization = cmbSpecialization.Text;
            string boardCertified = cmbBoardCertified.Text;
            string medicalLicenseNumber = txtMedicalLicenseNumber.Text;
            string medicalSchool = txtMedicalSchool.Text;
            string description = txtDescription.Text;

            // Save data to the database
            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    connection.Open();
                    string query;

                    if (doctorID == -1)
                    {
                        // Insert new patient
                        query = "INSERT INTO TBL_Doctor (firstName, middleInitial, lastName, address, sex, dateOfBirth, contactNO, specialization, boardCertified, medicalLicenseNumber, medicalSchool, description) " +
                                "VALUES (@firstName, @middleInitial, @lastName, @address, @sex, @dateOfBirth, @contactNO, @specialization, @boardCertified, @medicalLicenseNumber, @medicalSchool, @description)";
                    }
                    else
                    {
                        // Update existing patient
                        query = "UPDATE TBL_Doctor SET firstName = @firstName, middleInitial = @middleInitial, lastName = @lastName, " +
                                "address = @address, sex = @sex, dateOfBirth = @dateOfBirth, contactNO = @contactNO, specialization = @specialization, " +
                                "boardCertified = @boardCertified, medicalLicenseNumber = @medicalLicenseNumber, medicalSchool = @medicalSchool, description = @description WHERE DoctorID = @doctorID";
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
                        cmd.Parameters.AddWithValue("@specialization", specialization);
                        cmd.Parameters.AddWithValue("@boardCertified", boardCertified);
                        cmd.Parameters.AddWithValue("@medicalLicenseNumber", medicalLicenseNumber);
                        cmd.Parameters.AddWithValue("@medicalSchool", medicalSchool);
                        cmd.Parameters.AddWithValue("@description", description);

                        if (doctorID != -1)
                        {
                            cmd.Parameters.AddWithValue("@doctorID", doctorID);
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
                cmbSpecialization.SelectedIndex = -1;
                cmbBoardCertified.SelectedIndex = -1;
                txtMedicalLicenseNumber.Clear();
                txtMedicalSchool.Clear();
                txtDescription.Clear();

                showToast("SUCCESS", "Doctor added successfully.");

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving the data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
