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
using GMap.NET.MapProviders;

using GMap.NET.WindowsForms.Markers;
using quanlichannuoi.DAO;
using System.Data.SqlClient;
namespace quanlichannuoi
{
    public partial class FreshWatermap : Form
    {
        public FreshWatermap()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void FreshWatermap_Load(object sender, EventArgs e)
        {
            LoadMap();
            LoadQuyHoachData();
        }


        private void LoadQuyHoachData()
        {

            string query = "SELECT TenCongTrinh, LoaiCongTrinh, XaID, TrangThai, Latitude, Longitude FROM CongTrinhNuocSach";

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
                            string tenQuyHoach = reader["TenCongTrinh"].ToString();
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

        private void button2_Click(object sender, EventArgs e)
        {
            gMapControl1.Zoom = Convert.ToDouble(zoom_level.Text);
            gMapControl1.Update();
            gMapControl1.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            gMapControl1.DragButton = MouseButtons.Left;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchName = txtSearch.Text;
            string query = "SELECT TenCongTrinh, LoaiCongTrinh, XaID, TrangThai, Latitude, Longitude FROM CongTrinhNuocSach WHERE TenCongTrinh LIKE @Name";

            using (SqlConnection conn = Database.GetConnection())
            {
                try
                {
                    conn.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                    {
                        // Thêm tham số tìm kiếm
                        adapter.SelectCommand.Parameters.AddWithValue("@Name", searchName);


                    }
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        GMapOverlay markersOverlay = new GMapOverlay("markers");

                        while (reader.Read())
                        {
                            string TenCongTrinh = reader["TenCongTrinh"].ToString();
                            string loaicongtrinh = reader["LoaiCongTrinh"].ToString();
                            float latitude = float.Parse(reader["Latitude"].ToString());
                            float longitude = float.Parse(reader["Longitude"].ToString());
                            string trangThai = reader["TrangThai"].ToString();

                            gMapControl1.Position = new GMap.NET.PointLatLng(Convert.ToDouble(latitude), Convert.ToDouble(longitude));

                            //gMapControl2.Zoom = 5;
                            gMapControl1.Update();
                            gMapControl1.Refresh();

                        }
                    }
                }
                // Tạo marker với màu dựa trên trạng thái
                /*
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
                */
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                }
            
            }
        }
    }
}
