using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtomasyonUygulaması
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void FormClosedHandler(object sender, FormClosedEventArgs e)
        {
            
            frm = null;
            frm2 = null;
            frm3 = null;
            frm4 = null;
            frm5 = null;
            frm6 = null;
            frm7 = null;
            frm8 = null;
            frm9 = null;
            frm10 = null;
        }

        FrmUrunler frm;
        private void BtnUrunler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm == null)
            {
                frm = new FrmUrunler();
                frm.MdiParent = this;
                frm.FormClosed += new FormClosedEventHandler(FormClosedHandler);
                frm.Show();
            }

        }

        FrmMusteriler frm2;
        private void BtnMusteriler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm2 == null)
            {
                frm2 = new FrmMusteriler();
                frm2.MdiParent = this;
                frm2.FormClosed += new FormClosedEventHandler(FormClosedHandler);
                frm2.Show();
            }

        }

        FrmFirmalar frm3;
        private void BtnFirmalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm3 == null)
            {
                frm3 = new FrmFirmalar();
                frm3.MdiParent = this;
                frm3.FormClosed += new FormClosedEventHandler(FormClosedHandler);
                frm3.Show();
            }      
        }

        FrmPersonel frm4;
        private void BtnPersoneller_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm4 == null)
            {
                frm4 = new FrmPersonel();
                frm4.MdiParent = this;
                frm4.FormClosed += new FormClosedEventHandler(FormClosedHandler);
                frm4.Show();
            }

        }

        FrmRehber frm5;
        private void BtnRehber_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm5 == null)
            {
                frm5 = new FrmRehber();
                frm5.MdiParent = this;
                frm5.FormClosed += new FormClosedEventHandler(FormClosedHandler);
                frm5.Show();
            }
        }

        FrmGiderler frm6;
        private void BtnGiderler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm6 == null)
            {
                frm6 = new FrmGiderler();
                frm6.MdiParent = this;
                frm6.FormClosed += new FormClosedEventHandler(FormClosedHandler);
                frm6.Show();
            }      
        }

        FrmBankalar frm7;
        private void BtnBankalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm7 == null)
            {
                frm7 = new FrmBankalar();
                frm7.MdiParent = this;
                frm7.FormClosed += new FormClosedEventHandler(FormClosedHandler);
                frm7.Show();
            }
        }

        FrmFaturalar frm8;
        private void BtnFaturalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (frm8 == null)
            {
                frm8 = new FrmFaturalar();
                frm8.MdiParent = this;
                frm8.FormClosed += new FormClosedEventHandler(FormClosedHandler);
                frm8.Show();
            }
        }

        FrmNotlar frm9;
        private void BtnNotlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm9 == null)
            {
                frm9 = new FrmNotlar();
                frm9.MdiParent = this;
                frm9.FormClosed += new FormClosedEventHandler(FormClosedHandler);
                frm9.Show();
            }
        }

        FrmHareketler frm10;
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm10 == null)
            {
                frm10 = new FrmHareketler();
                frm10.MdiParent = this;
                frm10.FormClosed += new FormClosedEventHandler(FormClosedHandler);
                frm10.Show();
            }
        }
    }
}
