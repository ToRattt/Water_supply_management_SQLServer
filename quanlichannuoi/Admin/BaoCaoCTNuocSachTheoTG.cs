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
    public partial class BaoCaoCTNuocSachTheoTG : UserControl
    {
        public BaoCaoCTNuocSachTheoTG()
        {
            InitializeComponent();
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            // Lấy khoảng thời gian từ DateTimePicker
            DateTime startDate = dtpStartDate.Value.Date;
            DateTime endDate = dtpEndDate.Value.Date;

            if (startDate > endDate)
            {
                MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Kết nối với cơ sở dữ liệu
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();

                    // Truy vấn báo cáo
                    string query = @"
                        SELECT 
                            ctns.MaCongTrinh, 
                            ctns.TenCongTrinh, 
                            ctns.ViTri, 
                            ctns.CongSuat, 
                            ctns.TrangThai, 
                            ctns.NgayLapDat
                        FROM CongTrinhNuocSach2 AS ctns
                        WHERE ctns.NgayLapDat BETWEEN @StartDate AND @EndDate
                        ORDER BY ctns.NgayLapDat ASC";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Đổ dữ liệu vào DataGridView
                    dgvReport.DataSource = dt;

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Không có dữ liệu trong khoảng thời gian này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo báo cáo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BaoCaoThangCTNuocSach_Load(object sender, EventArgs e)
        {

        }

        private void dgvReport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
