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

namespace quanlichannuoi.Admin
{
    public partial class dieukienchannuoi : UserControl
    {
        public dieukienchannuoi()
        {
            InitializeComponent();
        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void dieukienchannuoi_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text) ||
                        string.IsNullOrEmpty(txtmt.Text) ||
                        string.IsNullOrEmpty(txtcsvc.Text) ||
                        string.IsNullOrEmpty(txtthucan.Text) ||
                        string.IsNullOrEmpty(txtlaodong.Text) ||
                        string.IsNullOrEmpty(txtphongdich.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO livestock_conditions (organization_id, environment_condition, infrastructure_condition, breed_condition, feed_condition, veterinary_condition, labor_condition, created_at) " +
                               "VALUES (@organization_id, @environment_condition, @infrastructure_condition, @breed_condition, @feed_condition, @veterinary_condition, @labor_condition, @created_at)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@organization_id", txtID.Text);
                    cmd.Parameters.AddWithValue("@environment_condition", txtmt.Text);
                    cmd.Parameters.AddWithValue("@infrastructure_condition", txtcsvc.Text);
                    cmd.Parameters.AddWithValue("@breed_condition", txtthucan.Text);
                    cmd.Parameters.AddWithValue("@feed_condition", txtlaodong.Text);
                    cmd.Parameters.AddWithValue("@veterinary_condition", txtphongdich.Text);
                    cmd.Parameters.AddWithValue("@labor_condition", txtlaodong.Text); // Giả sử đây là điều kiện lao động
                    cmd.Parameters.AddWithValue("@created_at", timeupdate.Value.Date);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Điều kiện chăn nuôi đã được thêm thành công!");
                           // btnShow_Click(sender, e); // Cập nhật lại DataGridView
                        }
                        else
                        {
                            MessageBox.Show("Thêm điều kiện chăn nuôi thất bại.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi thêm điều kiện chăn nuôi: " + ex.Message);
                    }
                }
            }

        }
    }
}
