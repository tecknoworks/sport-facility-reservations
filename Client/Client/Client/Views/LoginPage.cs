using Client.ViewModels;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microsoft.Practices.Unity;
using Client.Services;

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

            _usernameEntry = new Entry
            {
                Keyboard = Keyboard.Email,
                Text = "tudor",
                Placeholder = "E-mail"
            };
            _usernameEntry.SetBinding(Entry.TextProperty, "Username");
            grid.Children.Add(_usernameEntry, 0, 3);

            var passwordEntry = new Entry
            {
                Keyboard = Keyboard.Default,
                Placeholder = "Password",
                IsPassword = true
            };
            passwordEntry.SetBinding(Entry.TextProperty, "Password");
            grid.Children.Add(passwordEntry, 0, 5);

            var loginButton = new Button
            {
                Text = "Login"
            };
            grid.Children.Add(loginButton, 0, 6);
            loginButton.Clicked += LoginButton_Clicked;

            var registerButton = new Button
            {
                Text = "Don't have an account?"

            };
            grid.Children.Add(registerButton, 0, 8);
            registerButton.Clicked += RegisterButton_Clicked;

            var facebookLoginButton = new Button
            {
                Text = "Login with Facebook"
            };
            grid.Children.Add(facebookLoginButton, 0, 9);
            facebookLoginButton.Clicked += FacebookLoginButton_Clicked;

            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            this.Content = grid;
        }

        private async void FacebookLoginButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Login());
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
                var homePageView = new HomePage($"Hello, {Settings.FirstName}");
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
