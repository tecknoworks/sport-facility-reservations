using Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Client.Views
{
    class RegisterView : ContentPage
    {
        public RegisterViewModel _viewModel;

        public RegisterView()
        {
            Title = "Register";
            Init();
        }
        private async Task Init()
        {
            
            _viewModel = new RegisterViewModel();
            BindingContext = _viewModel;

            var label = new Label
            {
                Text = "Register",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            var firstName = new Entry
            {
                Placeholder = "First Name",
                Keyboard = Keyboard.Default,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            firstName.SetBinding(Entry.TextProperty, "FirstName");

            var lastName = new Entry
            {
                Placeholder = "Last Name",
                Keyboard = Keyboard.Default,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            lastName.SetBinding(Entry.TextProperty, "LastName");

            var phone = new Entry
            {
                Placeholder = "Phone",
                Keyboard = Keyboard.Default,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            phone.SetBinding(Entry.TextProperty, "Phone");

            var password = new Entry
            {
                Placeholder = "Password",
                Keyboard = Keyboard.Default,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsPassword = true
            };
            phone.SetBinding(Entry.TextProperty, "Password");

            var button = new Button
            {
                Text = "Register",
                BorderWidth = 1,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            Content = new StackLayout
            {
                Children =
                {
                    label,
                    firstName,
                    lastName,
                    phone,
                    password,
                    button
                }
            };
        }
    }
}

