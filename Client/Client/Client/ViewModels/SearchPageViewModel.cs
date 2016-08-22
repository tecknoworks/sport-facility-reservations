using Client.Services.Interfaces;
using Client.Views;
using Commander;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Services;
using Prism.Mvvm;

namespace Client.ViewModels
{
    public class SearchPageViewModel: BindableBase, INotifyPropertyChanged
    {
		IServiceClient _serviceClient;
		public int FieldType
		{
			get
			{
				return Settings.FieldType;
			}
			set
			{
				if (Settings.FieldType == value)
					return;
				Settings.FieldType = value;
				OnPropertyChanged();
			}
		}

		public SearchPageViewModel(IServiceClient serviceClient)
		{
			_serviceClient = serviceClient;
		}

		public event PropertyChangedEventHandler PropertyChanged;
	}
}
