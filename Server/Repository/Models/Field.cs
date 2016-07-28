using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class Field
    {
        public int ID { get; set; }      
        public string Name { get; set; }
        public string Location { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public DateTime StartTime  { get; set; }
        public DateTime EndTime { get; set; }
        public virtual ICollection<Reservation> Reservation { get; set; }
        //public int OwnerId { get; set; }
        //[ForeignKey("OwnerId")]
        //public virtual User User { get; set; }
    }
}
