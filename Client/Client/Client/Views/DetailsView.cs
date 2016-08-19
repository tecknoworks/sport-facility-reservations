using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microsoft.Practices.Unity;
using Client.ViewModels;

namespace Client.Views
{
    public class NewsDetailsView : ContentPage
    {
        public DetailsViewModel _viewModel;

        public NewsDetailsView(Field item)
        {
            _viewModel = App.Container.Resolve<DetailsViewModel>();
            BindingContext = _viewModel;

            _viewModel.FieldId = item.Id;

			var fieldName = new Entry
			{
				Text = item.Name
			};

            var date = new DatePicker
            {
                Format = "D",
                MinimumDate = DateTime.Now
            };
            date.SetBinding(DatePicker.DateProperty, "Date");

            var time = new TimePicker
            {
                Format = "T",
                Time = new TimeSpan(DateTime.Now.Hour, 0, 0)
            };
            time.SetBinding(TimePicker.TimeProperty, "Time");
            
            var button = new Button
            {
                Text = "Reserve"
            };
            button.Clicked += ReserveButton_Clicked;

            Content = new StackLayout
            {
                Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5),
                Children =
                {
                    date,
                    time,
                    button
                }
            };
        }

        private async void ReserveButton_Clicked(object sender, EventArgs e)
        {
            await _viewModel.ReserveAsync();
        }
    }
}
