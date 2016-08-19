using System;
using Xamarin.Forms;
using Microsoft.Practices.Unity;
using System.Threading.Tasks;

namespace Client
{
	public class MyReservationsPage : ContentPage
	{
		MyReservationsViewModel _viewModel;

		public MyReservationsPage()
		{
			Title = "My Reservations";
			Init();
		}

		public async Task Init()
		{
			_viewModel = App.Container.Resolve<MyReservationsViewModel>();
			BindingContext = _viewModel;

			await _viewModel.LoadReservationsAsync();

			var stack = new StackLayout
			{
				Orientation = StackOrientation.Vertical,
				Padding = new Thickness(0, 8, 0, 8)
			};

			ListView listView = new ListView();
			listView.ItemsSource = _viewModel.Reservations;
			var cell = new DataTemplate(typeof(TextCell));
			cell.SetBinding(TextCell.TextProperty, "Field");
			cell.SetBinding(TextCell.DetailProperty, "Status");
			listView.ItemTemplate = cell;


			listView.SetBinding(ListView.ItemsSourceProperty, "Reservations");
			stack.Children.Add(listView);
			Content = stack;


			//ListView myReservationsListView = new ListView
			//{
			//	ItemsSource = _viewModel.Reservations,
			//	ItemTemplate = new DataTemplate(() =>
			//	{
			//		Label name = new Label
			//		{
			//			Text = "Field Name"
			//		};

			//		Button reservationStatus = new Button();

			//		if (_viewModel.Reservations.Status.Equals("accepted"))
			//		{
			//			reservationStatus.Text = "Accepted";
			//			reservationStatus.TextColor = Color.Green;
			//		}
			//		else if (_viewModel.Reservations.Status.Equals("rejected"))
			//		{
			//			reservationStatus.Text = "Rejected";
			//			reservationStatus.TextColor = Color.Red;
			//		}
			//		else {
			//			reservationStatus.Text = "Pending";
			//			reservationStatus.TextColor = Color.FromHex("#ffb732");
			//		}

			//		return new ViewCell
			//		{
			//			View = new StackLayout
			//			{
			//				Padding = new Thickness(0, 5),
			//				Orientation = StackOrientation.Horizontal,
			//				Children =
			//				{
			//					name
			//				}
			//			}
			//		};
			//	})
			//};
		}
	}
}

