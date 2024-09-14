using DevExpress.Utils.DirectXPaint.Svg;
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
    public partial class FrmFaturalar : Form
    {
        public FrmFaturalar()
        {
            InitializeComponent();
        }

        dbConnection dbconn = new dbConnection();

        void Listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * from TBL_FATURABILGI",dbconn.connection());
            sqlDataAdapter.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void temizle()
        {
            TxtSeri.Clear();
            TxtId.Clear();
            TxtSirano.Clear();
            TxtTarih.Value = DateTime.Now;
            TxtVergidairesi.Clear();
            TxtAlici.Clear();
            TxtTeslimeden.Clear();
            TxtTeslimalan.Clear();
            
        }

        private void FrmFaturalar_Load(object sender, EventArgs e)
        {
            Listele();
            temizle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            TxtId.Text = dr["FATURABILGIID"].ToString();
            TxtSeri.Text = dr["SERI"].ToString();
            TxtSirano.Text = dr["SIRANO"].ToString();
            TxtTarih.Value = Convert.ToDateTime(dr["TARIH"]);
            TxtVergidairesi.Text = dr["VERGIDAIRE"].ToString();
            TxtAlici.Text = dr["ALICI"].ToString();
            TxtTeslimeden.Text = dr["TESLIMEDEN"].ToString();
            TxtTeslimalan.Text = dr["TESLIMALAN"].ToString(); ;
        }

        private void btKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtId.Text))
            {
                SqlCommand sql = new SqlCommand("Insert Into TBL_FATURABILGI (SERI,SIRANO,TARIH,VERGIDAIRE,ALICI,TESLIMEDEN,TESLIMALAN) values" +
                "(@p1,@p2,@p3,@p4,@p5,@p6,@p7)", dbconn.connection());
                sql.Parameters.AddWithValue("@p1", TxtSeri.Text);
                sql.Parameters.AddWithValue("@p2", TxtSirano.Text);
                sql.Parameters.AddWithValue("@p3", TxtTarih.Value);
                sql.Parameters.AddWithValue("@p4", TxtVergidairesi.Text);
                sql.Parameters.AddWithValue("@p5", TxtAlici.Text);
                sql.Parameters.AddWithValue("@p6", TxtTeslimeden.Text);
                sql.Parameters.AddWithValue("@p7", TxtTeslimalan.Text);

                sql.ExecuteNonQuery();
                dbconn.connection().Close();
                MessageBox.Show("Yeni Fatura başarılı bir şekilde eklendi", "Fatura İşlemleri", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
                temizle();

            }
            else
            {
                MessageBox.Show("ID alanı Fatura eklenirken otomatik olarak atanmaktadır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand sql = new SqlCommand("Update TBL_FATURABILGI set " +
                "SERI=@p1,SIRANO=@p2,TARIH=@p3,VERGIDAIRE=@p4,ALICI=@p5,TESLIMEDEN=@p6,TESLIMALAN=@p7 where FATURABILGIID=@p8", dbconn.connection());
            sql.Parameters.AddWithValue("@p1", TxtSeri.Text);
            sql.Parameters.AddWithValue("@p2", TxtSirano.Text);
            sql.Parameters.AddWithValue("@p3", TxtTarih.Value);
            sql.Parameters.AddWithValue("@p4", TxtVergidairesi.Text);
            sql.Parameters.AddWithValue("@p5", TxtAlici.Text);
            sql.Parameters.AddWithValue("@p6", TxtTeslimeden.Text);
            sql.Parameters.AddWithValue("@p7", TxtTeslimalan.Text);
            sql.Parameters.AddWithValue("@p8", TxtId.Text);

            sql.ExecuteNonQuery();
            dbconn.connection().Close();
            MessageBox.Show("Fatura başarılı bir şekilde güncellendi", "Fatura İşlemleri", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            temizle();
        }

        private void btSil_Click(object sender, EventArgs e)
        {
            SqlCommand sql = new SqlCommand("Delete From TBL_FATURABILGI where FATURABILGIID=@p1", dbconn.connection());
            sql.Parameters.AddWithValue("@p1", TxtId.Text);
            sql.ExecuteNonQuery();
            dbconn.connection().Close();
            MessageBox.Show("Fatura başarılı bir şekilde silindi", "Fatura Silme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Listele();
            temizle();
        }

        private void btTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {

            double fiyat, tutar,miktar;
            miktar = Convert.ToDouble(Tmiktar.Text);
            fiyat = Convert.ToDouble(Tfiyat.Text);
            tutar = fiyat * miktar;
           

            if (string.IsNullOrEmpty(TxtId.Text))
            {
                SqlCommand sql = new SqlCommand("Insert Into TBL_FATURADETAY (URUNAD,MIKTAR,FIYAT,TUTAR,FATURAID) values" +
                "(@p1,@p2,@p3,@p4,@p5)", dbconn.connection());
                sql.Parameters.AddWithValue("@p1", Tad.Text);
                sql.Parameters.AddWithValue("@p2", Tmiktar.Text);
                sql.Parameters.AddWithValue("@p3", decimal.Parse(Tfiyat.Text));
                sql.Parameters.AddWithValue("@p4", tutar.ToString());
                sql.Parameters.AddWithValue("@p5", Tfaturaid.Text);

                sql.ExecuteNonQuery();
                dbconn.connection().Close();
                MessageBox.Show("Faturaya ait ürün başarılı bir şekilde eklendi", "Fatura İşlemleri", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
                temizle();

            }
            else
            {
                MessageBox.Show("ID alanı Fatura eklenirken otomatik olarak atanmaktadır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmFaturaUrunDetay frm = new FrmFaturaUrunDetay();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                frm.id = dr["FATURABILGIID"].ToString();
            }
            frm.Show();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Tad.Clear();
            Tmiktar.Clear();
            Tfiyat.Clear();
            Tfaturaid.Clear();
        }
    }
}
