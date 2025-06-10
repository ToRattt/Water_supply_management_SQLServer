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
using quanlichannuoi.DAO;

namespace quanlichannuoi.Admin
{
    public partial class Hienthigiaychungnhan : UserControl
    {
        public Hienthigiaychungnhan()
        {
            InitializeComponent();
        }
        string username;
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                username = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
            catch { }
        }

        private void guna2DataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                username = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
            catch { }

            
            }

        private void btnShow_Click(object sender, EventArgs e)
        {

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM certifications";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;
                int id = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells["id"].Value);

                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM certifications WHERE id = @id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        try
                        {
                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Giấy chứng nhận đã được xóa thành công!");
                                btnShow_Click(sender, e); // Cập nhật lại DataGridView
                            }
                            else
                            {
                                MessageBox.Show("Không thể xóa giấy chứng nhận.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi xóa giấy chứng nhận: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một giấy chứng nhận để xóa.");
            }

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void Hienthigiaychungnhan_Load(object sender, EventArgs e)
        {

        }
    }
}
