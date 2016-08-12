using Client.Models;
using Client.Services.Interfaces;
using Client.Services;
using Client.Views;
using Commander;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels
{
    //[ImplementPropertyChanged] ???
    public class LoginViewModel : BindableBase, INotifyPropertyChanged
    {
        private readonly IServiceClient _serviceClient;
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token {
            get
            {
                return Settings.Token;
            }
            set
            {
                if (Settings.Token == value)
                    return;
                Settings.Token = value;
                OnPropertyChanged();
            }
        }
        public bool Status
        {
            get
            {
                return Settings.Status;
            }
            set
            {
                if (Settings.Status == value)
                    return;
                Settings.Status = value;
                OnPropertyChanged();
            }
        }
        public string FirstName
        {
            get
            {
                return Settings.FirstName;
            }
            set
            {
                if (Settings.FirstName == value)
                    return;
                Settings.FirstName = value;
                OnPropertyChanged();
            }
        }
        public User User { get; set; }
        public string LoginMessage { get; set; }

        public LoginViewModel(IServiceClient serviceClient)
        {
            _serviceClient = serviceClient;
        }
        public async Task LoginVMAsync()
        {
            User = null;
            try
            {
                User = await _serviceClient.LoginAsync(Username, Password);
                Token = User.Token;
                Status = User.Status;
                FirstName = User.FirstName;
            }
            catch (ArgumentNullException)
            {
                LoginMessage = "Unable to log in. Username or password is empty.";
            }
        }

        public async void GetUser(User user)
        {
            await _serviceClient.AddUserAsync(user);
            Token = user.Token;
        }
    }
}