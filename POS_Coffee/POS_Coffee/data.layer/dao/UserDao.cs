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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace POS_Coffee.data.layer.dao
{
    internal class UserDao
    {
        public Boolean CheckDataExists(string username)
        {
            string query = "Select COUNT(*) from tbl_user Where deleted_date is null And user_name = @username";
            SqlCommand cmd = new SqlCommand(query, ConnectionDb.cnn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@username", username);

            ConnectionDb.cnn.Open();
            int count = (int)cmd.ExecuteScalar();
            ConnectionDb.cnn.Close();

            if (count > 0)
            {
                return true;
            }
            return false;
        }

        public Boolean create(UserDto user)
        {
            string query = "Insert into tbl_user(user_name, user_pwd, role, created_date, created_by, sid) values(@user_name, @user_pwd, @role, getdate(), @created_by, @sid)";
            SqlCommand cmd = new SqlCommand(query, ConnectionDb.cnn);
            cmd.Parameters.AddWithValue("@sid", user.Sid);
            cmd.Parameters.AddWithValue("@user_name", user.Username);
            cmd.Parameters.AddWithValue("@user_pwd", user.Password);
            cmd.Parameters.AddWithValue("@role", user.Role);
            cmd.Parameters.AddWithValue("@created_by", user.CreatedBy);

            ConnectionDb.cnn.Open();
            int result = cmd.ExecuteNonQuery();
            ConnectionDb.cnn.Close();

            if (result == 0) return false;
            return true;
        }

        public Boolean update(UserDto user)
        {
            string query = "Update tbl_user Set user_name=@user_name, user_pwd=@user_pwd, role=@role, updated_date=getdate(), updated_by=@updated_by Where uid=@uid";
            SqlCommand cmd = new SqlCommand(query, ConnectionDb.cnn);
            cmd.Parameters.AddWithValue("@user_name", user.Username);
            cmd.Parameters.AddWithValue("@user_pwd", user.Password);
            cmd.Parameters.AddWithValue("@role", user.Role);
            cmd.Parameters.AddWithValue("@updated_by", user.UpdatedBy);
            cmd.Parameters.AddWithValue("@uid", user.Uid);

            ConnectionDb.cnn.Open();
            int result = cmd.ExecuteNonQuery();
            ConnectionDb.cnn.Close();

            if (result == 0) return false;
            return true;
        }

        public Boolean deleteSoft(UserDto user)
        {
            string query = "Update tbl_user Set sid=NULL, updated_by=@updated_by, deleted_date=getdate() Where uid = @uid";
            SqlCommand cmd = new SqlCommand(query, ConnectionDb.cnn);
            cmd.Parameters.AddWithValue("@updated_by", user.UpdatedBy);
            cmd.Parameters.AddWithValue("@uid", user.Uid);

            ConnectionDb.cnn.Open();
            int result = cmd.ExecuteNonQuery();
            ConnectionDb.cnn.Close();

            if (result == 0) return false;
            return true;
        }

        public DataTable GetAllAvailable()
        {
            DataTable table = new DataTable();
            SqlCommand cmd = new SqlCommand("Select * from View_User", ConnectionDb.cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(table);

            return table;
        }

    }
}
