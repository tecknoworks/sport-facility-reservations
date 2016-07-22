using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Client.ViewModels
{
    public class SoccerFieldsView: ContentPage
    {
        public SoccerFieldsView()
        {
            Title = "Soccer Field";
            Init();
        }

        public async Task Init()
        {

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

            var nameLabel = new Label
            {
                Text = "Name"
            };
            grid.Children.Add(nameLabel, 0, 1);

            var nameEntry = new Entry
            {
                Keyboard = Keyboard.Default
            };
            grid.Children.Add(nameEntry, 1, 1);

            var dimensionLabel = new Label
            {
                Text = "Dimension"
            };
            grid.Children.Add(dimensionLabel, 0, 2);
            

            var cityLabel = new Label
            {
                Text = "City"
            };

            var cityEntry = new Entry
            {
                Keyboard = Keyboard.Default
            };

            Content = grid;
        }
    }
}
