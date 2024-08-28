using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JomareHospitalSystem
{
    public static class DatabaseConfig
    {
        private static readonly string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\ROSA\\Desktop\\JomareHospitalSystem Finale\\JomareHospitalSystem\\jomareClinicDB.mdf\";Integrated Security=True";

        public static string ConnectionString
        {
            get { return connectionString; }
        }
    }
}
