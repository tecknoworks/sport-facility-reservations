using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microsoft.Practices.Unity;

namespace Client.ViewModels
{
    public class SoccerFieldsView: ContentPage
    {
        SoccerFieldsViewModel _viewModel;
        public SoccerFieldsView()
        {
            Title = "Soccer Field";
            Init();
        }

        public async Task Init()
        {

            _viewModel = App.Container.Resolve<SoccerFieldsViewModel>();
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
                    new RowDefinition { Height = GridLength.Auto }
                }
            };

            var availabilityLabel = new Label
            {
                Text = "Availability"
            };
            grid.Children.Add(availabilityLabel, 0, 0);

            var datePicker = new DatePicker
            {
                Format = "D",
                VerticalOptions= LayoutOptions.CenterAndExpand
            };
            grid.Children.Add(datePicker, 1, 0);

            var timePicker = new TimePicker
            {
                Format = "T"
            };
            grid.Children.Add(timePicker, 2, 0);

            var nameLabel = new Label
            {
                Text = "Name"
            };
            grid.Children.Add(nameLabel, 0, 1);

            var nameEntry = new Entry
            {
                Keyboard = Keyboard.Default,

            };
            grid.Children.Add(nameEntry, 1, 1);
            nameEntry.SetBinding(Entry.TextProperty, "Name");

            var dimensionLabel = new Label
            {
                Text = "Dimension"
            };
            grid.Children.Add(dimensionLabel, 0, 2);
           
            

            var cityLabel = new Label
            {
                Text = "City"
            };
            grid.Children.Add(cityLabel, 0, 3);

            var cityEntry = new Entry
            {
                Keyboard = Keyboard.Default
            };
            grid.Children.Add(cityEntry, 1, 3);
            cityEntry.SetBinding(Entry.TextProperty, "City");

            var searchButton = new Button
            {
                Text = "Search",
                FontSize = 10
            };
            grid.Children.Add(searchButton, 1, 4);
            searchButton.SetBinding(Button.CommandProperty, "SearchCommand");

            Content = grid;

        }
    }
}
