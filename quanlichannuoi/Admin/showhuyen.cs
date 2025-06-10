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
    public partial class showhuyen : UserControl
    {
        public showhuyen()
        {
            InitializeComponent();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT HuyenID, TenHuyen, MaHuyen FROM dbo.Huyen ";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Hiển thị dữ liệu trong DataGridView
                    guna2DataGridView1.DataSource = dataTable;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchName = txtName.Text;

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                // Truy vấn tìm kiếm
                string query = "SELECT HuyenID, TenHuyen, MaHuyen FROM dbo.Huyen WHERE TenHuyen LIKE @Name";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    // Thêm tham số tìm kiếm
                    adapter.SelectCommand.Parameters.AddWithValue("@Name", searchName);

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Hiển thị dữ liệu trong DataGridView
                    guna2DataGridView1.DataSource = dataTable;
                }
            }
        }

        private void showhuyen_Load(object sender, EventArgs e)
        {

        }
    }
}
