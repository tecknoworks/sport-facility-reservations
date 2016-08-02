using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Services
{
    class UserSeeder
    {
        internal static List<User> GetData()
        {
            var items = new List<User>
            {
                new User() {Username="Mari", Password = "mar", Status = false },
                new User() {Username="Tudor", Password = "tud", Status = false},
                new User() {Username="Vero", Password = "ver", Status = true },
                new User() {Username="Y", Password = "y" , Status = false}
            };
            return items;
        }
    }
}
