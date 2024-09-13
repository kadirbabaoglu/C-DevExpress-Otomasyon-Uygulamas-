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
    public partial class FrmBankalar : Form
    {
        public FrmBankalar()
        {
            InitializeComponent();
        }

        dbConnection dbconn = new dbConnection();

        public void Listele()
        {
            DataTable dt = new DataTable();
            //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT BANKADI, TBL_BANKALAR.IL,TBL_BANKALAR.ILCE,SUBE,IBAN,HESAPNO,YETKILI,TBL_BANKALAR.TELEFON,TARIH,HESAPTURU,FIRMAAD \r\nFROM TBL_BANKALAR INNER JOIN TBL_FIRMALAR \r\nON TBL_BANKALAR.FIRMAID = TBL_FIRMALAR.ID", dbconn.connection());
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Execute BankalarListesi", dbconn.connection());
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

        private void Firmalistesi()
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select ID,FIRMAAD from TBL_FIRMALAR", dbconn.connection());
            sqlDataAdapter.Fill(dataTable);
            TxtFirma.Properties.ValueMember = "ID";
            TxtFirma.Properties.DisplayMember = "FIRMAAD";
            TxtFirma.Properties.DataSource = dataTable;
        }

        void temizle()
        {
            TxtID.Clear();
            TxtBankaAdi.Clear();
            cmbil.Clear();
            cmbilce.Clear();
            TxtSube.Clear();
            MskIban.Clear();
            MskHesapNo.Clear();
            TxtYetkili.Clear();
            MskTelefon.Clear();
            TxtTarih.Value = DateTime.Now;
            TxtHesapTuru.Clear();
            TxtFirma.EditValue = null;
        }
        private void FrmBankalar_Load(object sender, EventArgs e)
        {
            Listele();
            sehirListele();
            temizle();
            Firmalistesi();
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

            sqlDataReader.Close();
            dbconn.connection().Close();
        }

      

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtID.Text))
            {
                SqlCommand sql = new SqlCommand("Insert Into TBL_BANKALAR (BANKADI,IL,ILCE,SUBE,IBAN,HESAPNO,YETKILI,TELEFON,TARIH,HESAPTURU,FIRMAID) values" +
                "(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)", dbconn.connection());
                sql.Parameters.AddWithValue("@p1", TxtBankaAdi.Text);
                sql.Parameters.AddWithValue("@p2", cmbil.Text);
                sql.Parameters.AddWithValue("@p3", cmbilce.Text);
                sql.Parameters.AddWithValue("@p4", TxtSube.Text);
                sql.Parameters.AddWithValue("@p5", MskIban.Text);
                sql.Parameters.AddWithValue("@p6", MskHesapNo.Text);
                sql.Parameters.AddWithValue("@p7", TxtYetkili.Text);
                sql.Parameters.AddWithValue("@p8", MskTelefon.Text);
                sql.Parameters.AddWithValue("@p9", TxtTarih.Value);
                sql.Parameters.AddWithValue("@p10", TxtHesapTuru.Text);
                sql.Parameters.AddWithValue("@p11", TxtFirma.EditValue);
                sql.ExecuteNonQuery();
                dbconn.connection().Close();
                MessageBox.Show("Yeni Banka başarılı bir şekilde eklendi", "Banka İşlemleri", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
                temizle();

            }
            else
            {
                MessageBox.Show("ID alanı Banka eklenirken otomatik olarak atanmaktadır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand sql = new SqlCommand("Delete From TBL_BANKALAR where ID=@p1", dbconn.connection());
            sql.Parameters.AddWithValue("@p1", TxtID.Text);
            sql.ExecuteNonQuery();
            dbconn.connection().Close();
            MessageBox.Show("Banka başarılı bir şekilde silindi", "Banla Silme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Listele();
            temizle();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(TxtFirma.EditValue?.ToString()))
            {
                MessageBox.Show("Lütfen bir firma seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

            SqlCommand sql = new SqlCommand("Update TBL_BANKALAR set " +
               "BANKADI=@p1,IL=@p2,ILCE=@p3,SUBE=@p4,IBAN=@p5,HESAPNO=@p6,YETKILI=@p7,TELEFON=@p8,TARIH=@p9,HESAPTURU=@p10,FIRMAID=@p11 where ID=@p12", dbconn.connection());
            sql.Parameters.AddWithValue("@p1", TxtBankaAdi.Text);
            sql.Parameters.AddWithValue("@p2", cmbil.Text);
            sql.Parameters.AddWithValue("@p3", cmbilce.Text);
            sql.Parameters.AddWithValue("@p4", TxtSube.Text);
            sql.Parameters.AddWithValue("@p5", MskIban.Text);
            sql.Parameters.AddWithValue("@p6", MskHesapNo.Text);
            sql.Parameters.AddWithValue("@p7", TxtYetkili.Text);
            sql.Parameters.AddWithValue("@p8", MskTelefon.Text);
            sql.Parameters.AddWithValue("@p9", TxtTarih.Value);
            sql.Parameters.AddWithValue("@p10", TxtHesapTuru.Text);
            sql.Parameters.AddWithValue("@p11", TxtFirma.EditValue);
            sql.Parameters.AddWithValue("@p12", TxtID.Text);
            sql.ExecuteNonQuery();
            dbconn.connection().Close();
            MessageBox.Show("Gider başarılı bir şekilde güncellendi", "Gider İşlemleri", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            temizle();

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            TxtID.Text = dr["ID"].ToString();
            TxtBankaAdi.Text = dr["BANKADI"].ToString();
            cmbil.Text = dr["IL"].ToString();
            cmbilce.Text = dr["ILCE"].ToString();
            TxtSube.Text = dr["SUBE"].ToString();
            MskIban.Text = dr["IBAN"].ToString();
            MskHesapNo.Text = dr["HESAPNO"].ToString();
            TxtYetkili. Text = dr["YETKILI"].ToString();
            MskTelefon.Text = dr["TELEFON"].ToString();
            TxtTarih.Value = Convert.ToDateTime(dr["TARIH"]);
            TxtHesapTuru.Text = dr["HESAPTURU"].ToString();
            TxtFirma.EditValue = null;
        }
    }
}
