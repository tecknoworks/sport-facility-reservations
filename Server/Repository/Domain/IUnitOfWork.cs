using System;
using Repository.Domain;

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
