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
        public IUserRepository UserRepository { get; private set; }
        public IFieldRepository FieldRepository { get; private set; } 
        public FacilityContext _context;

        public UnitOfWork(FacilityContext context)
        {
            _context = context;
            UserRepository = new UserRepository(_context);
            FieldRepository = new FieldRepository(_context);
        }
      


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
