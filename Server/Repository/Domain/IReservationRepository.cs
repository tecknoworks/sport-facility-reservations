using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Domain
{
    public interface IReservationRepository:IRepository<Reservation>
    {
        IQueryable GetView(string token);
        //IQueryable GetFieldsOfOwner(string token);
    }
}
