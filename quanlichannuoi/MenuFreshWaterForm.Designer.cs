namespace quanlichannuoi
{
    partial class MenuFreshWaterForm
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
            this.btnManagerFresh = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnMap = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnManagerFresh
            // 
            this.btnManagerFresh.Location = new System.Drawing.Point(30, 27);
            this.btnManagerFresh.Name = "btnManagerFresh";
            this.btnManagerFresh.Size = new System.Drawing.Size(108, 71);
            this.btnManagerFresh.TabIndex = 0;
            this.btnManagerFresh.Text = "Quản lí công trình cấp nước";
            this.btnManagerFresh.UseVisualStyleBackColor = true;
            this.btnManagerFresh.Click += new System.EventHandler(this.btnManagerFresh_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(30, 141);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 71);
            this.button2.TabIndex = 1;
            this.button2.Text = "Quản lí công trình cấp nước nhỏ lẻ";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnMap
            // 
            this.btnMap.Location = new System.Drawing.Point(30, 262);
            this.btnMap.Name = "btnMap";
            this.btnMap.Size = new System.Drawing.Size(108, 71);
            this.btnMap.TabIndex = 2;
            this.btnMap.Text = "Bản đồ quy hoạch";
            this.btnMap.UseVisualStyleBackColor = true;
            this.btnMap.Click += new System.EventHandler(this.btnMap_Click);
            // 
            // MenuFreshWaterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnMap);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnManagerFresh);
            this.Name = "MenuFreshWaterForm";
            this.Text = "MenuFreshWaterForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnManagerFresh;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnMap;
    }
}