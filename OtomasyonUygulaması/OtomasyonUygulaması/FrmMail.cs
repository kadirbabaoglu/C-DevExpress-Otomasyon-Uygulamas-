using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

namespace OtomasyonUygulaması
{
    public partial class FrmMail : Form
    {
        public FrmMail()
        {
            InitializeComponent();
        }

        public string Mail;
        private void FrmMail_Load(object sender, EventArgs e)
        {
            TxtMail.Text = Mail;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
                SmtpClient smtpClient = new SmtpClient();

                smtpClient.Credentials = new System.Net.NetworkCredential("Email Address", "Mail Password"); 
                smtpClient.EnableSsl = true; 
                smtpClient.Host = "smtp.gmail.com";  
                smtpClient.Port = 587; 

                mailMessage.From = new MailAddress("Email Address");  
                mailMessage.To.Add(TxtMail.Text);  
                mailMessage.Subject = TxtKonu.Text;  
                mailMessage.Body = TxtMesaj.Text;  

                smtpClient.Send(mailMessage);

                MessageBox.Show("E-posta başarıyla gönderildi.");
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("E-posta gönderme hatası: " + ex.Message);
            }
        }
    }
}
