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
    public partial class FrmHareketler : Form
    {
        public FrmHareketler()
        {
            InitializeComponent();
        }

        dbConnection dbconn = new dbConnection();

        void MusteriHareket()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sql = new SqlDataAdapter("EXEC MusteriHareketleri" ,dbconn.connection());
            sql.Fill(dt);
            gridControl1.DataSource = dt;
        }

        private void FrmHareketler_Load(object sender, EventArgs e)
        {
            MusteriHareket();
        }
    }
}
