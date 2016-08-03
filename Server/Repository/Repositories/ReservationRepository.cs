using Repository.Domain;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ReservationRepository : Repository<Reservation>,IReservationRepository
    {
        public ReservationRepository(FacilityContext context)
           : base(context)
        {
        }
        public FacilityContext FacilityContext
        {
            get { return Context as FacilityContext; }
        }
    }
}
