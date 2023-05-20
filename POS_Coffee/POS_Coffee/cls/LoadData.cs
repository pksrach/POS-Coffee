using POS_Coffee.static_data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_Coffee.cls
{
    internal class LoadData
    {
        SqlCommand cmd;
        SqlDataReader dr;
        public void loadData(DataGridView dataGridView, string query,  int index0)
        {
            int row = 0;
            dataGridView.Rows.Clear();
            cmd = new SqlCommand(query, ConnectionDb.cnn);
            ConnectionDb.cnn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                row++;
                dataGridView.Rows.Add(row, dr[index0]);
            }
            dr.Close();
            ConnectionDb.cnn.Close();
        }

        public void loadData(DataGridView dataGridView, string query, int index0, int index1)
        {
            int row = 0;
            dataGridView.Rows.Clear();
            ConnectionDb.cnn.Open();
            cmd = new SqlCommand(query, ConnectionDb.cnn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                row++;
                dataGridView.Rows.Add(row, dr[index0], dr[index1]);
            }
            dr.Close();
            ConnectionDb.cnn.Close();
        }

        public void loadData(DataGridView dataGridView, string query, int index0, int index1, int index2, int index3, int index4, int index5)
        {
            int row = 0;
            dataGridView.Rows.Clear();
            ConnectionDb.cnn.Open();
            cmd = new SqlCommand(query, ConnectionDb.cnn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                row++;
                dataGridView.Rows.Add(row, dr[index0], dr[index1], dr[index2], dr[index3], dr[index4], dr[index5]);
            }
            dr.Close();
            ConnectionDb.cnn.Close();
        }

        //============Combobox===========
        public void ComboBoxLoad(ComboBox cbo, string sql, string name, string value)
        {
            ConnectionDb.cnn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, ConnectionDb.cnn); //call comboBox or display to C#
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbo.DataSource = dt;
            cbo.DisplayMember = name;
            cbo.ValueMember = value;
            ConnectionDb.cnn.Close();
            
        }//method show data into comboBox


        public void loadDataAdapter(string query, DataGridView dgv)
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("", ConnectionDb.cnn);
            dataAdapter.SelectCommand.CommandText = query;
            dataAdapter.Fill(dataTable);

            //add data into datagridview
            dgv.DataSource = dataTable;
            //hide col id
            dgv.Columns[0].Visible = false;
        }

        // Load Exchange Rate
        public void loadExchangeRate()
        {
            SqlCommand cmd = new SqlCommand("select exchange_rate from tbl_exchange", ConnectionDb.cnn);
            ConnectionDb.cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                StaticData.ExchangeRate = Convert.ToDouble(dr["exchange_rate"]);
            }
            else
            {
                StaticData.ExchangeRate = 4000;
            }
            dr.Close();
            ConnectionDb.cnn.Close();
        }
    }
}
