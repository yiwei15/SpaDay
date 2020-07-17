using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaDay.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Email  { get; set; }
        public string Password { get; set; }
        public DateTime JoinDate { get; set; }

        public User()
        {

        }
        public User(string name, string email, string password):this()
        {
            Username = name;
            Email = email;
            Password = password;
            JoinDate = DateTime.Now;
        }
    }
}
