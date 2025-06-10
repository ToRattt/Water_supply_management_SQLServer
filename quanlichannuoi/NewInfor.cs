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
    public partial class NewInfor : Form
    {
        public NewInfor()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnttk_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO NguoiDung (HoTen, Email, MatKhau) VALUES (@HoTen, @Email, @MatKhau)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@HoTen", txtName.Text);
                    cmd.Parameters.AddWithValue("@Email", txtNewEmail.Text);
                    cmd.Parameters.AddWithValue("@MatKhau", txtNewPassWord.Text);
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
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void NewInfor_Load(object sender, EventArgs e)
        {

        }
    }
    
}
