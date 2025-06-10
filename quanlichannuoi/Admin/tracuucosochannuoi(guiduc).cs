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
    public partial class tracuucosochannuoi_guiduc_ : UserControl
    {
        private string connectionString = "Data Source=DinhCong;Initial Catalog=QuanLyNongThon;Integrated Security=True;Encrypt=False";

        public tracuucosochannuoi_guiduc_()
        {
            InitializeComponent();
        }
        // Hàm tải toàn bộ dữ liệu
        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT * FROM livestock_facility";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        dataGridViewSearchResults.DataSource = dataTable;
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu để hiển thị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridViewSearchResults.DataSource = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }



        private void dataGridViewSearchResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Tạo truy vấn động dựa trên thông tin tìm kiếm
                    string query = @"SELECT * 
                                     FROM livestock_facility 
                                     WHERE (@NameFacilities IS NULL OR name_facilities LIKE '%' + @NameFacilities + '%')";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Gán tham số tìm kiếm
                        if (string.IsNullOrWhiteSpace(txtNameFacilities.Text))
                        {
                            cmd.Parameters.AddWithValue("@NameFacilities", DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@NameFacilities", txtNameFacilities.Text.Trim());
                        }

                        // Thực thi truy vấn và nạp kết quả vào DataGridView
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        if (dataTable.Rows.Count > 0)
                        {
                            dataGridViewSearchResults.DataSource = dataTable;
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy dữ liệu phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dataGridViewSearchResults.DataSource = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnReset_Click_1(object sender, EventArgs e)
        {
            // Xóa nội dung TextBox
            txtNameFacilities.Clear();

            // Nạp lại toàn bộ dữ liệu vào DataGridView
            LoadData();
        }

        private void dataGridViewSearchResults_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
