namespace quanlichannuoi
{
    partial class CongTrinhNuocSach
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.nguoiDungTableAdapter1 = new quanlichannuoi.QuanLyNongThonDataSetTableAdapters.NguoiDungTableAdapter();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.grpNuocSachDetails = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpNgayLapDat = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtViDo = new System.Windows.Forms.TextBox();
            this.txtKinhDo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nudCongSuat = new System.Windows.Forms.NumericUpDown();
            this.txtViTri = new System.Windows.Forms.TextBox();
            this.txtTenCongTrinh = new System.Windows.Forms.TextBox();
            this.dgvNuocSach = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.grpNuocSachDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCongSuat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNuocSach)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1119, 41);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "QUẢN LÍ NƯỚC SẠCH VÀ VỆ SINH MÔI TRƯỜNG";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Controls.Add(this.button2);
            this.flowLayoutPanel1.Controls.Add(this.button3);
            this.flowLayoutPanel1.Controls.Add(this.button4);
            this.flowLayoutPanel1.Controls.Add(this.button5);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 567);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1119, 110);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 87);
            this.button1.TabIndex = 0;
            this.button1.Text = "Thêm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(163, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(153, 87);
            this.button2.TabIndex = 1;
            this.button2.Text = "Sửa Công Trình";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(322, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(156, 87);
            this.button3.TabIndex = 2;
            this.button3.Text = "Xóa";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(484, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(165, 87);
            this.button4.TabIndex = 5;
            this.button4.Text = "Xem chi tiết";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(655, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(135, 87);
            this.button5.TabIndex = 6;
            this.button5.Text = "Báo cáo";
            this.button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // nguoiDungTableAdapter1
            // 
            this.nguoiDungTableAdapter1.ClearBeforeFill = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 41);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1119, 526);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.grpNuocSachDetails);
            this.tabPage1.Controls.Add(this.dgvNuocSach);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1111, 497);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Công trình nước sạch";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // grpNuocSachDetails
            // 
            this.grpNuocSachDetails.Controls.Add(this.label7);
            this.grpNuocSachDetails.Controls.Add(this.dtpNgayLapDat);
            this.grpNuocSachDetails.Controls.Add(this.label6);
            this.grpNuocSachDetails.Controls.Add(this.cboTrangThai);
            this.grpNuocSachDetails.Controls.Add(this.label5);
            this.grpNuocSachDetails.Controls.Add(this.label4);
            this.grpNuocSachDetails.Controls.Add(this.txtViDo);
            this.grpNuocSachDetails.Controls.Add(this.txtKinhDo);
            this.grpNuocSachDetails.Controls.Add(this.label3);
            this.grpNuocSachDetails.Controls.Add(this.label2);
            this.grpNuocSachDetails.Controls.Add(this.label1);
            this.grpNuocSachDetails.Controls.Add(this.nudCongSuat);
            this.grpNuocSachDetails.Controls.Add(this.txtViTri);
            this.grpNuocSachDetails.Controls.Add(this.txtTenCongTrinh);
            this.grpNuocSachDetails.Location = new System.Drawing.Point(3, 367);
            this.grpNuocSachDetails.Name = "grpNuocSachDetails";
            this.grpNuocSachDetails.Size = new System.Drawing.Size(1105, 124);
            this.grpNuocSachDetails.TabIndex = 1;
            this.grpNuocSachDetails.TabStop = false;
            this.grpNuocSachDetails.Text = "Thông tin chi tiết";
            this.grpNuocSachDetails.Enter += new System.EventHandler(this.grpNuocSachDetails_Enter);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(546, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "Ngày lắp đặt";
            // 
            // dtpNgayLapDat
            // 
            this.dtpNgayLapDat.Location = new System.Drawing.Point(639, 68);
            this.dtpNgayLapDat.Name = "dtpNgayLapDat";
            this.dtpNgayLapDat.Size = new System.Drawing.Size(134, 22);
            this.dtpNgayLapDat.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(546, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Trạng thái";
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.FormattingEnabled = true;
            this.cboTrangThai.Location = new System.Drawing.Point(639, 27);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(134, 24);
            this.cboTrangThai.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(295, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Vĩ độ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(295, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Kinh độ";
            // 
            // txtViDo
            // 
            this.txtViDo.Location = new System.Drawing.Point(367, 64);
            this.txtViDo.Multiline = true;
            this.txtViDo.Name = "txtViDo";
            this.txtViDo.Size = new System.Drawing.Size(125, 26);
            this.txtViDo.TabIndex = 7;
            // 
            // txtKinhDo
            // 
            this.txtKinhDo.Location = new System.Drawing.Point(367, 24);
            this.txtKinhDo.Multiline = true;
            this.txtKinhDo.Name = "txtKinhDo";
            this.txtKinhDo.Size = new System.Drawing.Size(125, 26);
            this.txtKinhDo.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 32);
            this.label3.TabIndex = 5;
            this.label3.Text = "Công suất (m3/tháng)\r\n\r\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Vị trí";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tên công trình\r\n";
            // 
            // nudCongSuat
            // 
            this.nudCongSuat.Location = new System.Drawing.Point(145, 96);
            this.nudCongSuat.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudCongSuat.Name = "nudCongSuat";
            this.nudCongSuat.Size = new System.Drawing.Size(125, 22);
            this.nudCongSuat.TabIndex = 2;
            // 
            // txtViTri
            // 
            this.txtViTri.Location = new System.Drawing.Point(130, 64);
            this.txtViTri.Multiline = true;
            this.txtViTri.Name = "txtViTri";
            this.txtViTri.Size = new System.Drawing.Size(125, 23);
            this.txtViTri.TabIndex = 1;
            // 
            // txtTenCongTrinh
            // 
            this.txtTenCongTrinh.Location = new System.Drawing.Point(130, 24);
            this.txtTenCongTrinh.Multiline = true;
            this.txtTenCongTrinh.Name = "txtTenCongTrinh";
            this.txtTenCongTrinh.Size = new System.Drawing.Size(125, 27);
            this.txtTenCongTrinh.TabIndex = 0;
            // 
            // dgvNuocSach
            // 
            this.dgvNuocSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNuocSach.Location = new System.Drawing.Point(0, 6);
            this.dgvNuocSach.Name = "dgvNuocSach";
            this.dgvNuocSach.RowHeadersWidth = 51;
            this.dgvNuocSach.RowTemplate.Height = 24;
            this.dgvNuocSach.Size = new System.Drawing.Size(1105, 355);
            this.dgvNuocSach.TabIndex = 0;
            this.dgvNuocSach.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNuocSach_CellContentClick);
            // 
            // CongTrinhNuocSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.textBox1);
            this.Name = "CongTrinhNuocSach";
            this.Size = new System.Drawing.Size(1119, 677);
            this.Load += new System.EventHandler(this.QLNuocSachVaVSMoiTruong_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.grpNuocSachDetails.ResumeLayout(false);
            this.grpNuocSachDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCongSuat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNuocSach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private QuanLyNongThonDataSetTableAdapters.NguoiDungTableAdapter nguoiDungTableAdapter1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox grpNuocSachDetails;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpNgayLapDat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtViDo;
        private System.Windows.Forms.TextBox txtKinhDo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudCongSuat;
        private System.Windows.Forms.TextBox txtViTri;
        private System.Windows.Forms.TextBox txtTenCongTrinh;
        private System.Windows.Forms.DataGridView dgvNuocSach;
    }
}