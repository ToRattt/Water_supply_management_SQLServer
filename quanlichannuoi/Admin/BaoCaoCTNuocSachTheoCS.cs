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
    public partial class BaoCaoCTNuocSachTheoCS : UserControl
    {
        private int selectedMaChiSo; // Lưu mã chỉ số được chọn
        private int selectedMaFile; // Lưu mã file được chọn
        private string selectedDuongDan; // Lưu đường dẫn file được chọn

        public BaoCaoCTNuocSachTheoCS()
        {
            InitializeComponent();
            this.dgvChiSoNuoc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChiSoNuoc_CellContentClick);
            this.dgvFileDinhKem.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFileDinhKem_CellContentClick_1);
        }

        private void QLChiSoNuocSach_Load(object sender, EventArgs e)
        {
            LoadCongTrinh();
            LoadChiSoNuoc();
        }
        private void LoadCongTrinh()
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT MaCongTrinh, TenCongTrinh FROM CongTrinhNuocSach2";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable data = new DataTable();
                adapter.Fill(data);

                cbCongTrinh.DataSource = data;
                cbCongTrinh.DisplayMember = "TenCongTrinh";
                cbCongTrinh.ValueMember = "MaCongTrinh";
            }
        }

        // Load danh sách chỉ số nước vào DataGridView
        private void LoadChiSoNuoc()
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT ChiSoNuoc.MaChiSo, CongTrinhNuocSach2.TenCongTrinh, ChiSoNuoc.ThangNam, ChiSoNuoc.ChiSo, ChiSoNuoc.GhiChu " +
                               "FROM ChiSoNuoc " +
                               "INNER JOIN CongTrinhNuocSach2 ON ChiSoNuoc.MaCongTrinh = CongTrinhNuocSach2.MaCongTrinh";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable data = new DataTable();
                adapter.Fill(data);
                dgvChiSoNuoc.DataSource = data;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO ChiSoNuoc (MaCongTrinh, ThangNam, ChiSo, GhiChu) VALUES (@MaCongTrinh, @ThangNam, @ChiSo, @GhiChu)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaCongTrinh", cbCongTrinh.SelectedValue);
                cmd.Parameters.AddWithValue("@ThangNam", dtpThangNam.Value);
                cmd.Parameters.AddWithValue("@ChiSo", nudChiSo.Value);
                cmd.Parameters.AddWithValue("@GhiChu", txtGhiChu.Text);
                cmd.ExecuteNonQuery();
                LoadChiSoNuoc();
                MessageBox.Show("Thêm chỉ số nước thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvChiSoNuoc.SelectedRows.Count > 0)
            {
                int maChiSo = (int)dgvChiSoNuoc.SelectedRows[0].Cells["MaChiSo"].Value;

                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE ChiSoNuoc SET MaCongTrinh = @MaCongTrinh, ThangNam = @ThangNam, ChiSo = @ChiSo, GhiChu = @GhiChu WHERE MaChiSo = @MaChiSo";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaCongTrinh", cbCongTrinh.SelectedValue);
                    cmd.Parameters.AddWithValue("@ThangNam", dtpThangNam.Value);
                    cmd.Parameters.AddWithValue("@ChiSo", nudChiSo.Value);
                    cmd.Parameters.AddWithValue("@GhiChu", txtGhiChu.Text);
                    cmd.Parameters.AddWithValue("@MaChiSo", maChiSo);
                    cmd.ExecuteNonQuery();
                    LoadChiSoNuoc();
                    MessageBox.Show("Cập nhật chỉ số nước thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvChiSoNuoc.SelectedRows.Count > 0)
            {
                int maChiSo = (int)dgvChiSoNuoc.SelectedRows[0].Cells["MaChiSo"].Value;

                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM ChiSoNuoc WHERE MaChiSo = @MaChiSo";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaChiSo", maChiSo);
                    cmd.ExecuteNonQuery();
                    LoadChiSoNuoc();
                    MessageBox.Show("Xóa chỉ số nước thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnThemFile_Click(object sender, EventArgs e)
        {
            if (selectedMaChiSo <= 0)
            {
                MessageBox.Show("Vui lòng chọn một chỉ số nước trước khi đính kèm file.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "All Files|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string tenFile = Path.GetFileName(openFileDialog.FileName);
                    string duongDan = openFileDialog.FileName;

                    using (SqlConnection conn = Database.GetConnection())
                    {
                        conn.Open();

                        // Kiểm tra xem `MaChiSo` có tồn tại trong bảng `ChiSoNuoc` không
                        string checkQuery = "SELECT COUNT(*) FROM ChiSoNuoc WHERE MaChiSo = @MaChiSo";
                        SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                        checkCmd.Parameters.AddWithValue("@MaChiSo", selectedMaChiSo);

                        int exists = (int)checkCmd.ExecuteScalar();
                        if (exists == 0)
                        {
                            MessageBox.Show("Mã chỉ số không hợp lệ. Vui lòng chọn lại chỉ số nước.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Thêm file nếu `MaChiSo` hợp lệ
                        string insertQuery = "INSERT INTO FileBCChiSoNuoc (MaChiSo, TenFile, DuongDan) VALUES (@MaChiSo, @TenFile, @DuongDan)";
                        SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                        insertCmd.Parameters.AddWithValue("@MaChiSo", selectedMaChiSo);
                        insertCmd.Parameters.AddWithValue("@TenFile", tenFile);
                        insertCmd.Parameters.AddWithValue("@DuongDan", duongDan);

                        insertCmd.ExecuteNonQuery();
                        MessageBox.Show("File đã được thêm thành công!", "Thông báo");
                        LoadDanhSachFile(); // Tải lại danh sách file
                    }
                }
            }
        }

        private void btnXoaFile_Click(object sender, EventArgs e)
        {
            if (selectedMaFile > 0) // selectedMaFile là file đang được chọn
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    string query = "DELETE FROM FileBCChiSoNuoc WHERE MaFile = @MaFile";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaFile", selectedMaFile);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("File đã được xoá thành công!", "Thông báo");
                    LoadDanhSachFile(); // Tải lại danh sách file
                }
            }
        }

        private void btnMoFile_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedDuongDan)) // selectedDuongDan là đường dẫn file được chọn
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                {
                    FileName = selectedDuongDan,
                    UseShellExecute = true
                });
            }
            else
            {
                MessageBox.Show("Vui lòng chọn file cần mở.", "Thông báo");
            }
        }
        private void LoadDanhSachFile()
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT MaFile, TenFile, DuongDan, NgayTai FROM FileBCChiSoNuoc WHERE MaChiSo = @MaChiSo";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaChiSo", selectedMaChiSo);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable data = new DataTable();
                adapter.Fill(data);

                dgvFileDinhKem.DataSource = data; // dgvFileDinhKem là DataGridView
            }
        }

        private void dgvChiSoNuoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvChiSoNuoc.Rows[e.RowIndex];
                selectedMaChiSo = Convert.ToInt32(row.Cells["MaChiSo"].Value);
                LoadDanhSachFile(); // Tải danh sách file liên quan đến mã chỉ số được chọn
            }
        }

        private void dgvFileDinhKem_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvFileDinhKem.Rows[e.RowIndex];
                selectedMaFile = Convert.ToInt32(row.Cells["MaFile"].Value);
                selectedDuongDan = row.Cells["DuongDan"].Value.ToString();
            }
        }
    }
}
