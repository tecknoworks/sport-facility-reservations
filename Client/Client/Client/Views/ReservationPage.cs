using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Client.Views
{
    class ReservationPage: ContentPage
    {
        public ReservationPage()
        {
            Title = "Reservation Page";
            Init();
        }

        public async Task Init()
        {
            var reservationList = new ListView();
            reservationList.ItemsSource = new List<String>() { "R1", "R2", "R3" };
            Content = reservationList;
        }
    }
}
