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
    public partial class ThemHuyen : UserControl
    {
        public ThemHuyen()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Huyen (TenHuyen, MaHuyen) VALUES (@TenHuyen, @MaHuyen)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TenHuyen", txtName.Text);

                    cmd.Parameters.AddWithValue("@MaHuyen", txtCode.Text);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Thêm huyện thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Không thể thêm huyện");
                    }
                }
            }
        }

        private void ThemHuyen_Load(object sender, EventArgs e)
        {

        }
    }
}
