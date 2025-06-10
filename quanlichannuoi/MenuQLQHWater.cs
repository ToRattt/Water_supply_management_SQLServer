using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlichannuoi
{
    public partial class MenuQLQHWater : Form
    {
        public MenuQLQHWater()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QuanliqhForm q = new QuanliqhForm();
            this.Hide();
            q.ShowDialog();
            this.Close();
        }

        private void btnManagerReport_Click(object sender, EventArgs e)
        {
            ManagerReportForm q = new ManagerReportForm();
            this.Hide();
            q.ShowDialog();
            this.Show();
        }

        private void btnMap_Click(object sender, EventArgs e)
        {
            Watermap watermap = new Watermap();
            this.Hide();
            watermap.ShowDialog();
            this.Show();
        }
    }
}
