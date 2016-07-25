using Client.Models;
using Client.Services.Interfaces;
using Commander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels
{
    class SoccerFieldsViewModel
    {
        public string Name { get; set; }
        public string City { get; set; }
        public List<Fields> Token { get; set; }
        IServiceClient _serviceClient;

        public SoccerFieldsViewModel(IServiceClient serviceClient)
        {
            _serviceClient = serviceClient;
        }

        [OnCommand("SearchCommand")]
        public void OnSearch()
        {
           Token =  _serviceClient.Search(Name, City);
        }


    }
}
