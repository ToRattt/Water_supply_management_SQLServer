namespace quanlichannuoi
{
    partial class BaoCaoCTNuocSachTheoCS
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
            this.cbCongTrinh = new System.Windows.Forms.ComboBox();
            this.dgvChiSoNuoc = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpThangNam = new System.Windows.Forms.DateTimePicker();
            this.nudChiSo = new System.Windows.Forms.NumericUpDown();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThemFile = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.quanLyNongThonDataSet1 = new quanlichannuoi.QuanLyNongThonDataSet();
            this.dgvFileDinhKem = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnXoaFile = new System.Windows.Forms.Button();
            this.btnMoFile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiSoNuoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudChiSo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyNongThonDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFileDinhKem)).BeginInit();
            this.SuspendLayout();
            // 
            // cbCongTrinh
            // 
            this.cbCongTrinh.FormattingEnabled = true;
            this.cbCongTrinh.Location = new System.Drawing.Point(173, 470);
            this.cbCongTrinh.Name = "cbCongTrinh";
            this.cbCongTrinh.Size = new System.Drawing.Size(271, 24);
            this.cbCongTrinh.TabIndex = 0;
            // 
            // dgvChiSoNuoc
            // 
            this.dgvChiSoNuoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiSoNuoc.Location = new System.Drawing.Point(29, 41);
            this.dgvChiSoNuoc.Name = "dgvChiSoNuoc";
            this.dgvChiSoNuoc.RowHeadersWidth = 51;
            this.dgvChiSoNuoc.RowTemplate.Height = 24;
            this.dgvChiSoNuoc.Size = new System.Drawing.Size(711, 396);
            this.dgvChiSoNuoc.TabIndex = 1;
            this.dgvChiSoNuoc.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChiSoNuoc_CellContentClick);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(25, 588);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(118, 48);
            this.btnThem.TabIndex = 2;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 470);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Chọn công trình";
            // 
            // dtpThangNam
            // 
            this.dtpThangNam.Location = new System.Drawing.Point(173, 500);
            this.dtpThangNam.Name = "dtpThangNam";
            this.dtpThangNam.Size = new System.Drawing.Size(271, 22);
            this.dtpThangNam.TabIndex = 4;
            // 
            // nudChiSo
            // 
            this.nudChiSo.Location = new System.Drawing.Point(173, 530);
            this.nudChiSo.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudChiSo.Name = "nudChiSo";
            this.nudChiSo.Size = new System.Drawing.Size(271, 22);
            this.nudChiSo.TabIndex = 5;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(173, 560);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(271, 22);
            this.txtGhiChu.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 500);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Thời gian";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 530);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Chỉ số nước (mg/L)";
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(175, 588);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(118, 48);
            this.btnSua.TabIndex = 9;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(326, 588);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(118, 48);
            this.btnXoa.TabIndex = 10;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThemFile
            // 
            this.btnThemFile.Location = new System.Drawing.Point(984, 489);
            this.btnThemFile.Name = "btnThemFile";
            this.btnThemFile.Size = new System.Drawing.Size(118, 48);
            this.btnThemFile.TabIndex = 11;
            this.btnThemFile.Text = "Đính kèm file";
            this.btnThemFile.UseVisualStyleBackColor = true;
            this.btnThemFile.Click += new System.EventHandler(this.btnThemFile_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 560);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Ghi chú";
            // 
            // quanLyNongThonDataSet1
            // 
            this.quanLyNongThonDataSet1.DataSetName = "QuanLyNongThonDataSet";
            this.quanLyNongThonDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dgvFileDinhKem
            // 
            this.dgvFileDinhKem.ColumnHeadersHeight = 29;
            this.dgvFileDinhKem.Location = new System.Drawing.Point(798, 41);
            this.dgvFileDinhKem.Name = "dgvFileDinhKem";
            this.dgvFileDinhKem.RowHeadersWidth = 51;
            this.dgvFileDinhKem.Size = new System.Drawing.Size(304, 396);
            this.dgvFileDinhKem.TabIndex = 18;
            this.dgvFileDinhKem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFileDinhKem_CellContentClick_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(887, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "Chọn file";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 16);
            this.label6.TabIndex = 15;
            this.label6.Text = "Chọn công trình";
            // 
            // btnXoaFile
            // 
            this.btnXoaFile.Location = new System.Drawing.Point(984, 549);
            this.btnXoaFile.Name = "btnXoaFile";
            this.btnXoaFile.Size = new System.Drawing.Size(118, 48);
            this.btnXoaFile.TabIndex = 16;
            this.btnXoaFile.Text = "Xóa file";
            this.btnXoaFile.UseVisualStyleBackColor = true;
            this.btnXoaFile.Click += new System.EventHandler(this.btnXoaFile_Click);
            // 
            // btnMoFile
            // 
            this.btnMoFile.Location = new System.Drawing.Point(984, 603);
            this.btnMoFile.Name = "btnMoFile";
            this.btnMoFile.Size = new System.Drawing.Size(118, 48);
            this.btnMoFile.TabIndex = 17;
            this.btnMoFile.Text = "Mở file";
            this.btnMoFile.UseVisualStyleBackColor = true;
            this.btnMoFile.Click += new System.EventHandler(this.btnMoFile_Click);
            // 
            // BaoCaoCTNuocSachTheoCS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnMoFile);
            this.Controls.Add(this.btnXoaFile);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvFileDinhKem);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnThemFile);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.nudChiSo);
            this.Controls.Add(this.dtpThangNam);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgvChiSoNuoc);
            this.Controls.Add(this.cbCongTrinh);
            this.Name = "BaoCaoCTNuocSachTheoCS";
            this.Size = new System.Drawing.Size(1119, 677);
            this.Load += new System.EventHandler(this.QLChiSoNuocSach_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiSoNuoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudChiSo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyNongThonDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFileDinhKem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbCongTrinh;
        private System.Windows.Forms.DataGridView dgvChiSoNuoc;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpThangNam;
        private System.Windows.Forms.NumericUpDown nudChiSo;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThemFile;
        private System.Windows.Forms.Label label4;
        private QuanLyNongThonDataSet quanLyNongThonDataSet1;
        private System.Windows.Forms.DataGridView dgvFileDinhKem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnXoaFile;
        private System.Windows.Forms.Button btnMoFile;
    }
}