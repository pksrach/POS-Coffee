using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Coffee.data.layer.dto
{
    internal class ExpenseDto
    {
        private long id;
        private double total_us;
        private long total_kh;
        private long created_by;
        private DateTime created_date;
        private long updated_by;

        public long Id { get => id; set => id = value; }
        public double Total_us { get => total_us; set => total_us = value; }
        public long Total_kh { get => total_kh; set => total_kh = value; }
        public long Created_by { get => created_by; set => created_by = value; }
        public long Updated_by { get => updated_by; set => updated_by = value; }
        public DateTime Created_date { get => created_date; set => created_date = value; }
    }
}
