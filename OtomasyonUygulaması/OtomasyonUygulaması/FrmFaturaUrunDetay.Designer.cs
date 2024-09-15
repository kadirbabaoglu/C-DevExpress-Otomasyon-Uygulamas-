namespace OtomasyonUygulaması
{
    partial class FrmFaturaUrunDetay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFaturaUrunDetay));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl5 = new DevExpress.XtraEditors.GroupControl();
            this.BtnSil = new DevExpress.XtraEditors.SimpleButton();
            this.BtnGuncelle = new DevExpress.XtraEditors.SimpleButton();
            this.lbl1 = new DevExpress.XtraEditors.LabelControl();
            this.Tfaturaid = new DevExpress.XtraEditors.TextEdit();
            this.Tfiyat = new DevExpress.XtraEditors.TextEdit();
            this.Tad = new DevExpress.XtraEditors.TextEdit();
            this.Tid = new DevExpress.XtraEditors.TextEdit();
            this.lbl = new DevExpress.XtraEditors.LabelControl();
            this.labelControl21 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl22 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl23 = new DevExpress.XtraEditors.LabelControl();
            this.Tmiktar = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).BeginInit();
            this.groupControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Tfaturaid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tfiyat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tmiktar.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(636, 343);
            this.gridControl1.TabIndex = 6;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // groupControl5
            // 
            this.groupControl5.Controls.Add(this.BtnSil);
            this.groupControl5.Controls.Add(this.BtnGuncelle);
            this.groupControl5.Controls.Add(this.lbl1);
            this.groupControl5.Controls.Add(this.Tfaturaid);
            this.groupControl5.Controls.Add(this.Tfiyat);
            this.groupControl5.Controls.Add(this.Tad);
            this.groupControl5.Controls.Add(this.Tid);
            this.groupControl5.Controls.Add(this.lbl);
            this.groupControl5.Controls.Add(this.labelControl21);
            this.groupControl5.Controls.Add(this.labelControl22);
            this.groupControl5.Controls.Add(this.labelControl23);
            this.groupControl5.Controls.Add(this.Tmiktar);
            this.groupControl5.Location = new System.Drawing.Point(642, 0);
            this.groupControl5.Name = "groupControl5";
            this.groupControl5.Size = new System.Drawing.Size(285, 343);
            this.groupControl5.TabIndex = 7;
            this.groupControl5.Text = "groupControl5";
            // 
            // BtnSil
            // 
            this.BtnSil.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnSil.Appearance.Options.UseFont = true;
            this.BtnSil.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnSil.ImageOptions.Image")));
            this.BtnSil.Location = new System.Drawing.Point(158, 210);
            this.BtnSil.Name = "BtnSil";
            this.BtnSil.Size = new System.Drawing.Size(109, 34);
            this.BtnSil.TabIndex = 40;
            this.BtnSil.Text = "Sil";
            this.BtnSil.Click += new System.EventHandler(this.BtnSil_Click);
            // 
            // BtnGuncelle
            // 
            this.BtnGuncelle.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnGuncelle.Appearance.Options.UseFont = true;
            this.BtnGuncelle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnGuncelle.ImageOptions.Image")));
            this.BtnGuncelle.Location = new System.Drawing.Point(43, 210);
            this.BtnGuncelle.Name = "BtnGuncelle";
            this.BtnGuncelle.Size = new System.Drawing.Size(109, 34);
            this.BtnGuncelle.TabIndex = 39;
            this.BtnGuncelle.Text = "Güncelle";
            this.BtnGuncelle.Click += new System.EventHandler(this.BtnGuncelle_Click);
            // 
            // lbl1
            // 
            this.lbl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl1.Appearance.Options.UseFont = true;
            this.lbl1.Location = new System.Drawing.Point(29, 157);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(65, 14);
            this.lbl1.TabIndex = 38;
            this.lbl1.Text = "Fatura ID: ";
            // 
            // Tfaturaid
            // 
            this.Tfaturaid.Location = new System.Drawing.Point(100, 153);
            this.Tfaturaid.Name = "Tfaturaid";
            this.Tfaturaid.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Tfaturaid.Properties.Appearance.Options.UseFont = true;
            this.Tfaturaid.Size = new System.Drawing.Size(145, 22);
            this.Tfaturaid.TabIndex = 36;
            // 
            // Tfiyat
            // 
            this.Tfiyat.Location = new System.Drawing.Point(100, 125);
            this.Tfiyat.Name = "Tfiyat";
            this.Tfiyat.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Tfiyat.Properties.Appearance.Options.UseFont = true;
            this.Tfiyat.Size = new System.Drawing.Size(145, 22);
            this.Tfiyat.TabIndex = 34;
            // 
            // Tad
            // 
            this.Tad.Location = new System.Drawing.Point(101, 69);
            this.Tad.Name = "Tad";
            this.Tad.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Tad.Properties.Appearance.Options.UseFont = true;
            this.Tad.Size = new System.Drawing.Size(145, 22);
            this.Tad.TabIndex = 33;
            // 
            // Tid
            // 
            this.Tid.Location = new System.Drawing.Point(101, 41);
            this.Tid.Name = "Tid";
            this.Tid.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Tid.Properties.Appearance.Options.UseFont = true;
            this.Tid.Size = new System.Drawing.Size(145, 22);
            this.Tid.TabIndex = 32;
            // 
            // lbl
            // 
            this.lbl.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl.Appearance.Options.UseFont = true;
            this.lbl.Location = new System.Drawing.Point(53, 128);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(41, 14);
            this.lbl.TabIndex = 25;
            this.lbl.Text = "Fiyat : ";
            // 
            // labelControl21
            // 
            this.labelControl21.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl21.Appearance.Options.UseFont = true;
            this.labelControl21.Location = new System.Drawing.Point(43, 99);
            this.labelControl21.Name = "labelControl21";
            this.labelControl21.Size = new System.Drawing.Size(51, 14);
            this.labelControl21.TabIndex = 24;
            this.labelControl21.Text = "Miktar : ";
            // 
            // labelControl22
            // 
            this.labelControl22.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl22.Appearance.Options.UseFont = true;
            this.labelControl22.Location = new System.Drawing.Point(29, 71);
            this.labelControl22.Name = "labelControl22";
            this.labelControl22.Size = new System.Drawing.Size(65, 14);
            this.labelControl22.TabIndex = 23;
            this.labelControl22.Text = "Ürün Adı : ";
            // 
            // labelControl23
            // 
            this.labelControl23.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl23.Appearance.Options.UseFont = true;
            this.labelControl23.Location = new System.Drawing.Point(68, 44);
            this.labelControl23.Name = "labelControl23";
            this.labelControl23.Size = new System.Drawing.Size(26, 14);
            this.labelControl23.TabIndex = 22;
            this.labelControl23.Text = "ID : ";
            // 
            // Tmiktar
            // 
            this.Tmiktar.Location = new System.Drawing.Point(101, 97);
            this.Tmiktar.Name = "Tmiktar";
            this.Tmiktar.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Tmiktar.Properties.Appearance.Options.UseFont = true;
            this.Tmiktar.Size = new System.Drawing.Size(145, 22);
            this.Tmiktar.TabIndex = 31;
            // 
            // FrmFaturaUrunDetay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 398);
            this.Controls.Add(this.groupControl5);
            this.Controls.Add(this.gridControl1);
            this.Name = "FrmFaturaUrunDetay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmFaturaUrunDetay";
            this.Load += new System.EventHandler(this.FrmFaturaUrunDetay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).EndInit();
            this.groupControl5.ResumeLayout(false);
            this.groupControl5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Tfaturaid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tfiyat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tmiktar.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.GroupControl groupControl5;
        private DevExpress.XtraEditors.LabelControl lbl1;
        private DevExpress.XtraEditors.TextEdit Tfaturaid;
        private DevExpress.XtraEditors.TextEdit Tfiyat;
        private DevExpress.XtraEditors.TextEdit Tad;
        private DevExpress.XtraEditors.TextEdit Tid;
        private DevExpress.XtraEditors.LabelControl lbl;
        private DevExpress.XtraEditors.LabelControl labelControl21;
        private DevExpress.XtraEditors.LabelControl labelControl22;
        private DevExpress.XtraEditors.LabelControl labelControl23;
        private DevExpress.XtraEditors.TextEdit Tmiktar;
        private DevExpress.XtraEditors.SimpleButton BtnGuncelle;
        private DevExpress.XtraEditors.SimpleButton BtnSil;
    }
}