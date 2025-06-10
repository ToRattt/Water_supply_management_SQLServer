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
    public partial class chinhsuathongtinnuocsach : Form
    {
        public chinhsuathongtinnuocsach()
        {
            InitializeComponent();
        }
        string ten;
        public chinhsuathongtinnuocsach(string name)
        {
            InitializeComponent();
            cbType.Items.Add("Tập trung");
            cbType.Items.Add("Nhỏ lẻ");
            cbState.Items.Add("Hoạt động");
            cbState.Items.Add("Không hoạt động");
            ten= name;
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT TenCongTrinh,LoaiCongTrinh, TrangThai, Latitude, Longitude FROM CongTrinhNuocSach WHERE TenCongTrinh= @name";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            txtkd.Text = reader["Latitude"].ToString();
                            txtvd.Text = reader["Latitude"].ToString();
                            txtName.Text= reader["TenCongTrinh"].ToString();
                            cbType.SelectedItem= reader["LoaiCongTrinh"].ToString();
                            cbState.SelectedItem = reader["TrangThai"].ToString();


                        }
                    }

                }

            }
        }

        private void chinhsuathongtinnuocsach_Load(object sender, EventArgs e)
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
                string query = "UPDATE CongTrinhNuocSach SET TenCongTrinh=@QuyHoach,LoaiCongTrinh = @MoTa,TrangThai=@TrangThai, Latitude=@kd, Longitude=@vd Where TenCongTrinh=@name";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", ten);
                    cmd.Parameters.AddWithValue("@QuyHoach", txtName.Text);
                    cmd.Parameters.AddWithValue("@MoTa", cbType.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@TrangThai", cbState.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@kd", float.Parse(txtkd.Text));
                    cmd.Parameters.AddWithValue("@vd", float.Parse(txtvd.Text));
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
