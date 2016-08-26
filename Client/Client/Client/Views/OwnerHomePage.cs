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
	class OwnerHomePage :TabbedPage
    {
        public OwnerHomePage()
        {
			NavigationPage.SetHasBackButton(this, false);
            var homePage = new HomePage($"Hello, {Settings.FirstName}");
            homePage.Icon = "home-16.png";
            var reservationPage = new ReservationPage();
			reservationPage.Icon = "list-16.png";
			Children.Add(reservationPage);
			Children.Add(homePage);
        }

		protected override void OnAppearing()
		{
			base.OnAppearing();
		}
    }
}
