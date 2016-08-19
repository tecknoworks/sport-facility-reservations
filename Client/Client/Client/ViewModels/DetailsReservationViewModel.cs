using Client.Services;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels
{
    [ImplementPropertyChanged]
    public class DetailsReservationViewModel
    {
        public ServiceClient _serviceClient;

        public int Id;
        public string Status;

        public DetailsReservationViewModel(ServiceClient serviceClient)
        {
            _serviceClient = serviceClient;
        }

        public async void AcceptedAsync()
        {
            await _serviceClient.AcceptReservation(Id);        
        }

        public async void RejectedAsync()
        {
            await _serviceClient.RejectReservation(Id);
        }
    }

}
