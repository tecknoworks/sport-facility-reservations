using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    public class Field
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<DateTime> Availability { get; set; }
        public string Location { get; set; }
        public int Type { get; set; }
        public int? Length { get; set; }
        public int? Width { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public float? Price { get; set; }
        public string OwnerName { get; set; }
        public string Token { get; set; }

        public Field(int sport, string fieldName, string adress, int? length, int? width, TimeSpan startTime, TimeSpan endTime, float? price,string ownerName)
        {           
            Name = fieldName;
            Location = adress;
            Type = sport;
            Price = price;
            Length = length;
            Width = width;
            StartTime = startTime;
            EndTime = endTime;
            OwnerName = ownerName;
        }
    }
}
