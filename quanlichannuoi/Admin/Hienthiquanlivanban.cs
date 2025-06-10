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
    public partial class Hienthiquanlivanban : UserControl
    {
        public Hienthiquanlivanban()
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
        private void LoadData()
        {
            using (SqlConnection connection = ConnectDatabase())
            {
                string query = "SELECT * FROM legal_documents";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                // Gán dữ liệu vào DataGridView
                dataGridView1.DataSource = dataTable;
            }
        }
        private void btnShowAll_Click(object sender, EventArgs e)
        {
            LoadData(); // Gọi hàm LoadData để tải và hiển thị dữ liệu
        }

        private void Hienthiquanlivanban_Load(object sender, EventArgs e)
        {

        }
    }
}
