using POS_Coffee.cls;
using POS_Coffee.data.layer.dto;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Coffee.data.layer.dao
{
    internal class ExpenseTypeDao
    {
        public Boolean create(ExpenseTypeDto expense)
        {
            SqlCommand cmd = new SqlCommand("insert into tbl_expense_type(type) values(@type)", ConnectionDb.cnn);
            cmd.Parameters.AddWithValue("@type", expense.Type);
            ConnectionDb.cnn.Open();
            int result = cmd.ExecuteNonQuery();
            ConnectionDb.cnn.Close();

            if (result == 0) return false;
            return true;
        }

        public DataTable GetAllAvailable()
        {
            DataTable table = new DataTable();
            SqlCommand cmd = new SqlCommand("Select id, type from tbl_expense_type Where deleted_date is null", ConnectionDb.cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(table);

            return table;
        }

        public Boolean update(ExpenseTypeDto expense)
        {
            string query = "Update tbl_expense_type Set type=@type Where id=@id";
            SqlCommand cmd = new SqlCommand(query, ConnectionDb.cnn);
            cmd.Parameters.AddWithValue("@type", expense.Type);
            cmd.Parameters.AddWithValue("@id", expense.Id);

            ConnectionDb.cnn.Open();
            int result = cmd.ExecuteNonQuery();
            ConnectionDb.cnn.Close();

            if (result == 0) return false;
            return true;
        }

        public Boolean deleteSoft(ExpenseTypeDto expense)
        {
            string query1 = "Update tbl_expense_type Set deleted_date=getdate() Where id = @id";
            SqlCommand cmd = new SqlCommand(query1, ConnectionDb.cnn);
            cmd.Parameters.AddWithValue("@id", expense.Id);

            ConnectionDb.cnn.Open();
            int result = cmd.ExecuteNonQuery();
            ConnectionDb.cnn.Close();

            if (result == 0) return false;
            return true;
        }

        public Boolean CheckDataExists(string name)
        {
            string query = "Select COUNT(*) from tbl_expense_type Where deleted_date is null And type = @type";
            SqlCommand cmd = new SqlCommand(query, ConnectionDb.cnn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@type", name);

            ConnectionDb.cnn.Open();
            int count = (int)cmd.ExecuteScalar();
            ConnectionDb.cnn.Close();

            if (count > 0)
            {
                return true;
            }
            return false;
        }

    }
}
