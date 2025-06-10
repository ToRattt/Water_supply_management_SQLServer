using quanlichannuoi.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlichannuoi
{
    public partial class BaoCaoCTNuocSachTheoCT : UserControl
    {
        public BaoCaoCTNuocSachTheoCT()
        {
            InitializeComponent();
        }

        private void LoadCongTrinh()
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT MaCongTrinh, TenCongTrinh FROM CongTrinhNuocSach2"; // Điều chỉnh query nếu cần
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBoxCongTrinh.DisplayMember = "TenCongTrinh"; // Hiển thị tên công trình
                comboBoxCongTrinh.ValueMember = "MaCongTrinh"; // Giá trị là MaCongTrinh
                comboBoxCongTrinh.DataSource = dt;
            }
        }


        private void LoadChiTieu()
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT MaChiTieu, TenChiTieu FROM ChiTieuNuocSach";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        comboBoxChiTieu.DisplayMember = "TenChiTieu";
                        comboBoxChiTieu.ValueMember = "MaChiTieu";
                        comboBoxChiTieu.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu chỉ tiêu nước sạch.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message);
                }
            }
        }

        private void LoadBaoCao()
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT bc.MaBaoCao, ct.TenChiTieu, bc.SanLuongThucTe, bc.ChiTieuDatDuoc, bc.Thang " +
                               "FROM BaoCaoChiTieuNuocSach AS bc " +
                               "INNER JOIN ChiTieuNuocSach AS ct ON bc.MaChiTieu = ct.MaChiTieu";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewBaoCao.DataSource = dt;
            }
        }

        // Hàm để lưu báo cáo vào cơ sở dữ liệu
        private void SaveBaoCao()
        {
            try
            {
                // Kiểm tra dữ liệu từ ComboBox
                if (comboBoxChiTieu.SelectedValue == null || comboBoxCongTrinh.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn đầy đủ thông tin chỉ tiêu và công trình.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra và chuyển đổi dữ liệu từ TextBox
                if (!decimal.TryParse(txtSanLuong.Text, out decimal sanLuongThucTe))
                {
                    MessageBox.Show("Sản lượng thực tế phải là số hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(txtChiTieuDatDuoc.Text, out decimal chiTieuDatDuoc))
                {
                    MessageBox.Show("Chỉ tiêu đạt được phải là số hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy giá trị từ các điều khiển
                int maChiTieu = Convert.ToInt32(comboBoxChiTieu.SelectedValue);
                int maCongTrinh = Convert.ToInt32(comboBoxCongTrinh.SelectedValue);
                string thang = dateTimePickerThang.Value.ToString("yyyy-MM-dd");

                // Kết nối và lưu dữ liệu
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO BaoCaoChiTieuNuocSach (MaCongTrinh, MaChiTieu, SanLuongThucTe, ChiTieuDatDuoc, Thang) " +
                                   "VALUES (@MaCongTrinh, @MaChiTieu, @SanLuongThucTe, @ChiTieuDatDuoc, @Thang)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaCongTrinh", maCongTrinh);
                        cmd.Parameters.AddWithValue("@MaChiTieu", maChiTieu);
                        cmd.Parameters.AddWithValue("@SanLuongThucTe", sanLuongThucTe);
                        cmd.Parameters.AddWithValue("@ChiTieuDatDuoc", chiTieuDatDuoc);
                        cmd.Parameters.AddWithValue("@Thang", thang);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Báo cáo đã được lưu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Tải lại danh sách báo cáo
                LoadBaoCao();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hàm để cập nhật báo cáo
        private void UpdateBaoCao(int maBaoCao)
        {
            try
            {
                int maChiTieu = Convert.ToInt32(comboBoxChiTieu.SelectedValue);
                decimal sanLuongThucTe = Convert.ToDecimal(txtSanLuong.Text);
                decimal chiTieuDatDuoc = Convert.ToDecimal(txtChiTieuDatDuoc.Text);
                string thang = dateTimePickerThang.Value.ToString("yyyy-MM-dd");

                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE BaoCaoChiTieuNuocSach SET MaChiTieu = @MaChiTieu, SanLuongThucTe = @SanLuongThucTe, " +
                                   "ChiTieuDatDuoc = @ChiTieuDatDuoc, Thang = @Thang WHERE MaBaoCao = @MaBaoCao";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaBaoCao", maBaoCao);
                    cmd.Parameters.AddWithValue("@MaChiTieu", maChiTieu);
                    cmd.Parameters.AddWithValue("@SanLuongThucTe", sanLuongThucTe);
                    cmd.Parameters.AddWithValue("@ChiTieuDatDuoc", chiTieuDatDuoc);
                    cmd.Parameters.AddWithValue("@Thang", thang);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Báo cáo đã được cập nhật thành công.");
                LoadBaoCao(); // Sau khi cập nhật, tải lại danh sách báo cáo
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        // Hàm để xóa báo cáo
        private void DeleteBaoCao(int maBaoCao)
        {
            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM BaoCaoChiTieuNuocSach WHERE MaBaoCao = @MaBaoCao";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaBaoCao", maBaoCao);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Báo cáo đã được xóa.");
                LoadBaoCao(); // Sau khi xóa, tải lại danh sách báo cáo
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void BaoCaoChiTieuNuocSach_Load(object sender, EventArgs e)
        {
            LoadChiTieu(); // Load các chỉ tiêu
            LoadBaoCao(); // Load báo cáo đã có
            LoadCongTrinh();
            LoadBaoCaoFileDinhKem();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveBaoCao(); // Lưu báo cáo
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int maBaoCao = Convert.ToInt32(dataGridViewBaoCao.SelectedRows[0].Cells["MaBaoCao"].Value);
            UpdateBaoCao(maBaoCao); // Cập nhật báo cáo
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int maBaoCao = Convert.ToInt32(dataGridViewBaoCao.SelectedRows[0].Cells["MaBaoCao"].Value);
            DeleteBaoCao(maBaoCao); // Xóa báo cáo
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void QuanLyFileDinhKem_Load(object sender, EventArgs e)
        {
            LoadBaoCaoFileDinhKem(); // Load danh sách báo cáo
            LoadFiles();  // Load danh sách file đính kèm
        }

        private void LoadBaoCaoFileDinhKem()
        {
            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = @"
                    SELECT BaoCaoChiTieuNuocSach.MaBaoCao, ChiTieuNuocSach.TenChiTieu
                    FROM BaoCaoChiTieuNuocSach
                    INNER JOIN ChiTieuNuocSach ON BaoCaoChiTieuNuocSach.MaChiTieu = ChiTieuNuocSach.MaChiTieu";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        comboBoxBaoCao.DisplayMember = "TenChiTieu";
                        comboBoxBaoCao.ValueMember = "MaBaoCao";
                        comboBoxBaoCao.DataSource = dt;

                        foreach (DataRow row in dt.Rows)
                        {
                            Console.WriteLine("MaBaoCao: " + row["MaBaoCao"] + ", TenChiTieu: " + row["TenChiTieu"]);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu báo cáo.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadFiles()
        {
            if (comboBoxBaoCao.SelectedValue == null)
                return;

            int maBaoCao = Convert.ToInt32(comboBoxBaoCao.SelectedValue);

            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT MaFileDinhKem, TenFile, LoaiFile, NgayTai FROM FileChiTieuNuocSachDinhKem WHERE MaBaoCao = @MaBaoCao";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@MaBaoCao", maBaoCao);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridViewFiles.DataSource = dt;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadFiles();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBoxBaoCao.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn một báo cáo.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string fileName = Path.GetFileName(filePath);
                string fileType = Path.GetExtension(filePath);

                byte[] fileContent = File.ReadAllBytes(filePath);
                int maBaoCao = Convert.ToInt32(comboBoxBaoCao.SelectedValue);

                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO FileChiTieuNuocSachDinhKem (MaBaoCao, TenFile, LoaiFile, NoiDungFile, NgayTai) " +
                                   "VALUES (@MaBaoCao, @TenFile, @LoaiFile, @NoiDungFile, GETDATE())";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaBaoCao", maBaoCao);
                        cmd.Parameters.AddWithValue("@TenFile", fileName);
                        cmd.Parameters.AddWithValue("@LoaiFile", fileType);
                        cmd.Parameters.AddWithValue("@NoiDungFile", fileContent);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("File đã được tải lên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadFiles();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridViewFiles.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn file để tải xuống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maFileDinhKem = Convert.ToInt32(dataGridViewFiles.SelectedRows[0].Cells["MaFileDinhKem"].Value);
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT NoiDungFile, TenFile FROM FileChiTieuNuocSachDinhKem WHERE MaFileDinhKem = @MaFileDinhKem";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaFileDinhKem", maFileDinhKem);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            byte[] fileContent = (byte[])reader["NoiDungFile"];
                            string fileName = reader["TenFile"].ToString();

                            SaveFileDialog saveFileDialog = new SaveFileDialog();
                            saveFileDialog.FileName = fileName;
                            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                File.WriteAllBytes(saveFileDialog.FileName, fileContent);
                                MessageBox.Show("File đã được tải xuống thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridViewFiles.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn file để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maFileDinhKem = Convert.ToInt32(dataGridViewFiles.SelectedRows[0].Cells["MaFileDinhKem"].Value);

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM FileChiTieuNuocSachDinhKem WHERE MaFileDinhKem = @MaFileDinhKem";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaFileDinhKem", maFileDinhKem);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("File đã được xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadFiles();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewBaoCao_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
