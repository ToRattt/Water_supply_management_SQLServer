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
    public partial class CongTrinhNuocSach : UserControl
    {
        private string trangThai;
        public CongTrinhNuocSach()
        {
            InitializeComponent();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string tenCongTrinh = txtTenCongTrinh.Text;
            string viTri = txtViTri.Text;

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(tenCongTrinh) || string.IsNullOrWhiteSpace(viTri) ||
                string.IsNullOrWhiteSpace(txtViDo.Text) || string.IsNullOrWhiteSpace(txtKinhDo.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Để xử lý cho ViDo và KinhDo
            float viDo, kinhDo;

            // Sử dụng TryParse để kiểm tra tính hợp lệ
            if (!float.TryParse(txtViDo.Text, out viDo))
            {
                MessageBox.Show("Vĩ độ không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!float.TryParse(txtKinhDo.Text, out kinhDo))
            {
                MessageBox.Show("Kinh độ không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Làm tròn giá trị trước khi lưu vào cơ sở dữ liệu
            viDo = (float)Math.Round(viDo, 6);
            kinhDo = (float)Math.Round(kinhDo, 6);

            int congSuat = (int)nudCongSuat.Value;

            // Kiểm tra trạng thái
            string trangThai = cboTrangThai.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(trangThai))
            {
                MessageBox.Show("Vui lòng chọn trạng thái!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra giá trị trạng thái hợp lệ
            if (trangThai != "Hoạt động" && trangThai != "Ngừng hoạt động" && trangThai != "Đang bảo trì")
            {
                MessageBox.Show("Trạng thái không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Thực hiện lưu thông tin
            MessageBox.Show($"Lưu thành công: {tenCongTrinh}, {viTri}, {viDo}, {kinhDo}, {congSuat}, {trangThai}");

            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO CongTrinhNuocSach2 (TenCongTrinh, ViTri, ViDo, KinhDo, CongSuat, TrangThai, NgayLapDat) " +
                                   "VALUES (@TenCongTrinh, @ViTri, @ViDo, @KinhDo, @CongSuat, @TrangThai, @NgayLapDat)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TenCongTrinh", tenCongTrinh);
                    cmd.Parameters.AddWithValue("@ViTri", viTri);
                    cmd.Parameters.AddWithValue("@ViDo", viDo);
                    cmd.Parameters.AddWithValue("@KinhDo", kinhDo);
                    cmd.Parameters.AddWithValue("@CongSuat", congSuat);
                    cmd.Parameters.AddWithValue("@TrangThai", trangThai);
                    // Thêm giá trị ngày giờ hiện tại
                    cmd.Parameters.AddWithValue("@NgayLapDat", DateTime.Now);

                    cmd.ExecuteNonQuery();
                }
                LoadData();
                MessageBox.Show("Thêm thành công!");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi khi thêm công trình: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu không có dòng nào được chọn
            if (dgvNuocSach.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một công trình để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy ID công trình từ dòng đã chọn (sửa tên cột thành "MaCongTrinh")
            int idCongTrinh = Convert.ToInt32(dgvNuocSach.SelectedRows[0].Cells["MaCongTrinh"].Value);

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                // Câu lệnh xóa sử dụng cột MaCongTrinh thay vì ID
                string query = "DELETE FROM CongTrinhNuocSach2 WHERE MaCongTrinh = @MaCongTrinh";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaCongTrinh", idCongTrinh);
                cmd.ExecuteNonQuery();
            }

            LoadData(); // Tải lại dữ liệu sau khi xóa
            MessageBox.Show("Xóa thành công!");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtTenCongTrinh_TextChanged(object sender, EventArgs e)
        {

        }

        private void numCongSuat_ValueChanged(object sender, EventArgs e)
        {

        }

        private void QLNuocSachVaVSMoiTruong_Load(object sender, EventArgs e)
        {
            // Thêm các giá trị vào ComboBox
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.AddRange(new string[] { "Hoạt động", "Ngừng hoạt động", "Đang bảo trì" });

            // Đặt giá trị mặc định cho ComboBox (nếu cần)
            if (cboTrangThai.Items.Count > 0)
            {
                cboTrangThai.SelectedIndex = 0; // Chọn giá trị đầu tiên trong ComboBox
            }

            // Thiết lập cột cho DataGridView
            dgvNuocSach.Columns.Clear();
            dgvNuocSach.Columns.Add("ID", "ID");
            dgvNuocSach.Columns.Add("TenCongTrinh", "Tên Công Trình");
            dgvNuocSach.Columns.Add("ViTri", "Vị Trí");
            dgvNuocSach.Columns.Add("CongSuat", "Công Suất");
            dgvNuocSach.Columns.Add("KinhDo", "Kinh Độ");
            dgvNuocSach.Columns.Add("ViDo", "Vĩ Độ");
            dgvNuocSach.Columns.Add("TrangThai", "Trạng Thái");

            // Cấu hình các cột để dễ dàng chỉnh sửa
            dgvNuocSach.Columns["ID"].Visible = false; // Ẩn cột ID vì nó chỉ dùng cho tham chiếu
        }

        private void cmbTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu người dùng đã chọn một trạng thái
            if (cboTrangThai.SelectedItem != null)
            {
                trangThai = cboTrangThai.SelectedItem.ToString();  // Lấy giá trị được chọn
            }
            else
            {
                MessageBox.Show("Vui lòng chọn trạng thái!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenCongTrinh.Text) ||
            string.IsNullOrWhiteSpace(txtViTri.Text) ||
            string.IsNullOrWhiteSpace(txtKinhDo.Text) ||
            string.IsNullOrWhiteSpace(txtViDo.Text) ||
            cboTrangThai.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            // Cập nhật vào DataGridView
            if (dgvNuocSach.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvNuocSach.SelectedRows[0];

                selectedRow.Cells["TenCongTrinh"].Value = txtTenCongTrinh.Text;
                selectedRow.Cells["ViTri"].Value = txtViTri.Text;
                selectedRow.Cells["CongSuat"].Value = nudCongSuat.Value;
                selectedRow.Cells["KinhDo"].Value = txtKinhDo.Text;
                selectedRow.Cells["ViDo"].Value = txtViDo.Text;
                selectedRow.Cells["TrangThai"].Value = cboTrangThai.SelectedItem.ToString();
            }

            // Cập nhật cơ sở dữ liệu
            UpdateDatabase();

            MessageBox.Show("Cập nhật thông tin thành công!");
        }

        private void dgvNuocSach_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            string columnName = dgvNuocSach.Columns[e.ColumnIndex].Name;

            // Lấy dữ liệu đã chỉnh sửa
            var value = dgvNuocSach.Rows[rowIndex].Cells[columnName].Value;

            // Ghi dữ liệu thay đổi vào cơ sở dữ liệu
            UpdateDatabase(rowIndex, columnName, value);
        }

        private void LoadData()
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT MaCongTrinh, TenCongTrinh, ViTri, CongSuat, KinhDo, ViDo, TrangThai, NgayLapDat FROM CongTrinhNuocSach2 ORDER BY MaCongTrinh ASC";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dgvNuocSach.Columns.Clear();
                dgvNuocSach.DataSource = dataTable;

                dgvNuocSach.Columns["MaCongTrinh"].HeaderText = "Mã Công Trình";
                dgvNuocSach.Columns["TenCongTrinh"].HeaderText = "Tên Công Trình";
                dgvNuocSach.Columns["ViTri"].HeaderText = "Vị Trí";
                dgvNuocSach.Columns["CongSuat"].HeaderText = "Công Suất";
                dgvNuocSach.Columns["KinhDo"].HeaderText = "Kinh Độ";
                dgvNuocSach.Columns["ViDo"].HeaderText = "Vĩ Độ";
                dgvNuocSach.Columns["TrangThai"].HeaderText = "Trạng Thái";
                dgvNuocSach.Columns["NgayLapDat"].HeaderText = "Ngày Lắp Đặt"; // Thêm cột ngày lắp đặt
            }
        }


        private void UpdateDatabase(int rowIndex, string columnName, object value)
        {
            using (SqlConnection conn = new SqlConnection("YourConnectionString"))
            {
                conn.Open();
                string query = $"UPDATE CongTrinhNuocSach2 SET {columnName} = @Value WHERE ID = @ID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Value", value);
                    cmd.Parameters.AddWithValue("@ID", dgvNuocSach.Rows[rowIndex].Cells["ID"].Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        private void UpdateDatabase()
        {
            using (SqlConnection conn = new SqlConnection("YourConnectionString"))
            {
                conn.Open();

                string query = "UPDATE CongTrinhNuocSach2 SET TenCongTrinh = @TenCongTrinh, ViTri = @ViTri, CongSuat = @CongSuat, KinhDo = @KinhDo, ViDo = @ViDo, TrangThai = @TrangThai WHERE ID = @ID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", dgvNuocSach.SelectedRows[0].Cells["ID"].Value);
                    cmd.Parameters.AddWithValue("@TenCongTrinh", txtTenCongTrinh.Text);
                    cmd.Parameters.AddWithValue("@ViTri", txtViTri.Text);
                    cmd.Parameters.AddWithValue("@CongSuat", nudCongSuat.Value);
                    cmd.Parameters.AddWithValue("@KinhDo", txtKinhDo.Text);
                    cmd.Parameters.AddWithValue("@ViDo", txtViDo.Text);
                    cmd.Parameters.AddWithValue("@TrangThai", cboTrangThai.SelectedItem.ToString());

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu không có dòng nào được chọn
            if (dgvNuocSach.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một công trình để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy ID công trình từ dòng đã chọn
            int idCongTrinh = Convert.ToInt32(dgvNuocSach.SelectedRows[0].Cells["MaCongTrinh"].Value);

            // Lấy các giá trị từ các ô nhập liệu (TextBox, ComboBox, NumericUpDown)
            string tenCongTrinh = txtTenCongTrinh.Text;
            string viTri = txtViTri.Text;
            float viDo = Convert.ToSingle(txtViDo.Text);
            float kinhDo = Convert.ToSingle(txtKinhDo.Text);
            int congSuat = (int)nudCongSuat.Value;
            string trangThai = cboTrangThai.SelectedItem?.ToString();

            // Lấy ngày lắp đặt từ DateTimePicker hoặc TextBox
            DateTime ngayLapDat = dtpNgayLapDat.Value; // Nếu sử dụng DateTimePicker

            // Kiểm tra dữ liệu nhập vào
            if (string.IsNullOrWhiteSpace(tenCongTrinh) || string.IsNullOrWhiteSpace(viTri) ||
                string.IsNullOrWhiteSpace(txtViDo.Text) || string.IsNullOrWhiteSpace(txtKinhDo.Text) ||
                string.IsNullOrEmpty(trangThai))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Cập nhật dữ liệu vào cơ sở dữ liệu
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "UPDATE CongTrinhNuocSach2 SET TenCongTrinh = @TenCongTrinh, ViTri = @ViTri, CongSuat = @CongSuat, " +
                               "KinhDo = @KinhDo, ViDo = @ViDo, TrangThai = @TrangThai, NgayLapDat = @NgayLapDat WHERE MaCongTrinh = @MaCongTrinh";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaCongTrinh", idCongTrinh);
                cmd.Parameters.AddWithValue("@TenCongTrinh", tenCongTrinh);
                cmd.Parameters.AddWithValue("@ViTri", viTri);
                cmd.Parameters.AddWithValue("@CongSuat", congSuat);
                cmd.Parameters.AddWithValue("@KinhDo", kinhDo);
                cmd.Parameters.AddWithValue("@ViDo", viDo);
                cmd.Parameters.AddWithValue("@TrangThai", trangThai);
                cmd.Parameters.AddWithValue("@NgayLapDat", ngayLapDat);  // Thêm ngày lắp đặt vào câu lệnh SQL

                cmd.ExecuteNonQuery();
            }

            // Cập nhật lại DataGridView sau khi sửa
            LoadData();
            MessageBox.Show("Cập nhật công trình thành công!");
        }

        private void dgvNuocSach_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNuocSach.SelectedRows.Count > 0)
            {
                // Lấy dòng đã chọn
                DataGridViewRow selectedRow = dgvNuocSach.SelectedRows[0];

                // Hiển thị các thông tin vào các ô nhập liệu
                txtTenCongTrinh.Text = selectedRow.Cells["TenCongTrinh"].Value.ToString();
                txtViTri.Text = selectedRow.Cells["ViTri"].Value.ToString();
                nudCongSuat.Value = Convert.ToDecimal(selectedRow.Cells["CongSuat"].Value);
                txtKinhDo.Text = selectedRow.Cells["KinhDo"].Value.ToString();
                txtViDo.Text = selectedRow.Cells["ViDo"].Value.ToString();
                cboTrangThai.SelectedItem = selectedRow.Cells["TrangThai"].Value.ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dgvNuocSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void grpNuocSachDetails_Enter(object sender, EventArgs e)
        {

        }
    }
}
