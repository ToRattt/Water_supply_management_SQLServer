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
    public partial class hienthitochucchungnhan : UserControl
    {
        public hienthitochucchungnhan()
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

           chinhsuatochucchungnhan chinhsuatochucchungnhan=new chinhsuatochucchungnhan(username);
           chinhsuatochucchungnhan.ShowDialog();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
                 using (SqlConnection conn = Database.GetConnection())
     {
         conn.Open();
         string query = "SELECT * FROM certification_organizations";
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
                    string query = "DELETE FROM certification_organizations WHERE id = @id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Tổ chức chứng nhận đã được xóa thành công!");
                            btnShow_Click(sender, e); // Cập nhật lại DataGridView
                        }
                        else
                        {
                            MessageBox.Show("Xóa tổ chức chứng nhận thất bại.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một tổ chức chứng nhận để xóa.");
            }

        }

        private void hienthitochucchungnhan_Load(object sender, EventArgs e)
        {

        }
    }
}
