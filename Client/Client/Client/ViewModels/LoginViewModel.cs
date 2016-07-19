﻿using Client.Services.Interfaces;
using Client.Views;
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
        private readonly INavigationService _navigationService;

        private string Username { get; set; }
        private string Password { get; set; }

        string _title = "Login Page";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private bool _canNavigate = true;
        public bool CanNavigate
        {
            get { return _canNavigate; }
            set { SetProperty(ref _canNavigate, value); }
        }

        public DelegateCommand NavigateCommand { get; set; }

        // TODO: Make it work when we have time
        public LoginViewModel(IServiceClient serviceClient/*, INavigationService navigationService*/)
        {
            _serviceClient = serviceClient;
            //_navigationService = navigationService;
            //NavigateCommand = new DelegateCommand(Navigate);//.ObservesCanExecute((vm) => CanNavigate);
            // TODO: create a method for login (ICommand style) and call the line above
            //_serviceClient.Login(Username, Password);
        }

        //public void Navigate()
        //{
        //    //CanNavigate = false;
        //    _navigationService.Navigate("HomePage");
        //    //CanNavigate = true;
        //}
        
        
    }
}