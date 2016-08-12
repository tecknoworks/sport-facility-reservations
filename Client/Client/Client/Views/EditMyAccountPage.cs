using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microsoft.Practices.Unity;
using Client.ViewModels;
using Client.Services;

namespace Client.Views
{
    public class EditMyAccountPage : ContentPage
    {
        public EditMyAccountViewModel _viewModel;
        public Entry _password;
        public Entry _confirmPassword;
        public EditMyAccountPage()
        {
            Title = "Edit My Account Page";
            Init();
        }
        public async Task Init()
        {
            _viewModel = App.Container.Resolve<EditMyAccountViewModel>();
            BindingContext = _viewModel;

            await _viewModel.LoadGetUserByIdAsync();

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
            username.SetBinding(Entry.TextProperty, "Username");

            var labelPhone = new Label
            {
                Text = "Phone",
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };

            var phone = new Entry
            {
                Keyboard = Keyboard.Numeric
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
                IsPassword = true,
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
                Text = "Save"
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
            
            ListView listView = new ListView();
            listView.ItemsSource = _viewModel.Users;
            var cell = new DataTemplate(typeof(TextCell));
            cell.SetBinding(TextCell.TextProperty, "FirstName");
            cell.SetBinding(TextCell.DetailProperty, "FirsttName");
            cell.SetBinding(TextCell.TextProperty, "LastName");
            cell.SetBinding(TextCell.DetailProperty, "Password");
            cell.SetBinding(TextCell.TextProperty, "ConfirmPassword");
            cell.SetBinding(TextCell.DetailProperty, "Location");
            listView.ItemTemplate = cell;

            listView.SetBinding(ListView.ItemsSourceProperty, "Users");
            layout.Children.Add(listView);
            Content = layout;

        }
    }
}