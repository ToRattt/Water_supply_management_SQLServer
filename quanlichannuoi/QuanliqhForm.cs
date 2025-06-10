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
    public partial class QuanliqhForm : Form
    {
        public QuanliqhForm()
        {
            InitializeComponent();
            comboBoxTrangThai.Items.Add("Hoạt động");
            comboBoxTrangThai.Items.Add("Không hoạt động");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM QuyHoachNuocSach2 ";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Hiển thị dữ liệu trong DataGridView
                    dataGridView1.DataSource = dataTable;
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboBoxTrangThai.SelectedItem.ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open(); 
                string query = "INSERT INTO QuyHoachNuocSach2 (TenQuyHoach, MoTa, NgayThucHien, TrangThai, Latitude, Longitude) VALUES (@TenQuyHoach, @MoTa, @NgayThucHien, @TrangThai, @Latitude, @Longitude)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TenQuyHoach", txtTenQuyHoach.Text);
                    cmd.Parameters.AddWithValue("@MoTa", txtMoTa.Text);
                    cmd.Parameters.AddWithValue("@NgayThucHien", datePickerNgayThucHien.Value);
                    cmd.Parameters.AddWithValue("@TrangThai", comboBoxTrangThai.SelectedItem.ToString());
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtkd_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTenQuyHoach_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
