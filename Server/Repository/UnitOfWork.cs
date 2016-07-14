using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repository.Models;
 

namespace Repository
{

    public class UnitOfWork : IUnitOfWork
    {
        private readonly SportFacilityEntities _context;
        SportFacilityEntities context = new SportFacilityEntities();
        public UnitOfWork()
        {
           
            ClientRepository = new ClientRepository(_context);

        }
        public IClientRepository ClientRepository { get; }


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
