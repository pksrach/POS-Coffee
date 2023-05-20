using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;

namespace POS_Coffee.cls
{
    static class ConnectionDb
    {
        public static SqlConnection cnn;

        private static string data;

        public static bool MyConnection()
        {
            try
            {
                cnn = new SqlConnection();
                data = @"Data Source=" + Environment.MachineName + ";Initial Catalog=pos_coffee;User ID=sa;Password=sa";
                cnn.ConnectionString = data;
                return true;
            }
            catch (Exception ex)
            {
                cnn.Close();
                return false;
                throw new Exception(ex.Message);
            }
        }

    }
}
