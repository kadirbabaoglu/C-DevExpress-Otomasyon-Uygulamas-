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
    }
}
