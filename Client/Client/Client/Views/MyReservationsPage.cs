using System;
using Xamarin.Forms;
using Microsoft.Practices.Unity;
using System.Threading.Tasks;
using Client.CustomCell;

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
			var cell = new DataTemplate(typeof(CustomCelll));
			listView.ItemsSource = _viewModel.Reservations;
			listView.ItemTemplate = cell;
			cell.SetBinding(CustomCelll.NameProperty, "Field");
			cell.SetBinding(CustomCelll.StatusProperty, "Status");

			listView.SetBinding(ListView.ItemsSourceProperty, "Reservations");

			listView.SeparatorVisibility = SeparatorVisibility.None;
			stack.Children.Add(listView);

			Content = stack;
		}
	}
}

