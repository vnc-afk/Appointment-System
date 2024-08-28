using JomareHospitalSystem.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace JomareHospitalSystem.UC_Folder
{
    public partial class UCAppointmentList : UserControl
    {
        private string previousStatus = "";
       
        public UCAppointmentList()
        {
            InitializeComponent();

            if (!DesignMode)
            {
                this.dgvAppointmentList.CellContentClick += new DataGridViewCellEventHandler(this.dgvAppointmentList_CellContentClick);
                this.dgvAppointmentList.CellFormatting += new DataGridViewCellFormattingEventHandler(this.dgvAppointmentList_CellFormatting);

            }
            LoadAppointmentList();
        }

        private void UCAppointmentList_Load(object sender, EventArgs e)
        {
            LoadAppointmentList();
            AddStatusColumns();
        }

        public void showToast(string type, string message)
        {
            ToastFormcs toast = new ToastFormcs(type, message);
            toast.Show();
        }

      
        private void LoadAppointmentList()
        {
            string query = "SELECT * FROM TBL_Appointment";

            using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dgvAppointmentList.DataSource = dataTable;

                        dgvAppointmentList.Refresh();
        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }


        private void AddStatusColumns()
        {
            DataGridViewButtonColumn completeColumn = new DataGridViewButtonColumn
            {
                Name = "Complete",
                HeaderText = "Complete",
                Text = "Complete",
                UseColumnTextForButtonValue = true
            };
            dgvAppointmentList.Columns.Add(completeColumn);

            DataGridViewButtonColumn cancelColumn = new DataGridViewButtonColumn
            {
                Name = "Cancel",
                HeaderText = "Cancel",
                Text = "Cancel",
                UseColumnTextForButtonValue = true
            };
            dgvAppointmentList.Columns.Add(cancelColumn);


            DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn
            {
                Name = "Delete",
                HeaderText = "Delete",
                Text = "Delete",
                UseColumnTextForButtonValue = true
            };
            dgvAppointmentList.Columns.Add(deleteColumn);
        }
        private void dgvAppointmentList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
          
            if (dgvAppointmentList.Columns[e.ColumnIndex].Name == "Complete")
            {
                UpdateAppointmentStatus(e.RowIndex, "Completed");
            }
            else if (dgvAppointmentList.Columns[e.ColumnIndex].Name == "Cancel")
            {
                UpdateAppointmentStatus(e.RowIndex, "Cancelled");
            }
            else if (dgvAppointmentList.Columns[e.ColumnIndex].Name == "Delete")
            {
                DeleteAppointment(e.RowIndex);
            }
        }

        private void UpdateAppointmentStatus(int rowIndex, string status)
        {
            int appointmentID = Convert.ToInt32(dgvAppointmentList.Rows[rowIndex].Cells["AppointmentID"].Value);
            string query = "UPDATE TBL_Appointment SET Status = @status WHERE AppointmentID = @appointmentID";

            using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@status", status);
                    command.Parameters.AddWithValue("@appointmentID", appointmentID);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0 && previousStatus != status)
                        {
                            LoadAppointmentList();
                            dgvAppointmentList.Invalidate();
                            showToast("INFO", $"Appointment marked as {status}.");
                            previousStatus = status; 
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Error updating appointment status: " + ex.Message);
                    }
                }
            }
        }



        private void DeleteAppointment(int rowIndex)
        {
            int appointmentID = Convert.ToInt32(dgvAppointmentList.Rows[rowIndex].Cells["AppointmentID"].Value);

            DialogResult result = MessageBox.Show("Are you sure you want to delete this appointment?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string query = "DELETE FROM TBL_Appointment WHERE AppointmentID = @appointmentID";

                using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@appointmentID", appointmentID);

                        try
                        {
                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                LoadAppointmentList();
                                dgvAppointmentList.Invalidate();
                                showToast("SUCCESS", "Appointment deleted successfully.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error deleting appointment: " + ex.Message);
                        }
                    }
                }
            }
        }

  
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchText = searchAppList.Text.ToLower();

            if (searchText.Length > 50) 
            {
                searchText = searchText.Substring(0, 50);
            }

            LoadAppointmentList();

            DataView dv = new DataView((DataTable)dgvAppointmentList.DataSource);
            dv.RowFilter = string.Format("PatientName LIKE '%{0}%'", searchText);

            dgvAppointmentList.DataSource = dv;
        }

        private void dgvAppointmentList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvAppointmentList.Columns["Status"] != null && e.RowIndex >= 0)
            {
                var statusCell = dgvAppointmentList.Rows[e.RowIndex].Cells["Status"];
                if (statusCell.Value != null)
                {
                    string status = statusCell.Value.ToString();
                    DataGridViewRow row = dgvAppointmentList.Rows[e.RowIndex];
                    Console.WriteLine($"Row {e.RowIndex} Status: {status}");  // Debug line

                    if (status == "Completed ")
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                    else if (status == "Cancelled ")
                    {
                        row.DefaultCellStyle.BackColor = Color.LightCoral;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                    }
                }
            }
        }
    }
}

