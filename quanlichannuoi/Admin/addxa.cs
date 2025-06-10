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

namespace quanlichannuoi.Admin
{
    public partial class addxa : UserControl
    {
        public addxa()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Xa (TenXa, MaXa, HuyenID) VALUES (@TenXa, @MaXa, @HuyenID)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TenXa", txtNameVillage.Text);

                    cmd.Parameters.AddWithValue("@MaXa", txtCodeVillage.Text);

                    cmd.Parameters.AddWithValue("@HuyenID", txtCodeDistrict.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Thêm xã thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Không thể thêm xã");
                    }
                }
            }
        }

        private void addxa_Load(object sender, EventArgs e)
        {

        }
    }
}
