using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
   public class Reservation
    {
        public int FieldId { get; set; }
        public int Hour{ get; set; }
        public string Token { get; set; }
        public string Field { get; set; }
        public DateTime StartHour { get; set; }

        public Reservation(string token, int idField, int hour )
        {
            this.Token = token;
            this.FieldId = idField;
           Hour = hour;
        }
    }
}
