using Client.Models;
using Client.Services.Interfaces;
using Commander;
using Prism.Mvvm;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Services;

namespace Client.ViewModels
{
    [ImplementPropertyChanged]
    public class HomeViewModel : BindableBase
    {
        public string GreetingText { get; set; }
        public User User { get; set; }
        public string Token
        {
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

        public void SignOut()
        {
            Token=string.Empty;
        }

        //string _title = "HomePage";
        //public string Title
        //{
        //    get { return _title; }
        //    set { SetProperty(ref _title, value); }
        //}
        
        //public IServiceClient _serviceClient;

        //public HomeViewModel(IServiceClient serviceClient)
        //{
        //    _serviceClient = serviceClient;
        //}
    }
}
