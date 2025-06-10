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
    public partial class FreshWater : Form
    {
        public FreshWater()
        {
            InitializeComponent();
            cbType.Items.Add("Tập trung");
            cbType.Items.Add("Nhỏ lẻ");

            cbState.Items.Add("Hoạt động");
            cbState.Items.Add("Không hoạt động");
        }

        private void txtkd_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM CongTrinhNuocSach ";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Hiển thị dữ liệu trong DataGridView
                    dataGridView1.DataSource = dataTable;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO CongTrinhNuocSach (TenCongTrinh, LoaiCongTrinh, XaID, TrangThai, Latitude, Longitude) VALUES (@TenCongTrinh, @LoaiCongTrinh, @XaID, @TrangThai, @Latitude, @Longitude)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TenCongTrinh", txtName.Text);
                    cmd.Parameters.AddWithValue("@LoaiCongTrinh", cbType.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@XaID", int.Parse(txtXa.Text));
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
