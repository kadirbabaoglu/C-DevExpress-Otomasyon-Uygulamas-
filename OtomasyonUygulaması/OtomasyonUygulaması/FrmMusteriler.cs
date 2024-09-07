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
    public partial class FrmMusteriler : Form
    {
        public FrmMusteriler()
        {
            InitializeComponent();
        }

        dbConnection dbconn = new dbConnection();

        public void Listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * From TBL_MUSTERILER" , dbconn.connection());
            sqlDataAdapter.Fill(dt);
            gridControl1.DataSource = dt;
        }

        public void sehirListele()
        {
            var connection = dbconn.connection(); // Bağlantıyı bir kez açıyoruz
            SqlCommand sqlCommand = new SqlCommand("Select SEHIR from TBL_ILLER", connection);
            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                cmbil.Properties.Items.Add(reader[0]); 
            }

            reader.Close(); // SqlDataReader'ı kapatıyoruz
            connection.Close(); // Bağlantıyı kapatıyoruz
        }

        void temizle()
        {
            TxtID.Clear();
            TxtAd.Clear();
            TxtSoyad.Clear();
            MaskTelefon.Clear();
            MaskTelefon2.Clear();
            MaskTc.Clear();
            TxtMail.Clear();
            cmbil.Clear();
            cmbilce.Clear();
            TxtVergiDaire.Clear();
            RichAdres.Clear();
        }

        private void FrmMusteriler_Load(object sender, EventArgs e)
        {
            Listele();
            sehirListele();


        }


        private void cmbil_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbilce.Properties.Items.Clear();

            SqlCommand sql = new SqlCommand("Select ILCE from TBL_ILCELER where SEHIR=@p1", dbconn.connection());
            sql.Parameters.AddWithValue("@p1", cmbil.SelectedIndex + 1);

            SqlDataReader sqlDataReader = sql.ExecuteReader();

            while (sqlDataReader.Read())
            {
                cmbilce.Properties.Items.Add(sqlDataReader[0]);
            }

            sqlDataReader.Close(); // SqlDataReader'ı kapat
            dbconn.connection().Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtID.Text))
            {
                SqlCommand sql = new SqlCommand("Insert Into TBL_MUSTERILER (AD,SOYAD,TELEFON,TELEFON2,TC,MAIL,IL,ILCE,VERGIDAIRE,ADRES) values" +
                "(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)", dbconn.connection());
            sql.Parameters.AddWithValue("@p1" , TxtAd.Text);
            sql.Parameters.AddWithValue("@p2" , TxtSoyad.Text);
            sql.Parameters.AddWithValue("@p3" , MaskTelefon.Text);
            sql.Parameters.AddWithValue("@p4" , MaskTelefon2.Text);
            sql.Parameters.AddWithValue("@p5" , MaskTc.Text);
            sql.Parameters.AddWithValue("@p6" , TxtMail.Text);
            sql.Parameters.AddWithValue("@p7" , cmbil.Text);
            sql.Parameters.AddWithValue("@p8" , cmbilce.Text);
            sql.Parameters.AddWithValue("@p9" , TxtVergiDaire.Text);
            sql.Parameters.AddWithValue("@p10" , RichAdres.Text);
            sql.ExecuteNonQuery();
            dbconn.connection().Close();
            MessageBox.Show("Yeni Müşteri başarılı bir şekilde eklendi" , "Müşteri İşlemleri" , MessageBoxButtons.OK , MessageBoxIcon.Information);
            Listele();
            temizle();
             
            }
            else
            {
                MessageBox.Show("ID alanı Müşteri eklenirken otomatik olarak atanmaktadır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand sql = new SqlCommand("Delete from TBL_MUSTERILER where ID=@p1",dbconn.connection());
            sql.Parameters.AddWithValue("@p1" , TxtID.Text);
            sql.ExecuteNonQuery();
            dbconn.connection().Close();
            MessageBox.Show("Müşteri başarılı bir şekilde silindi", "Müşteri Silme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Listele();
            temizle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            TxtID.Text = dr["ID"].ToString();
            TxtAd.Text = dr["AD"].ToString();
            TxtSoyad.Text = dr["SOYAD"].ToString();
            MaskTelefon.Text = dr["TELEFON"].ToString();
            MaskTelefon2.Text = dr["TELEFON2"].ToString();
            MaskTc.Text = dr["TC"].ToString();
            TxtMail.Text = dr["MAIL"].ToString();
            cmbil.Text = dr["IL"].ToString();
            cmbilce.Text = dr["ILCE"].ToString();
            TxtVergiDaire.Text = dr["VERGIDAIRE"].ToString();
            RichAdres.Text = dr["ADRES"].ToString();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand sql = new SqlCommand("Update TBL_MUSTERILER set " +
                "AD=@p1,SOYAD=@p2,TELEFON=@p3,TELEFON2=@p4,TC=@p5,MAIL=@p6,IL=@p7,ILCE=@p8,VERGIDAIRE=@p9,ADRES=@p10 where ID=@p11", dbconn.connection());
            sql.Parameters.AddWithValue("@p1", TxtAd.Text);
            sql.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            sql.Parameters.AddWithValue("@p3", MaskTelefon.Text);
            sql.Parameters.AddWithValue("@p4", MaskTelefon2.Text);
            sql.Parameters.AddWithValue("@p5", MaskTc.Text);
            sql.Parameters.AddWithValue("@p6", TxtMail.Text);
            sql.Parameters.AddWithValue("@p7", cmbil.Text);
            sql.Parameters.AddWithValue("@p8", cmbilce.Text);
            sql.Parameters.AddWithValue("@p9", TxtVergiDaire.Text);
            sql.Parameters.AddWithValue("@p10", RichAdres.Text);
            sql.Parameters.AddWithValue("@p11",TxtID.Text);
            sql.ExecuteNonQuery();
            dbconn.connection().Close();
            MessageBox.Show("Yeni Müşteri başarılı bir şekilde güncellendi", "Müşteri İşlemleri", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }
    }
}
