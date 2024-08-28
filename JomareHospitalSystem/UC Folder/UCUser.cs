using JomareHospitalSystem.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace JomareHospitalSystem.UC_Folder
{
    public partial class UCUser : UserControl
    {
       
        private List<User> user = new List<User>();
        public UCUser()
        {
            InitializeComponent();

            RetrieveAndDisplayUserData();
        }

        private void RetrieveAndDisplayUserData()
        {
            string query = "SELECT UserID, firstName, middleInitial, lastName, emailAddress, username, password FROM TBL_User";

            using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        user.Clear(); 

                        while (reader.Read())
                        {
                            int userID = Convert.ToInt32(reader["UserID"]);
                            string firstName = reader["firstName"].ToString().Trim();
                            string middleInitial = reader["middleInitial"].ToString().Trim();
                            string lastName = reader["lastName"].ToString().Trim();
                            string emailAddress = reader["emailAddress"].ToString().Trim();
                            string userName = reader["userName"].ToString().Trim();
                            string password = reader["password"].ToString().Trim();

                            user.Add(new User
                            {
                                UserID = userID,
                                FirstName = firstName,
                                MiddleInitial = middleInitial,
                                LastName = lastName,
                                EmailAddress = emailAddress,
                                Username = userName,
                                Password = password,
                            });
                        }

                        DisplayUser(user);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();
            List<User> filteredUser = user.Where(p => p.FullName.ToLower().Contains(searchText)).ToList();
            DisplayUser(filteredUser);
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            UserRegistration userRegistration = new UserRegistration();
            userRegistration.FormClosed += (s, args) => RetrieveAndDisplayUserData(); 
            userRegistration.Show();
        }

        private void DisplayUser(List<User> userList)
        {
            panelContainer.Controls.Clear(); 

            foreach (var user in userList)
            {
                AddNewPanel(user.UserID, user.FirstName, user.MiddleInitial, user.LastName, user.EmailAddress, user.Username, user.Password);
            }
        }

        private void AddNewPanel(int userID, string firstName, string middleInitial, string lastName, string emailAddress, string userName, string password)
        {
            UCUserProfile newProfile = new UCUserProfile();
            newProfile.userProfile(userID, firstName, middleInitial, lastName, emailAddress, userName, password);
            newProfile.UserEdited += (s, args) => RetrieveAndDisplayUserData(); 
            panelContainer.Controls.Add(newProfile);
        }
    }

    public class User
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string FullName
        {
            get
            {
                return string.IsNullOrEmpty(MiddleInitial) ? $"{FirstName} {LastName}" : $"{FirstName} {MiddleInitial} {LastName}";
            }
        }
    }
}
