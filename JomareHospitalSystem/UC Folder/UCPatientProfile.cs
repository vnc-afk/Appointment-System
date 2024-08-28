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
using System.Xml.Linq;
using static JomareHospitalSystem.UC_Folder.UCDoctor;

namespace JomareHospitalSystem.UC_Folder
{
    public partial class UCPatientProfile : UserControl
    {
        private int patientID;
        private string firstName;
        private string middleInitial;
        private string lastName;
        private string address;
        private string gender;
        private DateTime dateOfBirth;
        private string contactNumber;

        public Action<object, object> PatientEdited { get; internal set; }

        public UCPatientProfile()
        {
            InitializeComponent();

        }

        public void showToast(string type, string message)
        {
            ToastFormcs toast = new ToastFormcs(type, message);
            toast.Show();
        }

        public void patientProfile(int patientID, string firstName, string middleInitial, string lastName, string address, string gender, DateTime dateOfBirth, string contactNumber)
        {
            this.patientID = patientID;
            this.firstName = firstName;
            this.middleInitial = middleInitial;
            this.lastName = lastName;
            this.address = address;
            this.gender = gender;
            this.dateOfBirth = dateOfBirth;
            this.contactNumber = contactNumber;

            lblPatientID.Text = "Patient ID: " + patientID;
            lblName.Text = string.IsNullOrEmpty(middleInitial)
                ? $"{firstName} {lastName}"
                : $"{firstName} {middleInitial}. {lastName}";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            AddPatientForm patientForm = new AddPatientForm(patientID, firstName, middleInitial, lastName, address, gender, dateOfBirth, contactNumber);
            patientForm.FormClosed += (s, args) =>
            {
                OnPatientEdited(EventArgs.Empty);
            };

            patientForm.Show();
        }

        protected virtual void OnPatientEdited(EventArgs e)
        {
            PatientEdited?.Invoke(this, e);
            showToast("SUCCESS", "Patient information upadated successfully.");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this patient record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DeletePatientData(patientID);
            }
        }

        private void DeletePatientData(int patientID)
        {
            string query = "DELETE FROM [TBL_Patient] WHERE PatientID = @PatientID";

            using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PatientID", patientID);

                    try
                    {
                        connection.Open();
                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                           
                            this.Parent.Controls.Remove(this);
                            showToast("SUCCESS", "Patient record deleted successfully.");
                        }
                        else
                        {
                            showToast("ERROR", "Failed to delete patient record.");
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
