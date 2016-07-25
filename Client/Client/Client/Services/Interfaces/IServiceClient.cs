using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client.Services.Interfaces
{
    public interface IServiceClient
    {
        string Login(string username, string password);
        string Register(string username, string password, string confirmPassword); //, string phone, int type, string sport, string nameSports, string adress, int lungime, int latime, DateTime startTime, DateTime stopTime, int price);
        List<Fields> Search(string filter);
        List<Fields> Search(string filter1, string filter2);
    }
}
    