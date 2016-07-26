using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Type { get; set; }

        public User()
        {

        }

        public User(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
    }
}
