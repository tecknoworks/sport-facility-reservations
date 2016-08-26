using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Client.CustomCell
{
	public class CustomCelll : ViewCell
	{
		Label nameLabel;
		Label statusLabel;

		public StackLayout cellWrapper = new StackLayout
		{
			Padding = new Thickness(10, Device.OnPlatform(10, 0, 0), 10, 5),
			VerticalOptions = LayoutOptions.FillAndExpand,
			HorizontalOptions = LayoutOptions.FillAndExpand,
		};
		public StackLayout horizontalLayout = new StackLayout
		{
			VerticalOptions = LayoutOptions.FillAndExpand,
			HorizontalOptions = LayoutOptions.FillAndExpand,
			Orientation = StackOrientation.Horizontal
		};

		public static readonly BindableProperty NameProperty = BindableProperty.Create("Field", typeof(string), typeof(ViewCell), "Name");

		public string Field
		{
			get { return (string)GetValue(NameProperty); }
			set { SetValue(NameProperty, value); }
		}

		public static readonly BindableProperty StatusProperty = BindableProperty.Create("Status", typeof(string), typeof(ViewCell), "pending");

		public string Status
		{
			get { return (string)GetValue(StatusProperty); }
			set { SetValue(StatusProperty, value); }
		}

		public CustomCelll()
		{
			nameLabel = new Label 
			{ 
				HorizontalOptions = LayoutOptions.StartAndExpand,
				//HeightRequest = 17
			};
			statusLabel = new Label
			{
				HorizontalOptions = LayoutOptions.StartAndExpand,
				//HeightRequest = 12,
				FontSize = 15
			};

			nameLabel.SetBinding(Label.TextProperty, "Field");
			statusLabel.SetBinding(Label.TextProperty, "Status");

			horizontalLayout.Children.Add(nameLabel);
			horizontalLayout.Children.Add(statusLabel);

			cellWrapper.Children.Add(horizontalLayout);
			View = cellWrapper;
		}

		protected override void OnBindingContextChanged()
		{
			base.OnBindingContextChanged();

			if (BindingContext != null)
			{
				nameLabel.Text = Field;
				statusLabel.Text = Status;
				if (Status.Equals("accepted"))
				{
					statusLabel.TextColor = Color.Green;
				}
				else if (Status.Equals("rejected"))
				{
					statusLabel.TextColor = Color.Red;
				}
				else {
					statusLabel.TextColor = Color.FromHex("#FFA500");
				}
			}
		}
	}
}


