using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
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
    public partial class chinhsuaquyhoachadmin : Form
    {
        public chinhsuaquyhoachadmin()
        {
            InitializeComponent();
        }
        string ten;
        public chinhsuaquyhoachadmin(string name)
        {
            InitializeComponent();
            comboBoxTrangThai.Items.Add("Hoạt động");
            comboBoxTrangThai.Items.Add("Không hoạt động");
            ten = name;
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT TenQuyHoach,MoTa, NgayThucHien, TrangThai, Latitude, Longitude FROM QuyHoachNuocSach2 WHERE TenQuyHoach= @name";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            
                            txtTenQuyHoach.Text= reader["TenQuyHoach"].ToString();
                            txtMoTa.Text= reader["MoTa"].ToString();
                            datePickerNgayThucHien.Value = Convert.ToDateTime(reader["NgayThucHien"]);
                            comboBoxTrangThai.SelectedItem= reader["TrangThai"].ToString();
                            txtkd.Text= reader["Latitude"].ToString();
                            txtvd.Text= reader["Latitude"].ToString();


                        }
                    }

                }

            }
        }

        private void chinhsuaquyhoachadmin_Load(object sender, EventArgs e)
        {

        }

        private void comboBoxTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboBoxTrangThai.SelectedItem.ToString();
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
                string query = "UPDATE QuyHoachNuocSach2 SET TenQuyHoach=@QuyHoach,MoTa = @MoTa,NgayThucHien=@Date,TrangThai=@TrangThai, Latitude=@kd, Longitude=@vd Where TenQuyHoach=@name";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", ten);
                    cmd.Parameters.AddWithValue("@QuyHoach", txtTenQuyHoach.Text);
                    cmd.Parameters.AddWithValue("@MoTa", txtMoTa.Text);
                    cmd.Parameters.AddWithValue("@Date", datePickerNgayThucHien.Value);
                    cmd.Parameters.AddWithValue("@TrangThai", comboBoxTrangThai.SelectedItem.ToString());
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
