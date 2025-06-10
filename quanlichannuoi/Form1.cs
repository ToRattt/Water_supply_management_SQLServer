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
using quanlichannuoi.DAO;
namespace quanlichannuoi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
       
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
            Application.Exit();
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM  dbo.NguoiDung WHERE Email = @Email AND MatKhau = @MatKhau; UPDATE NguoiDung\r\nSET LastLoginTime = GETDATE()\r\nWHERE Email = @Email;";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@MatKhau", txtMatKhau.Text);
                    SqlDataReader reader = cmd.ExecuteReader();


                    if (reader.Read())
                    {
                        string captk = reader["CapTk"].ToString();
                        if (captk == "1")
                        {
                            MessageBox.Show("Đăng nhập thành công!");
                            // Chuyển sang form chính
                            frmadmin admin = new frmadmin(txtEmail.Text);
                            this.Hide();
                            admin.ShowDialog();
                            this.Show();
                            txtEmail.Clear();
                            txtMatKhau.Clear();
                        }
                        else
                        {
                           MessageBox.Show("Đăng nhập thành công!");
                            // Chuyển sang form chính
                           nguoidung nd=new nguoidung(txtEmail.Text);
                           this.Hide();
                           nd.ShowDialog();
                           this.Show();
                           txtEmail.Clear();
                           txtMatKhau.Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Đăng nhập thất bại! Kiểm tra email hoặc mật khẩu.");
                    }
                }
            }
            
            
            
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            
        }

        private void quenmatkhau1_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            Quenmatkhau1 quenmatkhau1 = new Quenmatkhau1();
            this.Hide();
            quenmatkhau1.ShowDialog();
            this.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
           
            Doimk doimkhau = new Doimk();
            this.Hide();
            doimkhau.ShowDialog();
            this.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            TaoTk doimkhau = new TaoTk();
            this.Hide();
            doimkhau.ShowDialog();
            this.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
