using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
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
    public partial class Watermap : Form
    {
        public Watermap()
        {
            InitializeComponent();
        }

        private void Watermap_Load(object sender, EventArgs e)
        {
            LoadMap();
            LoadQuyHoachData();
        }

        private void LoadMap()
        {
            gMapControl2.MapProvider = GMap.NET.MapProviders.GMapProviders.GoogleMap;
            gMapControl2.ShowCenter = false;
            gMapControl2.MapProvider = GMap.NET.MapProviders.BingMapProvider.Instance;
            gMapControl2.Position = new GMap.NET.PointLatLng(20.9716, 105.8545); // Tọa độ mặc định
            gMapControl2.MinZoom = 5;
            gMapControl2.MaxZoom = 20;
            gMapControl2.Zoom = 10;
            
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            

            // Thêm marker
            GMapOverlay markers = new GMapOverlay("markers");
            markers.Markers.Add(new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
                new GMap.NET.PointLatLng(20.9716, 105.8545),
                GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red));
            gMapControl2.Overlays.Add(markers);
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

                        gMapControl2.Overlays.Add(markersOverlay);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                }
            }


        }

        private void button1_Click(object sender, EventArgs e)

        {
              
            gMapControl2.Position = new GMap.NET.PointLatLng(Convert.ToDouble(latitude.Text), Convert.ToDouble(longitude.Text));
               
            //gMapControl2.Zoom = 5;
            gMapControl2.Update();
            gMapControl2.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gMapControl2.Zoom = Convert.ToDouble(zoom_level.Text);
            gMapControl2.Update();
            gMapControl2.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            gMapControl2.DragButton = MouseButtons.Left;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            gMapControl2.MouseClick += gMapControl2_MouseClick;
        }

        void gMapControl2_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("X:" + e.X.ToString() + " and Y:" + e.Y.ToString());
        }

        private void btnAddpst_Click(object sender, EventArgs e)
        {
            var markersOverlay = new GMap.NET.WindowsForms.GMapOverlay("marker1");

            //Marker far away in Quebec, Canada just to check my point in discussion    
            var marker = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
              new PointLatLng(Convert.ToDouble(latitude.Text), Convert.ToDouble(longitude.Text)),
              GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red_small);

            markersOverlay.Markers.Add(marker);
            gMapControl2.Overlays.Add(markersOverlay);
        }

        private void latitude_TextChanged(object sender, EventArgs e)
        {

        }
    }
}