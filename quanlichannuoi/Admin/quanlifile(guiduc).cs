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
    public partial class quanlifile_guiduc_ : UserControl
    {
        public quanlifile_guiduc_()
        {
            InitializeComponent();
        }

        private void guna2HtmlLabel12_Click(object sender, EventArgs e)
        {

        }
        // Hàm để kết nối với cơ sở dữ liệu
        private SqlConnection ConnectDatabase()
        {
            
            // Chuỗi kết nối cho Windows Authentication
            string connectionString = "Data Source=DinhCong;Initial Catalog=QuanLyNongThon;Integrated Security=True;Encrypt=False";
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
       
        private void ClearInputFields()
        {
            // Xóa các TextBox
            txtIDFile.Clear();
            txtNameFile.Clear();
            txtIDLegalDocuments.Clear();

            // Đặt lại DateTimePicker về ngày hiện tại
            dtpUploadDate.Value = DateTime.Now;
        }
        
        private async void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ các TextBox
                int id_file = Convert.ToInt32(txtIDFile.Text); // Tương ứng với cột "id_file"
                int id_legal_documents = Convert.ToInt32(txtIDLegalDocuments.Text); // Tương ứng với cột "id_legal_documents"
                string name_file = txtNameFile.Text.Trim(); // Tương ứng với cột "name_file"
                DateTime upload_date = dtpUploadDate.Value; // Tương ứng với cột "upload_date"

                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrEmpty(name_file) || id_legal_documents <= 0)
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin cần thiết!");
                    return;
                }

                // Kết nối tới cơ sở dữ liệu và thực thi câu lệnh SQL
                using (SqlConnection connection = ConnectDatabase())
                {
                    string query = "INSERT INTO files (id_file, id_legal_documents, name_file, upload_date) " +
                                   "VALUES (@id_file, @id_legal_documents, @name_file, @upload_date)";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@id_file", id_file);
                    cmd.Parameters.AddWithValue("@id_legal_documents", id_legal_documents);
                    cmd.Parameters.AddWithValue("@name_file", name_file);
                    cmd.Parameters.AddWithValue("@upload_date", upload_date);

                    connection.Open();
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    connection.Close();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("File đã được thêm thành công!");

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

        private void quanlifile_guiduc__Load(object sender, EventArgs e)
        {

        }
    }
}
