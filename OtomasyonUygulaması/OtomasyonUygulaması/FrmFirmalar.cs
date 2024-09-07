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
using System.Windows;
using System.Windows.Forms;

namespace OtomasyonUygulaması
{
    public partial class FrmFirmalar : Form
    {
        public FrmFirmalar()
        {
            InitializeComponent();
        }

        dbConnection dbconn = new dbConnection();

        void Listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sql = new SqlDataAdapter("select * from TBL_FIRMALAR",dbconn.connection());
            sql.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void SehirListele()
        {
            SqlCommand sql = new SqlCommand("Select SEHIR from TBL_ILLER", dbconn.connection());
            SqlDataReader reader = sql.ExecuteReader();
            while (reader.Read())
            {
                cmbil.Properties.Items.Add(reader[0]);
            }
            reader.Close();
            dbconn.connection().Close();
        }

        void Temizle()
        {
            TxtId.Clear();
            TxtAd.Clear();
            TxtSoyad.Clear();
            TxtYetkili.Clear();
            TxtGorev.Clear();
            TxtSektor.Clear();
            MskTc.Clear();
            MskTelefon1.Clear();
            MskTelefon2.Clear();
            MskTelefon3.Clear();
            MskFax.Clear();
            TxtMail.Clear();
            cmbil.Clear();
            cmbilce.Clear();
            TxtVergiDaire.Clear();
            RichAdres.Clear();
            TxtKod1.Clear();
            TxtKod2.Clear();
            TxtKod3.Clear();

        }

        private void FrmFirmalar_Load(object sender, EventArgs e)
        {
            Listele();
            SehirListele();
        }

