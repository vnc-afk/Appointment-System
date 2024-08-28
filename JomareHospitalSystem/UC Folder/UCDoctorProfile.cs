using JomareHospitalSystem.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JomareHospitalSystem.UC_Folder
{
   
    public partial class UCDoctorProfile : UserControl
    {
        private int doctorID;
        private string firstName;
        private string middleInitial;
        private string lastName;
        private string address;
        private string gender;
        private DateTime dateOfBirth;
        private string contactNumber;
        private string specialization;
        private string boardCertified;
        private string medicalLicenseNumber;
        private string medicalSchool;
        private string description;

        public Action<object, object> DoctorEdited { get; internal set; }

        public UCDoctorProfile()
        {
            InitializeComponent();
        }

        public void showToast(string type, string message)
        {
            ToastFormcs toast = new ToastFormcs(type, message);
            toast.Show();
        }
        public void doctorProfile(int doctorID, string firstName, string middleInitial, string lastName, string address, string gender, DateTime dateOfBirth, string contactNumber, string specialization, string boardCertified, string medicalLicenseNumber, string medicalSchool, string description)
        {
            this.doctorID = doctorID;
            this.firstName = firstName;
            this.middleInitial = middleInitial;
            this.lastName = lastName;
            this.address = address;
            this.gender = gender;
            this.dateOfBirth = dateOfBirth;
            this.contactNumber = contactNumber;
            this.specialization = specialization;
            this.boardCertified = boardCertified;
            this.medicalLicenseNumber = medicalLicenseNumber;
            this.medicalSchool = medicalSchool;
            this.description = description;


            lblDoctorID.Text = "Doctor ID: " + doctorID;
            lblName.Text = string.IsNullOrEmpty(middleInitial)
                ? $"{firstName} {lastName}"
                : $"Dr. {firstName} {middleInitial} {lastName}";

            pictureBox1.Image = GetImageFromDatabase(doctorID);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this doctor record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DeleteDoctorData(doctorID);
            }
        }

        private void DeleteDoctorData(int doctorID)
        {
            
            string query = "DELETE FROM [TBL_Doctor] WHERE doctorID = @doctorID";

            using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@doctorID", doctorID);

                    try
                    {
                        connection.Open();
                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            this.Parent.Controls.Remove(this);
                            showToast("SUCCESS", "Doctor record deleted successfully.");
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


        private void btnEdit_Click(object sender, EventArgs e)
        {
            AddDoctorForm doctorForm = new AddDoctorForm(doctorID, firstName, middleInitial, lastName, address, gender, dateOfBirth, contactNumber, specialization, boardCertified, medicalLicenseNumber, medicalSchool, description);
            doctorForm.FormClosed += (s, args) =>
            {
                OnDoctorEdited(EventArgs.Empty);
            };
            doctorForm.Show();
        }

        protected virtual void OnDoctorEdited(EventArgs e)
        {
            DoctorEdited?.Invoke(this, e);
            showToast("SUCCESS", "Doctor information upadated successfully.");
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png) | *.jpg; *.jpeg; *.gif; *.bmp; *.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
                SaveImageToDatabase(doctorID, pictureBox1.Image);
            }
        }

        private byte[] ImageToByteArray(Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }

        private void SaveImageToDatabase(int doctorID, Image image)
        {
            byte[] imageBytes = ImageToByteArray(image);

            string query = "UPDATE [TBL_Doctor] SET image = @image WHERE doctorID = @doctorID";

            using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@image", imageBytes);
                    command.Parameters.AddWithValue("@doctorID", doctorID);

                    try
                    {
                        connection.Open();
                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            showToast("SUCCESS", "Image saved successfully.");
                        }
                        else
                        {
                            showToast("ERROR", "Failed to save image.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private Image GetImageFromDatabase(int doctorID)
        {
            string query = "SELECT image FROM [TBL_Doctor] WHERE doctorID = @doctorID";

            using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@doctorID", doctorID);

                    try
                    {
                        connection.Open();
                        byte[] imageBytes = command.ExecuteScalar() as byte[];

                        if (imageBytes != null && imageBytes.Length > 0)
                        {
                            using (var ms = new MemoryStream(imageBytes))
                            {
                                return Image.FromStream(ms);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }

            return null;
        }
    }
}
