using POS_Coffee.cls;
using POS_Coffee.data.layer.dto;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_Coffee.data.layer.dao
{
    internal class ExpenseDao
    {
        public Boolean create(ExpenseDto expense, DataGridView dataGridView)
        {
            ConnectionDb.cnn.Open();
            SqlTransaction transaction = ConnectionDb.cnn.BeginTransaction();
            try
            {
                string expenseQuery = "insert into tbl_expenses(total_us, total_kh, created_date, created_by) values(@total_us, @total_kh, @created_date, @created_by); SELECT SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(expenseQuery, ConnectionDb.cnn, transaction);
                cmd.Parameters.AddWithValue("@total_us", expense.Total_us);
                cmd.Parameters.AddWithValue("@total_kh", expense.Total_kh);
                cmd.Parameters.AddWithValue("@created_date", expense.Created_date);
                cmd.Parameters.AddWithValue("@created_by", expense.Created_by);

                long expense_id = Convert.ToInt64(cmd.ExecuteScalar());

                ExpenseDetailDto detail = new ExpenseDetailDto();
                int result = 0;
                string expenseDetailQuery = "insert into tbl_expense_details(master_id, type_id, total_us, total_kh, description) values(@master_id, @type_id, @total_us, @total_kh, @description)";

                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    detail.Total_us = Convert.ToDouble(row.Cells["colTotalUs"].Value);
                    detail.Total_kh = Convert.ToInt64(row.Cells["colTotalKh"].Value);
                    detail.Description = row.Cells["colDescription"].Value.ToString();
                    detail.Type_id = Convert.ToInt64(row.Cells["colExpenseTypeId"].Value);

                    cmd = new SqlCommand(expenseDetailQuery, ConnectionDb.cnn, transaction);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@master_id", expense_id);
                    cmd.Parameters.AddWithValue("@type_id", detail.Type_id);
                    cmd.Parameters.AddWithValue("@total_us", detail.Total_us);
                    cmd.Parameters.AddWithValue("@total_kh", detail.Total_kh);
                    cmd.Parameters.AddWithValue("@description", detail.Description);
                    result = cmd.ExecuteNonQuery();

                    if (result == 0) return false;
                }

                transaction.Commit();
            }
            catch (Exception ex)
            {
                // If error then rollback
                transaction.Rollback(); // do not save all in db
                MessageBox.Show("Import Failed [" + ex.Message + "]!");
            }
            finally
            {
                ConnectionDb.cnn.Close();
            }

            return true;
        }
    }
}
