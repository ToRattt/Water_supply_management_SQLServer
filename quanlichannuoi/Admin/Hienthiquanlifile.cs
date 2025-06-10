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
    public partial class Hienthiquanlifile : UserControl
    {
        public Hienthiquanlifile()
        {
            InitializeComponent();
        }
        // thang them o day
        // Hàm để kết nối với cơ sở dữ liệu
        private SqlConnection ConnectDatabase()
        {
            // Chuỗi kết nối cho Windows Authentication
            string connectionString = "Data Source=DinhCong;Initial Catalog=QuanLyNongThon;Integrated Security=True;Encrypt=False";
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
        private void Hienthiquanlifile_Load(object sender, EventArgs e)
        {

        }
        private void LoadData()
        {
            using (SqlConnection connection = ConnectDatabase())
            {
                string query = "SELECT f.id_file, f.name_file, f.upload_date, l.name " +
                               "FROM files f " +
                               "JOIN legal_documents l ON f.id_legal_documents = l.id";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                // Gán dữ liệu vào DataGridView
                dataGridView1.DataSource = dataTable;

                // Đặt tiêu đề cột tùy chỉnh (nếu cần)
                dataGridView1.Columns["id_file"].HeaderText = "ID File";
                dataGridView1.Columns["name_file"].HeaderText = "Tên File";
                dataGridView1.Columns["upload_date"].HeaderText = "Ngày Upload";
                dataGridView1.Columns["name"].HeaderText = "Tên Văn Bản";
            }
        }
        private void btnShowAll_Click(object sender, EventArgs e)
        {
            LoadData(); // Gọi hàm LoadData để tải và hiển thị dữ liệu
        }
    }
}
