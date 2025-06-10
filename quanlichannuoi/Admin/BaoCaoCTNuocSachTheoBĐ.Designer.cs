namespace quanlichannuoi
{
    partial class BaoCaoCTNuocSachTheoBĐ
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.btnHienThi_Click = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.clbCongTrinh = new System.Windows.Forms.CheckedListBox();
            this.chartSoSanh = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSoSanh)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCapNhat);
            this.groupBox1.Controls.Add(this.btnHienThi_Click);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpDenNgay);
            this.groupBox1.Controls.Add(this.dtpTuNgay);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 510);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1119, 167);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bảng điều khiển";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Location = new System.Drawing.Point(15, 52);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(160, 93);
            this.btnCapNhat.TabIndex = 8;
            this.btnCapNhat.Text = "Cập nhật thời gian";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // btnHienThi_Click
            // 
            this.btnHienThi_Click.Location = new System.Drawing.Point(230, 52);
            this.btnHienThi_Click.Name = "btnHienThi_Click";
            this.btnHienThi_Click.Size = new System.Drawing.Size(160, 93);
            this.btnHienThi_Click.TabIndex = 4;
            this.btnHienThi_Click.Text = "Tạo biểu đồ";
            this.btnHienThi_Click.UseVisualStyleBackColor = true;
            this.btnHienThi_Click.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(476, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Đến ngày";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(476, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Từ ngày";
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.Location = new System.Drawing.Point(582, 113);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(200, 22);
            this.dtpDenNgay.TabIndex = 1;
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.Location = new System.Drawing.Point(582, 55);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(200, 22);
            this.dtpTuNgay.TabIndex = 0;
            this.dtpTuNgay.ValueChanged += new System.EventHandler(this.dtpTuNgay_ValueChanged);
            // 
            // clbCongTrinh
            // 
            this.clbCongTrinh.FormattingEnabled = true;
            this.clbCongTrinh.Location = new System.Drawing.Point(736, 3);
            this.clbCongTrinh.Name = "clbCongTrinh";
            this.clbCongTrinh.Size = new System.Drawing.Size(380, 514);
            this.clbCongTrinh.TabIndex = 1;
            this.clbCongTrinh.SelectedIndexChanged += new System.EventHandler(this.clbCongTrinh_SelectedIndexChanged);
            // 
            // chartSoSanh
            // 
            chartArea1.Name = "ChartArea1";
            this.chartSoSanh.ChartAreas.Add(chartArea1);
            this.chartSoSanh.Dock = System.Windows.Forms.DockStyle.Left;
            legend1.Name = "Legend1";
            this.chartSoSanh.Legends.Add(legend1);
            this.chartSoSanh.Location = new System.Drawing.Point(0, 0);
            this.chartSoSanh.Name = "chartSoSanh";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartSoSanh.Series.Add(series1);
            this.chartSoSanh.Size = new System.Drawing.Size(708, 510);
            this.chartSoSanh.TabIndex = 1;
            this.chartSoSanh.Text = "chart1";
            this.chartSoSanh.Click += new System.EventHandler(this.chart1_Click);
            // 
            // BaoCaoCTNuocSachTheoBĐ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chartSoSanh);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.clbCongTrinh);
            this.Name = "BaoCaoCTNuocSachTheoBĐ";
            this.Size = new System.Drawing.Size(1119, 677);
            this.Load += new System.EventHandler(this.BaoCaoSoSanhSanLuong_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSoSanh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Button btnHienThi_Click;
        private System.Windows.Forms.CheckedListBox clbCongTrinh;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSoSanh;
        private System.Windows.Forms.Button btnCapNhat;
    }
}