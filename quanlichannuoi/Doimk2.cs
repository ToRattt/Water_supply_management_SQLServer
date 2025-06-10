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
    public partial class Doimk2 : Form
    {
        string email;
        public Doimk2()
        {
            InitializeComponent();

        }
        
        public Doimk2(string user)
        {
            InitializeComponent();
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT HoTen FROM  dbo.NguoiDung WHERE Email = @Email";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", user);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string ten = reader["HoTen"].ToString();
                            email = user;
                            labelUserName.Text = ten;
                        }
                    }

                }

            }
        }

        private void Doimk2_Load(object sender, EventArgs e)
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
                string query = "UPDATE NguoiDung SET MatKhau = @NewPassword Where Email=@Email";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (txtPassword.Text == txtPassword2.Text)
                    {
                        cmd.Parameters.AddWithValue("@NewPassword", txtPassword.Text);
                        cmd.Parameters.AddWithValue("@Email", email);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Mật khẩu đã được đặt lại!");
                        }
                        else
                        {
                            MessageBox.Show("Mã khôi phục không hợp lệ.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nhập lại mật khẩu");
                    }


                }
            }
        }

        private void labelUserName_Click(object sender, EventArgs e)
        {

        }
    }
}
