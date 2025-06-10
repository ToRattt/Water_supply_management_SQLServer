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
    public partial class hienthidieukien : UserControl
    {
        public hienthidieukien()
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
            using (SqlConnection conn = Database.GetConnection())
            {
                try
                {

                    username = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                }
                catch { }



                
            }
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM processing_facilities";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                    }
                }

            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void hienthidieukien_Load(object sender, EventArgs e)
        {

        }
    }
}
