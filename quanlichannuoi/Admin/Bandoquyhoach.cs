using GMap.NET.WindowsForms;
using GMap.NET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET.WindowsForms.Markers;
using quanlichannuoi.DAO;
using System.Data.SqlClient;

namespace quanlichannuoi.Admin
{
    public partial class Bandoquyhoach : UserControl
    {
        public Bandoquyhoach()
        {
            InitializeComponent();
        }

        private void Bandoquyhoach_Load(object sender, EventArgs e)
        {
            LoadMap();
            LoadQuyHoachData();
        }
        private void LoadMap()
        {
            gMapControl1.MapProvider = GMap.NET.MapProviders.GMapProviders.GoogleMap;
            gMapControl1.ShowCenter = false;
            gMapControl1.MapProvider = GMap.NET.MapProviders.BingMapProvider.Instance;
            gMapControl1.Position = new GMap.NET.PointLatLng(20.9716, 105.8545); // Tọa độ mặc định
            gMapControl1.MinZoom = 5;
            gMapControl1.MaxZoom = 20;
            gMapControl1.Zoom = 10;

            GMaps.Instance.Mode = AccessMode.ServerAndCache;


            // Thêm marker
            GMapOverlay markers = new GMapOverlay("markers");
            markers.Markers.Add(new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
                new GMap.NET.PointLatLng(20.9716, 105.8545),
                GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red));
            gMapControl1.Overlays.Add(markers);
        }

        private void LoadQuyHoachData()
        {

            string query = "SELECT TenQuyHoach, Latitude, Longitude, TrangThai FROM QuyHoachNuocSach2";

            using (SqlConnection conn = Database.GetConnection())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        GMapOverlay markersOverlay = new GMapOverlay("markers");

                        while (reader.Read())
                        {
                            string tenQuyHoach = reader["TenQuyHoach"].ToString();
                            float latitude = float.Parse(reader["Latitude"].ToString());
                            float longitude = float.Parse(reader["Longitude"].ToString());
                            string trangThai = reader["TrangThai"].ToString();

                            // Tạo marker với màu dựa trên trạng thái
                            GMarkerGoogleType markerType = trangThai == "Hoạt động"
                                ? GMarkerGoogleType.green
                                : GMarkerGoogleType.red;

                            GMapMarker marker = new GMarkerGoogle(
                                new PointLatLng(latitude, longitude), markerType)
                            {
                                ToolTipText = $"{tenQuyHoach}\nTrạng thái: {trangThai}",
                                ToolTipMode = MarkerTooltipMode.OnMouseOver
                            };

                            markersOverlay.Markers.Add(marker);
                        }

                        gMapControl1.Overlays.Add(markersOverlay);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                }
            }


        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
                gMapControl1.Position = new GMap.NET.PointLatLng(Convert.ToDouble(latitude.Text), Convert.ToDouble(longitude.Text));

                //gMapControl2.Zoom = 5;
                gMapControl1.Update();
                gMapControl1.Refresh();
            
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            var markersOverlay = new GMap.NET.WindowsForms.GMapOverlay("marker1");

            //Marker far away in Quebec, Canada just to check my point in discussion    
            var marker = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
              new PointLatLng(Convert.ToDouble(latitude.Text), Convert.ToDouble(longitude.Text)),
              GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red_small);

            markersOverlay.Markers.Add(marker);
            gMapControl1.Overlays.Add(markersOverlay);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            gMapControl1.DragButton = MouseButtons.Left;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = txttencongtrinh.Text;
            if (search == "")
            {
                MessageBox.Show("Vui lòng nhập tên công trình");
            }
            else
            {

                string query = @"SELECT TenQuyHoach, TrangThai, Latitude, Longitude 
                     FROM QuyHoachNuocSach2 
                     WHERE TenQuyHoach = @Name";

                using (SqlConnection conn = Database.GetConnection())
                {
                    try
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            // Thêm tham số tìm kiếm
                            cmd.Parameters.AddWithValue("@Name", search);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {


                                while (reader.Read())
                                {
                                    string TenCongTrinh = reader["TenQuyHoach"].ToString();
                                    
                                    float latitude = float.Parse(reader["Latitude"].ToString());
                                    float longitude = float.Parse(reader["Longitude"].ToString());
                                    string TrangThai = reader["TrangThai"].ToString();

                                    // Cập nhật vị trí bản đồ
                                    gMapControl1.Position = new PointLatLng(Convert.ToDouble(latitude), Convert.ToDouble(longitude));
                                    gMapControl1.Zoom = 20;
                                    gMapControl1.Update();
                                    gMapControl1.Refresh();
                                }

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            gMapControl1.ReloadMap();
        }

        private void gMapControl1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {


                PointLatLng point = gMapControl1.FromLocalToLatLng(e.X, e.Y);

                double latitude = point.Lat;
                double longitude = point.Lng;

                MessageBox.Show($"Tọa độ: \nLatitude: {latitude}\nLongitude: {longitude}",
                    "Tọa Độ GPS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
