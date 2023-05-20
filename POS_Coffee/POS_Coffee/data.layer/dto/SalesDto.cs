using POS_Coffee.cls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Coffee.data.layer.dto
{
    internal class SalesDto
    {
        private long sale_did;
        private double subtotal_us;
        private int discount_invoice;
        private double grand_total_us;
        private long grand_total_kh;
        private double received_us;
        private long received_kh;
        private long change_kh;
        private long sid;
        private DateTime datetime;
        private long paymentTypeId;

        public long Sale_did { get => sale_did; set => sale_did = value; }
        public string Invoice { get => GenerateInvoice.GetNextInvoiceString;}
        public double Subtotal_us { get => subtotal_us; set => subtotal_us = value; }
        public int Discount_invoice { get => discount_invoice; set => discount_invoice = value; }
        public double Grand_total_us { get => grand_total_us; set => grand_total_us = value; }
        public long Grand_total_kh { get => grand_total_kh; set => grand_total_kh = value; }
        public double Received_us { get => received_us; set => received_us = value; }
        public long Received_kh { get => received_kh; set => received_kh = value; }
        public long Change_kh { get => change_kh; set => change_kh = value; }
        public long Sid { get => sid; set => sid = value; }
        public DateTime Datetime { get => datetime; set => datetime = value; }
        public long PaymentTypeId { get => paymentTypeId; set => paymentTypeId = value; }
    }
}
