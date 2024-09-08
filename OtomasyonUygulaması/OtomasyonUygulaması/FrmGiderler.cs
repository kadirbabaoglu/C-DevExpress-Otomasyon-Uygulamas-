using DevExpress.XtraEditors.Mask.Design;
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
    public partial class FrmGiderler : Form
    {
        public FrmGiderler()
        {
            InitializeComponent();
        }

        dbConnection dbconn = new dbConnection();

        void Listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * From TBL_GIDERLER" , dbconn.connection());
            sqlDataAdapter.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void Temizle()
        {
            TxtID.Clear();
            TxtTarih.Value = DateTime.Now;
            TxtElektrik.Clear();
            TxtSu.Clear();
            TxtDogalgaz.Clear();
            TxtInternet.Clear();
            TxtEkstra.Clear();
            TxtMaaslar.Clear();
            RchNot.Clear();
        }

        private void FrmGiderler_Load(object sender, EventArgs e)
        {
             Listele();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtID.Text))
            {
                SqlCommand sql = new SqlCommand("Insert Into TBL_GIDERLER (TARIH,ELEKTIRIK,SU,DOGALGAZ,INTERNET,EKSTRA,MAASLAR,NOTLAR) values" +
                "(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", dbconn.connection());
                sql.Parameters.AddWithValue("@p1", TxtTarih.Value);
                sql.Parameters.AddWithValue("@p2", decimal.Parse(TxtElektrik.Text));
                sql.Parameters.AddWithValue("@p3", decimal.Parse(TxtSu.Text));
                sql.Parameters.AddWithValue("@p4", decimal.Parse(TxtDogalgaz.Text));
                sql.Parameters.AddWithValue("@p5", decimal.Parse(TxtInternet.Text));
                sql.Parameters.AddWithValue("@p6", decimal.Parse(TxtEkstra.Text));
                sql.Parameters.AddWithValue("@p7", decimal.Parse(TxtMaaslar.Text));
                sql.Parameters.AddWithValue("@p8", RchNot.Text);
               
                sql.ExecuteNonQuery();
                dbconn.connection().Close();
                MessageBox.Show("Yeni Gider başarılı bir şekilde eklendi", "Gider İşlemleri", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
                Temizle();

            }
            else
            {
                MessageBox.Show("ID alanı Giderler eklenirken otomatik olarak atanmaktadır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            TxtID.Text = dr["ID"].ToString();
            TxtTarih.Value = Convert.ToDateTime(dr["TARIH"]);
            TxtElektrik.Text = dr["ELEKTIRIK"].ToString();
            TxtSu.Text = dr["SU"].ToString();
            TxtDogalgaz.Text = dr["DOGALGAZ"].ToString();
            TxtInternet.Text = dr["INTERNET"].ToString();
            TxtEkstra.Text = dr["EKSTRA"].ToString();
            TxtMaaslar.Text = dr["MAASLAR"].ToString(); ;
            RchNot.Text = dr["NOTLAR"].ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand sql = new SqlCommand("Delete From TBL_GIDERLER where ID=@p1", dbconn.connection());
            sql.Parameters.AddWithValue("@p1", TxtID.Text);
            sql.ExecuteNonQuery();
            dbconn.connection().Close();
            MessageBox.Show("Gider başarılı bir şekilde silindi", "Gider Silme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Listele();
            Temizle();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand sql = new SqlCommand("Update TBL_GIDERLER set " +
                "TARIH=@p1,ELEKTIRIK=@p2,SU=@p3,DOGALGAZ=@p4,INTERNET=@p5,EKSTRA=@p6,MAASLAR=@p7,NOTLAR=@p8 where ID=@p9", dbconn.connection());
            sql.Parameters.AddWithValue("@p1", TxtTarih.Value);
            sql.Parameters.AddWithValue("@p2", decimal.Parse(TxtElektrik.Text));
            sql.Parameters.AddWithValue("@p3", decimal.Parse(TxtSu.Text));
            sql.Parameters.AddWithValue("@p4", decimal.Parse(TxtDogalgaz.Text));
            sql.Parameters.AddWithValue("@p5", decimal.Parse(TxtInternet.Text));
            sql.Parameters.AddWithValue("@p6", decimal.Parse(TxtEkstra.Text));
            sql.Parameters.AddWithValue("@p7", decimal.Parse(TxtMaaslar.Text));
            sql.Parameters.AddWithValue("@p8", RchNot.Text);
            sql.Parameters.AddWithValue("@p9", TxtID.Text);
            sql.ExecuteNonQuery();
            dbconn.connection().Close();
            MessageBox.Show("Gider başarılı bir şekilde güncellendi", "Gider İşlemleri", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            Temizle();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

       
    }
}
