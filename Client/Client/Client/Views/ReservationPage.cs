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
            Title = "Reservation Page";
            Init();
        }
        public async Task Init()
        {
            _viewModel = App.Container.Resolve<ReservationPageViewModel>();
            BindingContext = _viewModel;

            await _viewModel.LoadReservedFieldsAsync();

            var stack = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Padding = new Thickness(0, 8, 0, 8)
            };

            ListView listView = new ListView();
            listView.ItemsSource = _viewModel.ReservedFields;
            var cell = new DataTemplate(typeof(TextCell));
            cell.SetBinding(TextCell.TextProperty, "Field");
            cell.SetBinding(TextCell.DetailProperty, "StartHour");
            listView.ItemTemplate = cell;


            listView.ItemTapped += (sender, args) => {
                if (listView.SelectedItem == null)
                    return;
                this.Navigation.PushAsync(new DetailsReservationPage());
                listView.SelectedItem = null;
            };

            listView.SetBinding(ListView.ItemsSourceProperty, "ReservedFields");
            stack.Children.Add(listView);
            Content = stack;
        }
    }
}
