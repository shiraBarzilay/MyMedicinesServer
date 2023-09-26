using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class UsersModel
    {
        public int UserId { get; set; }
        public string UserPassword { get; set; }
        public string UserEmail { get; set; }
        public string UserAddress { get; set; }
        public string UserFirstname { get; set; }
        public string UserLastname { get; set; }
        public DateTime? UserBirthday { get; set; }
        public string UserCity { get; set; }
    }
}
