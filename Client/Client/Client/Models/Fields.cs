using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    public class Fields
    {
        public string Name { get; set; }
        private List<DateTime> Availability { get; set; }
        private string City { get; set; }

        public Fields(string Name, List<DateTime> Availability, string City)
        {
            this.Name = Name;
            this.Availability = Availability;
            this.City = City;
        }

        public Fields(string Name)
        {
            this.Name = Name;
        }

        public Fields(List<DateTime> Availability)
        {
            this.Availability = Availability;
        }
        
        public Fields(string Name, string City)
        {
            this.Name = Name;
            this.City = City;
        }
    }
}
