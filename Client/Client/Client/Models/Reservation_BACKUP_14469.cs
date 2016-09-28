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
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public string Token { get; set; }
        public string Field { get; set; }
        public DateTime StartHour { get; set; }
<<<<<<< HEAD
		public string Status { get; set; }
=======
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int Id { get; set; }
>>>>>>> c717bb37a5422f3ed98f69c6b557f40a4b23878f

        public Reservation(string token, int idField, int hour, int day, int month, int year,string firstName,string lastName,string phoneNumber)
        {
            this.Token = token;
            this.FieldId = idField;
            Hour = hour;
            Day = day;
            Month = month;
            Year = year;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
        }
    }
}
