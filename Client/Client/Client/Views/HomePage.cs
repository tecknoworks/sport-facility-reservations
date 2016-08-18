using Client.ViewModels;
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
    public class HomePage : ContentPage
    {
        private const int BORDER = 1;
        private HomeViewModel _viewModel;
        private string _greetingText;
        public HomePage(string greetingText)
        {
            Title = "Home";
            _greetingText = greetingText;
            Init();
        }
        public async Task Init()
        {
            _viewModel = App.Container.Resolve<HomeViewModel>();
            BindingContext = _viewModel;

            var signOutButton = new Button
            {
                Text = "Log out"
            };
            signOutButton.Clicked += SignOutButton_Clicked;

            var label = new Label
            {
                Text = "your name",
                TextColor = Color.White,
                Font = Font.SystemFontOfSize(NamedSize.Large),
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            label.SetBinding(Label.TextProperty, "GreetingText");

            _viewModel.GreetingText = _greetingText;

            var contentLayout = new StackLayout { Padding = 50, VerticalOptions = LayoutOptions.Center };

            var searchButton = new Button
            {
                Text = "Search",
                WidthRequest = 200,
                HeightRequest = 50,
                BorderWidth = BORDER,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            searchButton.Clicked += NavigationButton_Clicked;

            var viewFieldsButton = new Button
            {
                Text = "View fields",
                BorderWidth = BORDER,
                WidthRequest = 200,
                HeightRequest = 50,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            viewFieldsButton.Clicked += viewFieldsButton_Clicked;

            var editAccountButton = new Button
            {
                Text = "My Account",
                WidthRequest = 200,
                HeightRequest = 50,
                BorderWidth = BORDER,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            editAccountButton.Clicked += editAccountButton_Clicked;
            contentLayout.Children.Add(label);
            contentLayout.Children.Add(viewFieldsButton);
            contentLayout.Children.Add(searchButton);
            contentLayout.Children.Add(editAccountButton);
            contentLayout.Children.Add(signOutButton);

            Content = contentLayout;
        }

        private async void editAccountButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditMyAccountPage());
        }

        private async void SignOutButton_Clicked(object sender, EventArgs e)
        {
            _viewModel.SignOut();
            await Navigation.PopAsync();
            NavigationPage.SetHasBackButton(this, false);
            await Navigation.PushAsync(new LoginPage());
        }

        private async void viewFieldsButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FieldsListView());
        }

        private async void NavigationButton_Clicked(object sender, EventArgs e)
        {
            var searchPageView = new SearchPage();
            await Navigation.PushAsync(searchPageView);
        }
    }
}
