using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallBasket.Models
{
    public class UserModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class LoginUser
    {
        public string UserName { get; set; }
        public int ID { get; set; }
        public long ContactNumber { get; set; }
    }
}
