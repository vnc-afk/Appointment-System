using JomareHospitalSystem.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static JomareHospitalSystem.UC_Folder.UCDoctor;

namespace JomareHospitalSystem.UC_Folder
{
    public partial class UCUserProfile : UserControl
    {
        private int userID;
        private string firstName;
        private string middleInitial;
        private string lastName;
        private string emailAddress;
        private string userName;
        private string password;

        public Action<object, object> UserEdited { get; internal set; }

        public UCUserProfile()
        {
            InitializeComponent();
        }

        public void showToast(string type, string message)
        {
            ToastFormcs toast = new ToastFormcs(type, message);
            toast.Show();
        }

        public void userProfile(int userID, string firstName, string middleInitial, string lastName, string emailAddress, string userName, string password)
        {
            this.userID = userID;
            this.firstName = firstName;
            this.middleInitial = middleInitial;
            this.lastName = lastName;
            this.emailAddress = emailAddress;
            this.userName = userName;
            this.password = password;


            lblUserID.Text = "User ID: " + userID;
            lblName.Text = string.IsNullOrEmpty(middleInitial)
                ? $"{firstName} {lastName}"
                : $"{firstName} {middleInitial}. {lastName}";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            UserRegistration userRegistration = new UserRegistration(userID, firstName, middleInitial, lastName, emailAddress, userName, password);
            userRegistration.FormClosed += (s, args) =>
            {
                OnUserEdited(EventArgs.Empty);
            };
            userRegistration.Show();
        }

        protected virtual void OnUserEdited(EventArgs e)
        {
            UserEdited?.Invoke(this, e);
            showToast("SUCCESS", "User information updated successfully.");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this user record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DeleteUserData(userID);
            }
        }

        private void DeleteUserData(int userID)
        {
            string query = "DELETE FROM [TBL_User] WHERE UserID = @UserID";

            using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userID);

                    try
                    {
                        connection.Open();
                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {   
                            this.Parent.Controls.Remove(this);
                            showToast("SUCCESS", "User record deleted successfully.");
                        }
                        else
                        {
                            showToast("ERROR", "Failed to delete user record.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }
    }
}
