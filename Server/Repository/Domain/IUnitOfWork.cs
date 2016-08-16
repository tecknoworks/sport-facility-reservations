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
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IFieldRepository FieldRepository { get; }
        IReservationRepository ReservationRepository { get; }
        int Complete();
    }
}
