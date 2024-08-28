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

namespace JomareHospitalSystem.UC_Folder
{
    public partial class UCDoctor : UserControl
    {
       
        private List<Doctor> doctor = new List<Doctor>();
        public UCDoctor()
        {
            InitializeComponent();

            RetrieveAndDisplayDoctorData();
        }

        private void RetrieveAndDisplayDoctorData()
        {
            string query = "SELECT DoctorID, firstName, middleInitial, lastName, address, sex, dateOfBirth, contactNO, specialization, boardCertified, medicalLicenseNumber, medicalSchool, description FROM TBL_Doctor";

            using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        doctor.Clear();

                        while (reader.Read())
                        {
                            int doctorID = Convert.ToInt32(reader["DoctorID"]);
                            string firstName = reader["firstName"].ToString().Trim();
                            string middleInitial = reader["middleInitial"].ToString().Trim();
                            string lastName = reader["lastName"].ToString().Trim();
                            string address = reader["address"].ToString().Trim();
                            string gender = reader["sex"].ToString().Trim();
                            DateTime dateOfBirth = Convert.ToDateTime(reader["dateOfBirth"]);
                            string contactNumber = reader["contactNO"].ToString().Trim();
                            string specialization = reader["specialization"].ToString().Trim();
                            string boardCertified = reader["boardCertified"].ToString().Trim();
                            string medicalLicenseNumber = reader["medicalLicenseNumber"].ToString().Trim();
                            string medicalSchool = reader["medicalSchool"].ToString().Trim();
                            string description = reader["description"].ToString().Trim();
                            
                            doctor.Add(new Doctor
                            {
                                DoctorID = doctorID,
                                FirstName = firstName,
                                MiddleInitial = middleInitial,
                                LastName = lastName,
                                Address = address,
                                Gender = gender,
                                DateOfBirth = dateOfBirth,
                                ContactNumber = contactNumber,
                                Specialization = specialization,
                                BoardCertified = boardCertified,
                                MedicalLicenseNumber = medicalLicenseNumber,
                                MedicalSchool = medicalSchool,
                                Description = description,

                            });
                        }

                        DisplayDoctor(doctor);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void DisplayDoctor(List<Doctor> doctortList)
        {
            panelContainer.Controls.Clear(); 

            foreach (var doctor in doctortList)
            {
                AddNewPanel(doctor.DoctorID, doctor.FirstName, doctor.MiddleInitial, doctor.LastName, doctor.Address, doctor.Gender, doctor.DateOfBirth, doctor.ContactNumber, doctor.Specialization, doctor.BoardCertified, doctor.MedicalLicenseNumber, doctor.MedicalSchool, doctor.Description);
            }
        }

        private void AddNewPanel(int doctorID, string firstName, string middleInitial, string lastName, string address, string gender, DateTime dateOfBirth, string contactNumber, string specialization, string boardCertified, string medicalLicenseNumber, string medicalSchool, string description)
        {
            UCDoctorProfile newProfile = new UCDoctorProfile();
            newProfile.doctorProfile(doctorID, firstName, middleInitial, lastName, address, gender, dateOfBirth, contactNumber, specialization, boardCertified, medicalLicenseNumber, medicalSchool, description);
            newProfile.DoctorEdited += (s, args) => RetrieveAndDisplayDoctorData();
            panelContainer.Controls.Add(newProfile);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();
            List<Doctor> filteredPatients = doctor.Where(p => p.FullName.ToLower().Contains(searchText)).ToList();
            DisplayDoctor(filteredPatients);
        }
        public class Doctor
        {
            public int DoctorID { get; set; }
            public string FirstName { get; set; }
            public string MiddleInitial { get; set; }
            public string LastName { get; set; }
            public string Address { get; set; }
            public string Gender { get; set; }
            public DateTime DateOfBirth { get; set; }
            public string ContactNumber { get; set; }
            public string Specialization { get; set; }
            public string BoardCertified { get; set; }
            public string MedicalLicenseNumber { get; set; }
            public string MedicalSchool { get; set; }
            public string Description { get; set; }
          
            public string FullName
            {
                get
                {
                    return string.IsNullOrEmpty(MiddleInitial) ? $"{FirstName} {LastName}" : $"{FirstName} {MiddleInitial} {LastName}";
                }
            }
        }

        private void btnAddDoctor_Click(object sender, EventArgs e)
        {
            AddDoctorForm addDoctor = new AddDoctorForm();
            addDoctor.FormClosed += (s, args) => RetrieveAndDisplayDoctorData(); 
            addDoctor.Show();
        }
    }
}
