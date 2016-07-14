using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Models;


namespace Repository
{
    public interface IClientRepository : IRepository<Client>
    {
       // IEnumerable<Client> GetClients(int count);
    }
}
