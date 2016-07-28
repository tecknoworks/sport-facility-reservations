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
                new Field() {Name="Field0", City = "Cluj", Availability = new List<DateTime>(new [] { new DateTime(2016, 7, 28, 11, 00, 00), new DateTime(2016, 7, 28, 12, 00, 00), new DateTime(2016, 7, 28, 13, 00, 00), new DateTime(2016, 7, 28, 14, 00, 00) }  )},
                new Field() {Name="Field0", City = "Bistrita", Availability = new List<DateTime>(new []{ new DateTime(2016, 7, 28, 11, 00, 00), new DateTime(2016, 7, 28, 12, 00, 00), new DateTime(2016, 7, 28, 13, 00, 00), new DateTime(2016, 7, 28, 14, 00, 00) })},
                new Field() {Name="Field1", City = "Mures", Availability = new List<DateTime>(new []{new DateTime(2016, 7, 28, 12, 00, 00), new DateTime(2016, 7, 28, 13, 00, 00), new DateTime(2016, 7, 28, 14, 00, 00) }) },
                new Field() {Name="Field2", City = "Bistrita", Availability =new List<DateTime>(new [] { new DateTime(2016, 7, 28, 11, 00, 00), new DateTime(2016, 7, 28, 12, 00, 00), new DateTime(2016, 7, 28, 13, 00, 00), new DateTime(2016, 7, 28, 14, 00, 00) }) },
                new Field() {Name="Field3", City = "Brasov", Availability = new List<DateTime>(new []{ new DateTime(2016, 7, 28, 11, 00, 00), new DateTime(2016, 7, 28, 12, 00, 00), new DateTime(2016, 7, 28, 13, 00, 00), new DateTime(2016, 7, 28, 14, 00, 00) }) }
            };
            return items;
        }
    }
}
