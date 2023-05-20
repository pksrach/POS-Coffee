using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Coffee.data.layer.dto
{
    internal class SalesDetailDto
    {
        private long sale_did;
        private long product_id;
        private double price;
        private int qty;
        private int discount_item;
        private double amount;

        public long Sale_did { get => sale_did; set => sale_did = value; }
        public long Product_id { get => product_id; set => product_id = value; }
        public double Price { get => price; set => price = value; }
        public int Qty { get => qty; set => qty = value; }
        public int Discount_item { get => discount_item; set => discount_item = value; }
        public double Amount { get => amount; set => amount = value; }
    }
}
