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

			var stack = new StackLayout { Padding = 30, HorizontalOptions = LayoutOptions.Start };
			var grid = new Grid();

			var nameLabel = new Label
			{
				Text = "Made by: ",
				FontSize = Constants.LABEL_FONT_SIZE 
			};
			grid.Children.Add(nameLabel, 0, 0);

            var fullName = new Label
            {
				Text = reservation.FirstName + " " + reservation.LastName, 
				VerticalOptions = LayoutOptions.StartAndExpand
            };
            grid.Children.Add(fullName, 1, 0);

			var phoneLabel = new Label
			{
				Text = "Phone: ",
				FontSize = Constants.LABEL_FONT_SIZE 
			};
			grid.Children.Add(phoneLabel, 0, 1);

            var phone = new Label
            {
                Text = reservation.PhoneNumber, 
				VerticalOptions = LayoutOptions.StartAndExpand
            };
            grid.Children.Add(phone, 1, 1);

            acceptBtn = new Button
            {
                Text = "Accept",
				TextColor = Color.Green,
				FontSize = Constants.LABEL_FONT_SIZE,
				VerticalOptions = LayoutOptions.StartAndExpand
			};
            grid.Children.Add(acceptBtn, 0, 2);
            acceptBtn.Clicked += AcceptButton_Clicked;

            rejectBtn = new Button
            {
                Text = "Reject",
				TextColor = Color.Red,
				FontSize = Constants.LABEL_FONT_SIZE,
				VerticalOptions = LayoutOptions.StartAndExpand
            };
            grid.Children.Add(rejectBtn, 1, 2);
            rejectBtn.Clicked += RejectButton_Clicked;
			stack.Children.Add(grid);

            Content = stack;

        }
        private async void AcceptButton_Clicked(object sender, EventArgs e)
        {
            _viewModel.AcceptedAsync();
            acceptBtn.BackgroundColor = Color.Green;
            rejectBtn.BackgroundColor = Color.Default;
            await Navigation.PushAsync(new OwnerHomePage());
        }
        private async void RejectButton_Clicked(object sender, EventArgs e)
        {
            _viewModel.RejectedAsync();
            rejectBtn.BackgroundColor = Color.Red;
            acceptBtn.BackgroundColor = Color.Default;
            await Navigation.PushAsync(new OwnerHomePage());
        }
    }
}

