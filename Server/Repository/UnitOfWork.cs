using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repository.Models;
 

namespace Repository
{

    public class UnitOfWork : IUnitOfWork
    {
        //private readonly SportFacilityEntities1 context;
        SportFacilityEntities1 _context = new SportFacilityEntities1();
        public UnitOfWork()
        {
           
            clientRepository = new ClientRepository(_context);

        }
        public IClientRepository clientRepository { get; }


        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
