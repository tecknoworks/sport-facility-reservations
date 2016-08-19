using Client.Models;
using Client.Services;
using Commander;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels
{
    //[ImplementPropertyChanged]
    public class DetailsViewModel
    {
        public ServiceClient _serviceClient;
        public int FieldId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public DetailsViewModel(ServiceClient serviceClient)
        {
            _serviceClient = serviceClient;
        }

       // [OnCommand("ResCommand")]
        public async Task ReserveAsync()
        {
           Reservation reservation = new Reservation(Settings.Token, FieldId, Time.Hours, Date.Day, Date.Month, Date.Year,FirstName,LastName,Phone);
           await _serviceClient.AddReservationAsync(reservation);
        }
    }
}
