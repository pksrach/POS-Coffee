using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Coffee.data.layer.dto
{
    internal class ExpenseDetailDto
    {
        private long id;
        private long master_id;
        private long type_id;
        private double total_us;
        private long total_kh;
        private string description;

        public long Id { get => id; set => id = value; }
        public long Master_id { get => master_id; set => master_id = value; }
        public long Type_id { get => type_id; set => type_id = value; }
        public double Total_us { get => total_us; set => total_us = value; }
        public long Total_kh { get => total_kh; set => total_kh = value; }
        public string Description { get => description; set => description = value; }
    }
}
