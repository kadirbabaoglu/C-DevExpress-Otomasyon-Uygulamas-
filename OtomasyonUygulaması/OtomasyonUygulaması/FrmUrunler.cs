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
    public partial class FrmUrunler : Form
    {
        public FrmUrunler()
        {
            InitializeComponent();
        }

        dbConnection dbconn = new dbConnection();

        public void Listele()
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * from TBL_URUNLER" , dbconn.connection());
            sqlDataAdapter.Fill(dataTable);
            gridControl1.DataSource = dataTable;
        }

        private void FrmUrunler_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(TxtID.Text))
            {
                SqlCommand Sql = new SqlCommand("insert into TBL_URUNLER (URUNAD,MARKA,MODEL,YIL,ADET,ALISFIYAT,SATISFIYAT,DETAY) values " +
                "(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", dbconn.connection());
                Sql.Parameters.AddWithValue("@p1", TxtAd.Text);
                Sql.Parameters.AddWithValue("@p2", txtMarka.Text);
                Sql.Parameters.AddWithValue("@p3", TxtModel.Text);
                Sql.Parameters.AddWithValue("@p4", MaskYıl.Text);
                Sql.Parameters.AddWithValue("@p5", int.Parse(NuAdet.Value.ToString()));
                Sql.Parameters.AddWithValue("@p6", decimal.Parse(TxtAlisFiyat.Text));
                Sql.Parameters.AddWithValue("@p7", decimal.Parse(TxtSatisFiyat.Text));
                Sql.Parameters.AddWithValue("@p8", RichDetay.Text);
                Sql.ExecuteNonQuery();
                dbconn.connection().Close();
                MessageBox.Show("Yeni Ürün Başarı ile Eklendi", "Yeni Ürün Ekleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
                TxtAd.Clear();
                txtMarka.Clear();
                TxtModel.Clear();
                MaskYıl.Clear();
                NuAdet.ResetText();
                TxtAlisFiyat.Clear();
                TxtSatisFiyat.Clear();
                RichDetay.Clear();

            }
            else
            {
                MessageBox.Show("ID alanı ürün eklenirken otomatik olarak atanmaktadır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand sql = new SqlCommand("Delete From TBL_URUNLER where ID=@p1" , dbconn.connection());
            sql.Parameters.AddWithValue("@p1", TxtID.Text);
            sql.ExecuteNonQuery();
            dbconn.connection().Close();
            MessageBox.Show("Ürün başarılı bir şekilde silindi", "Ürün Silme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Listele();
            TxtID.Clear();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            
            TxtID.Text = dr["ID"].ToString();
            TxtAd.Text = dr["URUNAD"].ToString();
            txtMarka.Text = dr["MARKA"].ToString();
            TxtModel.Text = dr["MODEL"].ToString();
            MaskYıl.Text = dr["YIL"].ToString();
            NuAdet.Value = decimal.Parse(dr["ADET"].ToString());
            TxtAlisFiyat.Text = dr["ALISFIYAT"].ToString();
            TxtSatisFiyat.Text = dr["SATISFIYAT"].ToString();
            RichDetay.Text = dr["DETAY"].ToString();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            TxtID.Clear();
            TxtAd.Clear();
            txtMarka.Clear();
            TxtModel.Clear();
            MaskYıl.Clear();
            NuAdet.ResetText();
            TxtAlisFiyat.Clear();
            TxtSatisFiyat.Clear();
            RichDetay.Clear();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand Sql = new SqlCommand("Update TBL_URUNLER set " +
                "URUNAD=@P1, MARKA=@P2,MODEL=@P3,YIL=@P4,ADET=@P5,ALISFIYAT=@P6,SATISFIYAT=@P7, DETAY=@P8 WHERE ID=@P9", dbconn.connection());
            Sql.Parameters.AddWithValue("@P1", TxtAd.Text);
            Sql.Parameters.AddWithValue("@P2", txtMarka.Text);
            Sql.Parameters.AddWithValue("@P3", TxtModel.Text);
            Sql.Parameters.AddWithValue("@P4", MaskYıl.Text);
            Sql.Parameters.AddWithValue("@P5", int.Parse(NuAdet.Value.ToString()));
            Sql.Parameters.AddWithValue("@P6", decimal.Parse(TxtAlisFiyat.Text));
            Sql.Parameters.AddWithValue("@P7", decimal.Parse(TxtSatisFiyat.Text));
            Sql.Parameters.AddWithValue("@P8", RichDetay.Text);
            Sql.Parameters.AddWithValue("@P9", TxtID.Text);
            Sql.ExecuteNonQuery();
            dbconn.connection().Close();

            MessageBox.Show("Ürün başarılı bir şekilde güncellendi", "Ürün Güncelleme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }
    }
}
