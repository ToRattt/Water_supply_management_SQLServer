namespace quanlichannuoi
{
    partial class DistrictForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btmDistrictShow = new System.Windows.Forms.Button();
            this.btnAddDistrict = new System.Windows.Forms.Button();
            this.btnSearchDistrict = new System.Windows.Forms.Button();
            this.tbSearchDistrict = new System.Windows.Forms.TextBox();
            this.tbNameDistrict = new System.Windows.Forms.TextBox();
            this.tbCodeDistrict = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 132);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(776, 306);
            this.dataGridView1.TabIndex = 0;
            // 
            // btmDistrictShow
            // 
            this.btmDistrictShow.Location = new System.Drawing.Point(12, 12);
            this.btmDistrictShow.Name = "btmDistrictShow";
            this.btmDistrictShow.Size = new System.Drawing.Size(159, 27);
            this.btmDistrictShow.TabIndex = 1;
            this.btmDistrictShow.Text = "Hiển thị danh sách";
            this.btmDistrictShow.UseVisualStyleBackColor = true;
            this.btmDistrictShow.Click += new System.EventHandler(this.btmDistrictShow_Click);
            // 
            // btnAddDistrict
            // 
            this.btnAddDistrict.Location = new System.Drawing.Point(12, 45);
            this.btnAddDistrict.Name = "btnAddDistrict";
            this.btnAddDistrict.Size = new System.Drawing.Size(159, 27);
            this.btnAddDistrict.TabIndex = 2;
            this.btnAddDistrict.Text = "Thêm Huyện";
            this.btnAddDistrict.UseVisualStyleBackColor = true;
            this.btnAddDistrict.Click += new System.EventHandler(this.btnAddDistrict_Click);
            // 
            // btnSearchDistrict
            // 
            this.btnSearchDistrict.Location = new System.Drawing.Point(12, 78);
            this.btnSearchDistrict.Name = "btnSearchDistrict";
            this.btnSearchDistrict.Size = new System.Drawing.Size(159, 23);
            this.btnSearchDistrict.TabIndex = 3;
            this.btnSearchDistrict.Text = "Tìm Huyện";
            this.btnSearchDistrict.UseVisualStyleBackColor = true;
            this.btnSearchDistrict.Click += new System.EventHandler(this.btnSearchDistrict_Click);
            // 
            // tbSearchDistrict
            // 
            this.tbSearchDistrict.Location = new System.Drawing.Point(205, 79);
            this.tbSearchDistrict.Name = "tbSearchDistrict";
            this.tbSearchDistrict.Size = new System.Drawing.Size(284, 22);
            this.tbSearchDistrict.TabIndex = 4;
            // 
            // tbNameDistrict
            // 
            this.tbNameDistrict.Location = new System.Drawing.Point(205, 50);
            this.tbNameDistrict.Name = "tbNameDistrict";
            this.tbNameDistrict.Size = new System.Drawing.Size(124, 22);
            this.tbNameDistrict.TabIndex = 5;
            // 
            // tbCodeDistrict
            // 
            this.tbCodeDistrict.Location = new System.Drawing.Point(346, 50);
            this.tbCodeDistrict.Name = "tbCodeDistrict";
            this.tbCodeDistrict.Size = new System.Drawing.Size(143, 22);
            this.tbCodeDistrict.TabIndex = 6;
            // 
            // DistrictForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tbCodeDistrict);
            this.Controls.Add(this.tbNameDistrict);
            this.Controls.Add(this.tbSearchDistrict);
            this.Controls.Add(this.btnSearchDistrict);
            this.Controls.Add(this.btnAddDistrict);
            this.Controls.Add(this.btmDistrictShow);
            this.Controls.Add(this.dataGridView1);
            this.Name = "DistrictForm";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btmDistrictShow;
        private System.Windows.Forms.Button btnAddDistrict;
        private System.Windows.Forms.Button btnSearchDistrict;
        private System.Windows.Forms.TextBox tbSearchDistrict;
        private System.Windows.Forms.TextBox tbNameDistrict;
        private System.Windows.Forms.TextBox tbCodeDistrict;
    }
}