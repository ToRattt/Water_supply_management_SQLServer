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
    public partial class quanlyketquachannuoinhole_guiduc_ : UserControl
    {
        private string connection_string = "Data Source=DinhCong;Initial Catalog=QuanLyNongThon;Integrated Security=True;Encrypt=False";

        public quanlyketquachannuoinhole_guiduc_()
        {
            InitializeComponent();
        }
        private void quanlyketquachannuoinhole_Load(object sender, EventArgs e)
        {
            // Khi form được load, tự động hiển thị danh sách cơ sở chăn nuôi quy mô nhỏ
            load_statistics();
        }
        // Hàm tải dữ liệu thống kê (chỉ lấy các cơ sở có quy mô nhỏ)
        // Hàm tải dữ liệu thống kê (chỉ lấy các cơ sở có quy mô nhỏ) và đếm số lượng hộ chăn nuôi nhỏ lẻ
        private void load_statistics()
        {
            using (SqlConnection conn = new SqlConnection(connection_string))
            {
                // Truy vấn để lấy thông tin cơ sở có quy mô nhỏ
                string query = "SELECT id, name_facilities, name_s, address, phone, email, product_types, scale FROM livestock_facility WHERE scale = N'nhỏ'";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgv_livestock.DataSource = dt; // Gán DataTable cho DataGridView

                // Truy vấn để đếm số lượng cơ sở có quy mô nhỏ
                string countQuery = "SELECT COUNT(*) FROM livestock_facility WHERE scale = N'nhỏ'";
                SqlCommand countCommand = new SqlCommand(countQuery, conn);
                conn.Open();
                int count = (int)countCommand.ExecuteScalar(); // Lấy số lượng cơ sở có quy mô nhỏ
                conn.Close();

                // Hiển thị kết quả đếm lên Label
                lbl_statistics.Text = count.ToString();
            }
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            load_statistics();
        }

        private void lbl_statistics_Click(object sender, EventArgs e)
        {

        }

        private void quanlyketquachannuoinhole_guiduc__Load(object sender, EventArgs e)
        {

        }
    }
}
