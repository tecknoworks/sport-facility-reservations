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

			var fieldName = new Label
			{
				Text = "Name:  " + item.Name,
				FontSize = Constants.LABEL_FONT_SIZE,
				HorizontalOptions = LayoutOptions.StartAndExpand
			};

			var fieldLocation = new Label
			{
				Text = "Location:  " + item.Location,
				FontSize = Constants.LABEL_FONT_SIZE,
				HorizontalOptions = LayoutOptions.StartAndExpand
			};

			var fieldType = new Label
			{
				FontSize = Constants.LABEL_FONT_SIZE,
				HorizontalOptions = LayoutOptions.StartAndExpand
			};

			if (item.Type == 0)
			{
				fieldType.Text = "Type:  Soccer Field";
			}
			else if (item.Type == 1)
			{
				fieldType.Text = "Type:  Tennis Field";
			}
			else {
				fieldType.Text = "Type:  Squash Field";
			}

			var fieldProgram = new Label
			{
				Text = "Open:  " + item.StartTime + " - " + item.EndTime,
				FontSize = Constants.LABEL_FONT_SIZE,
				HorizontalOptions = LayoutOptions.StartAndExpand
			};

			var fieldPrice = new Label
			{
				Text = "Price per hour:  " + item.Price,
				FontSize = Constants.LABEL_FONT_SIZE,
				HorizontalOptions = LayoutOptions.StartAndExpand
			};

            var date = new DatePicker
            {
                Format = "D",
                MinimumDate = DateTime.Now,
				HeightRequest = Constants.ENTRY_HEIGHT
            };
            date.SetBinding(DatePicker.DateProperty, "Date");

           var timePicker = new TimePicker
		   {
			   Format = "HH:mm",
			   HeightRequest = Constants.ENTRY_HEIGHT,
			   Time = new TimeSpan(DateTime.Now.Hour + 1, 0, 0)
		   };
            
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
					fieldName,
					fieldLocation,
					fieldType,
					fieldProgram,
					fieldPrice,
                    date,
                    timePicker,
                    button
                }
            };
        }

        private async void ReserveButton_Clicked(object sender, EventArgs e)
        {
            await _viewModel.ReserveAsync();
			await DisplayAlert("", "Your reservation was registered. Please check if accepted", "OK");
			await Navigation.PushAsync(new HomePage(""));
        }
    }
}
