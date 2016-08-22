using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
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
        public float? Price { get; set; }
        public int? Width { get; set; }
        public int? Length { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string OwnerName { get; set; }
        
        [IgnoreDataMember]
        public virtual ICollection<Reservation> Reservation { get; set; }
        //[ForeignKey("OwnerId")]
        //public virtual User User { get; set; }
    }

}
