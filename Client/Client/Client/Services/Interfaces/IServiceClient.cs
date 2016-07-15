using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Services.Interfaces
{
    interface IServiceClient
    {
        string Login(string username, string password);
    }
}
