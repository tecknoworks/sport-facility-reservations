using Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microsoft.Practices.Unity;

namespace Client.Views
{
    public class SearchPage: ContentPage
    {
        public static NavigationPage NavigationPage;
        private SearchPageViewModel _viewModel;
        public SearchPage()
        {
            Title = "Fields";
            Init();   
        }

        public async Task Init() {
            _viewModel = App.Container.Resolve<SearchPageViewModel>();
            BindingContext = _viewModel;

            var soccerLabel = new Label
            {
                Text = "Soccer Field"
            };
            var soccerFields = new Image
            {
                Source = "football_field.jpg"
               
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
            var tapGestureRecognizer2 = new TapGestureRecognizer();
            tapGestureRecognizer2.Tapped += OnTapGestureRecognizerTapped2;
            tennisFields.GestureRecognizers.Add(tapGestureRecognizer2);

            var squashlabel = new Label
            {
                Text = "squash court"
            };
            var squashfields = new Image
            {
                Source = "squash2.jpg",
               // WidthRequest = 300,
               // HeightRequest = 200
            };
            squashfields.GestureRecognizers.Add(new TapGestureRecognizer(sender => { squashfields.Opacity = 0.6; squashfields.FadeTo(1); }));

            Content = new StackLayout
            {
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

        public async void OnTapGestureRecognizerTapped2(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new OwnerHomePage());
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
