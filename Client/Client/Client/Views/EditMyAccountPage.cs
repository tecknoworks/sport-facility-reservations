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
		
        private const int PICKER_OWNER_INDEX = 0;
        public EditMyAccountViewModel _viewModel;
        public Entry _password;
        public Entry _confirmPassword;
        private TimePicker _startTime;
        private TimePicker _endTime;
        public EditMyAccountPage()
        {
            Title = "My Account";
            Init();
        }
        public async Task Init()
        {
            _viewModel = App.Container.Resolve<EditMyAccountViewModel>();
            BindingContext = _viewModel;


            ToolbarItems.Add(new ToolbarItem
            {
                Name = "Save",
                Order = ToolbarItemOrder.Primary,
                Command = new Command(async () => {
                    await _viewModel.UpdateUser();
                    if (_viewModel.IsOwner)
                    {
                        //await Navigation.PopAsync();
                        await Navigation.PushAsync(new OwnerHomePage());
                    }
                    else
                    {
                        //await Navigation.PopAsync();
                        await Navigation.PushAsync(new HomePage($"Hello, {Settings.FirstName}"));
                    }
                } )
            });


            await _viewModel.LoadGetUserByIdAsync();

            var labelFirstName = new Label
            {
                Text = "First Name",
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            var firstName = new Entry
            {
                Keyboard = Keyboard.Default,
				HeightRequest = Constants.ENTRY_HEIGHT
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
				HeightRequest = Constants.ENTRY_HEIGHT
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
                Keyboard = Keyboard.Default,
				HeightRequest = Constants.ENTRY_HEIGHT
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
                Keyboard = Keyboard.Numeric,
				HeightRequest = Constants.ENTRY_HEIGHT
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
				HeightRequest = Constants.ENTRY_HEIGHT
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
                IsPassword = true,
				HeightRequest = Constants.ENTRY_HEIGHT
            };
            _confirmPassword.SetBinding(Entry.TextProperty, "ConfirmPassword");

            var labelType = new Label
            {
                Text = "Type",
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            var type = new Picker
            {
				HeightRequest = Constants.ENTRY_HEIGHT
            };
            type.Items.Add("Owner");  // 0 = PICKER_OWNER_INDEX
            type.Items.Add("Player");
            type.SetBinding(Picker.SelectedIndexProperty, "Status");

            var labelField = new Label
            {
                Text = "Register Field",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            var fieldName = new Label
            {
                Text = "Field Name",
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            var fieldNameEntry = new Entry
            {
                Keyboard = Keyboard.Default,
				HeightRequest = Constants.ENTRY_HEIGHT
            };
            fieldNameEntry.SetBinding(Entry.TextProperty, "FieldName");

            var fieldDimension = new Label
            {
                Text = "Dimension",
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };

            var labelLength = new Label
            {
                Text = "Length",
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            var entryLength = new Entry
            {
                Keyboard = Keyboard.Numeric,
				HeightRequest = Constants.ENTRY_HEIGHT 
            };
            entryLength.SetBinding(Entry.TextProperty, "Length");

            var labelWidth = new Label
            {
                Text = "Width",
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            var entryWidth = new Entry
            {
                Keyboard = Keyboard.Numeric,

            };
            entryWidth.SetBinding(Entry.TextProperty, "Width");

            var fieldAvailability = new Label
            {
                Text = "Availabity",
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };

            _startTime = new TimePicker() { Format = "T" };
            _startTime.SetBinding(TimePicker.TimeProperty, "StartTime");

            _endTime = new TimePicker() { Format = "T" };
            _endTime.SetBinding(TimePicker.TimeProperty, "EndTime");

            var price = new Label
            {
                Text = "Price per Hour",
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };
            var priceEntry = new Entry
            {
                Keyboard = Keyboard.Numeric,
				HeightRequest = Constants.ENTRY_HEIGHT
            };
            priceEntry.SetBinding(Entry.TextProperty, "Price");

            var adress = new Label
            {
                Text = "Address",
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };
            var adressEntry = new Entry
            {
                Keyboard = Keyboard.Default,
				HeightRequest = Constants.ENTRY_HEIGHT
            };
            adressEntry.SetBinding(Entry.TextProperty, "Adress");

            var sportsLabel = new Label
            {
                Text = "Sports",
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };

			var sports = new Picker
			{
				HeightRequest = Constants.ENTRY_HEIGHT
			};
            sports.Items.Add("Football");
            sports.Items.Add("Tennis");
            sports.Items.Add("Squash");
            sports.SetBinding(Picker.SelectedIndexProperty, "SportIndex");

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
            layout.Children.Add(type);

            var ownerLayout = new StackLayout() { Orientation = StackOrientation.Vertical, IsVisible = false };

            ownerLayout.Children.Add(labelField);
            ownerLayout.Children.Add(sportsLabel);
            ownerLayout.Children.Add(sports);
            ownerLayout.Children.Add(fieldName);
            ownerLayout.Children.Add(fieldNameEntry);
            ownerLayout.Children.Add(adress);
            ownerLayout.Children.Add(adressEntry);
            ownerLayout.Children.Add(fieldDimension);
            ownerLayout.Children.Add(labelLength);
            ownerLayout.Children.Add(entryLength);
            ownerLayout.Children.Add(labelWidth);
            ownerLayout.Children.Add(entryWidth);
            ownerLayout.Children.Add(fieldAvailability);
            ownerLayout.Children.Add(_startTime);
            ownerLayout.Children.Add(_endTime);
            ownerLayout.Children.Add(price);
            ownerLayout.Children.Add(priceEntry);

            ownerLayout.SetBinding(StackLayout.IsVisibleProperty, "IsOwner");

            type.SelectedIndexChanged += (sender, args) =>
            {
                _viewModel.IsOwner = type.SelectedIndex == PICKER_OWNER_INDEX;
            };

                await _viewModel.GetFieldAsync();          

            layout.Children.Add(ownerLayout);

            var scrollView = new ScrollView { Content = layout };
            Content = scrollView;
        }
    }
}