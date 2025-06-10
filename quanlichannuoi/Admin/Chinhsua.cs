using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using quanlichannuoi.DAO;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace quanlichannuoi.Admin
{
    public partial class Chinhsua : UserControl
    {
        public Chinhsua()
        {
            InitializeComponent();
        }
        public Chinhsua(string name)
        {
            InitializeComponent();
            
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT HoTen,Email,MatKhau,CapTk  FROM  dbo.NguoiDung WHERE HoTen = @HoTen";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@HoTen", name);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            txtEmail.Text = reader["Email"].ToString();
                            txtHoTen.Text = reader["HoTen"].ToString();
                            txtMk.Text = reader["MatKhau"].ToString();
                            txtLoaiTk.Text = reader["CapTk"].ToString();

                        }
                    }

                }

            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            
        }

        private void Chinhsua_Load(object sender, EventArgs e)
        {
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }
    }
}
