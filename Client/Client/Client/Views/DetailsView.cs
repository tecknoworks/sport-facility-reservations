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

            _viewModel.FieldId = item.id;

            var date = new DatePicker
            {
                Format = "D"
            };
            date.SetBinding(DatePicker.DateProperty, "Date");

            var time = new TimePicker
            {
                Format = "T"
            };
            time.SetBinding(TimePicker.TimeProperty, "Time");
            
            var button = new Button
            {
                Text = "Reserve"
            };
            button.Clicked += ReserveButton_Clicked;

            Content = new StackLayout
            {
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
