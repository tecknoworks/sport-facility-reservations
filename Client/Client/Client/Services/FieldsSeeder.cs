using Client.Models;
using Client.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Services
{
    public class FieldsSeeder
    {
        internal static List<Field> GetData()
        {
            var items = new List<Field>
            {
                new Field() {Name="Field0", City = "Cluj" },
                new Field() {Name="Field1", City = "Mures" },
                new Field() {Name="Field2", City = "Bistrita" },
                new Field() {Name="Field3", City = "Brasov" }
            };
            return items;
        }
    }
}
