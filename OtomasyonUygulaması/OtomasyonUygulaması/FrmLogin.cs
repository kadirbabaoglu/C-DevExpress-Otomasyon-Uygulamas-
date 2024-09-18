using System;
using System.Data.SqlClient;
using System.Drawing;

using System.Windows.Forms;

namespace OtomasyonUygulaması
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        dbConnection dbconn = new dbConnection();

        private void simpleButton1_MouseHover(object sender, EventArgs e)
        {
            simpleButton1.BackColor = SystemColors.Control;
        }

        private void simpleButton1_MouseLeave(object sender, EventArgs e)
        {
            simpleButton1.BackColor = Color.Transparent;
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SqlCommand sql = new SqlCommand("Select * from TBL_ADMIN where KULLANICIADI=@p1 and SIFRE=@p2",dbconn.connection());
            sql.Parameters.AddWithValue("@p1", Tkullaniciadi.Text);
            sql.Parameters.AddWithValue("@p2", Tsifre.Text);
            SqlDataReader reader = sql.ExecuteReader();
            if (reader.Read())
            {

                string role = reader["ROLE"].ToString(); 

                if (role == "admin")
                {
                    MessageBox.Show("Admin giriş yaptı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form1 form = new Form1();
                    form.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("User olarak giriş yetkiniz yok", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Tkullaniciadi.Clear();  
                    Tsifre.Clear();
                }

            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            reader.Close();
            dbconn.connection().Close();
           
        }
    }
}
