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
    public class User
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
        public string Token { get; set; }
        [IgnoreDataMember]
        public virtual ICollection<Reservation> Reservations { get; set; }
        //public virtual ICollection<Field> Fields { get; set; }
    }
}
