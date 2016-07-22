using Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Client.Views
{
    public class SearchPage: ContentPage
    {
        public static NavigationPage NavigationPage;
        private SearchPageViewModel _viewModel;
        public SearchPage()
        {
            Title = "Search page";
            Init();   
        }

        public async Task Init() {
            _viewModel = new SearchPageViewModel();
            BindingContext = _viewModel;

            var soccerLabel = new Label
            {
                Text = "Soccer Field"
            };
            var soccerFields = new Image
            {
                BackgroundColor = Color.Yellow,
                Source = "football_field.jpg",
               // WidthRequest = 300,
               // HeightRequest = 200
            };
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += OnTapGestureRecognizerTapped;
            soccerFields.GestureRecognizers.Add(tapGestureRecognizer);

            var tennisLabel = new Label
            {
                Text = "Tennis Court"
            };
            var tennisFields = new Image
            {
                Source = "tennis_field.png",
               // WidthRequest = 300,
               // HeightRequest = 200
            };
            tennisFields.GestureRecognizers.Add(new TapGestureRecognizer(sender => { tennisFields.Opacity = 0.6; tennisFields.FadeTo(1); }));

            var squashlabel = new Label
            {
                Text = "squash court"
            };
            var squashfields = new Image
            {
                BackgroundColor = Color.Red,
                Source = "squash2.jpg",
               // WidthRequest = 300,
               // HeightRequest = 200
            };
            squashfields.GestureRecognizers.Add(new TapGestureRecognizer(sender => { squashfields.Opacity = 0.6; squashfields.FadeTo(1); }));

            Content = new StackLayout
            {
                BackgroundColor = Color.Accent,
                Children =
                {
                    soccerFields,
                    tennisFields,
                    squashfields
                }
            };
        }

        public async void OnTapGestureRecognizerTapped(object sender, EventArgs args)
        {
           await Navigation.PushAsync(new SoccerFieldsView());
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            var requiredHight = height / 3;
            var layout = (StackLayout)Content;
            foreach(var children in layout.Children)
            {
                children.HeightRequest = requiredHight;
            }
        }
    }
}
