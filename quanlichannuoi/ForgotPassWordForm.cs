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
    public partial class ForgotPassWordForm : Form
    {
        public ForgotPassWordForm()
        {
            InitializeComponent();
        }
        private string GenerateResetCode()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString(); // Mã 6 chữ số
        }

        private void btnSendResetCode_Click(object sender, EventArgs e)
        {
            string resetCode = GenerateResetCode();
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "UPDATE NguoiDung SET ResetCode = @ResetCode WHERE Email = @Email";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ResetCode", resetCode);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Mã khôi phục đã được gửi!");
                        // Gửi mã qua email (nếu cần tích hợp SMTP)
                    }
                    else
                    {
                        MessageBox.Show("Email không tồn tại trong hệ thống.");
                    }
                }
            }

        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            ResetPassWordForm resetPassWordForm = new ResetPassWordForm();
            resetPassWordForm.Show();
        }
    }
}
