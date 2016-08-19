using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DTOs
{
    public class ReservationDTO
    {
        public int ID;
        public int FieldId;
        public string Token;
        public string Status;
        public string Field;
        public int Year;
        public int Month;
        public int Day;
        public int Hour;
    }

}
