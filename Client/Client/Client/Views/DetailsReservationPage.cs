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

			var stack = new StackLayout { Padding = 30, VerticalOptions = LayoutOptions.Start };

			var nameLabel = new Label
			{
				Text = "Pending reservation from: ",
				FontSize = Constants.LABEL_FONT_SIZE
			};
			stack.Children.Add(nameLabel);

            var fullName = new Label
            {
				Text = reservation.FirstName + " " + reservation.LastName,       
            };
            stack.Children.Add(fullName);

			var phoneLabel = new Label
			{
				Text = "Phone: ",
				FontSize = Constants.LABEL_FONT_SIZE
			};
			stack.Children.Add(phoneLabel);

            var phone = new Label
            {
                Text = reservation.PhoneNumber,    
            };
            stack.Children.Add(phone);

			var grid = new Grid();

            acceptBtn = new Button
            {
                Text = "Accept",
				TextColor = Color.Green,
				FontSize = Constants.LABEL_FONT_SIZE,
				VerticalOptions = LayoutOptions.StartAndExpand
			};
            grid.Children.Add(acceptBtn, 0, 0);
            acceptBtn.Clicked += AcceptButton_Clicked;

            rejectBtn = new Button
            {
                Text = "Reject",
				TextColor = Color.Red,
				FontSize = Constants.LABEL_FONT_SIZE,
				VerticalOptions = LayoutOptions.StartAndExpand
            };
            grid.Children.Add(rejectBtn, 0, 1);
            rejectBtn.Clicked += RejectButton_Clicked;
			stack.Children.Add(grid);

            Content = stack;

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

