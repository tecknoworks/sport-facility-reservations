using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microsoft.Practices.Unity;
using Client.Views;

namespace Client.ViewModels
{
    public class SoccerFieldsView: ContentPage
    {
        SoccerFieldsViewModel _viewModel;
        public List<Models.Field> soccerFields;

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
                MinimumDate = DateTime.Now,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            datePicker.SetBinding(DatePicker.DateProperty, "Availability");
            grid.Children.Add(datePicker, 1, 0);

            var timePicker = new TimePicker
            {
                Format = "T",
                Time = new TimeSpan(DateTime.Now.Hour, 0, 0)
            };
            grid.Children.Add(timePicker, 1, 1);

            var nameLabel = new Label
            {
                Text = "Name"
            };
            grid.Children.Add(nameLabel, 0, 2);

            var nameEntry = new Entry
            {
                Keyboard = Keyboard.Default,

            };
            grid.Children.Add(nameEntry, 1, 2);
            nameEntry.SetBinding(Entry.TextProperty, "Name");

            var dimensionLabel = new Label
            {
                Text = "Dimension"
            };
            grid.Children.Add(dimensionLabel, 0, 3);

       
            var dimensionPicker = new Picker
            {
                Title = "Dimension",
                SelectedIndex = 0
            };
            dimensionPicker.Items.Add("2x5");
            dimensionPicker.Items.Add("2x6");
            dimensionPicker.Items.Add("2x7");
            grid.Children.Add(dimensionPicker, 1, 3);

            var cityLabel = new Label
            {
                Text = "City"
            };
            grid.Children.Add(cityLabel, 0, 4);

            var cityEntry = new Entry
            {
                Keyboard = Keyboard.Default
            };
            grid.Children.Add(cityEntry, 1, 4);
            cityEntry.SetBinding(Entry.TextProperty, "City");

            var searchButton = new Button
            {
                Text = "Search",
                HeightRequest = 2
            };
            grid.Children.Add(searchButton, 1, 5);
            searchButton.Clicked += SearchButton_Clicked;

            ListView listView = new ListView
            {
                ItemsSource = soccerFields,
                ItemTemplate = new DataTemplate(() =>
                {
                    var name = new Label();
                    name.SetBinding(Label.TextProperty, "Name");
                    var city = new Label();
                    city.SetBinding(Label.TextProperty, "City");
                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            Children =
                            {
                                name,
                                city
                            }
                        }
                    };
                }
                )
            };
            listView.SetBinding(ListView.ItemsSourceProperty, "Fields");
            grid.Children.Add(listView, 0, 6);
            Content = grid;


        }

        private async void SearchButton_Clicked(object sender, EventArgs e)
        {
            await _viewModel.SearchVMAsync();
            
        }
    }
}
