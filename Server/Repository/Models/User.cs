﻿using System;
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

        public string Password { get; set; }

        public string Teste { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
