using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace OtomasyonUygulaması
{
     class dbConnection
    {

        public SqlConnection connection() 
        {
            SqlConnection conn = new SqlConnection(@"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=TicariOtomasyon;Integrated Security=True;Encrypt=False;");
            conn.Open();
            return conn;
        }
    }
}
