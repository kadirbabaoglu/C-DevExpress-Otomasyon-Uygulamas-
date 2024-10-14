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
    public partial class FrmKasa : Form
    {
        public FrmKasa()
        {
            InitializeComponent();
        }

        dbConnection dbconn = new dbConnection();

        public void MusteriHareketleri()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Execute MusteriHareketleri" , dbconn.connection());
            sqlDataAdapter.Fill(dt);
            gridControl1.DataSource = dt;
        }

        public void BankaHareketleri()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Execute BankalarListesi", dbconn.connection());
            sqlDataAdapter.Fill(dt);
            gridControl3.DataSource = dt;
        }

        private void FrmKasa_Load(object sender, EventArgs e)
        {
            MusteriHareketleri();
            BankaHareketleri();

            // Toplam Tutar
            SqlCommand sql1 = new SqlCommand("Select Sum(TUTAR) From TBL_FATURADETAY" , dbconn.connection());
            SqlDataReader dr1 = sql1.ExecuteReader();
            while (dr1.Read()) 
            {
                labelControl2.Text = dr1[0].ToString() + "";
            }
            dbconn.connection().Close();

            // Son Ayın Fatura Giderleri
            SqlCommand sql2 = new SqlCommand("Select (ELEKTIRIK+SU+DOGALGAZ+INTERNET+EKSTRA+MAASLAR) from TBL_GIDERLER order by ID asc ", dbconn.connection());
            SqlDataReader dr2 = sql2.ExecuteReader();
            while (dr2.Read())
            {
                labelControl3.Text = dr2[0].ToString() + "";
            }
            dbconn.connection().Close();

            //Personel Maasları
            SqlCommand sql3 = new SqlCommand("Select MAASLAR from TBL_GIDERLER order by ID asc ", dbconn.connection());
            SqlDataReader dr3 = sql3.ExecuteReader();
            while (dr3.Read())
            {
                labelControl5.Text = dr3[0].ToString() + "";
            }
            dbconn.connection().Close();

            //Müşteri SAyısı
            SqlCommand sql4 = new SqlCommand("Select Count(*) from TBL_MUSTERILER ", dbconn.connection());
            SqlDataReader dr4 = sql4.ExecuteReader();
            while (dr4.Read())
            {
                labelControl7.Text = dr4[0].ToString() + "";
            }
            dbconn.connection().Close();

            //Firma SAyısı
            SqlCommand sql5 = new SqlCommand("Select Count(*) from TBL_FIRMALAR ", dbconn.connection());
            SqlDataReader dr5 = sql5.ExecuteReader();
            while (dr5.Read())
            {
                labelControl9.Text = dr5[0].ToString() + "";
            }
            dbconn.connection().Close();

            //Firma SAyısı
            SqlCommand sql6 = new SqlCommand("Select Count(distinct(IL)) from TBL_MUSTERILER ", dbconn.connection());
            SqlDataReader dr6 = sql6.ExecuteReader();
            while (dr6.Read())
            {
                labelControl11.Text = dr6[0].ToString() + "";
            }
            dbconn.connection().Close();

            //son 6 Ayın Elektirik Faturası
            SqlCommand sql7 = new SqlCommand("Select top 5 NOTLAR,ELEKTIRIK from TBL_GIDERLER order by ID DESC ", dbconn.connection());
            SqlDataReader dr7 = sql7.ExecuteReader();
            while (dr7.Read())
            {
                chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr7[0], dr7[1]));
            }
            dbconn.connection().Close();

            //son 6 Ayın Su Faturası
            SqlCommand sql8 = new SqlCommand("Select top 5 NOTLAR,SU from TBL_GIDERLER order by ID DESC ", dbconn.connection());
            SqlDataReader dr8 = sql8.ExecuteReader();
            while (dr8.Read())
            {
                chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr8[0], dr8[1]));
            }
            dbconn.connection().Close();
        }
    }
}
