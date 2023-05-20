using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace POS_Coffee.cls
{
    internal class GenerateInvoice
    {
        private static string _prefix;

        public GenerateInvoice(string prefix)
        {
            _prefix = prefix;
        }

        public GenerateInvoice() { }

        public static string NextInvoiceNumber()
        {
            string number = Invoice.ToString().PadLeft(5, '0');
            Invoice++;
            getNextInvoice = $"{_prefix}-{number}";
            return $"{_prefix}-{number}"; ;
        }

        private static int invoice;
        public static int Invoice
        {
            get => invoice;
            set => invoice = value;
        }

        private static string getNextInvoice;
        public static string GetNextInvoiceString
        {
            get => getNextInvoice;
            set => getNextInvoice = value;
        }

        public static int LoadingInvoiceNumber()
        {
            ConnectionDb.cnn.Close();
            ConnectionDb.cnn.Open();
            SqlCommand cmd = new SqlCommand("", ConnectionDb.cnn);
            cmd.CommandText = "select * from tbl_invoice_num";
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Invoice = (int)dr["InvoicesNum"];
            }
           
            dr.Close();
            ConnectionDb.cnn.Close();

            return Invoice;
        }

    }
}
