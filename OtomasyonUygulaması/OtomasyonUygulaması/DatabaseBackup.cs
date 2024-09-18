using System;
using System.Data.SqlClient;
using System.Windows.Forms;

public class DatabaseBackup
{
    public void BackupDatabase(string serverName, string databaseName, string backupFilePath)
    {
        try
        {
            string connectionString = $@"Server={serverName};Database=master;Integrated Security=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();  
                string backupQuery = $@"
                    BACKUP DATABASE [{databaseName}] 
                    TO DISK = @backupFilePath
                    WITH FORMAT, INIT,
                    NAME = 'Tam Yedekleme - {databaseName}',
                    SKIP, NOREWIND, NOUNLOAD, STATS = 10";

                using (SqlCommand cmd = new SqlCommand(backupQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@backupFilePath", backupFilePath);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Veritabanı yedekleme işlemi başarılı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Yedekleme sırasında bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
