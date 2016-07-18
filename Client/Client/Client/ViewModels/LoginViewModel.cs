using Client.Services.Interfaces;
using Prism.Mvvm;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels
{
    //[ImplementPropertyChanged] ???
    public class LoginViewModel : BindableBase
    {
        private readonly IServiceClient _serviceClient;

        private string Username { get; set; }
        private string Password { get; set; }

        public LoginViewModel(IServiceClient serviceClient)
        {
            _serviceClient = serviceClient;

            // TODO: create a method for login (ICommand style) and call the line above
            //_serviceClient.Login(Username, Password);
        }
    }
}