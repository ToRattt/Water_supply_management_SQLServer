using quanlichannuoi.DAO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace quanlichannuoi
{
    public partial class BaoCaoCTNuocSachTheoBĐ : UserControl
    {
        public BaoCaoCTNuocSachTheoBĐ()
        {
            InitializeComponent();
            LoadCongTrinh();
        }
        private void LoadCongTrinh()
        {
            // Kết nối cơ sở dữ liệu để lấy danh sách công trình
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT MaCongTrinh, TenCongTrinh FROM CongTrinhNuocSach2";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable data = new DataTable();
                adapter.Fill(data);

                clbCongTrinh.DataSource = data;
                clbCongTrinh.DisplayMember = "TenCongTrinh";
                clbCongTrinh.ValueMember = "MaCongTrinh";
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {
            // Lấy danh sách các công trình được chọn
            List<int> dsCongTrinh = new List<int>();
            foreach (DataRowView item in clbCongTrinh.CheckedItems)
            {
                dsCongTrinh.Add((int)item["MaCongTrinh"]);
            }

            if (dsCongTrinh.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một công trình.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy khoảng thời gian từ các điều khiển DateTimePicker
            DateTime tuNgay = dtpTuNgay.Value;
            DateTime denNgay = dtpDenNgay.Value;

            // Tạo bảng dữ liệu tổng hợp từ nhiều công trình
            DataTable data = new DataTable();
            foreach (int maCongTrinh in dsCongTrinh)
            {
                // Gọi hàm GetSanLuongData cho từng công trình
                DataTable congTrinhData = GetSanLuongData(maCongTrinh, tuNgay, denNgay);
                data.Merge(congTrinhData); // Gộp dữ liệu vào bảng tổng
            }

            if (data.Rows.Count > 0)
            {
                DisplayChart(data);
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Lấy danh sách các công trình được chọn
            List<int> dsCongTrinh = new List<int>();
            foreach (DataRowView item in clbCongTrinh.CheckedItems)
            {
                dsCongTrinh.Add((int)item["MaCongTrinh"]);
            }

            if (dsCongTrinh.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một công trình.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime tuNgay = dtpTuNgay.Value;
            DateTime denNgay = dtpDenNgay.Value;

            // Xóa dữ liệu cũ trên biểu đồ
            chartSoSanh.Series.Clear();

            // Lặp qua danh sách các công trình và lấy dữ liệu
            foreach (int maCongTrinh in dsCongTrinh)
            {
                // Gọi phương thức GetSanLuongData với đúng tham số
                DataTable data = GetSanLuongData(maCongTrinh, tuNgay, denNgay);

                if (data.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu trong khoảng thời gian này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Tạo series cho từng công trình
                string tenCongTrinh = clbCongTrinh.Items.Cast<DataRowView>()
                                        .Where(x => (int)x["MaCongTrinh"] == maCongTrinh) // Lọc theo MaCongTrinh
                                        .Select(x => x["TenCongTrinh"].ToString()) // Chọn tên công trình
                                        .FirstOrDefault(); // Lấy giá trị đầu tiên hoặc null nếu không có

                Series series = new Series(tenCongTrinh)
                {
                    ChartType = SeriesChartType.Column // Hoặc Đường, Tùy loại biểu đồ
                };

                // Thêm dữ liệu vào biểu đồ
                foreach (DataRow row in data.Rows)
                {
                    DateTime thangBatDau = Convert.ToDateTime(row["ThangBatDau"]);
                    decimal sanLuong = Convert.ToDecimal(row["SanLuong"]);
                    series.Points.AddXY(thangBatDau.ToString("yyyy-MM"), sanLuong);
                }

                // Thêm series vào biểu đồ
                chartSoSanh.Series.Add(series);
            }

            // Cấu hình trục biểu đồ
            chartSoSanh.ChartAreas[0].AxisX.Title = "Tháng";
            chartSoSanh.ChartAreas[0].AxisY.Title = "Sản lượng (m³)";
            chartSoSanh.Titles.Clear();
            chartSoSanh.Titles.Add("Biểu đồ so sánh năng suất công trình nước sạch");
        }


        private DataTable GetSanLuongData(int maCongTrinh, DateTime tuNgay, DateTime denNgay)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = @"
                SELECT 
                ct.TenCongTrinh,
                hd.ThangBatDau,
                hd.ThangKetThuc,
                hd.CongSuat
                FROM HoatDongCongTrinhNuocSach hd
                JOIN CongTrinhNuocSach2 ct ON hd.MaCongTrinh = ct.MaCongTrinh
                WHERE hd.MaCongTrinh = @MaCongTrinh
                AND hd.ThangBatDau <= @DenNgay 
                AND hd.ThangKetThuc >= @TuNgay
                ORDER BY hd.ThangBatDau";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaCongTrinh", maCongTrinh);
                cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
                cmd.Parameters.AddWithValue("@DenNgay", denNgay);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable data = new DataTable();
                adapter.Fill(data);

                // Thêm cột SanLuong nếu chưa tồn tại
                if (!data.Columns.Contains("SanLuong"))
                {
                    data.Columns.Add("SanLuong", typeof(double)); // Thêm cột SanLuong với kiểu double
                }

                // Tính sản lượng
                foreach (DataRow row in data.Rows)
                {
                    DateTime thangBatDau = (DateTime)row["ThangBatDau"];
                    DateTime thangKetThuc = (DateTime)row["ThangKetThuc"];
                    int congSuat = (int)row["CongSuat"];

                    // Giới hạn khoảng thời gian trong phạm vi người dùng chọn
                    DateTime start = thangBatDau < tuNgay ? tuNgay : thangBatDau;
                    DateTime end = thangKetThuc > denNgay ? denNgay : thangKetThuc;

                    // Tính số tháng giữa start và end
                    int soThang = ((end.Year - start.Year) * 12) + end.Month - start.Month + 1;
                    row["SanLuong"] = soThang * congSuat; // Cập nhật lại giá trị sản lượng
                }

                return data;
            }
        }

        private void DisplayChart(DataTable data)
        {
            try
            {
                // Kiểm tra dữ liệu
                if (data == null || data.Rows.Count == 0) // Kiểm tra Rows.Count thay vì data.Count
                {
                    MessageBox.Show("Không có dữ liệu để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Xóa dữ liệu cũ
                chartSoSanh.Series.Clear();

                // Thêm series mới
                var series = new Series
                {
                    Name = "Dữ liệu",
                    ChartType = SeriesChartType.Line // Hoặc các loại biểu đồ khác như Bar, Pie, etc.
                };

                chartSoSanh.Series.Add(series);

                // Gán dữ liệu
                foreach (DataRow row in data.Rows) // Duyệt qua các hàng (DataRow)
                {
                    DateTime thangBatDau = Convert.ToDateTime(row["ThangBatDau"]); // Giả sử bạn có trường "ThangBatDau"
                    double sanLuong = Convert.ToDouble(row["SanLuong"]); // Giả sử bạn có trường "SanLuong"

                    // Thêm điểm vào series
                    series.Points.AddXY(thangBatDau.ToString("yyyy-MM"), sanLuong);
                }

                // Cấu hình trục
                chartSoSanh.ChartAreas[0].AxisX.Interval = 1; // Khoảng cách giữa các điểm trên trục X
                chartSoSanh.ChartAreas[0].AxisY.Interval = 10; // Khoảng cách giữa các điểm trên trục Y

                // Đặt tự động nếu cần
                chartSoSanh.ChartAreas[0].AxisX.Interval = double.NaN; // Auto
                chartSoSanh.ChartAreas[0].AxisY.Interval = double.NaN; // Auto
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void BaoCaoSoSanhSanLuong_Load(object sender, EventArgs e)
        {

        }

        private void dtpTuNgay_ValueChanged(object sender, EventArgs e)
        {

        }

        private void UpdateThoiGianHoatDong(int maCongTrinh, DateTime thangBatDau, DateTime thangKetThuc)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"
            UPDATE HoatDongCongTrinhNuocSach
            SET ThangBatDau = @ThangBatDau,
                ThangKetThuc = @ThangKetThuc
            WHERE MaCongTrinh = @MaCongTrinh";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ThangBatDau", thangBatDau);
                cmd.Parameters.AddWithValue("@ThangKetThuc", thangKetThuc);
                cmd.Parameters.AddWithValue("@MaCongTrinh", maCongTrinh);

                cmd.ExecuteNonQuery();
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            // Kiểm tra công trình được chọn
            if (clbCongTrinh.CheckedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một công trình để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy thời gian từ DateTimePicker
            DateTime thangBatDau = dtpTuNgay.Value;
            DateTime thangKetThuc = dtpDenNgay.Value;

            if (thangBatDau > thangKetThuc)
            {
                MessageBox.Show("Tháng bắt đầu không được lớn hơn tháng kết thúc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Cập nhật từng công trình được chọn
            foreach (DataRowView item in clbCongTrinh.CheckedItems)
            {
                int maCongTrinh = (int)item["MaCongTrinh"];
                UpdateThoiGianHoatDong(maCongTrinh, thangBatDau, thangKetThuc);
            }

            MessageBox.Show("Cập nhật thời gian thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Làm mới dữ liệu biểu đồ nếu cần thiết
            chart1_Click(null, null);
        }

        private void clbCongTrinh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
