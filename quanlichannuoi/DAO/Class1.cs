using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlichannuoi.DAO
{
    
        public class Database
        {
            private static string connectionString = "Data Source=DinhCong;Initial Catalog=QuanLyNongThon;Integrated Security=True;Encrypt=False";

            public static SqlConnection GetConnection()
            {
                return new SqlConnection(connectionString);
            }
        }
    

}
