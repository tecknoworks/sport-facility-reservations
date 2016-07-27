using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
     public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
       // public string LastName { get; set; }
        public string UserName { get; set; }
        public int PhoneNumber { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
        

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
