using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Coffee.data.layer.dto
{
    internal class OrderDetailsDto
    {
        private long order_details_id;
        private long order_id;
        private long product_id;
        private double price;
        private int qty;
        private int discount_item;
        private double amount;

        public long Order_details_id { get => order_details_id; set => order_details_id = value; }
        public long Order_id { get => order_id; set => order_id = value; }
        public long Product_id { get => product_id; set => product_id = value; }
        public double Price { get => price; set => price = value; }
        public int Qty { get => qty; set => qty = value; }
        public int Discount_item { get => discount_item; set => discount_item = value; }
        public double Amount { get => amount; set => amount = value; }
    }
}
