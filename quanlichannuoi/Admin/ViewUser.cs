using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms;
using GMap.NET;
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
    public partial class ViewUser : UserControl
    {
        public ViewUser()
        {
            InitializeComponent();
        }

        private void btnSync_Click(object sender, EventArgs e)
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
                    guna2DataGridView1.DataSource = dataTable;
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string searchName = txtSearch.Text;

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                // Truy vấn tìm kiếm
                string query = "SELECT HoTen, Email, TrangThai FROM dbo.NguoiDung WHERE HoTen LIKE @Name";

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
        string username;
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                username = guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
            catch { }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM NguoiDung WHERE HoTen = @HoTen";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@HoTen", username));

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Xóa thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy bản ghi để xóa.");
                    }
                }
            }
        }

        private void guna2DataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            try
            {
                
                username = guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
            catch { }
            
            Doithongtin doithongtin = new Doithongtin(username);
            doithongtin.ShowDialog();
            

          
            

        }

        private void ViewUser_Load(object sender, EventArgs e)
        {
            
            
            

        }

        private void chinhsua1_Load(object sender, EventArgs e)
        {
            
            
        }
    }
}
