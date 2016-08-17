using Client.Models;
using Client.Services.Interfaces;
using Commander;
using PropertyChanged;
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
    [ImplementPropertyChanged]
    public class FieldsListViewModel: BindableBase
    {
        public IServiceClient _serviceClient;
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime Hours { get; set; }
        public List<Models.Field> Fields { get; set; }
        public bool IsFocusedTime { get; set; }
        public bool IsVisibleTime { get; set; }

        public FieldsListViewModel(IServiceClient serviceClient)
        {
            _serviceClient = serviceClient;
        }

        public async Task LoadFieldsAsync()
        {
            Fields = await _serviceClient.GetFieldsAsync();
        }
    }
}
