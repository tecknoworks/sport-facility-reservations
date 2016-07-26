using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    public class Field
    {
        public string Name { get; set; }
        public List<DateTime> Availability { get; set; }
        public string City { get; set; }

        public Field()
        {

        }
        public Field(string Name, List<DateTime> Availability, string City)
        {
            this.Name = Name;
            this.Availability = Availability;
            this.City = City;
        }

        public Field(string Name)
        {
            this.Name = Name;
        }

        public Field(List<DateTime> Availability)
        {
            this.Availability = Availability;
        }
        
        public Field(string Name, string City)
        {
            this.Name = Name;
            this.City = City;
        }
    }
}
