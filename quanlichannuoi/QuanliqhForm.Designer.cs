namespace quanlichannuoi
{
    partial class QuanliqhForm
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
            this.btnLoad = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.txtTenQuyHoach = new System.Windows.Forms.TextBox();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxTrangThai = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.quanLyNongThonDataSet1 = new quanlichannuoi.QuanLyNongThonDataSet();
            this.datePickerNgayThucHien = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.vd = new System.Windows.Forms.Label();
            this.txtkd = new System.Windows.Forms.TextBox();
            this.txtvd = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyNongThonDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(12, 21);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(86, 41);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Hiển thị";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 144);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(776, 294);
            this.dataGridView1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(118, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 41);
            this.button1.TabIndex = 2;
            this.button1.Text = "Thêm quy hoạch";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // txtTenQuyHoach
            // 
            this.txtTenQuyHoach.Location = new System.Drawing.Point(323, 12);
            this.txtTenQuyHoach.Name = "txtTenQuyHoach";
            this.txtTenQuyHoach.Size = new System.Drawing.Size(244, 22);
            this.txtTenQuyHoach.TabIndex = 3;
            this.txtTenQuyHoach.TextChanged += new System.EventHandler(this.txtTenQuyHoach_TextChanged);
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(323, 40);
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(244, 22);
            this.txtMoTa.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(221, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tên quy hoạch";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(221, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Mô tả";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(222, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Ngày thực hiện";
            // 
            // comboBoxTrangThai
            // 
            this.comboBoxTrangThai.FormattingEnabled = true;
            this.comboBoxTrangThai.Location = new System.Drawing.Point(323, 94);
            this.comboBoxTrangThai.Name = "comboBoxTrangThai";
            this.comboBoxTrangThai.Size = new System.Drawing.Size(244, 24);
            this.comboBoxTrangThai.TabIndex = 9;
            this.comboBoxTrangThai.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(222, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Trạng thái";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // quanLyNongThonDataSet1
            // 
            this.quanLyNongThonDataSet1.DataSetName = "QuanLyNongThonDataSet";
            this.quanLyNongThonDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // datePickerNgayThucHien
            // 
            this.datePickerNgayThucHien.Location = new System.Drawing.Point(323, 68);
            this.datePickerNgayThucHien.Name = "datePickerNgayThucHien";
            this.datePickerNgayThucHien.Size = new System.Drawing.Size(244, 22);
            this.datePickerNgayThucHien.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(577, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Kinh độ";
            // 
            // vd
            // 
            this.vd.AutoSize = true;
            this.vd.Location = new System.Drawing.Point(584, 46);
            this.vd.Name = "vd";
            this.vd.Size = new System.Drawing.Size(40, 16);
            this.vd.TabIndex = 13;
            this.vd.Text = "Vĩ độ";
            // 
            // txtkd
            // 
            this.txtkd.Location = new System.Drawing.Point(634, 12);
            this.txtkd.Name = "txtkd";
            this.txtkd.Size = new System.Drawing.Size(100, 22);
            this.txtkd.TabIndex = 14;
            this.txtkd.TextChanged += new System.EventHandler(this.txtkd_TextChanged);
            // 
            // txtvd
            // 
            this.txtvd.Location = new System.Drawing.Point(634, 46);
            this.txtvd.Name = "txtvd";
            this.txtvd.Size = new System.Drawing.Size(100, 22);
            this.txtvd.TabIndex = 15;
            // 
            // QuanliqhForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtvd);
            this.Controls.Add(this.txtkd);
            this.Controls.Add(this.vd);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.datePickerNgayThucHien);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxTrangThai);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMoTa);
            this.Controls.Add(this.txtTenQuyHoach);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnLoad);
            this.Name = "QuanliqhForm";
            this.Text = "QuanliqhForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyNongThonDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtTenQuyHoach;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxTrangThai;
        private System.Windows.Forms.Label label4;
        private QuanLyNongThonDataSet quanLyNongThonDataSet1;
        private System.Windows.Forms.DateTimePicker datePickerNgayThucHien;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label vd;
        private System.Windows.Forms.TextBox txtkd;
        private System.Windows.Forms.TextBox txtvd;
    }
}