using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlichannuoi.Admin
{
    public partial class Menu : UserControl
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            addxa1.Visible = false;
            showXa1.Visible = false;
            addhuyen1.Visible = false;
            showhuyen1.Visible = false;
            showquyhoac1.Visible = false;
            bdquyhoach1.Visible = false;
       
        }

        private void thêmXãToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addxa1.Visible = true;
            addxa1.BringToFront();
        }

        private void hiểnThịDanhSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showXa1.Visible = true;
            showXa1.BringToFront();
        }

        private void thêmHuyệnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addhuyen1.Visible = true;
            addhuyen1.BringToFront();
        }

        private void hiểnThịDanhSáchToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            showhuyen1.Visible = true;
            showhuyen1.BringToFront();
        }

        

        private void bảnĐồToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bdquyhoach1.Visible=true;
            bdquyhoach1.BringToFront();
        }

        private void hiểnThịDanhSáchToolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            showquyhoac1.Visible = true;
            showquyhoac1.BringToFront();
        }

        private void bdquyhoach1_Load(object sender, EventArgs e)
        {

        }
    }
}
