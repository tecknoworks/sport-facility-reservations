using Client.Models;
using Client.Services.Interfaces;
using Commander;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Client.Services;
using System.Threading.Tasks;

namespace Client.ViewModels
{
    public class SoccerFieldsViewModel : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public string City { get; set; }
        public DateTime Availability { get; set; }
        private ObservableCollection<Field> field;
        public ObservableCollection<Field> Fields
        {
            get { return field; }
            set
            {
                field = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Fields)));
            }
        }
        IServiceClient _serviceClient;

        public event PropertyChangedEventHandler PropertyChanged;

        public SoccerFieldsViewModel(IServiceClient serviceClient)
        {
            _serviceClient = serviceClient;
        }

        public async Task SearchVMAsync()
        {
			var fields = await _serviceClient.SearchAsync(Settings.Token, Settings.FieldType, Name, City);
            Fields = new ObservableCollection<Field>(fields);
        }


    }
}
