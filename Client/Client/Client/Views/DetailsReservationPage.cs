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
    public class DetailsReservationPage : ContentPage
    {
        private DetailsReservationViewModel _viewModel;
        Button rejectBtn;
        Button acceptBtn;
        public DetailsReservationPage(Reservation reservation)
        {
            _viewModel = App.Container.Resolve<DetailsReservationViewModel>();
            BindingContext = _viewModel;

            _viewModel.Id = reservation.Id;

            Grid grid = new Grid
            {
                Padding = new Thickness(0, 8, 0, 8),
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Start,
                RowDefinitions =
                {
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },

                },
                ColumnDefinitions =
                {
                    new ColumnDefinition {Width=GridLength.Auto },
                    new ColumnDefinition {Width=GridLength.Auto },
                    new ColumnDefinition {Width=GridLength.Auto }
                }
            };

            var firstName = new Label
            {
                Text = reservation.FirstName,       
            };
            grid.Children.Add(firstName, 0, 0);

            var lastName = new Label
            {
                Text = reservation.LastName,      
            };
            grid.Children.Add(lastName, 1, 0);

            var phone = new Label
            {
                Text = reservation.PhoneNumber,    
            };
            grid.Children.Add(phone, 0, 1);

            acceptBtn = new Button
            {
                Text = "Accept",
                Font = Font.SystemFontOfSize(NamedSize.Micro)
            };
            grid.Children.Add(acceptBtn, 0, 2);
            acceptBtn.Clicked += AcceptButton_Clicked;

            rejectBtn = new Button
            {
                Text = "Reject",
                Font = Font.SystemFontOfSize(NamedSize.Micro)
            };
            grid.Children.Add(rejectBtn, 1, 2);
            rejectBtn.Clicked += RejectButton_Clicked;

            Content = grid;

        }
        private async void AcceptButton_Clicked(object sender, EventArgs e)
        {
            _viewModel.AcceptedAsync();
            acceptBtn.BackgroundColor = Color.Green;
            rejectBtn.BackgroundColor = Color.Default;
            await Navigation.PushAsync(new ReservationPage());


        }
        private async void RejectButton_Clicked(object sender, EventArgs e)
        {
            _viewModel.RejectedAsync();
            rejectBtn.BackgroundColor = Color.Red;
            acceptBtn.BackgroundColor = Color.Default;
            await Navigation.PushAsync(new ReservationPage());
        }
    }
}

