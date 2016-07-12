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
        public LoginView()
        {
            Title = "Login";
            Init();
        }

        private async Task Init()
        {
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
            var usernameEntry = new Entry
            {
                Placeholder = "Fill in your username",
                Keyboard = Keyboard.Default
            };
            usernameEntry.SetBinding(Entry.TextProperty, "Username");

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
            button.SetBinding(Button.CommandProperty, "Login");

            Content = new StackLayout
            {
                Children =
                {
                    usernameLabel,
                    usernameEntry,
                    passwordLabel,
                    passwordEntry,
                    button
                }
            };
        }
    }
}
