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

namespace quanlichannuoi.Admin
{
    public partial class tochucchungnhan : UserControl
    {
        public tochucchungnhan()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO certification_organizations (name, address, phone_number, email, authorized_by) " +
                               "VALUES (@name, @address, @phone_number, @email, @authorized_by)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@phone_number", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@authorized_by", txtCoquan.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Tổ chức chứng nhận đã được thêm thành công!");
                        
                    }
                    else
                    {
                        MessageBox.Show("Thêm tổ chức chứng nhận thất bại.");
                    }
                }
            }

        }

        private void tochucchungnhan_Load(object sender, EventArgs e)
        {

        }
    }
}
