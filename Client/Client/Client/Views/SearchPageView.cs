using Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Client.Views
{
    class SearchPageView:ContentPage
    {
        private SearchPageViewModel _viewModel;
        public SearchPageView()
        {
            Title = "Search page";
            Init();   
        }

        public async Task Init() {
            _viewModel = new SearchPageViewModel();
            BindingContext = _viewModel;

            var soccerFields = new Button
            {
                Text = "Soccer Fields",
                WidthRequest = 200,
                HeightRequest = 50,
                BorderWidth = 5
            };

            var tennisFields = new Button
            {
                Text = "Tennis Fields",
                WidthRequest = 200,
                HeightRequest = 50,
                BorderWidth = 5
            };

            Content = new StackLayout
            {
                Children =
                {
                    soccerFields,
                    tennisFields
                }
            };
        }
    }
}
