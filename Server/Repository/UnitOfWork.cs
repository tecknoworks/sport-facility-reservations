﻿using System;
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
        public  FacilityContext _context;
        public UnitOfWork(FacilityContext context) {
            _context = context;
            userRepository=new UserRepository(_context);
            fieldRepository = new FieldRepository(_context);
        }
        public IUserRepository userRepository { get; private set; }
        public IFieldRepository fieldRepository { get; private set; }


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
