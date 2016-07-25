using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Services
{
    class FieldsSeeder
    {
        internal static List<Fields> GetData()
        {
            var items = new List<Fields>
            {
                new Fields("Enjoy", "Cluj"),
                new Fields("Field1", "Cluj"),
                new Fields("Field2", "Brasov"),
                new Fields("Field3", "Bistrita")
            };
            return items;
        }
    }
}
