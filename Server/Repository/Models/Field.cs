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
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public int Type { get; set; }
        public int Price { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }
        public TimeSpan Startime { get; set; }
        public TimeSpan Endtime { get; set; }
        public List<DateTime> Availability { get; set; }
        public virtual ICollection<Reservation> Reservation { get; set; }
        //public int OwnerId { get; set; }
        //[ForeignKey("OwnerId")]
        //public virtual User User { get; set; }
    }
}
