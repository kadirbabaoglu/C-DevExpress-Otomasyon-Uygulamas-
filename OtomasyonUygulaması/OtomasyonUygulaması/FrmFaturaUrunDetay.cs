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
    public partial class FrmFaturaUrunDetay : Form
    {
        public FrmFaturaUrunDetay()
        {
            InitializeComponent();
        }

        dbConnection dbconn = new dbConnection();

        public string id;

        void temizle()
        {
            Tad.Clear();
            Tmiktar.Clear();
            Tfiyat.Clear();
            Tfaturaid.Clear();
        }

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sqldata = new SqlDataAdapter("Select * From TBL_FATURADETAY where FATURAID='" + id + "'", dbconn.connection());
            sqldata.Fill(dt);  
            gridControl1.DataSource = dt;

            
        }

        private void FrmFaturaUrunDetay_Load(object sender, EventArgs e)
        {
            listele();
  
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if(dr != null)
            {
                Tid.Text = dr["FATURAURUNID"].ToString();
                Tad.Text = dr["URUNAD"].ToString();
                Tmiktar.Text = dr["MIKTAR"].ToString();
                Tfiyat.Text = dr["FIYAT"].ToString();
                Tfaturaid.Text = dr["FATURAID"].ToString();
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("Delete From TBL_FATURADETAY where FATURAURUNID=@p1",dbconn.connection());
            sqlCommand.Parameters.AddWithValue("@p1" , Tid.Text);
            sqlCommand.ExecuteNonQuery();
            dbconn.connection().Close();
            MessageBox.Show("Gider başarılı bir şekilde silindi", "Gider Silme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
            temizle();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            double fiyat, tutar, miktar;
            miktar = Convert.ToDouble(Tmiktar.Text);
            fiyat = Convert.ToDouble(Tfiyat.Text);
            tutar = fiyat * miktar;


               
                SqlCommand sql = new SqlCommand("Update TBL_FATURADETAY set " +
                "URUNAD=@p1,MIKTAR=@p2,FIYAT=@p3,TUTAR=@p4,FATURAID=@p5 where FATURAURUNID=@p6", dbconn.connection());
                sql.Parameters.AddWithValue("@p1", Tad.Text);
                sql.Parameters.AddWithValue("@p2", Tmiktar.Text);
                sql.Parameters.AddWithValue("@p3", decimal.Parse(Tfiyat.Text));
                sql.Parameters.AddWithValue("@p4", tutar.ToString());
                sql.Parameters.AddWithValue("@p5", Tfaturaid.Text);
                sql.Parameters.AddWithValue("@p6", Tid.Text);

                sql.ExecuteNonQuery();
                dbconn.connection().Close();
                MessageBox.Show("Faturaya ait ürün başarılı bir şekilde eklendi", "Fatura İşlemleri", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
                temizle();

            
        }
    }
}
