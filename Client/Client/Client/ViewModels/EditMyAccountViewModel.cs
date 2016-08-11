using Client.Services.Interfaces;
using Prism.Mvvm;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Models;
using Client.Services;

namespace Client.ViewModels
{
    [ImplementPropertyChanged]
    public class EditMyAccountViewModel: BindableBase
    {
        private readonly IServiceClient _serviceClient;
        public string Token { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public List<Models.User> Users { get; set; }
        public EditMyAccountViewModel(IServiceClient serviceClient)
        {
            _serviceClient = serviceClient;
        }
        public async Task LoadGetUserByIdAsync()
        {
            Users = await _serviceClient.GetUserByIdAsync(Settings.Token);
        }
    }
}
