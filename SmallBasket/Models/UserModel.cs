using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallBasket.Models
{
    public class UserModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class LoginUser
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public long ContactNumber { get; set; }
    }
}
