using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Models;
using Client.Services;
using Client.Services.Interfaces;
using PropertyChanged;
using Xamarin.Forms;

namespace Client
{
	[ImplementPropertyChanged]
	public class MyReservationsViewModel
	{
		IServiceClient _serviceClient;
		public string Field { get; set; }
		public string Status { get; set; }
		public Color detailColor;
		public Color DetailColor
		{
			get
			{
				return detailColor;
			}
			set{
				if (Status.Equals("accepted"))
				{
					detailColor = Color.Green;
				}
				else if (Status.Equals("rejected"))
				{
					detailColor = Color.Red;
				}
			}
		}



		public List<Reservation> Reservations { get; set; }

		public MyReservationsViewModel(IServiceClient serviceClient)
		{
			_serviceClient = serviceClient;
		}

		public async Task LoadReservationsAsync()
		{
			Reservations = await _serviceClient.GetReservationsAsync(Settings.Token);
		}

	}
}

