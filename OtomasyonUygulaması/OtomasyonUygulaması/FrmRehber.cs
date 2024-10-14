using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtomasyonUygulaması
{
    public partial class FrmRehber : Form
    {
        public FrmRehber()
        {
            InitializeComponent();
        }

        dbConnection dbconn = new dbConnection();

        void Musteriler()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select AD,SOYAD,TELEFON,TELEFON2,MAIL from TBL_MUSTERILER" , dbconn.connection());
            sqlDataAdapter.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void Firmalar()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select FIRMAAD,YETKILIADSOYAD,TELEFON,TELEFON1,TELEFON,MAIL,FAX from TBL_FIRMALAR", dbconn.connection());
            dataAdapter.Fill(dt);
            gridControl2.DataSource = dt;
        }

        private void FrmRehber_Load(object sender, EventArgs e)
        {
            Musteriler();
            Firmalar();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmMail frm = new FrmMail();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if(dr != null)
            {
                frm.Mail = dr["MAIL"].ToString();
            }
            frm.Show();
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            FrmMail frm = new FrmMail();
            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            if (dr != null)
            {
                frm.Mail = dr["MAIL"].ToString();
            }
            frm.Show();
        }

       
    }
}
