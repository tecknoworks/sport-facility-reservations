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
        public DetailsReservationViewModel _viewModel;
        public DetailsReservationPage()
        {
            _viewModel = App.Container.Resolve<DetailsReservationViewModel>();
            BindingContext = _viewModel;

            var userName = new Label
            {
                HorizontalOptions = LayoutOptions.Start
            };
            userName.SetBinding(Label.TextProperty, "Username");

            var phone=new Label
            {
                HorizontalOptions = LayoutOptions.Start
            };
            phone.SetBinding(Label.TextProperty, "Phone");

           var acceptBtn = new Button
            {
                Text = "Accept",
                HorizontalOptions = LayoutOptions.EndAndExpand,
                Font = Font.SystemFontOfSize(NamedSize.Micro)
            };

            var rejectBtn = new Button
            {
                Text = "Reject",
                HorizontalOptions = LayoutOptions.EndAndExpand,
                Font = Font.SystemFontOfSize(NamedSize.Micro)
            };

            Content = new StackLayout
            {
                Children =
                {   userName,
                    phone,
                    acceptBtn,
                    rejectBtn      
                }
            };

        }
    }
}
