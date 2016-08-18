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
    public class DetailsReservationPage:ContentPage
    {
        public DetailsReservationPage(Reservation reservation)
        {

            Grid grid = new Grid
            {
               HorizontalOptions = LayoutOptions.CenterAndExpand,
               VerticalOptions=LayoutOptions.Start,
                RowDefinitions =
                {
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },

                },
                ColumnDefinitions=
                {
                    new ColumnDefinition {Width=GridLength.Auto },
                    new ColumnDefinition {Width=GridLength.Auto }
                }
            };

            var firstName = new Label
            {
                Text = reservation.FirstName,
                HorizontalOptions = LayoutOptions.Start
            };
            grid.Children.Add(firstName, 0, 0);

            var lastName = new Label
            {
                Text = reservation.LastName,
                HorizontalOptions = LayoutOptions.Start
            };
            grid.Children.Add(lastName, 1, 0);

            var phone = new Label
            {
                Text = reservation.PhoneNumber,
                HorizontalOptions = LayoutOptions.Start
            };
            grid.Children.Add(phone, 0, 1);

            var acceptBtn = new Button
            {
                Text = "Accept",
                HorizontalOptions = LayoutOptions.EndAndExpand,
                Font = Font.SystemFontOfSize(NamedSize.Micro)
            };
            grid.Children.Add(acceptBtn, 0, 2);

            var rejectBtn = new Button
            {
                Text = "Reject",
                HorizontalOptions = LayoutOptions.EndAndExpand,
                Font = Font.SystemFontOfSize(NamedSize.Micro)
            };
            grid.Children.Add(rejectBtn, 1, 2);

            Content = grid;
        }
    }
}
