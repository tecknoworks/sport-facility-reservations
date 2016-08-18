using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microsoft.Practices.Unity;
using Client.ViewModels;
using Client.Services;

namespace Client.Views
{
    class OwnerHomePage : TabbedPage
    {
        public OwnerHomePage()
        {
			var reservationPage = new ReservationPage();
			reservationPage.Title = "Reservations";
			reservationPage.Icon = "list-16.png";
			Children.Add(reservationPage);
			var homePage = new HomePage($"Hello, {Settings.FirstName}");
			homePage.Icon = "home-16.png";
            Children.Add(homePage);
            //Children.Add(new HomePagee());
        }
    }
}
