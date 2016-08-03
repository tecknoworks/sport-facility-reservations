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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public int PhoneNumber { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
        public String Token { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual ICollection<Field> Fields { get; set; }
    }
}
