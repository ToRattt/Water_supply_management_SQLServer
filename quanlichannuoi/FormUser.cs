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
    public partial class FormUser : Form
    {
        public FormUser()
        {
            InitializeComponent();
        }

        private void btnInforManager_Click(object sender, EventArgs e)
        {
            UserManagerForm userManagerForm = new UserManagerForm();
            this.Hide();

            userManagerForm.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HuyenForm huyenForm = new HuyenForm();
            this.Hide();
            huyenForm.ShowDialog();
            this.Show();
        }
    }
}
