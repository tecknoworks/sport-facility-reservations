using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repository.Models;
using Repository.Domain;
using Repository.Repositories;

namespace Repository
{

    public class UnitOfWork : IUnitOfWork
    {
        //private readonly SportFacilityEntities1 context;
        private readonly FacilityContext _context;

        public UnitOfWork(FacilityContext context)
        {
            _context = context;
            userRepository = new UserRepository(_context);
           
        }
        public IUserRepository userRepository { get; }


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
