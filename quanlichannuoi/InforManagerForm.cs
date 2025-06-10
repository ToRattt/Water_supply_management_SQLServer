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
    public partial class InforManagerForm : Form
    {
        public InforManagerForm()
        {
            InitializeComponent();
        }

        


        private void label1_Click(object sender, EventArgs e)
        {

        }
        
        private void btnLoadData_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT HoTen, Email, TrangThai FROM dbo.NguoiDung ";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Hiển thị dữ liệu trong DataGridView
                    dataGridView1.DataSource = dataTable;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchName = txtSearchName.Text;

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                // Truy vấn tìm kiếm
                string query = "SELECT HoTen, Email, TrangThai FROM dbo.NguoiDung WHERE HoTen LIKE @Name";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    // Thêm tham số tìm kiếm
                    adapter.SelectCommand.Parameters.AddWithValue("@Name", searchName );

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Hiển thị dữ liệu trong DataGridView
                    dataGridView1.DataSource = dataTable;
                }
            }
        }
    }
}
