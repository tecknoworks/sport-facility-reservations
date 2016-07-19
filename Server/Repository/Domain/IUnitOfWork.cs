using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Models;
using Repository.Domain;
using Repository.Repositories;

namespace Repository
{
    interface IUnitOfWork : IDisposable
    {
        IUserRepository userRepository { get; }

        int Complete();
    }
}
