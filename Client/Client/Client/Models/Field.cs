using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    public class Field
    {
        public string Name { get; set; }
        public List<DateTime> Availability { get; set; }
        public string Location { get; set; }
        public int Type { get; set; }
        public string Length { get; set; }
        public string Width { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Price { get; set; }

        public Field(int sport, string fieldName, string adress, int? length, int? width, TimeSpan startTime, TimeSpan endTime, float? price)
        {
            Type = sport;
            Name = fieldName;
            Location = adress;
            Length = length.ToString();
            Width = width.ToString();
            StartTime = startTime;
            EndTime = endTime;
            Price = price.ToString();
        }
    }
}
