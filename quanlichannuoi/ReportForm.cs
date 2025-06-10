using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices.Diagnostics.Internal;
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
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT NguoiDungID, HoTen, Email, TrangThai FROM NguoiDung \r\n ";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Hiển thị dữ liệu trong DataGridView
                    ReportDataSource reportDataSource = new ReportDataSource("DataSet1", dataTable);
                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(reportDataSource);

                    // Đảm bảo ReportViewer sử dụng báo cáo đã thiết kế
                    //reportViewer1.LocalReport.ReportPath = "UserReport.rdlc";

                    // Cập nhật báo cáo
                    reportViewer1.RefreshReport();
                }
            }

        }

        private void ReportForm_Load(object sender, EventArgs e)
        {

            
            this.reportViewer1.RefreshReport();
            
        }
    }
}
