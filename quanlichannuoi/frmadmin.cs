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
    public partial class frmadmin : Form
    {
        public frmadmin()
        {
            InitializeComponent();
        }

        public frmadmin(string user)
        {

            InitializeComponent();
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT HoTen FROM  dbo.NguoiDung WHERE Email = @Email";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", user);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string ten = reader["HoTen"].ToString();
                            labelUserName.Text = ten;
                        }
                    }

                }

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            viewUser1.Visible = true;
            viewUser1.BringToFront();
        }

        private void labelUserName_Click(object sender, EventArgs e)
        {
          
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnDashbord_Click(object sender, EventArgs e)
        {
            dashbord1.Visible = true;
            dashbord1.BringToFront();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void manual1_Load(object sender, EventArgs e)
        {

        }

        private void btnManual_Click(object sender, EventArgs e)
        {
            manual1.Visible = true;
            manual1.BringToFront();
        }

        private void frmadmin_Load(object sender, EventArgs e)
        {
            manual1.Visible=false;
            addUser1.Visible=false;
            viewUser1.Visible=false;
            dashbord1.Visible=false;
            
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            addUser1.Visible = true;
            addUser1.BringToFront();
        }

        private void addUser1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
