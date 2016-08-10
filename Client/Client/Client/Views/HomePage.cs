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
    public class HomePage: ContentPage
    {
        private HomeViewModel _viewModel;
        private string _greetingText;
        public HomePage(string greetingText)
        {
            Title = "Home Page";
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
            
            var contentLayout = new StackLayout { Padding = 50, VerticalOptions = LayoutOptions.End };

            var searchButton = new Button
            {
                Text = "Search",
                WidthRequest = 200,
                HeightRequest = 50,
                BorderWidth = 5,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            searchButton.Clicked += Button_Clicked;

            var viewFieldsButton = new Button
            {
                Text = "View fields",
                BorderWidth = 5,
                WidthRequest = 200,
                HeightRequest = 50,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            viewFieldsButton.Clicked += viewFieldsButton_Clicked;

            var editAccountButton = new Button
            {
                Text = "Edit My Account",
                WidthRequest = 200,
                HeightRequest = 50,
                BorderWidth = 5,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            editAccountButton.Clicked += EditMyAccount_Clicked;

            
            contentLayout.Children.Add(label);
            contentLayout.Children.Add(viewFieldsButton);
            contentLayout.Children.Add(searchButton);
            contentLayout.Children.Add(editAccountButton);
            contentLayout.Children.Add(signOutButton);

            var myImage = new Image
            {
                Source = ImageSource.FromFile("image4.jpg")
            };
            var relativeLayout = new RelativeLayout();
            relativeLayout.Children.Add(myImage,
                Constraint.Constant(0),
                Constraint.Constant(0),
                Constraint.RelativeToParent((parent) => { return parent.Width; }),
                Constraint.RelativeToParent((parent) => { return parent.Height; }));
           
            relativeLayout.Children.Add(contentLayout,
                Constraint.Constant(0),
                Constraint.Constant(0),
                Constraint.RelativeToParent((parent) => { return parent.Width ; }),
                Constraint.RelativeToParent((parent) => { return parent.Height / 2+ 60; }));
            
            Content = relativeLayout;
        }
        public async void EditMyAccount_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditMyAccountPage());
        }
        private async void SignOutButton_Clicked(object sender, EventArgs e)
        {
            _viewModel.SignOut();
            await Navigation.PushAsync(new LoginPage());
        }

        private async void viewFieldsButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FieldsListView());
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var searchPageView = new SearchPage();
            await Navigation.PushAsync(searchPageView);
        }
    }
}
