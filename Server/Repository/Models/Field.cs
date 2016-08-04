using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class Field
    {
        public int ID { get; set; }
        [Index(IsUnique = true)]
        [StringLength(200)]
        public string Name { get; set; }
        public string Location { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public TimeSpan Startime { get; set; }
        public TimeSpan Endtime { get; set; }
        public List<DateTime> Availability { get; set; }
        public virtual ICollection<Reservation> Reservation { get; set; }
        //public int OwnerId { get; set; }
        //[ForeignKey("OwnerId")]
        //public virtual User User { get; set; }
    }
}
