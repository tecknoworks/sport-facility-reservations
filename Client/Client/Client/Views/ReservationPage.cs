using Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microsoft.Practices.Unity;
using Client.Models;

namespace Client.Views
{
    public class ReservationPage : ContentPage
    {
        public ReservationPageViewModel _viewModel;
        public ReservationPage()
        {
            Title = "Reservations";
            Init();
        }
        public async Task Init()
        {
            _viewModel = App.Container.Resolve<ReservationPageViewModel>();
            BindingContext = _viewModel;
            

            await _viewModel.LoadReservedFieldsAsync();

            var listView = new ListView
            {
                HorizontalOptions = LayoutOptions.Start,
                ItemsSource = _viewModel.ReservedFields,

                ItemTemplate = new DataTemplate(() =>
                {
					Label nameLabel = new Label();
					nameLabel.SetBinding(Label.TextProperty, "Field");
                    Label dataLabel = new Label();
					dataLabel.SetBinding(Label.TextProperty, "StartHour");
                    Label statusLabel = new Label();
					statusLabel.SetBinding(Label.TextProperty, "Status");

                    var stack = new StackLayout
                    {
                        Padding = new Thickness(0, 5),
                        Orientation = StackOrientation.Horizontal,
                        Children =
                        {
                            nameLabel,
                            dataLabel,
                            statusLabel
                        }
                    };                   
                    
					return new ViewCell
                    {
                        View = stack
                    };
                })
            };

            listView.ItemTapped += (sender, args) =>
            {
                if (listView.SelectedItem == null)
                    return;
                Navigation.PushAsync(new DetailsReservationPage(listView.SelectedItem as Reservation));
                listView.SelectedItem = null;
            };
            listView.SetBinding(ListView.ItemsSourceProperty, "ReservedFields");

            Content = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    listView
                }
            };
        }
    }
}