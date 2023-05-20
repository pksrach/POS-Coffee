using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_Coffee.cls
{
    internal class Check
    {
        public string CheckExistsData(string query, string data, string columnName)
        {
            ConnectionDb.cnn.Open();
            SqlCommand cmd = new SqlCommand(query, ConnectionDb.cnn);
            SqlDataReader dr = cmd.ExecuteReader();
           while (dr.Read())
            {
                data = (string)dr[columnName];
            }
            dr.Close();
            ConnectionDb.cnn.Close();

            return data;
        }
    }
}
