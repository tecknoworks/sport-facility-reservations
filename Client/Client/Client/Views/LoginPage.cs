﻿using Client.ViewModels;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microsoft.Practices.Unity;

namespace Client.Views
{
    public class LoginPage : ContentPage
    {
        public Image Img { get; set; }
        public LoginViewModel _viewModel;
        public Entry _usernameEntry;
        public LoginPage()
        {
            Title = "Login";
            Init();
        }

        public async Task Init()
        {
            _viewModel = App.Container.Resolve<LoginViewModel>();

            BindingContext = _viewModel;

            Grid grid = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                RowDefinitions =
                {
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto }
                },
            };


            var usernameLabel = new Label
            {
                Text = "Username",
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            grid.Children.Add(usernameLabel, 0, 2);

            var passwordLabel = new Label
            {
                Text = "Password",
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            grid.Children.Add(passwordLabel, 0, 4);

            _usernameEntry = new Entry
            {

                Keyboard = Keyboard.Default
            };
            _usernameEntry.SetBinding(Entry.TextProperty, "Username");
            grid.Children.Add(_usernameEntry, 0, 3);

            var passwordEntry = new Entry
            {
                Keyboard = Keyboard.Default,
                IsPassword = true
            };
            passwordEntry.SetBinding(Entry.TextProperty, "Password");
            grid.Children.Add(passwordEntry, 0, 5);

            var loginButton = new Button
            {
                Text = "Login",
                FontSize = 10,
            };
            grid.Children.Add(loginButton, 0, 6);
            loginButton.Clicked += LoginButton_Clicked;

            var registerLabel = new Label
            {
                Text = "Don't have an account?",
                FontSize = 10,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            grid.Children.Add(registerLabel, 0, 7);


            var registerButton = new Button
            {
                Text = "Register",
                FontSize = 10,
            };
            grid.Children.Add(registerButton, 0, 8);
            registerButton.Clicked += RegisterButton_Clicked;

            this.Content = grid;
        }
        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            await _viewModel.LoginVMAsync();
            if (string.IsNullOrEmpty(_viewModel.Username) || string.IsNullOrEmpty(_viewModel.Password))
            {
                await DisplayAlert("Warning", _viewModel.LoginMessage, "OK");
                return;
            }
            if (_viewModel.User == null)
            {
                await DisplayAlert("Warning", "Non-existent user", "OK");
                return;
            }
            else if (_viewModel.User.Status == true)
            {
                await Navigation.PushAsync(new OwnerHomePage());
            }
            else if (_viewModel.User.Status == false)
            {
                var homePageView = new HomePage($"Hello, {_viewModel.User.LastName}");
                await Navigation.PushAsync(homePageView);
            }
            
            return;
        }
        private async void RegisterButton_Clicked(object sender, EventArgs e)
        {
            var registerPageView = new RegisterPage();
            await Navigation.PushAsync(registerPageView);
        }
    }
}
