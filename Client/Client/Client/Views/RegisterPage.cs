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
        private const int PICKER_OWNER_INDEX = 0;
        public RegisterViewModel _viewModel;
        Entry _password;
        Entry _confirmPassword;
        public RegisterPage()
        {
            Title = "Register";
            Init();
        }
        public async Task Init()
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
                VerticalOptions = LayoutOptions.CenterAndExpand,
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

            var buttonRegister = new Button
            {
                Text = "Submit"
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
            type.Items.Add("Owner");    // 0 = PICKER_OWNER_INDEX
            type.Items.Add("Player");
            // type.SetBinding(Picker.SelectedIndexProperty, "IndexType");

            var labelField = new Label
            {
                Text = "Register Field",
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            var fieldName = new Label
            {
                Text = "Name",
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };
            fieldName.SetBinding(Label.TextProperty, "FieldName");

            var fieldNameEntry = new Entry
            {
                Keyboard = Keyboard.Default,
            };

            var fieldDimension = new Label
            {
                Text = "Dimension",
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };

            var fieldAvailability = new Label
            {
                Text = "Availabity",
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };

            var price = new Label
            {
                Text = "Price",
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };

            var city = new Label
            {
                Text = "City",
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };

            var layout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Padding = 10
            };
            layout.Children.Add(labelFirstName);
            layout.Children.Add(firstName);
            layout.Children.Add(labelLastName);
            layout.Children.Add(lastName);
            layout.Children.Add(labelUsername);
            layout.Children.Add(username);
            layout.Children.Add(labelPassword);
            layout.Children.Add(_password);
            layout.Children.Add(labelConfirmPassword);
            layout.Children.Add(_confirmPassword);
            layout.Children.Add(labelPhone);
            layout.Children.Add(phone);
            layout.Children.Add(labelType);
            layout.Children.Add(type);

            var ownerLayout = new StackLayout() { Orientation = StackOrientation.Vertical, IsVisible = false };

            ownerLayout.Children.Add(labelField);
            ownerLayout.Children.Add(fieldName);
            ownerLayout.Children.Add(fieldNameEntry);
            ownerLayout.Children.Add(fieldDimension);
            ownerLayout.Children.Add(fieldAvailability);
            ownerLayout.Children.Add(city);

            ownerLayout.SetBinding(StackLayout.IsVisibleProperty, "IsOwner");

            type.SelectedIndexChanged += (sender, args) =>
            {
                _viewModel.IsOwner = type.SelectedIndex == PICKER_OWNER_INDEX;
            };

            layout.Children.Add(ownerLayout);
            layout.Children.Add(buttonRegister);

            var scrollView = new ScrollView { Content = layout };
            Content = scrollView;
        }

        private async void OnAlertClicked(object sender, EventArgs e)
        {
            if (_password.Text.Equals(_confirmPassword.Text))
                await (DisplayAlert("Message", "Password completed", "OK"));

            else
                await (DisplayAlert("Message", "Password deosn't match ", "Cancel"));
        }

    }
}

