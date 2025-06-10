using quanlichannuoi.Admin;
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
    public partial class Quenmatkhau1 : Form
    {
        public Quenmatkhau1()
        {
            InitializeComponent();
        }

        private void Quenmatkhau1_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM  dbo.NguoiDung WHERE Email = @Email ";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);

                    SqlDataReader reader = cmd.ExecuteReader();


                    if (reader.Read())
                    {
                        MessageBox.Show("Kiểm tra thành công");
                        Quenmatkhau2 quenmatkhau2 = new Quenmatkhau2(txtEmail.Text);
                        this.Hide();
                        quenmatkhau2.ShowDialog();
                        this.Show();
                        txtEmail.Clear();
                        

                    }


                    else
                    {
                        MessageBox.Show("Kiểm tra thất bại! Kiểm tra email.");
                    }
                }
            }
        }
    }
}
