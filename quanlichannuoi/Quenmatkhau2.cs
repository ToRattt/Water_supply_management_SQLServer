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
    public partial class Quenmatkhau2 : Form
    {
        string Email;
        public Quenmatkhau2()
        {
            InitializeComponent();
        }
        public Quenmatkhau2(string user)
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
                            Email = user;
                            labelUserName.Text = ten;
                        }
                    }

                }

            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "UPDATE NguoiDung SET MatKhau = @NewPassword WHERE Email=@Email";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (txtNewPassWord.Text == txtNewPassWord2.Text)
                    {
                        cmd.Parameters.AddWithValue("@NewPassword", txtNewPassWord.Text);
                        cmd.Parameters.AddWithValue("@Email", Email);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Mật khẩu đã được đặt lại!");
                        }
                        else
                        {
                            MessageBox.Show("Không thành công");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nhập lại mật khẩu");
                    }
                    
                    
                }
            }

        }

        private void Quenmatkhau2_Load(object sender, EventArgs e)
        {

        }
    }
}
