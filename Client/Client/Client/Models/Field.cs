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

        public Field() : base()
        {
        }
    }
}
