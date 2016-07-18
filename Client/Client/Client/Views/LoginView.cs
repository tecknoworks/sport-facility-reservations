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
        public Image Img { get; set; }
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
            Grid grid = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                RowDefinitions =
                {
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto }
                },
                ColumnDefinitions =
                {
              
                
                }
            };


            var usernameLabel = new Label
            {
                Text = "Username",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            grid.Children.Add(usernameLabel, 0,2);

            var passwordLabel = new Label
            {
                Text = "Password",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            grid.Children.Add(passwordLabel, 0, 4);

            _usernameEntry = new Entry
            {
                Placeholder = "Fill in your password",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Keyboard = Keyboard.Default
            };
            grid.Children.Add(_usernameEntry, 0, 3);
            _usernameEntry.SetBinding(Entry.TextProperty, "Username");

            var passwordEntry = new Entry
            {
                Placeholder = "Fill in your password",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Keyboard = Keyboard.Default,
                IsPassword = true
            };
            grid.Children.Add(passwordEntry, 0,5 );
            passwordEntry.SetBinding(Entry.TextProperty, "Password");

            var loginButton = new Button
            {
                Text = "Login",
                FontSize = 10,
                BorderWidth = 1,
                WidthRequest = 100,
                HeightRequest = 30,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
<<<<<<< HEAD
            grid.Children.Add(button, 0, 6);
            button.Clicked += Button_Clicked;
=======
            grid.Children.Add(loginButton, 1, 4);
            loginButton.Clicked += Button_Clicked;
>>>>>>> 95eb3b9e0d2d070a93a7708c5712a097582cb9f8

            var registerLabel = new Label
            {
                Text = "Don't have an account?",
                FontSize = 10,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            grid.Children.Add(registerLabel, 0, 7);


            var registerButton = new Button
            {
                Text = "Register",
                FontSize = 10,
                WidthRequest = 100,
                HeightRequest = 30,
                BorderWidth = 1,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand

            };
<<<<<<< HEAD
            grid.Children.Add(button2, 0, 8);
            button2.Clicked += Button_Clicked2;
=======
            grid.Children.Add(registerButton, 1, 7);
            registerButton.Clicked += Button_Clicked2;
>>>>>>> 95eb3b9e0d2d070a93a7708c5712a097582cb9f8

            //Content = new StackLayout
            //{
            //    Children =
            //    {
            //        usernameLabel,
            //        _usernameEntry,
            //        passwordLabel,
            //        passwordEntry,
            //        button,
            //        registerLabel,
            //        button2
            //    }
            //};
            this.Content = grid;
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            var homePageView = new HomePageView($"Hello, {_usernameEntry.Text}");
            await Navigation.PushAsync(homePageView);

        }
        private async void Button_Clicked2(object sender, EventArgs e)
        {
            var homePageView = new RegisterView();
            await Navigation.PushAsync(homePageView);

        }
    }
}
