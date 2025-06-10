namespace quanlichannuoi
{
    partial class Watermap
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
            this.btnAddpst = new System.Windows.Forms.Button();
            this.gMapControl2 = new GMap.NET.WindowsForms.GMapControl();
            this.latitude = new System.Windows.Forms.TextBox();
            this.longitude = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.zoom_level = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddpst
            // 
            this.btnAddpst.Location = new System.Drawing.Point(12, 146);
            this.btnAddpst.Name = "btnAddpst";
            this.btnAddpst.Size = new System.Drawing.Size(101, 23);
            this.btnAddpst.TabIndex = 0;
            this.btnAddpst.Text = "Thêm vị trí";
            this.btnAddpst.UseVisualStyleBackColor = true;
            this.btnAddpst.Click += new System.EventHandler(this.btnAddpst_Click);
            // 
            // gMapControl2
            // 
            this.gMapControl2.Bearing = 0F;
            this.gMapControl2.CanDragMap = true;
            this.gMapControl2.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl2.GrayScaleMode = false;
            this.gMapControl2.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl2.LevelsKeepInMemmory = 5;
            this.gMapControl2.Location = new System.Drawing.Point(229, 12);
            this.gMapControl2.MarkersEnabled = true;
            this.gMapControl2.MaxZoom = 2;
            this.gMapControl2.MinZoom = 2;
            this.gMapControl2.MouseWheelZoomEnabled = true;
            this.gMapControl2.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl2.Name = "gMapControl2";
            this.gMapControl2.NegativeMode = false;
            this.gMapControl2.PolygonsEnabled = true;
            this.gMapControl2.RetryLoadTile = 0;
            this.gMapControl2.RoutesEnabled = true;
            this.gMapControl2.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl2.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl2.ShowTileGridLines = false;
            this.gMapControl2.Size = new System.Drawing.Size(569, 426);
            this.gMapControl2.TabIndex = 2;
            this.gMapControl2.Zoom = 0D;
            // 
            // latitude
            // 
            this.latitude.Location = new System.Drawing.Point(13, 22);
            this.latitude.Name = "latitude";
            this.latitude.Size = new System.Drawing.Size(100, 22);
            this.latitude.TabIndex = 3;
            this.latitude.TextChanged += new System.EventHandler(this.latitude_TextChanged);
            // 
            // longitude
            // 
            this.longitude.Location = new System.Drawing.Point(13, 62);
            this.longitude.Name = "longitude";
            this.longitude.Size = new System.Drawing.Size(100, 22);
            this.longitude.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 103);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 25);
            this.button1.TabIndex = 5;
            this.button1.Text = "go to";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // zoom_level
            // 
            this.zoom_level.Location = new System.Drawing.Point(13, 192);
            this.zoom_level.Name = "zoom_level";
            this.zoom_level.Size = new System.Drawing.Size(100, 22);
            this.zoom_level.TabIndex = 6;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(129, 182);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 47);
            this.button2.TabIndex = 7;
            this.button2.Text = "Change Zoom";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(22, 231);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(73, 51);
            this.button3.TabIndex = 8;
            this.button3.Text = "Active drag";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(22, 301);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(73, 54);
            this.button4.TabIndex = 9;
            this.button4.Text = "Active mouse click";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Watermap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.zoom_level);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.longitude);
            this.Controls.Add(this.latitude);
            this.Controls.Add(this.gMapControl2);
            this.Controls.Add(this.btnAddpst);
            this.Name = "Watermap";
            this.Text = "Watermap";
            this.Load += new System.EventHandler(this.Watermap_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddpst;
        private GMap.NET.WindowsForms.GMapControl gMapControl2;
        private System.Windows.Forms.TextBox latitude;
        private System.Windows.Forms.TextBox longitude;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox zoom_level;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}