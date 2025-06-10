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
    public partial class themcongtrinhcapnuoc : UserControl
    {
        public themcongtrinhcapnuoc()
        {
            InitializeComponent();
         
            cbType.Items.Add("Tập trung");
            cbType.Items.Add("Nhỏ lẻ");

            cbState.Items.Add("Hoạt động");
            cbState.Items.Add("Không hoạt động");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void themcongtrinhcapnuoc_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO CongTrinhNuocSach (TenCongTrinh, LoaiCongTrinh, TrangThai, Latitude, Longitude) VALUES (@TenCongTrinh, @LoaiCongTrinh, @TrangThai, @Latitude, @Longitude)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TenCongTrinh", txtName.Text);
                    cmd.Parameters.AddWithValue("@LoaiCongTrinh", cbType.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@TrangThai", cbState.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Latitude", float.Parse(txtkd.Text));
                    cmd.Parameters.AddWithValue("@Longitude", float.Parse(txtvd.Text));


                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Thêm thông tin thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Không thể thêm thông tin");
                    }
                }
            }
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = cbType.SelectedItem.ToString();
        }

        private void cbState_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = cbState.SelectedItem.ToString();
        }
    }
}
