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
using System.Xml.Linq;

namespace quanlichannuoi
{
    public partial class TaoTk : Form
    {
        public TaoTk()
        {
            InitializeComponent();
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
                string query = "INSERT INTO NguoiDung (HoTen, Email, MatKhau) VALUES (@HoTen, @Email, @MatKhau)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (txtmk.Text == txtmk2.Text)
                    {
                        cmd.Parameters.AddWithValue("@HoTen", txthoten.Text);
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@MatKhau", txtmk.Text);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Tài khoản đã được tạo thành công!");
                        }
                        else
                        {
                            MessageBox.Show("Không thể tạo tài khoản.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nhập lại mật khẩu");
                    }
                }
            }
        }
    }
}
