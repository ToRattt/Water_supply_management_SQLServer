using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;
namespace quanlichannuoi.Admin
{
    public partial class Manual : UserControl
    {
        public Manual()
        {
            InitializeComponent();
        }

        private void Manual_Load(object sender, EventArgs e)
        {
            
            webView21.Source = new Uri("https://drive.google.com/drive/folders/1jULX9xbm9HHw21afjIjwkq_ckV-8hyGX");  // Đặt nguồn trang web
        }
        

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

     
        private void webView21_Click(object sender, EventArgs e)
        {

        }
    }
}
