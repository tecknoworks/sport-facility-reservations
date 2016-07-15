using Client.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Services
{
    class ServiceClient: IServiceClient
    {
        public string Login(string username, string password)
        {
            return Guid.NewGuid().ToString();
        }
        //sa spuna da te-am inregistrat
        //exista deja un cont creat cu aceste date 
    }
}