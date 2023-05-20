using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Coffee.data.layer.dto
{
    internal class ExpenseTypeDto
    {
        private long id;
        private string type;

        public long Id { get => id; set => id = value; }
        public string Type { get => type; set => type = value; }
    }
}
