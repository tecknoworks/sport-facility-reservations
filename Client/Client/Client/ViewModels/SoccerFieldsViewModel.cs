using Client.Models;
using Client.Services.Interfaces;
using Commander;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Client.ViewModels
{
    class SoccerFieldsViewModel:INotifyPropertyChanged
    {
        public string Name { get; set; }
        public string City { get; set; }
        public DateTime Availability { get; set; }
        private ObservableCollection<Field> field;
        public ObservableCollection<Field> Fields { get { return field; }
            set {
                field = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Fields)));
            } }
        IServiceClient _serviceClient;

        public event PropertyChangedEventHandler PropertyChanged;

        public SoccerFieldsViewModel(IServiceClient serviceClient)
        {
            _serviceClient = serviceClient;
        }

        [OnCommand("SearchCommand")]
        public void OnSearch()
        {
            var fields = _serviceClient.Search(Name);
            Fields = new ObservableCollection<Field>(fields);
        }


    }
}
