using Client.Services.Interfaces;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Services;
using Xamarin.Forms;

namespace Client.ViewModels
{
    [ImplementPropertyChanged]
    public class ReservationPageViewModel
    {
        public IServiceClient _serviceClient;
        public string Field { get; set; }        
        public DateTime StartHour { get; set; }
        public List<Models.Reservation> ReservedFields { get; set; }
        public string Status { get; set; }
        public Color Color { get; set; }

        public ReservationPageViewModel(IServiceClient serviceClient)
        {
            _serviceClient = serviceClient;
        }
        public async Task LoadReservedFieldsAsync()
        {
            ReservedFields = await _serviceClient.GetReservedFieldsAsync(Settings.Token);
        }
    }
}
