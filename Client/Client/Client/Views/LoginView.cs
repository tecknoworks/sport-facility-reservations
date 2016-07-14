using Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Client.Views
{
    class LoginView: ContentPage
    {
        public LoginViewModel _viewModel;
        private Entry _usernameEntry;
        public LoginView()
        {
            Title = "Login";
            Init();
        }

        private async Task Init()
        {
            _viewModel = new LoginViewModel();
            BindingContext = _viewModel;

            var usernameLabel = new Label
            {
                Text = "Username",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            var passwordLabel = new Label
            {
                Text = "Password",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            _usernameEntry = new Entry
            {
                Placeholder = "Fill in your username",
                Keyboard = Keyboard.Default
            };
            _usernameEntry.SetBinding(Entry.TextProperty, "Username");

            var passwordEntry = new Entry
            {
                Placeholder = "Fill in your password",
                Keyboard = Keyboard.Default,
                IsPassword = true
            };
            passwordEntry.SetBinding(Entry.TextProperty, "Password");

            var button = new Button
            {
                Text = "Login",
                BorderWidth = 1,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            button.Clicked += Button_Clicked;

            var registerLabel = new Label
            {
                Text = "Don't have an account?",
                FontSize = 10,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            var button2 = new Button
            {
                Text = "Register",
                BorderWidth = 1,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            button2.Clicked += Button_Clicked2;

            Content = new StackLayout
            {
                Children =
                {
                    usernameLabel,
                    _usernameEntry,
                    passwordLabel,
                    passwordEntry,
                    button,
                    registerLabel,
                    button2
                    
                }
            };
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            var homePageView = new HomePageView($"Hello {_usernameEntry.Text}");
            await Navigation.PushAsync(homePageView);

        }
        private async void Button_Clicked2(object sender, EventArgs e)
        {
            var homePageView = new RegisterView();
            await Navigation.PushAsync(homePageView);

        }
    }
}
