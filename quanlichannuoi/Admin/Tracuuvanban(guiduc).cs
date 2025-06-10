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
    public partial class Tracuuvanban_guiduc_ : UserControl
    {
        string connectionString = "Data Source=DinhCong;Initial Catalog=QuanLyNongThon;Integrated Security=True;Encrypt=False";
        
        public Tracuuvanban_guiduc_()
        {
            InitializeComponent();
        }

        private void Tracuuvanban_guiduc__Load(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

      

        private void btnTimKiem_Click_1(object sender, EventArgs e)
        {
            string idVanBan = txtIDVanBan.Text.Trim();
            string tenVanBan = txtTenVanBan.Text.Trim();

            if (string.IsNullOrEmpty(idVanBan) && string.IsNullOrEmpty(tenVanBan))
            {
                MessageBox.Show("Vui lòng nhập ID hoặc Tên văn bản để tìm kiếm.");
                return;
            }

            string query = "SELECT * FROM legal_documents WHERE 1=1";

            // Thêm điều kiện tìm kiếm theo ID và Tên nếu có
            if (!string.IsNullOrEmpty(idVanBan))
                query += " AND id = @idVanBan";
            if (!string.IsNullOrEmpty(tenVanBan))
                query += " AND name LIKE @tenVanBan";

            // Kết nối cơ sở dữ liệu và thực thi truy vấn
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

                // Thêm tham số truy vấn
                adapter.SelectCommand.Parameters.AddWithValue("@idVanBan", idVanBan);
                adapter.SelectCommand.Parameters.AddWithValue("@tenVanBan", "%" + tenVanBan + "%");

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Hiển thị kết quả vào DataGridView
                if (dataTable.Rows.Count > 0)
                {
                    dataGridView.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy văn bản nào với thông tin đã nhập.");
                }
            }
        }
    }
}
