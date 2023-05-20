using POS_Coffee.cls;
using POS_Coffee.static_data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace POS_Coffee.data.layer.dto
{
    internal class OrderDto
    {
        private long oid;
        private long table_id;
        private long sid;
        private string invoice;

        public long Oid { get => oid; set => oid = value; }
        public string Invoice { get => StaticData.GetStaticInvoice; set => invoice = value; }
        public long Table_id { get => table_id; set => table_id = value; }
        public long Sid { get => sid; set => sid = value; }
    }
}
