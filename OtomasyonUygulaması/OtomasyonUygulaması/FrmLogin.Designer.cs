namespace OtomasyonUygulaması
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.Tkullaniciadi = new DevExpress.XtraEditors.TextEdit();
            this.Tsifre = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.Tkullaniciadi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tsifre.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(282, 121);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(106, 18);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Kullanıcı Adı : ";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(338, 162);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(50, 18);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Şifre : ";
            // 
            // Tkullaniciadi
            // 
            this.Tkullaniciadi.Location = new System.Drawing.Point(394, 118);
            this.Tkullaniciadi.Name = "Tkullaniciadi";
            this.Tkullaniciadi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Tkullaniciadi.Properties.Appearance.Options.UseFont = true;
            this.Tkullaniciadi.Size = new System.Drawing.Size(189, 24);
            this.Tkullaniciadi.TabIndex = 2;
            // 
            // Tsifre
            // 
            this.Tsifre.Location = new System.Drawing.Point(394, 159);
            this.Tsifre.Name = "Tsifre";
            this.Tsifre.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Tsifre.Properties.Appearance.Options.UseFont = true;
            this.Tsifre.Properties.UseSystemPasswordChar = true;
            this.Tsifre.Size = new System.Drawing.Size(189, 24);
            this.Tsifre.TabIndex = 3;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(482, 215);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(101, 44);
            this.simpleButton1.TabIndex = 4;
            this.simpleButton1.Text = "Giriş";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            this.simpleButton1.MouseLeave += new System.EventHandler(this.simpleButton1_MouseLeave);
            this.simpleButton1.MouseHover += new System.EventHandler(this.simpleButton1_MouseHover);
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(634, 313);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.Tsifre);
            this.Controls.Add(this.Tkullaniciadi);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmLogin";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Tkullaniciadi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tsifre.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit Tkullaniciadi;
        private DevExpress.XtraEditors.TextEdit Tsifre;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}