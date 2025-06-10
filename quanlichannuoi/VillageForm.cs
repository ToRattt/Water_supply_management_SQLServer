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
    public partial class VillageForm : Form
    {
        public VillageForm()
        {
            InitializeComponent();
        }

        private void VillageShow_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT Tenxa, MaXa, HuyenID FROM dbo.Xa ";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Hiển thị dữ liệu trong DataGridView
                    dataGridView1.DataSource = dataTable;
                }
            }
        }

        private void btnAddVillage_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Xa (TenXa, MaXa, HuyenID) VALUES (@TenXa, @MaXa, @HuyenID)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TenXa", txtNameVillage.Text);

                    cmd.Parameters.AddWithValue("@MaXa", txtCodeVillage.Text);

                    cmd.Parameters.AddWithValue("@HuyenID", txtCodeDistrict.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Thêm xã thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Không thể thêm xã");
                    }
                }
            }
        }

        private void btnSearchVillage_Click(object sender, EventArgs e)
        {

            string searchName = txtSearchNameVillage.Text;

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                // Truy vấn tìm kiếm
                string query = "SELECT Tenxa, MaXa, HuyenID FROM dbo.Xa WHERE TenXa LIKE @Name";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    // Thêm tham số tìm kiếm
                    adapter.SelectCommand.Parameters.AddWithValue("@Name", searchName);

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Hiển thị dữ liệu trong DataGridView
                    dataGridView1.DataSource = dataTable;
                }
            }
        }
    }
}
