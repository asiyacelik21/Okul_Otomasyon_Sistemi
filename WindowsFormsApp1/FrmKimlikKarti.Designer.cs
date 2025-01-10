namespace WindowsFormsApp1
{
    partial class FrmKimlikKarti
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmKimlikKarti));
            this.lblTc = new DevExpress.XtraEditors.LabelControl();
            this.lblAd = new DevExpress.XtraEditors.LabelControl();
            this.lblSoyad = new DevExpress.XtraEditors.LabelControl();
            this.LblDogTr = new DevExpress.XtraEditors.LabelControl();
            this.lblCinsiyet = new DevExpress.XtraEditors.LabelControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTc
            // 
            this.lblTc.Location = new System.Drawing.Point(28, 98);
            this.lblTc.Name = "lblTc";
            this.lblTc.Size = new System.Drawing.Size(75, 16);
            this.lblTc.TabIndex = 0;
            this.lblTc.Text = "labelControl1";
            // 
            // lblAd
            // 
            this.lblAd.Location = new System.Drawing.Point(201, 98);
            this.lblAd.Name = "lblAd";
            this.lblAd.Size = new System.Drawing.Size(75, 16);
            this.lblAd.TabIndex = 1;
            this.lblAd.Text = "labelControl2";
            // 
            // lblSoyad
            // 
            this.lblSoyad.Location = new System.Drawing.Point(201, 150);
            this.lblSoyad.Name = "lblSoyad";
            this.lblSoyad.Size = new System.Drawing.Size(75, 16);
            this.lblSoyad.TabIndex = 2;
            this.lblSoyad.Text = "labelControl3";
            // 
            // LblDogTr
            // 
            this.LblDogTr.Location = new System.Drawing.Point(229, 190);
            this.LblDogTr.Name = "LblDogTr";
            this.LblDogTr.Size = new System.Drawing.Size(75, 16);
            this.LblDogTr.TabIndex = 3;
            this.LblDogTr.Text = "labelControl4";
            // 
            // lblCinsiyet
            // 
            this.lblCinsiyet.Location = new System.Drawing.Point(384, 190);
            this.lblCinsiyet.Name = "lblCinsiyet";
            this.lblCinsiyet.Size = new System.Drawing.Size(75, 16);
            this.lblCinsiyet.TabIndex = 4;
            this.lblCinsiyet.Text = "labelControl5";
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Location = new System.Drawing.Point(28, 134);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit1.Size = new System.Drawing.Size(112, 127);
            this.pictureEdit1.TabIndex = 5;
            // 
            // FrmKimlikKarti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(604, 302);
            this.Controls.Add(this.pictureEdit1);
            this.Controls.Add(this.lblCinsiyet);
            this.Controls.Add(this.LblDogTr);
            this.Controls.Add(this.lblSoyad);
            this.Controls.Add(this.lblAd);
            this.Controls.Add(this.lblTc);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.Name = "FrmKimlikKarti";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmKimlikKarti";
            this.Load += new System.EventHandler(this.FrmKimlikKarti_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblTc;
        private DevExpress.XtraEditors.LabelControl lblAd;
        private DevExpress.XtraEditors.LabelControl lblSoyad;
        private DevExpress.XtraEditors.LabelControl LblDogTr;
        private DevExpress.XtraEditors.LabelControl lblCinsiyet;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
    }
}