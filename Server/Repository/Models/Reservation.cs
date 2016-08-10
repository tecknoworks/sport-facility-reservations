using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public int FieldID { get; set; }     
        public DateTime StartHour { get; set; }
        [IgnoreDataMember]
        public virtual User User { get; set; }
        [IgnoreDataMember]
        public virtual Field Field { get; set; }
    }
}
