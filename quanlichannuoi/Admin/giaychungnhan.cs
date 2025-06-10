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
using quanlichannuoi.DAO;

namespace quanlichannuoi.Admin
{
    public partial class giaychungnhan : UserControl
    {
        public giaychungnhan()
        {
            InitializeComponent();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtType.Text) || string.IsNullOrEmpty(txtCoquan.Text) ||
         string.IsNullOrEmpty(txtIDorg.Text) ||
        string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO certifications (organization_id, certificate_type, issue_date, expiry_date, issued_by) " +
                               "VALUES (@organization_id, @certificate_type, @issue_date, @expiry_date, @issued_by)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@organization_id", txtID.Text);
                    cmd.Parameters.AddWithValue("@certificate_type", txtType.Text);
                    cmd.Parameters.AddWithValue("@issue_date", ngaycap.Text);
                    cmd.Parameters.AddWithValue("@expiry_date", ngayhet.Text);
                    cmd.Parameters.AddWithValue("@issued_by", txtCoquan.Text);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Giấy chứng nhận đã được thêm thành công!");
                           
                        }
                        else
                        {
                            MessageBox.Show("Thêm giấy chứng nhận thất bại.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi thêm giấy chứng nhận: " + ex.Message);
                    }
                }
            }

        }

        private void giaychungnhan_Load(object sender, EventArgs e)
        {

        }
    }
}
