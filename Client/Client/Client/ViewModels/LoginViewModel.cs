using Client.Models;
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
        private readonly ILoginService _loginService;
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public User User { get; set; }
        public string LoginMessage { get; set; }

        public LoginViewModel(ILoginService loginService)
        {
            _loginService = loginService;
        }
        public async Task LoginVMAsync()
        {
            User = null;
            try
            {
                User = await _loginService.LoginAsync(Username, Password);
            }
            catch (ArgumentNullException)
            {
                LoginMessage = "Unable to log in. Username or password is empty.";
            }
        }

    }
}