        private void cmbil_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbilce.Properties.Items.Clear();
            SqlCommand sql = new SqlCommand("select ILCE from TBL_ILCELER where SEHIR=@p1",dbconn.connection());
            sql.Parameters.AddWithValue("@p1" , cmbil.SelectedIndex + 1);
            SqlDataReader reader = sql.ExecuteReader();
            while (reader.Read()) 
            {
                cmbilce.Properties.Items.Add(reader[0]);
            }
            reader.Close();
            dbconn.connection().Close();

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtId.Text))
            {
                SqlCommand sql = new SqlCommand("Insert Into TBL_FIRMALAR (YETKILISTATU,YETKILIAD,YETKILISOYAD,YETKILITC,SEKTOR,TELEFON,TELEFON1,TELEFON2,FAX,MAIL,IL,ILCE,VERGIDAIRE,ADRES,OZELKOD1,OZELKOD2,OZELKOD3) values" +
                "(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17)", dbconn.connection());
                sql.Parameters.AddWithValue("@p1", TxtGorev.Text);
                sql.Parameters.AddWithValue("@p2", TxtAd.Text);
                sql.Parameters.AddWithValue("@p3", TxtSoyad.Text);
                sql.Parameters.AddWithValue("@p4", MskTc.Text);
                sql.Parameters.AddWithValue("@p5", TxtSektor.Text);
                sql.Parameters.AddWithValue("@p6", MskTelefon1.Text);
                sql.Parameters.AddWithValue("@p7", MskTelefon2.Text);
                sql.Parameters.AddWithValue("@p8", MskTelefon3.Text);
                sql.Parameters.AddWithValue("@p9", MskFax.Text);
                sql.Parameters.AddWithValue("@p10", TxtMail.Text);
                sql.Parameters.AddWithValue("@p11", cmbil.Text);
                sql.Parameters.AddWithValue("@p12", cmbilce.Text);
                sql.Parameters.AddWithValue("@p13", TxtVergiDaire.Text);
                sql.Parameters.AddWithValue("@p14", RichAdres.Text);
                sql.Parameters.AddWithValue("@p15", TxtKod1.Text);
                sql.Parameters.AddWithValue("@p16", TxtKod2.Text);
                sql.Parameters.AddWithValue("@p17", TxtKod3.Text);
                sql.ExecuteNonQuery();
                dbconn.connection().Close();
                MessageBox.Show("Yeni Firma başarılı bir şekilde eklendi", "Firma İşlemleri", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
                Temizle();

            }
            else
            {
                MessageBox.Show("ID alanı Firma eklenirken otomatik olarak atanmaktadır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand sql = new SqlCommand("Delete From TBL_FIRMALAR where ID=@p1", dbconn.connection());
            sql.Parameters.AddWithValue("@p1", TxtId.Text);
            sql.ExecuteNonQuery();
            dbconn.connection().Close();
            MessageBox.Show("Firma başarılı bir şekilde silindi", "Firma Silme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Listele();
            Temizle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            TxtId.Text = dr["ID"].ToString();
            TxtGorev.Text = dr["YETKILISTATU"].ToString();
            TxtAd.Text = dr["YETKILIAD"].ToString();
            TxtSoyad.Text = dr["YETKILISOYAD"].ToString();
            MskTc.Text = dr["YETKILITC"].ToString();
            TxtSektor.Text = dr["SEKTOR"].ToString();
            MskTelefon1.Text = dr["TELEFON"].ToString();
            MskTelefon2.Text = dr["TELEFON1"].ToString();
            MskTelefon3.Text = dr["TELEFON2"].ToString();
            MskFax.Text = dr["FAX"].ToString();
            TxtMail.Text = dr["MAIL"].ToString();
            cmbil.Text = dr["IL"].ToString();
            cmbilce.Text = dr["ILCE"].ToString();
            TxtVergiDaire.Text = dr["VERGIDAIRE"].ToString();
            RichAdres.Text = dr["ADRES"].ToString();
            TxtKod1.Text = dr["OZELKOD1"].ToString();
            TxtKod2.Text = dr["OZELKOD2"].ToString();
            TxtKod3.Text = dr["OZELKOD3"].ToString();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand sql = new SqlCommand("Update TBL_FIRMALAR set YETKILISTATU=@p1,YETKILIAD=@p2,YETKILISOYAD=@p3,YETKILITC=@p4,SEKTOR=@p5,TELEFON=@p6,TELEFON1=@p7,TELEFON2=@p8,FAX=@p9,MAIL=@p10,IL=@p11,ILCE=@p12,VERGIDAIRE=@p13,ADRES=@p14,OZELKOD1=@p15,OZELKOD2=@p16,OZELKOD3=@p17 where ID=@p18 ", dbconn.connection());
            sql.Parameters.AddWithValue("@p1", TxtGorev.Text);
            sql.Parameters.AddWithValue("@p2", TxtAd.Text);
            sql.Parameters.AddWithValue("@p3", TxtSoyad.Text);
            sql.Parameters.AddWithValue("@p4", MskTc.Text);
            sql.Parameters.AddWithValue("@p5", TxtSektor.Text);
            sql.Parameters.AddWithValue("@p6", MskTelefon1.Text);
            sql.Parameters.AddWithValue("@p7", MskTelefon2.Text);
            sql.Parameters.AddWithValue("@p8", MskTelefon3.Text);
            sql.Parameters.AddWithValue("@p9", MskFax.Text);
            sql.Parameters.AddWithValue("@p10", TxtMail.Text);
            sql.Parameters.AddWithValue("@p11", cmbil.Text);
            sql.Parameters.AddWithValue("@p12", cmbilce.Text);
            sql.Parameters.AddWithValue("@p13", TxtVergiDaire.Text);
            sql.Parameters.AddWithValue("@p14", RichAdres.Text);
            sql.Parameters.AddWithValue("@p15", TxtKod1.Text);
            sql.Parameters.AddWithValue("@p16", TxtKod2.Text);
            sql.Parameters.AddWithValue("@p17", TxtKod3.Text);
            sql.Parameters.AddWithValue("@p18", TxtId.Text);
            sql.ExecuteNonQuery();
            dbconn.connection().Close();
            MessageBox.Show("Yeni Firma başarılı bir şekilde güncellendi", "Firma İşlemleri", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            Temizle();
        }
    }
}
