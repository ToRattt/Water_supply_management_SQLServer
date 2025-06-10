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
    public partial class ResetPassWordForm : Form
    {
        public ResetPassWordForm()
        {
            InitializeComponent();
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "UPDATE NguoiDung SET MatKhau = @NewPassword, ResetCode = NULL WHERE ResetCode = @ResetCode";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NewPassword", txtNewPassword.Text);
                    cmd.Parameters.AddWithValue("@ResetCode", txtResetCode.Text);
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
            }

        }
    }
}
