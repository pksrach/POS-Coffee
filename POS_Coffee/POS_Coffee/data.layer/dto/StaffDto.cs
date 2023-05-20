using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Coffee.data.layer.dto
{
    internal class StaffDto
    {
        private long sid;
        private string staff_name;
        private string gender;
        private DateTime dob;
        private string phone_number;
        private string address;

        public string Staff_name { get => staff_name; set => staff_name = value; }
        public string Gender { get => gender; set => gender = value; }
        public DateTime Dob { get => dob; set => dob = value; }
        public string Phone_number { get => phone_number; set => phone_number = value; }
        public string Address { get => address; set => address = value; }
        public long Sid { get => sid; set => sid = value; }
    }
}
