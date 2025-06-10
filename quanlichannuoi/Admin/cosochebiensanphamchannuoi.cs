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
using System.Xml.Linq;

namespace quanlichannuoi.Admin
{
    public partial class cosochebiensanphamchannuoi : UserControl
    {
        public cosochebiensanphamchannuoi()
        {
            InitializeComponent();
        }

        private void cosochebiensanphamchannuoi_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO processing_facilities (name_facilities, address, phone, email,commune_id, product_types) " +
                               "VALUES (@name, @address, @phone, @email, @commune_id, @product_types)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", textID.Text);
                    cmd.Parameters.AddWithValue("@address", txtname.Text);
                    cmd.Parameters.AddWithValue("@phone", txtphone.Text);
                    cmd.Parameters.AddWithValue("@email", txtmail.Text);
                    
                    cmd.Parameters.AddWithValue("@commune_id", txtIDxa.Text);
                    cmd.Parameters.AddWithValue("@product_types", txttype.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Thêm mới thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Thêm mới không thành công!");
                    }

                    guna2Button1_Click(sender, e); // Refresh dữ liệu
                }
            }

        }
    }
}
