using Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Client.Views
{
    class HomePageView: ContentPage
    {
        private HomePageViewModel _viewModel;
        private string _greetingText;
        public HomePageView(string greetingText)
        {
            Title = "Home Page";
            _greetingText = greetingText;
            Init();
        }

        public async Task Init()
        {
            _viewModel = new HomePageViewModel();
            BindingContext = _viewModel;

            var label = new Label
            {
                Text = "your name",
                Font = Font.SystemFontOfSize(NamedSize.Large),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            label.SetBinding(Label.TextProperty, "GreetingText");

            _viewModel.GreetingText = _greetingText;

            Content = new StackLayout
            {
                Children =
                {
                    label
                }
            };
        }
    }
}
