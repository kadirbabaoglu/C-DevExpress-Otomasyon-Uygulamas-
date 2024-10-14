using DevExpress.XtraRichEdit.Import.OpenXml;
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
    public partial class FrmAyarlar : Form
    {
        public FrmAyarlar()
        {
            InitializeComponent();
        }

        dbConnection dbconn = new dbConnection();


        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sql = new SqlDataAdapter("Select * From TBL_ADMIN" , dbconn.connection());
            sql.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void temizle()
        {
            Tid.Clear();
            TkullaniciAdi.Clear();
            Tsifre.Clear();
            Crol.Clear();
        }

        private void FrmAyarlar_Load(object sender, EventArgs e)
        {
            listele();
            temizle();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Tid.Text))
            {
                SqlCommand sql = new SqlCommand("Insert Into TBL_ADMIN (KULLANICIADI,SIFRE,ROLE) values (@p1,@p2,@p3)",dbconn.connection());
                sql.Parameters.AddWithValue("@p1", TkullaniciAdi.Text);
                sql.Parameters.AddWithValue("@p2", Tsifre.Text);
                sql.Parameters.AddWithValue("@p3", Crol.Text);
                sql.ExecuteNonQuery();
                dbconn.connection().Close();
                MessageBox.Show("Yeni Kullanıcı başarılı bir şekilde eklendi", "Kullanıcı İşlemleri", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
                temizle();
            }   
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                Tid.Text = dr["ID"].ToString();
                TkullaniciAdi.Text = dr["KULLANICIADI"].ToString();
                Tsifre.Text = dr["SIFRE"].ToString();
                Crol.Text = dr["ROLE"].ToString();
            }
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete From TBL_ADMIN where ID=@p1" , dbconn.connection());
            cmd.Parameters.AddWithValue("@p1" , Tid.Text);
            cmd.ExecuteNonQuery();
            dbconn.connection().Close();
            MessageBox.Show("Kullanıcı başarılı bir şekilde silindi", "Kullanıcı Silme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
            temizle();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("Update TBL_ADMIN set KULLANICIADI=@p1,SIFRE=@p2,ROLE=@p3 where ID=@p4",dbconn.connection());
            sqlCommand.Parameters.AddWithValue("@p1", TkullaniciAdi.Text);
            sqlCommand.Parameters.AddWithValue("@p2", Tsifre.Text);
            sqlCommand.Parameters.AddWithValue("@p3", Crol.Text);
            sqlCommand.Parameters.AddWithValue("@p4" , Tid.Text);
            sqlCommand.ExecuteNonQuery();
            dbconn.connection().Close();
            MessageBox.Show("Kullanıcı başarılı bir şekilde güncellendi", "Kullanıcı İşlemleri", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle();
        }


        
       
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DateTime localDate = DateTime.Now;
            String s;
            s = localDate.ToString("yyyy-MM-dd");
            DatabaseBackup dbBackup = new DatabaseBackup();
            string serverName = Tservername.Text;  
            string databaseName = Tdatabasename.Text;
            string backupFilePath = @"C:\Yedekler\VeritabaniAdi_Yedek_"+ s + ".bak";

            dbBackup.BackupDatabase(serverName, databaseName, backupFilePath);

            
        }
    }
}
