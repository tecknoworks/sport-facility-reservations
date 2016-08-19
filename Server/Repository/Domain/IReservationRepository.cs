using Repository.Models;
using System.Linq;

namespace Repository.Domain
{
    public interface IReservationRepository : IRepository<Reservation>
    {
        IQueryable GetView(string token);
        IQueryable GetReservationOfPlayer(string token);
    }
}
