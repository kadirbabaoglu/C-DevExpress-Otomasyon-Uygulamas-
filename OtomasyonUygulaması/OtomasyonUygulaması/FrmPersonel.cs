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
    public partial class FrmPersonel : Form
    {
        public FrmPersonel()
        {
            InitializeComponent();
        }

        dbConnection dbconn = new dbConnection();

        public void Listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * From TBL_PERSONELLER", dbconn.connection());
            sqlDataAdapter.Fill(dt);
            gridControl1.DataSource = dt;
        }

        public void sehirListele()
        {
            var connection = dbconn.connection();
            SqlCommand sqlCommand = new SqlCommand("Select SEHIR from TBL_ILLER", connection);
            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                cmbil.Properties.Items.Add(reader[0]);
            }

            reader.Close();
            connection.Close();
        }

        void temizle()
        {
            TxtID.Clear();
            TxtAd.Clear();
            TxtSoyad.Clear();
            MaskTelefon.Clear();
            MaskTc.Clear();
            TxtMail.Clear();
            cmbil.Clear();
            cmbilce.Clear();
            TxtGorev.Clear();
            RichAdres.Clear();
        }


        private void FrmPersonel_Load(object sender, EventArgs e)
        {
            Listele();
            sehirListele();
            temizle();
        }


        private void cmbil_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            cmbilce.Properties.Items.Clear();

            SqlCommand sql = new SqlCommand("Select ILCE from TBL_ILCELER where SEHIR=@p1", dbconn.connection());
            sql.Parameters.AddWithValue("@p1", cmbil.SelectedIndex + 1);

            SqlDataReader sqlDataReader = sql.ExecuteReader();

            while (sqlDataReader.Read())
            {
                cmbilce.Properties.Items.Add(sqlDataReader[0]);
            }

            sqlDataReader.Close();
            dbconn.connection().Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtID.Text))
            {
                SqlCommand sql = new SqlCommand("Insert Into TBL_PERSONELLER (AD,SOYAD,TELEFON,TC,MAIL,IL,ILCE,ADRES,GOREV) values" +
                "(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", dbconn.connection());
                sql.Parameters.AddWithValue("@p1", TxtAd.Text);
                sql.Parameters.AddWithValue("@p2", TxtSoyad.Text);
                sql.Parameters.AddWithValue("@p3", MaskTelefon.Text);
                sql.Parameters.AddWithValue("@p4", MaskTc.Text);
                sql.Parameters.AddWithValue("@p5", TxtMail.Text);
                sql.Parameters.AddWithValue("@p6", cmbil.Text);
                sql.Parameters.AddWithValue("@p7", cmbilce.Text);
                sql.Parameters.AddWithValue("@p8", RichAdres.Text);
                sql.Parameters.AddWithValue("@p9", TxtGorev.Text);
                sql.ExecuteNonQuery();
                dbconn.connection().Close();
                MessageBox.Show("Yeni Personel başarılı bir şekilde eklendi", "Personel İşlemleri", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
                temizle();

            }
            else
            {
                MessageBox.Show("ID alanı Personel eklenirken otomatik olarak atanmaktadır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand sql = new SqlCommand("Delete from TBL_PERSONELLER where ID=@p1", dbconn.connection());
            sql.Parameters.AddWithValue("@p1", TxtID.Text);
            sql.ExecuteNonQuery();
            dbconn.connection().Close();
            MessageBox.Show("PERSONEL başarılı bir şekilde silindi", "Personel Silme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Listele();
            temizle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            TxtID.Text = dr["ID"].ToString();
            TxtAd.Text= dr["AD"].ToString();
            TxtSoyad.Text= dr["SOYAD"].ToString();
            MaskTelefon.Text = dr["TELEFON"].ToString();
            MaskTc.Text = dr["TC"].ToString();
            TxtMail.Text = dr["MAIL"].ToString();
            cmbil.Text= dr["IL"].ToString();
            cmbilce.Text= dr["ILCE"].ToString();
            TxtGorev.Text= dr["ADRES"].ToString();
            RichAdres.Text= dr["GOREV"].ToString();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand sql = new SqlCommand("Update TBL_PERSONELLER set " +
                "AD=@p1,SOYAD=@p2,TELEFON=@p3,TC=@p4,MAIL=@p5,IL=@p6,ILCE=@p7,ADRES=@p8,GOREV=@p9 where ID=@p10", dbconn.connection());
            sql.Parameters.AddWithValue("@p1", TxtAd.Text);
            sql.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            sql.Parameters.AddWithValue("@p3", MaskTelefon.Text);
            sql.Parameters.AddWithValue("@p4", MaskTc.Text);
            sql.Parameters.AddWithValue("@p5", TxtMail.Text);
            sql.Parameters.AddWithValue("@p6", cmbil.Text);
            sql.Parameters.AddWithValue("@p7", cmbilce.Text);
            sql.Parameters.AddWithValue("@p8", RichAdres.Text);
            sql.Parameters.AddWithValue("@p9", TxtGorev.Text);
            sql.Parameters.AddWithValue("@p10", TxtID.Text);
            sql.ExecuteNonQuery();
            dbconn.connection().Close();
            MessageBox.Show("Yeni Personel başarılı bir şekilde güncellendi", "Personel İşlemleri", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }
    }
}
