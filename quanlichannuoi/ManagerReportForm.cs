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
    public partial class ManagerReportForm : Form
    {
        public ManagerReportForm()
        {
            InitializeComponent();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void btnselectfile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Tất cả tệp|*.*|Tệp văn bản|*.txt|Tệp hình ảnh|*.jpg;*.png";
                openFileDialog.Title = "Chọn file đính kèm";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Lấy đường dẫn file
                    string filePath = openFileDialog.FileName;

                    // Hiển thị đường dẫn trong TextBox
                    txtFileDinhKem.Text = filePath;
                }
            }
        }

        private void ManagerReportForm_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO BaoCaoQuyHoach (QuyHoachID, TieuDe, NoiDung, FileDinhKem) VALUES (@QuyHoachID, @TieuDe, @NoiDung, @FileDinhKem)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@QuyHoachID", int.Parse(txtQuyHoachID.Text));
                    cmd.Parameters.AddWithValue("@TieuDe", txtTieuDe.Text);
                    cmd.Parameters.AddWithValue("@NoiDung", txtNoiDung.Text);
                    cmd.Parameters.AddWithValue("@FileDinhKem", txtFileDinhKem.Text);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Thêm thông tin thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Không thể thêm ");
                    }

                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT *FROM dbo.BaoCaoQuyHoach ";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Hiển thị dữ liệu trong DataGridView
                    dataGridView1.DataSource = dataTable;
                }
            }
        }
    }
}
