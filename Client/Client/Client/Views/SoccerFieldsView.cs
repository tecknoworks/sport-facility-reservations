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
			var stackLayout = new StackLayout();
			this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

			var datePicker = new DatePicker
			{
				Format = "D",
				HeightRequest = Constants.ENTRY_HEIGHT,
                MinimumDate = DateTime.Now,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            datePicker.SetBinding(DatePicker.DateProperty, "Availability");
			stackLayout.Children.Add(datePicker);

            var timePicker = new TimePicker
            {
                Format = "HH:mm",
				HeightRequest = Constants.ENTRY_HEIGHT,
				Time = new TimeSpan(DateTime.Now.Hour + 1, 0, 0)
            };
			stackLayout.Children.Add(timePicker);

            var nameEntry = new Entry
            {
                Keyboard = Keyboard.Default,
				HeightRequest = Constants.ENTRY_HEIGHT,
				Placeholder = "Name"
            };
			stackLayout.Children.Add(nameEntry);
            nameEntry.SetBinding(Entry.TextProperty, "Name");
       
            var dimensionPicker = new Picker
            {
                Title = "Dimension",
				HeightRequest = Constants.ENTRY_HEIGHT,
				SelectedIndex = 0
            };
            dimensionPicker.Items.Add("2x5");
            dimensionPicker.Items.Add("2x6");
            dimensionPicker.Items.Add("2x7");
			stackLayout.Children.Add(dimensionPicker);

            var cityEntry = new Entry
            {
                Keyboard = Keyboard.Default,
				HeightRequest = Constants.ENTRY_HEIGHT,
				Placeholder = "City"
            };
			stackLayout.Children.Add(cityEntry);
            cityEntry.SetBinding(Entry.TextProperty, "City");

            var searchButton = new Button
            {
                Text = "Search"
            };
			stackLayout.Children.Add(searchButton);
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
							VerticalOptions = LayoutOptions.Center,
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
			stackLayout.Children.Add(listView);
			Content = stackLayout;


        }

        private async void SearchButton_Clicked(object sender, EventArgs e)
        {
            await _viewModel.SearchVMAsync();
            
        }
    }
}
