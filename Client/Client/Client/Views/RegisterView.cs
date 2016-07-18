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

            var labelFirstName = new Label
            {
                Text = "First Name",
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            var firstName = new Entry
            {
                Placeholder = "Input",
                Keyboard = Keyboard.Default
               
            };
            firstName.SetBinding(Entry.TextProperty, "FirstName");

            var labelLastName = new Label
            {
                Text = "Last Name",
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            var lastName = new Entry
            {
                Placeholder = "Last Name",
                Keyboard = Keyboard.Default,          
            };
            lastName.SetBinding(Entry.TextProperty, "LastName");

            var labelUsername = new Label
            {
                Text = "Username",
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            var username = new Entry
            {
                Placeholder = "Input",
                Keyboard = Keyboard.Default
            };
            firstName.SetBinding(Entry.TextProperty, "Username");

            var labelPhone = new Label
            {
                Text = "Phone",
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            var phone = new Entry
            {
                Placeholder = "Input",
                Keyboard = Keyboard.Default            
            };
            phone.SetBinding(Entry.TextProperty, "Phone");

            var labelPassword = new Label
            {
                Text = "Password",
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            var password = new Entry
            {
                Placeholder = "Input",
                Keyboard = Keyboard.Default,
                IsPassword = true
            };
            phone.SetBinding(Entry.TextProperty, "Password");

            var labelConfirmPassword = new Label
            {
                Text = "Confirm Password",
                HorizontalOptions = LayoutOptions.Start,
               // VerticalOptions = LayoutOptions.CenterAndExpand
            };

            var confirmPassword = new Entry
            {
                Placeholder = "Input",
                Keyboard = Keyboard.Default,
                IsPassword = true
            };

            var buttonRegister = new Button
            {
                Text = "Register",
                BorderWidth = 1,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            var type = new Picker
            {
                Title = "Type",
             
            };
            type.Items.Add("Owner");
            type.Items.Add("Player");

            Content = new StackLayout
            {
                Children =
                {
                    labelFirstName,
                    firstName,
                    labelLastName,
                    lastName,
                    labelUsername,
                    username,
                    labelPassword,
                    password,
                    labelConfirmPassword,
                    confirmPassword,
                    labelPhone,
                    phone, 
                    type,
                    buttonRegister
                }
            };
        }
    }
}

