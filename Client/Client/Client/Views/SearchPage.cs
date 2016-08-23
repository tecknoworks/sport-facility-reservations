using Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microsoft.Practices.Unity;
using Client.Services;

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
            var tapGestureRecognizerSoccer = new TapGestureRecognizer();
            tapGestureRecognizerSoccer.Tapped += OnTapGestureRecognizerTappedSoccer;
            soccerFields.GestureRecognizers.Add(tapGestureRecognizerSoccer);

            var tennisLabel = new Label
            {
                Text = "Tennis Court"
            };
            var tennisFields = new Image
            {
                Source = "tennis_field2.png"
            };
            var tapGestureRecognizerTennis = new TapGestureRecognizer();
            tapGestureRecognizerTennis.Tapped += OnTapGestureRecognizerTappedTennis;
            tennisFields.GestureRecognizers.Add(tapGestureRecognizerTennis);

            var squashlabel = new Label
            {
                Text = "squash court"
            };
            var squashfields = new Image
            {
                Source = "squash.jpg"
            };
			var tapGestureRecognizerSquash = new TapGestureRecognizer();
			tapGestureRecognizerSquash.Tapped += OnTapGestureRecognizerTappedSquash;
			squashfields.GestureRecognizers.Add(tapGestureRecognizerSquash);
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

        public async void OnTapGestureRecognizerTappedSoccer(object sender, EventArgs args)
        {
			Settings.FieldType = 0;
            await Navigation.PushAsync(new SoccerFieldsView());
        }

        public async void OnTapGestureRecognizerTappedTennis(object sender, EventArgs args)
        {
			Settings.FieldType = 1;
			await Navigation.PushAsync(new SoccerFieldsView());
        }

		public async void OnTapGestureRecognizerTappedSquash(object sender, EventArgs args)
		{
			Settings.FieldType = 2;
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
