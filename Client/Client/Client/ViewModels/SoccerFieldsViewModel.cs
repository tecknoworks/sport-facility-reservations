using Client.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels
{
    class SoccerFieldsViewModel
    {
        IServiceClient _serviceClient;
       
        public SoccerFieldsViewModel(IServiceClient serviceClient)
        {
            _serviceClient = serviceClient;
        }
    }
}
