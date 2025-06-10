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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("ban co that su muon thoat chuong trinh ?", "Thong bao", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;

            }
        }

        private void button1_Click(object sender, EventArgs e)
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
                            MainForm mainForm = new MainForm();
                            this.Hide();
                            mainForm.ShowDialog();
                            this.Show();
                        }
                        else
                        {
                            MessageBox.Show("Đăng nhập thành công!");
                            // Chuyển sang form chính
                            FormUser user = new FormUser();
                            this.Hide();
                            user.ShowDialog();
                            this.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Đăng nhập thất bại! Kiểm tra email hoặc mật khẩu.");
                    }
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ForgotPassWordForm form = new ForgotPassWordForm();

            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NewInfor newInfor = new NewInfor();
            newInfor.ShowDialog();

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }
    }
}
