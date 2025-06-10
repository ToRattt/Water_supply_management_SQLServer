namespace quanlichannuoi
{
    partial class MenuQLQHWater
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnManagerReport = new System.Windows.Forms.Button();
            this.btnMap = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Location = new System.Drawing.Point(25, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 75);
            this.button1.TabIndex = 0;
            this.button1.Text = "Quản lí quy hoạch";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnManagerReport
            // 
            this.btnManagerReport.Location = new System.Drawing.Point(25, 143);
            this.btnManagerReport.Name = "btnManagerReport";
            this.btnManagerReport.Size = new System.Drawing.Size(147, 76);
            this.btnManagerReport.TabIndex = 1;
            this.btnManagerReport.Text = "Quản lí bào cáo";
            this.btnManagerReport.UseVisualStyleBackColor = true;
            this.btnManagerReport.Click += new System.EventHandler(this.btnManagerReport_Click);
            // 
            // btnMap
            // 
            this.btnMap.Location = new System.Drawing.Point(25, 253);
            this.btnMap.Name = "btnMap";
            this.btnMap.Size = new System.Drawing.Size(147, 76);
            this.btnMap.TabIndex = 2;
            this.btnMap.Text = "Bản đồ";
            this.btnMap.UseVisualStyleBackColor = true;
            this.btnMap.Click += new System.EventHandler(this.btnMap_Click);
            // 
            // MenuQLQHWater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnMap);
            this.Controls.Add(this.btnManagerReport);
            this.Controls.Add(this.button1);
            this.Name = "MenuQLQHWater";
            this.Text = "MenuQLQHWater";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnManagerReport;
        private System.Windows.Forms.Button btnMap;
    }
}