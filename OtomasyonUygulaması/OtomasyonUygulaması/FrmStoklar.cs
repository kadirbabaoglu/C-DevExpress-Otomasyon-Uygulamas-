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
    public partial class FrmStoklar : Form
    {
        public FrmStoklar()
        {
            InitializeComponent();
        }
        dbConnection dbconn = new dbConnection();
        private void FrmStoklar_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Select URUNAD,Sum(ADET) as 'Miktar' from TBL_URUNLER GROUP By URUNAD", dbconn.connection());
            adapter.Fill(dt);
            gridControl1.DataSource = dt;

            SqlCommand sql = new SqlCommand("SELECT TOP 25 URUNAD, SUM(ADET) AS [Miktar] FROM TBL_URUNLER GROUP BY URUNAD", dbconn.connection());
            SqlDataReader reader = sql.ExecuteReader();
            while (reader.Read())
            { 
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(reader[0]) , Convert.ToDouble(reader[1]));
            }

            SqlCommand sql2 = new SqlCommand("Select TOP 10 IL,Count(*) from TBL_FIRMALAR Group By IL", dbconn.connection());
            SqlDataReader reader2 = sql2.ExecuteReader();
            while (reader2.Read())
            {
                chartControl2.Series["Series 1"].Points.AddPoint(Convert.ToString(reader2[0]), Convert.ToDouble(reader2[1]));
            }
        }
    }
}
