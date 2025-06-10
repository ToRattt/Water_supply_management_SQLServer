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

namespace quanlichannuoi
{
    public partial class Doithongtinhuyen : Form
    {
        public Doithongtinhuyen()
        {
            InitializeComponent();
        }
        public Doithongtinhuyen(string name)
        {
            InitializeComponent();
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT TenHuyen, MaHuyen  FROM  dbo.Huyen WHERE TenHuyen = @Ten";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("Ten", name);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            txtName.Text = reader["TenHuyen"].ToString();
                            txtCode.Text = reader["MaHuyen"].ToString();
                            

                        }
                    }

                }

            }

        }

        private void Doithongtinhuyen_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "UPDATE Huyen SET MaHuyen=@NewCode Where TenHuyen=@Ten";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Ten", txtName.Text);
                    cmd.Parameters.AddWithValue("@NewCode", txtCode.Text);
                    
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật không thành công");
                    }
                }
            }
        }
    }
}
