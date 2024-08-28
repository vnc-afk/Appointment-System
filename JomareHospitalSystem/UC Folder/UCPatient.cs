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

namespace JomareHospitalSystem.UC_Folder
{
    public partial class UCPatient : UserControl
    {
       
        private List<Patient> patients = new List<Patient>();

        public UCPatient()
        {
            InitializeComponent();

            RetrieveAndDisplayPatientData();
        }
       
        private void RetrieveAndDisplayPatientData()
        {
            string query = "SELECT PatientID, firstName, middleInitial, lastName, address, sex, dateOfBirth, contactNO FROM TBL_Patient";

            using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        patients.Clear(); // Clear existing data

                        while (reader.Read())
                        {
                            int patientID = Convert.ToInt32(reader["PatientID"]);
                            string firstName = reader["firstName"].ToString().Trim();
                            string middleInitial = reader["middleInitial"].ToString().Trim();
                            string lastName = reader["lastName"].ToString().Trim();
                            string address = reader["address"].ToString().Trim();
                            string gender = reader["sex"].ToString().Trim();
                            DateTime dateOfBirth = Convert.ToDateTime(reader["dateOfBirth"]);
                            string contactNumber = reader["contactNO"].ToString().Trim();

                            patients.Add(new Patient
                            {
                                PatientID = patientID,
                                FirstName = firstName,
                                MiddleInitial = middleInitial,
                                LastName = lastName,
                                Address = address,
                                Gender = gender,
                                DateOfBirth = dateOfBirth,
                                ContactNumber = contactNumber
                            });
                        }

                        DisplayPatients(patients);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void btnAddPatient_Click(object sender, EventArgs e)
        {
            AddPatientForm addPatient = new AddPatientForm();
            addPatient.FormClosed += (s, args) => RetrieveAndDisplayPatientData(); 
            addPatient.Show();
        }

        private void DisplayPatients(List<Patient> patientList)
        {
            panelContainer.Controls.Clear(); 

            foreach (var patient in patientList)
            {
                AddNewPanel(patient.PatientID, patient.FirstName, patient.MiddleInitial, patient.LastName, patient.Address, patient.Gender, patient.DateOfBirth, patient.ContactNumber);
            }
        }

        private void AddNewPanel(int patientID, string firstName, string middleInitial, string lastName, string address, string gender, DateTime dateOfBirth, string contactNumber)
        {
            UCPatientProfile newProfile = new UCPatientProfile();
            newProfile.patientProfile(patientID, firstName, middleInitial, lastName, address, gender, dateOfBirth, contactNumber);
            newProfile.PatientEdited += (s, args) => RetrieveAndDisplayPatientData();
            panelContainer.Controls.Add(newProfile);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();
            List<Patient> filteredPatients = patients.Where(p => p.FullName.ToLower().Contains(searchText)).ToList();
            DisplayPatients(filteredPatients);
        }
    }

    public class Patient
    {
        public int PatientID { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ContactNumber { get; set; }

        public string FullName
        {
            get
            {
                return string.IsNullOrEmpty(MiddleInitial) ? $"{FirstName} {LastName}" : $"{FirstName} {MiddleInitial} {LastName}";
            }
        }

    }
}
