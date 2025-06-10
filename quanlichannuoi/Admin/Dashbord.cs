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
    public partial class Dashbord : UserControl
    {
        public Dashbord()
        {
            InitializeComponent();
        }

        private void Dashbord_Load(object sender, EventArgs e)
        {
            themxa1.Visible = false;
            hienThiXa1.Visible = false;
            hienThiHuyen1.Visible = false;
            themHuyen1.Visible = false;
            lichsutruycap1.Visible = false;
            hienThiCongTrinh1.Visible = false;
            themquyhoach1.Visible = false;
            bandoquyhoach1.Visible = false;
            baocao1.Visible = false;
            themcongtrinhcapnuoc1.Visible = false;
            hienthicongtrinhcapnuoc1.Visible=false;
            bandocongtrinhnuocsach1.Visible=false;
            cosochebiensanphamchannuoi2.Visible=false;
            baoCaoCTNuocSachTheoTG1.Visible = false;
            baoCaoCTNuocSachTheoCT1.Visible =false;
            baoCaoCTNuocSachTheoCS1.Visible = false;
            congTrinhNuocSach1.Visible = false;
            baoCaoCTNuocSachTheoBĐ1.Visible = false;
            quanlicosochannuoi_guiduc_1.Visible = false;
            btnRefresh1.Visible = false;
            quanlifile_guiduc_1.Visible = false;
            hienthiquanlifile1.Visible = false;
            quanlivanban_guiduc_1.Visible = false;
            hienthiquanlivanban1.Visible = false;
            quanlynhole_guiduc_1.Visible=false;
            hienthiquanlynhole1.Visible = false;
            quanlyketquachannuoinhole_guiduc_1.Visible = false;
            tracuucosochannuoi_guiduc_1.Visible = false;
            tracuuvanban_guiduc_1.Visible = false;
            hienthicosochebien1.Visible = false;
            dieukienchannuoi1.Visible = false;
            hienthidieukien1.Visible = false;
            giaychungnhan1.Visible = false;
            hienthigiaychungnhan1.Visible=false;
            tochucchungnhan1.Visible = false;
            hienthitochucchungnhan1.Visible = false;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cấpXãToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void thêmXãToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themxa1.Visible = true;
            themxa1.BringToFront();
        }

        private void hiểnThịDanhSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hienThiXa1.Visible = true;
            hienThiXa1.BringToFront();
        }

        private void hienThiXa1_Load(object sender, EventArgs e)
        {

        }

        private void hiểnThịDanhSáchToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            hienThiHuyen1.Visible = true;
            hienThiHuyen1.BringToFront();
        }

        private void thêmHuyệnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themHuyen1.Visible=true;
            themHuyen1.BringToFront();
        }

        private void lịchSửTruyCậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lichsutruycap1.Visible = true;
            lichsutruycap1 .BringToFront();
        }

        private void hiểnThịDanhSáchToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            hienThiCongTrinh1.Visible = true;
            hienThiCongTrinh1 .BringToFront();
        }

        private void thêmQuyHoạchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themquyhoach1.Visible = true;
            themquyhoach1.BringToFront();
        }

        

        private void bảnĐồToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            bandoquyhoach1.Visible = true;
            bandoquyhoach1.BringToFront();
        }

        private void ngườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baocao1.Visible = true;
            baocao1 .BringToFront();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void thêmCôngTrìnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themcongtrinhcapnuoc1 .Visible = true;
            themcongtrinhcapnuoc1.BringToFront();
        }

        private void hiểnThịDanhSáchToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            hienthicongtrinhcapnuoc1.Visible = true;
            hienthicongtrinhcapnuoc1.BringToFront();
        }

        private void bảnĐồToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bandocongtrinhnuocsach1 .Visible = true;
            bandocongtrinhnuocsach1.BringToFront();
        }

        private void bandocongtrinhnuocsach1_Load(object sender, EventArgs e)
        {

        }

        private void thêmThôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void quảnLíQuyHoạchNướcSạchToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void thêmThôngTinToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cosochebiensanphamchannuoi2.Visible = true;
            cosochebiensanphamchannuoi2 .BringToFront();
        }

        private void qUảnLíVănBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void quảnLíVănBảnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void quảnLíFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void traCứuVănBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void quảnLíDanhMụcTổChứcToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void traCứuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void kếtQuảThốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void traCứuKếtQuảToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void quảnLíBáoCáoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baoCaoCTNuocSachTheoCT1.Visible = true;
            baoCaoCTNuocSachTheoCT1.BringToFront();
        }

        private void soSánhCôngTrìnhNướcSạchDướiDạngBiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baoCaoCTNuocSachTheoBĐ1.Visible = true;
            baoCaoCTNuocSachTheoBĐ1.BringToFront();
        }

        private void báoCáoCôngTrìnhNướcSạchTheoThờiGianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baoCaoCTNuocSachTheoTG1.Visible = true;
            baoCaoCTNuocSachTheoTG1.BringToFront();
        }

        private void quảnLíBáoCáoChỉSốNướcSạchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baoCaoCTNuocSachTheoCS1.Visible = true;
            baoCaoCTNuocSachTheoCS1 .BringToFront();
        }

        private void côngTrìnhNướcSạchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            congTrinhNuocSach1.Visible = true;
            congTrinhNuocSach1.BringToFront();
        }

        private void thêmThôngTinToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            quanlicosochannuoi_guiduc_1.Visible = true;
            quanlicosochannuoi_guiduc_1 .BringToFront();
        }

        private void hiểnThịToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            btnRefresh1.Visible = true;
            btnRefresh1.BringToFront();
        }

        private void thêmThôngTinToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            quanlifile_guiduc_1.Visible=true;
            quanlifile_guiduc_1.BringToFront();
        }

        private void hiểnThịToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            hienthiquanlifile1.Visible=true;
            hienthiquanlifile1 .BringToFront();
        }

        private void thêmThôngTinToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            quanlivanban_guiduc_1.Visible = true;
            quanlivanban_guiduc_1.BringToFront();
        }

        private void hiểnThịToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            hienthiquanlivanban1 .Visible=true;
            hienthiquanlivanban1.BringToFront();
        }

        private void thêmThôngTinToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            quanlynhole_guiduc_1.Visible = true;
            quanlynhole_guiduc_1 .BringToFront();
        }

        private void hiểnThịToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            hienthiquanlynhole1 .Visible=true;
            hienthiquanlynhole1.BringToFront();
        }

        private void kếtQuảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            quanlyketquachannuoinhole_guiduc_1.Visible = true;
            quanlyketquachannuoinhole_guiduc_1.BringToFront();
        }

        private void cơSởChănNuôiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tracuucosochannuoi_guiduc_1.Visible = true;
            tracuucosochannuoi_guiduc_1.BringToFront();
        }

        private void vănBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tracuuvanban_guiduc_1.Visible = true;
            tracuuvanban_guiduc_1.BringToFront();

        }

        private void hiểnThịToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hienthicosochebien1 .Visible = true;    
            hienthicosochebien1.BringToFront();
        }

        private void hiểnThịToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            hienthidieukien1.Visible = true;
            hienthidieukien1 .BringToFront();
        }

        private void thêmThôngTinToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            dieukienchannuoi1 .Visible = true;
            dieukienchannuoi1.BringToFront ();
        }

        private void thêmThôngTinToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            giaychungnhan1 .Visible = true;
            giaychungnhan1.BringToFront ();
        }

        private void giấyChứngNhậnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void hiểnThịToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            hienthigiaychungnhan1.Visible = true;
            hienthigiaychungnhan1.BringToFront () ;
        }

        private void thêmThôngTinToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            tochucchungnhan1.Visible=true;
            tochucchungnhan1.BringToFront() ;
        }

        private void hiểnThịToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            hienthitochucchungnhan1.Visible = true;
            hienthitochucchungnhan1.BringToFront();
        }
    }
}
