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

            var soccerLabel = new Label
            {
                Text = "Soccer Field"
            };
            var soccerFields = new Image
            {
                Source = "football_field.jpg",
                WidthRequest = 300,
                HeightRequest = 250
            };
            soccerFields.GestureRecognizers.Add(new TapGestureRecognizer(sender => { soccerFields.Opacity = 0.6; soccerFields.FadeTo(1); }));

            var tennisLabel = new Label
            {
                Text = "Tennis Court"
            };
            var tennisFields = new Image
            {
                Source = "tennis_field.png",
                WidthRequest = 300,
                HeightRequest = 250
            };
            tennisFields.GestureRecognizers.Add(new TapGestureRecognizer(sender => { tennisFields.Opacity = 0.6; tennisFields.FadeTo(1); }));

            var squashLabel = new Label
            {
                Text = "Squash Court"
            };
            var squashFields = new Image
            {
                Source = "squash2.jpg",
                WidthRequest = 300,
                HeightRequest = 250
            };
            squashFields.GestureRecognizers.Add(new TapGestureRecognizer(sender => { squashFields.Opacity = 0.6; squashFields.FadeTo(1); }));

            //var relativeLayout1 = new RelativeLayout();
            //relativeLayout1.Children.Add(soccerFields,
            //    Constraint.Constant(0),
            //    Constraint.Constant(0),
            //    Constraint.RelativeToParent((parent) => { return parent.Width; }),
            //    Constraint.RelativeToParent((parent) => { return parent.Height; }));
            //relativeLayout1.Children.Add(soccerLabel,
            //    Constraint.Constant(0),
            //    Constraint.Constant(0),
            //    Constraint.RelativeToParent((parent) => { return parent.Width; }),
            //    Constraint.RelativeToParent((parent) => { return parent.Height; }));

            //var relativeLayout2 = new RelativeLayout();
            //relativeLayout2.Children.Add(tennisFields,
            //    Constraint.Constant(0),
            //    Constraint.Constant(0),
            //    Constraint.RelativeToParent((parent) => { return parent.Width; }),
            //    Constraint.RelativeToParent((parent) => { return parent.Height; }));
            //relativeLayout2.Children.Add(tennisLabel,
            //    Constraint.Constant(0),
            //    Constraint.Constant(0),
            //    Constraint.RelativeToParent((parent) => { return parent.Width; }),
            //    Constraint.RelativeToParent((parent) => { return parent.Height; }));

            //var soccerFields = new Button
            //{
            //    Image = "football_field.jpg",
            //    Text = "Soccer Fields",
            //    //WidthRequest = 200,
            //    HeightRequest = 250,
            //    BorderWidth = 5
            //};

            //var tennisFields = new Button
            //{
            //    Text = "Tennis Fields",
            //   // WidthRequest = 200,
            //    HeightRequest = 250,
            //    BorderWidth = 5
            //};

            Content = new StackLayout
            {
                Children =
                {
                    soccerFields,
                    tennisFields,
                   // squashFields
                }
            };
        }
    }
}
