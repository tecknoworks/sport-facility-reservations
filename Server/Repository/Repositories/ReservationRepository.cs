using Repository.Domain;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ReservationRepository : Repository<Reservation>, IReservationRepository
    {
        public ReservationRepository(FacilityContext context)
           : base(context)
        {
        }
        public IQueryable  GetView(string token)
        {
            var query = (from r in FacilityContext.Reservations
                         join u in FacilityContext.Users on r.UserID equals u.ID
                         join f in FacilityContext.Fields on r.FieldID equals f.ID
                         where u.Token == token  
                         select new
                         {
                             Name = u.UserName,
                             Field = f.Name,
                             StartHour=r.StartHour,
                         });
            return query;
        }
        public FacilityContext FacilityContext
        {
            get { return Context as FacilityContext; }
        }
    }
}
