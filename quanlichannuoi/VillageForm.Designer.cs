namespace quanlichannuoi
{
    partial class VillageForm
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
            this.VillageShow = new System.Windows.Forms.Button();
            this.btnAddVillage = new System.Windows.Forms.Button();
            this.btnSearchVillage = new System.Windows.Forms.Button();
            this.txtNameVillage = new System.Windows.Forms.TextBox();
            this.txtCodeVillage = new System.Windows.Forms.TextBox();
            this.txtCodeDistrict = new System.Windows.Forms.TextBox();
            this.txtSearchNameVillage = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 114);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(776, 324);
            this.dataGridView1.TabIndex = 0;
            // 
            // VillageShow
            // 
            this.VillageShow.Location = new System.Drawing.Point(12, 12);
            this.VillageShow.Name = "VillageShow";
            this.VillageShow.Size = new System.Drawing.Size(175, 29);
            this.VillageShow.TabIndex = 1;
            this.VillageShow.Text = "Hiển thị danh sách xã";
            this.VillageShow.UseVisualStyleBackColor = true;
            this.VillageShow.Click += new System.EventHandler(this.VillageShow_Click);
            // 
            // btnAddVillage
            // 
            this.btnAddVillage.Location = new System.Drawing.Point(12, 47);
            this.btnAddVillage.Name = "btnAddVillage";
            this.btnAddVillage.Size = new System.Drawing.Size(175, 23);
            this.btnAddVillage.TabIndex = 2;
            this.btnAddVillage.Text = "Thêm xã";
            this.btnAddVillage.UseVisualStyleBackColor = true;
            this.btnAddVillage.Click += new System.EventHandler(this.btnAddVillage_Click);
            // 
            // btnSearchVillage
            // 
            this.btnSearchVillage.Location = new System.Drawing.Point(12, 76);
            this.btnSearchVillage.Name = "btnSearchVillage";
            this.btnSearchVillage.Size = new System.Drawing.Size(175, 23);
            this.btnSearchVillage.TabIndex = 3;
            this.btnSearchVillage.Text = "Tìm xã";
            this.btnSearchVillage.UseVisualStyleBackColor = true;
            this.btnSearchVillage.Click += new System.EventHandler(this.btnSearchVillage_Click);
            // 
            // txtNameVillage
            // 
            this.txtNameVillage.Location = new System.Drawing.Point(217, 48);
            this.txtNameVillage.Name = "txtNameVillage";
            this.txtNameVillage.Size = new System.Drawing.Size(163, 22);
            this.txtNameVillage.TabIndex = 4;
            // 
            // txtCodeVillage
            // 
            this.txtCodeVillage.Location = new System.Drawing.Point(405, 47);
            this.txtCodeVillage.Name = "txtCodeVillage";
            this.txtCodeVillage.Size = new System.Drawing.Size(163, 22);
            this.txtCodeVillage.TabIndex = 5;
            // 
            // txtCodeDistrict
            // 
            this.txtCodeDistrict.Location = new System.Drawing.Point(584, 47);
            this.txtCodeDistrict.Name = "txtCodeDistrict";
            this.txtCodeDistrict.Size = new System.Drawing.Size(163, 22);
            this.txtCodeDistrict.TabIndex = 6;
            // 
            // txtSearchNameVillage
            // 
            this.txtSearchNameVillage.Location = new System.Drawing.Point(217, 77);
            this.txtSearchNameVillage.Name = "txtSearchNameVillage";
            this.txtSearchNameVillage.Size = new System.Drawing.Size(163, 22);
            this.txtSearchNameVillage.TabIndex = 7;
            // 
            // VillageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtSearchNameVillage);
            this.Controls.Add(this.txtCodeDistrict);
            this.Controls.Add(this.txtCodeVillage);
            this.Controls.Add(this.txtNameVillage);
            this.Controls.Add(this.btnSearchVillage);
            this.Controls.Add(this.btnAddVillage);
            this.Controls.Add(this.VillageShow);
            this.Controls.Add(this.dataGridView1);
            this.Name = "VillageForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button VillageShow;
        private System.Windows.Forms.Button btnAddVillage;
        private System.Windows.Forms.Button btnSearchVillage;
        private System.Windows.Forms.TextBox txtNameVillage;
        private System.Windows.Forms.TextBox txtCodeVillage;
        private System.Windows.Forms.TextBox txtCodeDistrict;
        private System.Windows.Forms.TextBox txtSearchNameVillage;
    }
}