using JomareHospitalSystem.UC_Folder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JomareHospitalSystem.Forms
{
    public partial class UserRegistration : Form
    {
        private int userID = -1;
        public UserRegistration()
        {
            InitializeComponent();
            AssignKeyPressEvents();
        }
        public void showToast(string type, string message)
        {
            ToastFormcs toast = new ToastFormcs(type, message);
            toast.Show();
        }
        public UserRegistration(int userID, string firstName, string middleInitial, string lastName, string emailAddress, string userName, string password)
        {
            InitializeComponent();
            AssignKeyPressEvents();
            this.userID = userID;
            txtFirstName.Text = firstName;
            txtMiddleInitial.Text = middleInitial;
            txtLastName.Text = lastName;
            txtEmailAddress.Text = emailAddress;
            txtUserName.Text = userName;
            txtPassword.Text = password;
        }

        private void AssignKeyPressEvents()
        {
            txtFirstName.KeyPress += TxtName_KeyPress;
            txtMiddleInitial.KeyPress += TxtName_KeyPress;
            txtLastName.KeyPress += TxtName_KeyPress;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
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
            if (string.IsNullOrWhiteSpace(txtEmailAddress.Text))
            {
                showToast("ERROR", "Email address is required.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                showToast("ERROR", "User name is required.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                showToast("ERROR", "Password is required.");
                return;
            }

            // Simulate saving data
            string firstName = txtFirstName.Text;
            string middleInitial = txtMiddleInitial.Text;
            string lastName = txtLastName.Text;
            string emailAddress = txtEmailAddress.Text;
            string username = txtUserName.Text;
            string password = txtPassword.Text;

            // Save data to the database
            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    connection.Open();
                    string query;

                    if (userID == -1)
                    {
                        // Insert new patient
                        query = "INSERT INTO TBL_User (FirstName, MiddleInitial, LastName, EmailAddress, UserName, Password) " +
                                "VALUES (@firstName, @middleInitial, @lastName, @emailAddress, @userName, @password)";
                    }
                    else
                    {
                        // Update existing patient
                        query = "UPDATE TBL_User SET firstName = @firstName, middleInitial = @middleInitial, lastName = @lastName, " +
                                "emailAddress = @emailAddress, userName = @userName, password = @password WHERE UserID = @userID";
                    }

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@firstName", firstName);
                        command.Parameters.AddWithValue("@middleInitial", middleInitial);
                        command.Parameters.AddWithValue("@lastName", lastName);
                        command.Parameters.AddWithValue("@emailAddress", emailAddress);
                        command.Parameters.AddWithValue("@userName", username);
                        command.Parameters.AddWithValue("@password", password);
                        if (userID != -1)
                        {
                            command.Parameters.AddWithValue("@userID", userID);
                        }

                        command.ExecuteNonQuery();
                    }
                }

                // Clear fields after saving
                txtFirstName.Clear();
                txtMiddleInitial.Clear();
                txtLastName.Clear();
                txtEmailAddress.Clear();
                txtUserName.Clear();
                txtPassword.Clear();

                showToast("SUCCESS", "User created successfully.");
                this.Close();

            }
            catch (Exception ex)
            {
                showToast("SUCCESS", "Error saving appointment: " + ex.Message);
            }
        }
        private void TxtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                showToast("ERROR", "Only letters are allowed.");
            }
        }
    }
}
