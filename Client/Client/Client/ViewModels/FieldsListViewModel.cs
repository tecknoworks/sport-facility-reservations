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

namespace Client.ViewModels
{
    [ImplementPropertyChanged]
    public class FieldsListViewModel
    {
        public IServiceClient _serviceClient;
        public string Name { get; set; }
        public string Location { get; set; }
        public List<Models.Field> Fields { get; set; }

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
