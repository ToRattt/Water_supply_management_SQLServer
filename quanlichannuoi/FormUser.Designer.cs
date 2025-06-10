namespace quanlichannuoi
{
    partial class FormUser
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
            this.btnManagerQH = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnHistoryLogin = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnInforManager = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnManagerQH
            // 
            this.btnManagerQH.Location = new System.Drawing.Point(240, 246);
            this.btnManagerQH.Name = "btnManagerQH";
            this.btnManagerQH.Size = new System.Drawing.Size(175, 68);
            this.btnManagerQH.TabIndex = 11;
            this.btnManagerQH.Text = "Quản lý quy hoạch nước sạch và vệ sinh môi trường nông thôn";
            this.btnManagerQH.UseVisualStyleBackColor = true;
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(240, 118);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(175, 68);
            this.btnReport.TabIndex = 10;
            this.btnReport.Text = "Báo cáo";
            this.btnReport.UseVisualStyleBackColor = true;
            // 
            // btnHistoryLogin
            // 
            this.btnHistoryLogin.Location = new System.Drawing.Point(240, 12);
            this.btnHistoryLogin.Name = "btnHistoryLogin";
            this.btnHistoryLogin.Size = new System.Drawing.Size(175, 68);
            this.btnHistoryLogin.TabIndex = 9;
            this.btnHistoryLogin.Text = "Lịch sử truy cập người dùng";
            this.btnHistoryLogin.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 246);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(175, 68);
            this.button3.TabIndex = 8;
            this.button3.Text = "Quản lí đơn vị hành chính cấp xã";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 118);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(175, 68);
            this.button2.TabIndex = 7;
            this.button2.Text = "Quản lí đơn vị hành chính cấp huyện";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnInforManager
            // 
            this.btnInforManager.Location = new System.Drawing.Point(12, 12);
            this.btnInforManager.Name = "btnInforManager";
            this.btnInforManager.Size = new System.Drawing.Size(175, 68);
            this.btnInforManager.TabIndex = 6;
            this.btnInforManager.Text = "Quản lí thông tin tài khoản";
            this.btnInforManager.UseVisualStyleBackColor = true;
            this.btnInforManager.Click += new System.EventHandler(this.btnInforManager_Click);
            // 
            // FormUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnManagerQH);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnHistoryLogin);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnInforManager);
            this.Name = "FormUser";
            this.Text = "FormUser";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnManagerQH;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnHistoryLogin;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnInforManager;
    }
}