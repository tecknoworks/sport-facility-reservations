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
			cell.SetValue(TextCell.DetailColorProperty, _viewModel.DetailColor);

			listView.ItemTemplate = cell;

			listView.SetBinding(ListView.ItemsSourceProperty, "Reservations");
			listView.SeparatorVisibility = SeparatorVisibility.None;
			stack.Children.Add(listView);
			Content = stack;
		}
	}
}

