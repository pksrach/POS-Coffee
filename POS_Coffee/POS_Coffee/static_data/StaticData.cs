using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Coffee.static_data
{
    internal class StaticData
    {
        // Field Static
        private static long sid;
        private static string staff_name;
        private static string role;
        private static DataTable dt = new DataTable();
        private static string getInvoice;

        // Encapsulation
        public static string GetStaticInvoice
        {
            get => getInvoice;
            set => getInvoice= value;
        }

        public static DataTable DT
        {
            get { return dt; }
            set { dt = value; }
        }

        public static long SID
        {
            get => sid;
            set => sid = value;
        }

        public static string StaffName
        {
            get => staff_name;
            set => staff_name = value;
        }

        public static string Role
        {
            get => role;
            set => role = value;
        }

        private static double exchange_rate;
        public static double ExchangeRate
        {
            get => exchange_rate;
            set => exchange_rate = value;
        }
    }
}
