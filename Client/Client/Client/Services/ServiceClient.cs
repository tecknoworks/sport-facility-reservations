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
            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
                return new ArgumentNullException("Fields must not be null", "username").ToString();
            return Guid.NewGuid().ToString();
        }
        public string Register(string username, string password, string phone, string type)
        {
            return Guid.NewGuid().ToString();
        }
        
        //sa spuna da te-am inregistrat
        //exista deja un cont creat cu aceste date - TBD




    }
}