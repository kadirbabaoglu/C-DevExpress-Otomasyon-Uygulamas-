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
    public partial class FrmNotlar : Form
    {
        public FrmNotlar()
        {
            InitializeComponent();
        }

        dbConnection dbconn = new dbConnection();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sql = new SqlDataAdapter("Select * From TBL_NOTLAR" , dbconn.connection());
            sql.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void temizle()
        {
            TxtID.Clear();
            TxtTarih.Value = DateTime.Now;
            TxtKimden.Clear();
            TxtKime.Clear();
            TxtBaslik.Clear();
            TxtDetay.Clear();
        }

        private void FrmNotlar_Load(object sender, EventArgs e)
        {
            listele();
            temizle();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(TxtID.Text))
            {
                SqlCommand sql = new SqlCommand("Insert Into TBL_NOTLAR (TARIH,KIMDEN,KIME,BASLIK,DETAY) values" +
                "(@p1,@p2,@p3,@p4,@p5)", dbconn.connection());
                sql.Parameters.AddWithValue("@p1", TxtTarih.Value);
                sql.Parameters.AddWithValue("@p2", TxtKimden.Text);
                sql.Parameters.AddWithValue("@p3", TxtKime.Text);
                sql.Parameters.AddWithValue("@p4", TxtBaslik.Text);
                sql.Parameters.AddWithValue("@p5", TxtDetay.Text);
                sql.ExecuteNonQuery();
                dbconn.connection().Close();
                MessageBox.Show("Yeni Not başarılı bir şekilde eklendi", "Not İşlemleri", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
                temizle();
            }
            else
            {
                MessageBox.Show("ID alanı Notlar eklenirken otomatik olarak atanmaktadır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                TxtID.Text = dr["ID"].ToString();
                TxtTarih.Value = Convert.ToDateTime(dr["TARIH"]);
                TxtKimden.Text = dr["KIMDEN"].ToString();
                TxtKime.Text = dr["KIME"].ToString();
                TxtBaslik.Text = dr["BASLIK"].ToString();
                TxtDetay.Text = dr["DETAY"].ToString();
            }

        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand sql = new SqlCommand("Delete From TBL_NOTLAR where ID=@p1", dbconn.connection());
            sql.Parameters.AddWithValue("@p1", TxtID.Text);
            sql.ExecuteNonQuery();
            dbconn.connection().Close();
            MessageBox.Show("NOT başarılı bir şekilde silindi", "NOT Silme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
            temizle();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand sql = new SqlCommand("update TBL_NOTLAR set TARIH=@p1,KIMDEN=@p2,KIME=@p3,BASLIK=@p4,DETAY=@p5 where ID=@p6",dbconn.connection());
            sql.Parameters.AddWithValue("@p1", TxtTarih.Value);
            sql.Parameters.AddWithValue("@p2", TxtKimden.Text);
            sql.Parameters.AddWithValue("@p3", TxtKime.Text);
            sql.Parameters.AddWithValue("@p4", TxtBaslik.Text);
            sql.Parameters.AddWithValue("@p5", TxtDetay.Text);
            sql.Parameters.AddWithValue("@p6", TxtID.Text);
            sql.ExecuteNonQuery();
            dbconn.connection().Close();
            MessageBox.Show("Not başarılı bir şekilde güncellendi", "Not İşlemleri", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle();
        }
    }
}
