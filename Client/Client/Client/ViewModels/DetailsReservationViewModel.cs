using Client.Models;
using Client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels
{
   public class DetailsReservationViewModel
    {
        public ServiceClient _serviceClient;
        public string Username{ get; set; }
        public string Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public bool IsOwner { get; set; }

        public DetailsReservationViewModel(ServiceClient serviceClient)
        {
            _serviceClient = serviceClient;
        }

        public async Task UserDetailsAsync()
        {
            User user = new User(FirstName, LastName, Username, Password, Phone, IsOwner);
            FirstName = user.FirstName;
            LastName = user.LastName;
            Phone = user.PhoneNumber;
        }
    }
}
