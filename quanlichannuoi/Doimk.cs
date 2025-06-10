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
    public partial class Doimk : Form
    {
        public Doimk()
        {
            InitializeComponent();
        }

        private void Doimk_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM  dbo.NguoiDung WHERE Email = @Email AND MatKhau = @MatKhau; UPDATE NguoiDung\r\nSET LastLoginTime = GETDATE()\r\nWHERE Email = @Email;";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@MatKhau", txtPassword.Text);
                    SqlDataReader reader = cmd.ExecuteReader();


                    if (reader.Read())
                    {
                       
                            MessageBox.Show("Kiểm tra thành công!");
                            // Chuyển sang form chính
                            
                            Doimk2 doimk2 = new Doimk2(txtEmail.Text);
                            this.Hide();
                            doimk2.ShowDialog();
                            this.Show();
                            txtEmail.Clear();
                            txtPassword.Clear();
                        
                       
                    }
                    else
                    {
                        MessageBox.Show("Kiểm tra email hoặc mật khẩu.");
                    }
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
