using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public bool Status { get; set; }
        public string Token { get; set; }

        public User()
        {

        }
        public User(string firstName, string lastName, string username, string paswword, string phoneNumber, bool status)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Password = paswword;
            PhoneNumber = phoneNumber;
            Status = status;
        }
        public User(string token, string username)
        {
            Token = token;
            Username = username;
        }
    }
}
