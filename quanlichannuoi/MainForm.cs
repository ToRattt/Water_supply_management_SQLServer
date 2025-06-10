using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace quanlichannuoi
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnInforManager_Click(object sender, EventArgs e)
        {
            InforManagerForm frm = new InforManagerForm();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DistrictForm frm = new DistrictForm();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            VillageForm villageForm = new VillageForm();
            this.Hide();
            villageForm.ShowDialog();
            this.Show();
        }

        private void btnHistoryLogin_Click(object sender, EventArgs e)
        {
            HistoricAccess historicAccess = new HistoricAccess();
            this.Hide();
            historicAccess.ShowDialog();
            this.Show();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            ReportForm frm = new ReportForm();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void btnManagerQH_Click(object sender, EventArgs e)
        {
            
            MenuQLQHWater menuQLQHWater = new MenuQLQHWater();
            this.Hide();
            menuQLQHWater.ShowDialog();
            this.Show();
            
        }

        private void btnFreshWater_Click(object sender, EventArgs e)
        {
            MenuFreshWaterForm frm = new MenuFreshWaterForm();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }
    }
}
