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
    public partial class quanlivanban_guiduc_ : UserControl
    {
        public quanlivanban_guiduc_()
        {
            InitializeComponent();
        }
        // Hàm để kết nối với cơ sở dữ liệu
        private SqlConnection ConnectDatabase()
        {
            // Chuỗi kết nối cho Windows Authentication
            string connectionString = "Data Source=DinhCong;Initial Catalog=QuanLyNongThon;Integrated Security=True;Encrypt=False";
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
        private void LoadData()
        {
            using (SqlConnection connection = ConnectDatabase())
            {
                string query = "SELECT * FROM legal_documents";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                
            }
        }
        private void ClearInputFields()
        {
            // Xóa các TextBox
            txtID.Clear();
            txtTenVanBan.Clear();
            txtLoaiVanBan.Clear();
            txtCoQuanBanHanh.Clear();
            txtFileDinhKem.Clear();

            // Đặt lại DateTimePicker về ngày hiện tại
            dtpNgayBanHanh.Value = DateTime.Now;
            dtpNgayCoHieuLuc.Value = DateTime.Now;

            // Đặt lại ComboBox về giá trị mặc định
            cmbTrangThai.SelectedIndex = -1;
        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }

        private void quanlivanban_guiduc__Load(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel7_Click(object sender, EventArgs e)
        {

        }



        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel12_Click(object sender, EventArgs e)
        {

        }

        private void cmbTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        // thang them o day

        private async void guna2Button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ các TextBox
                int id = Convert.ToInt32(txtID.Text); // Tương ứng với cột "id"
                string name = txtTenVanBan.Text.Trim(); // Tương ứng với cột "name"
                string type = txtLoaiVanBan.Text.Trim(); // Tương ứng với cột "type"
                DateTime issued_date = dtpNgayBanHanh.Value; // Tương ứng với cột "issued_date"
                DateTime effective_date = dtpNgayCoHieuLuc.Value; // Tương ứng với cột "effective_date"
                string issued_by = txtCoQuanBanHanh.Text.Trim(); // Tương ứng với cột "issued_by"
                string file_path = txtFileDinhKem.Text.Trim(); // Tương ứng với cột "file_path"
                byte status = (byte)cmbTrangThai.SelectedIndex; // Tương ứng với cột "status"

                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(type) || string.IsNullOrEmpty(issued_by))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin cần thiết!");
                    return;
                }

                // Kết nối tới cơ sở dữ liệu và thực thi câu lệnh SQL
                using (SqlConnection connection = ConnectDatabase())
                {
                    string query = "INSERT INTO legal_documents (id, name, type, issued_date, effective_date, issued_by, file_path, status) " +
                                   "VALUES (@id, @name, @type, @issued_date, @effective_date, @issued_by, @file_path, @status)";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@issued_date", issued_date);
                    cmd.Parameters.AddWithValue("@effective_date", effective_date);
                    cmd.Parameters.AddWithValue("@issued_by", issued_by);
                    cmd.Parameters.AddWithValue("@file_path", file_path);
                    cmd.Parameters.AddWithValue("@status", status);

                    connection.Open();
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    connection.Close();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Văn bản pháp luật đã được thêm thành công!");

                        // Xóa các ô nhập liệu sau khi thêm thành công
                        ClearInputFields();

                        
                    }
                    else
                    {
                        MessageBox.Show("Không có dòng nào được thêm vào!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }
    }
}
