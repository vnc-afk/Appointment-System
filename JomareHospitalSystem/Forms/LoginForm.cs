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
    public partial class LoginForm : Form
    {
        public Action<object, EventArgs> LoginSuccessful { get; internal set; }

        public LoginForm()
        {
            InitializeComponent();

        }

      
        public void showToast(string type, string message)
        {
            ToastFormcs toast = new ToastFormcs(type, message);
            toast.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                showToast("ERROR", "Please enter your username.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                showToast("ERROR", "Please enter your password.");
                return;
            }

            string username = txtUserName.Text;
            string password = txtPassword.Text;

            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM TBL_User WHERE username=@username AND password=@password";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);

                        int count = Convert.ToInt32(command.ExecuteScalar());

                        if (count == 1)
                        {
                            this.Hide();

                            form mainForm = new form(username);
                            mainForm.FormClosed += (s, args) => this.Close(); 
                            mainForm.Show();
                            showToast("SUCCESS", "Login successful!");
                        }
                        else
                        {
                            showToast("ERROR", "Invalid username or password.");
                        }
                    }
                }
            
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during login: " + ex.Message);
            }
        }
    }
}

