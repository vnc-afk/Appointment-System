using JomareHospitalSystem.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JomareHospitalSystem.UC_Folder
{
    public partial class UCAppointment : UserControl
    {
        int month, year;
        public UCAppointment()
        {
            InitializeComponent();
        }

        private void displayDays()
        {
            DateTime now = DateTime.Now;
            month = now.Month;
            year = now.Year;

            String monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            LBDATE.Text = monthname + " " + year;

            DateTime startofthemonth = new DateTime(year, month, 1);

            int days = DateTime.DaysInMonth(year, month);

            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek);

            dayContainer.Controls.Clear();

            for (int i = 0; i < dayoftheweek; i++)
            {
                UCBlank blank = new UCBlank();
                dayContainer.Controls.Add(blank);
            }

            for (int i = 1; i <= days; i++)
            {
                UCDays ucdays = new UCDays();
                ucdays.days(i, month, year); 
                dayContainer.Controls.Add(ucdays);
            }
        }

        private void UCAppointment_Load(object sender, EventArgs e)
        {
            displayDays();

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (month == 12)
            {
                month = 1;
                year++;
            }
            else
            {
                month++;
            }
            UpdateCalendar();

        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (month == 1)
            {
                month = 12;
                year--;
            }
            else
            {
                month--;
            }
            UpdateCalendar();
        }

        private void UpdateCalendar()
        {
            string monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            LBDATE.Text = monthname + " " + year;

            DateTime startofthemonth = new DateTime(year, month, 1);

            int days = DateTime.DaysInMonth(year, month);
            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek);

            dayContainer.Controls.Clear();

            for (int i = 0; i < dayoftheweek; i++)
            {
                UCBlank blank = new UCBlank();
                dayContainer.Controls.Add(blank);
            }

            for (int i = 1; i <= days; i++)
            {
                UCDays ucdays = new UCDays();

                ucdays.days(i, month, year); 
                dayContainer.Controls.Add(ucdays);
            }
        }
    }
}
