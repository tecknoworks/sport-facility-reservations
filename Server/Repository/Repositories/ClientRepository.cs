using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using Repository.Models;
 


namespace Repository
{
    public class ClientRepository : IClientRepository
    {
        SportFacilityEntities context;
        public ClientRepository(SportFacilityEntities context)
        {
            this.context = context;
        }
        public IEnumerable<Client> GetAll()
        {
            return context.Clients.ToList();
        }

        public Client Get(int id)
        {
            return context.Clients.Find(id);
        }

        public void Add(Client client)
        {
            context.Clients.Add(client);
        }

        public void Remove(Client client)
        {
            
            context.Clients.Remove(client);
        }

        public void UpdateClient(Client client)
        {
            context.Entry(client).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

    }

}
