using POS_Coffee.AlertMessage;
using POS_Coffee.cls;
using POS_Coffee.data.layer.dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Coffee.data.layer.dao
{
    internal class StaffDao
    {
        public Boolean create(StaffDto staff)
        {
            SqlCommand cmd = new SqlCommand("insert into tbl_staffs(staff_name,gender,dob,phone_number,address) values(@staff_name,@gender,@dob,@phone_number,@address)", ConnectionDb.cnn);
            cmd.Parameters.AddWithValue("@staff_name", staff.Staff_name);
            cmd.Parameters.AddWithValue("@gender", staff.Gender);
            cmd.Parameters.AddWithValue("@dob", staff.Dob);
            cmd.Parameters.AddWithValue("@phone_number", staff.Phone_number);
            cmd.Parameters.AddWithValue("@address", staff.Address);
            ConnectionDb.cnn.Open();
            int result = cmd.ExecuteNonQuery();
            ConnectionDb.cnn.Close();

            if (result== 0 ) return false;
            return true;
        }

        public DataTable GetAllAvailable()
        {
            DataTable table = new DataTable();
            SqlCommand cmd = new SqlCommand("Select * from View_Staffs", ConnectionDb.cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(table);

            return table;
        }

        public Boolean update(StaffDto staff)
        {
            string query = "Update tbl_staffs Set staff_name=@staff_name, gender=@gender, dob=@dob, phone_number=@phone_number, address=@address Where sid=@sid";
            SqlCommand cmd = new SqlCommand(query, ConnectionDb.cnn);
            cmd.Parameters.AddWithValue("@staff_name", staff.Staff_name);
            cmd.Parameters.AddWithValue("@gender", staff.Gender);
            cmd.Parameters.AddWithValue("@dob", staff.Dob);
            cmd.Parameters.AddWithValue("@phone_number", staff.Phone_number);
            cmd.Parameters.AddWithValue("@address", staff.Address);
            cmd.Parameters.AddWithValue("@sid", staff.Sid);

            ConnectionDb.cnn.Open();
            int result = cmd.ExecuteNonQuery();
            ConnectionDb.cnn.Close();

            if (result== 0 ) return false;
            return true;
        }

        public Boolean deleteSofe(StaffDto staff)
        {
            ConnectionDb.cnn.Open();
            SqlTransaction transaction = ConnectionDb.cnn.BeginTransaction();

            try
            {
                string query1 = "Update tbl_staffs Set deleted_date=getdate() Where sid = @sid";
                SqlCommand cmd1 = new SqlCommand(query1, ConnectionDb.cnn, transaction);
                cmd1.Parameters.AddWithValue("@sid", staff.Sid);

                string query2 = "Update tbl_user Set deleted_date=getdate() Where uid = (select uid from tbl_user where deleted_date is null and sid = @sid";
                SqlCommand cmd2 = new SqlCommand(query2, ConnectionDb.cnn, transaction);
                cmd2.Parameters.Clear();
                cmd2.Parameters.AddWithValue("@sid", staff.Sid);

                int result1 = cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();

                if (result1 == 0)
                {
                    return false;
                }

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Warning warning = new Warning("ទិន្នន័យលុប បរាជ័យ [" + ex + "]", "លុបបុគ្គលិក");
                warning.ShowDialog();
            }
            finally
            {
                ConnectionDb.cnn.Close();
            }
            return true;
        }

    }
}
