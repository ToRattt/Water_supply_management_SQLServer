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
using System.Xml.Linq;

namespace quanlichannuoi
{
    public partial class Doithongtin : Form
    {
        public Doithongtin()
        {
            InitializeComponent();
        }

        public Doithongtin(string user)
        {
            InitializeComponent();

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT HoTen,Email,MatKhau,CapTk  FROM  dbo.NguoiDung WHERE HoTen = @HoTen";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@HoTen", user);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            txtEmail.Text = reader["Email"].ToString();
                            txtHoTen.Text = reader["HoTen"].ToString();
                            txtMk.Text = reader["MatKhau"].ToString();
                            txtLoaiTk.Text = reader["CapTk"].ToString();

                        }
                    }

                }

            }
        }
        private void Doithongtin_Load(object sender, EventArgs e)
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
                string query = "UPDATE NguoiDung SET HoTen=@NewHoTen,MatKhau = @NewPassword,CapTk=@CapTk Where Email=@Email";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@NewHoTen", txtHoTen.Text);
                        cmd.Parameters.AddWithValue("@NewPassword", txtMk.Text);
                        cmd.Parameters.AddWithValue("@CapTk", int.Parse(txtLoaiTk.Text));
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cập nhật thành công!");
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật không thành công");
                        }
                }
            }
        }
    }
}
