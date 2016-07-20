using Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Client.Views
{
    class RegisterPage : ContentPage
    {
        public RegisterViewModel _viewModel;
        Entry _password;
        Entry _confirmPassword;
        public RegisterPage()
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
                Keyboard = Keyboard.Default
            };
            phone.SetBinding(Entry.TextProperty, "Phone");

            var labelPassword = new Label
            {
                Text = "Password",
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            _password = new Entry
            {
                Keyboard = Keyboard.Default,
                IsPassword = true
            };
            _password.SetBinding(Entry.TextProperty, "Password");

            var labelConfirmPassword = new Label
            {
                Text = "Confirm Password",
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            _confirmPassword = new Entry
            {
                Keyboard = Keyboard.Default,
                IsPassword = true
            };
            _confirmPassword.SetBinding(Entry.TextProperty, "ConfirmPassword");
            _confirmPassword.TextChanged += OnAlertClicked;

            var buttonRegister = new Button
            {
                Text = "Submit",
                WidthRequest = 100,
                HeightRequest = 30,
                FontSize = 10,
            };
            buttonRegister.Clicked += OnAlertClicked;

            var labelType = new Label
            {
                Text = "Type",
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            var type = new Picker
            {
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
                    _password,
                    labelConfirmPassword,
                    _confirmPassword,
                    labelPhone,
                    phone,
                    labelType,
                    type,
                    buttonRegister
                }
            };
        }
        private async void OnAlertClicked(object sender, EventArgs e)
        {
            if (_password.Text.Equals(_confirmPassword.Text))
                await (DisplayAlert("Message", "Password completed", "OK"));
            
            else
                await (DisplayAlert("Message", "Password deosn't match ", "Cancel"));

        }
       

        //    DisplayAlert("Account created", "Add processing login here", "OK");


    }
}

