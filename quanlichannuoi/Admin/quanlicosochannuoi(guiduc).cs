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
    public partial class quanlicosochannuoi_guiduc_ : UserControl
    {
        // Kết nối đến SQL Server
        private string connectionString = "Data Source=DinhCong;Initial Catalog=QuanLyNongThon;Integrated Security=True;Encrypt=False";

        public quanlicosochannuoi_guiduc_()
        {
            InitializeComponent();
            // Nạp dữ liệu cho ComboBox
        }        
        private void LoadComboBoxes()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // 1. Lấy danh sách Huyện
                string queryDistrict = "SELECT HuyenID, TenHuyen FROM Huyen"; // Sử dụng đúng tên cột
                SqlDataAdapter daDistrict = new SqlDataAdapter(queryDistrict, conn);
                DataTable dtDistrict = new DataTable();
                daDistrict.Fill(dtDistrict);

                // Liên kết dữ liệu với comboBoxDistrict
                comboBoxDistrict.DataSource = dtDistrict;
                comboBoxDistrict.DisplayMember = "TenHuyen"; // Sử dụng đúng tên cột
                comboBoxDistrict.ValueMember = "HuyenID";

                // 2. Lấy danh sách Xã
                string queryCommune = "SELECT XaID, TenXa FROM Xa"; // Sử dụng đúng tên cột
                SqlDataAdapter daCommune = new SqlDataAdapter(queryCommune, conn);
                DataTable dtCommune = new DataTable();
                daCommune.Fill(dtCommune);

                // Liên kết dữ liệu với comboBoxCommune
                comboBoxCommune.DataSource = dtCommune;
                comboBoxCommune.DisplayMember = "TenXa"; // Sử dụng đúng tên cột
                comboBoxCommune.ValueMember = "XaID";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO livestock_facility 
                (name_facilities, name_s, address, phone, email, district_id, commune_id, product_types, scale)
                VALUES (@NameFacilities, @NameS, @Address, @Phone, @Email, @DistrictId, @CommuneId, @ProductTypes, @Scale)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Gán tham số
                        cmd.Parameters.AddWithValue("@NameFacilities", txtNameFacilities.Text);
                        cmd.Parameters.AddWithValue("@NameS", txtNameS.Text);
                        cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                        cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@DistrictId", comboBoxDistrict.SelectedValue);
                        cmd.Parameters.AddWithValue("@CommuneId", comboBoxCommune.SelectedValue);
                        cmd.Parameters.AddWithValue("@ProductTypes", txtProductTypes.Text);
                        cmd.Parameters.AddWithValue("@Scale", comboBoxScale.SelectedItem?.ToString());


                        // Thực thi lệnh
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Thêm thành công");
                        }
                        else
                        {
                            MessageBox.Show("Không có dữ liệu nào được thêm");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void comboBoxScale_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxCommune_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void quanlicosochannuoi_guiduc__Load(object sender, EventArgs e)
        {

        }
    }
}
