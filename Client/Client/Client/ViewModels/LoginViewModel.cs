using Client.Services.Interfaces;
using Client.Views;
using Commander;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
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

        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string LoginMessage { get; set; }

        public LoginViewModel(IServiceClient serviceClient)
        {
            _serviceClient = serviceClient;
        }

        [OnCommand("CheckCommand")]
        public void OnCheck()
        {
            Token = "";
            try
            {
                Token = _serviceClient.Login(Username, Password);
            }
            catch (ArgumentNullException)
            {
                LoginMessage = "Unable to log in. Username or password is empty.";
            }
        }
    }
}