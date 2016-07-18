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
        private Entry _usernameEntry;
        public LoginPage()
        {
            Title = "Login";
            Init();
        }

        private async Task Init()
        {
            var viewModel = App.Container.Resolve<LoginViewModel>();
            
            BindingContext = viewModel;

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
                    new RowDefinition { Height = GridLength.Auto }
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = GridLength.Auto },


                }
            };


            var usernameLabel = new Label
            {
                Text = "Username",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            grid.Children.Add(usernameLabel, 0, 2);

            var passwordLabel = new Label
            {
                Text = "Password",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            grid.Children.Add(passwordLabel, 0, 3);

            _usernameEntry = new Entry
            {
                Placeholder = "Fill in your username",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Keyboard = Keyboard.Default
            };
            grid.Children.Add(_usernameEntry, 1, 2);
            _usernameEntry.SetBinding(Entry.TextProperty, "Username");

            var passwordEntry = new Entry
            {
                Placeholder = "Fill in your password",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Keyboard = Keyboard.Default,
                IsPassword = true
            };
            grid.Children.Add(passwordEntry, 1, 3);
            passwordEntry.SetBinding(Entry.TextProperty, "Password");

            var loginButton = new Button
            {
                Text = "Login",
                FontSize = 10,
                BorderWidth = 1,
                WidthRequest = 100,
                HeightRequest = 30,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            grid.Children.Add(loginButton, 1, 4);
            loginButton.Clicked += Button_Clicked;

            var registerLabel = new Label
            {
                Text = "Don't have an account?",
                FontSize = 10,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            grid.Children.Add(registerLabel, 1, 6);


            var registerButton = new Button
            {
                Text = "Register",
                FontSize = 10,
                WidthRequest = 100,
                HeightRequest = 30,
                BorderWidth = 1,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand

            };
            grid.Children.Add(registerButton, 1, 7);
            registerButton.Clicked += Button_Clicked2;
            
            this.Content = grid;
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            var homePageView = new HomePageView($"Hello, {_usernameEntry.Text}");
            await Navigation.PushAsync(homePageView);

        }
        private async void Button_Clicked2(object sender, EventArgs e)
        {
            var homePageView = new RegisterView();
            await Navigation.PushAsync(homePageView);

        }
    }
}
