using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Coffee.data.layer.dto
{
    internal class UserDto
    {
        private long sid;
        private long uid;
        private string username;
        private string password;
        private string role;
        private long createdBy;
        private long updatedBy;

        public long Sid { get => sid; set => sid = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Role { get => role; set => role = value; }
        public long CreatedBy { get => createdBy; set => createdBy = value; }
        public long UpdatedBy { get => updatedBy; set => updatedBy = value; }
        public long Uid { get => uid; set => uid = value; }
    }
}
