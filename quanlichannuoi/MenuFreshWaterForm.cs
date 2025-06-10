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
    public partial class MenuFreshWaterForm : Form
    {
        public MenuFreshWaterForm()
        {
            InitializeComponent();
        }

        private void btnManagerFresh_Click(object sender, EventArgs e)
        {
            FreshWater freshWater = new FreshWater();
            this.Hide();
            freshWater.ShowDialog();
            this.Show();
        }

        private void btnMap_Click(object sender, EventArgs e)
        {
            FreshWatermap freshWatermap = new FreshWatermap();
            this.Hide();
            freshWatermap.ShowDialog();
            this.Show();
        }
    }
}
