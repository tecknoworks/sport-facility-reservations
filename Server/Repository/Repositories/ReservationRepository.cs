using Repository.Domain;
using Repository.DTOs;
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
        public IQueryable GetView(string token)
        {
            var query = (from r in FacilityContext.Reservations
                         join u in FacilityContext.Users on r.UserID equals u.ID
                         join f in FacilityContext.Fields on r.FieldID equals f.ID
                         where u.Token == token
                         select new
                         {
                             Id = r.Id,
                             Name = u.UserName,
                             FirstName = u.FirstName,
                             LastName = u.LastName,
                             Field = f.Name,
                             StartHour = r.StartHour,
                             PhoneNumber = u.PhoneNumber,
                             Status=r.Status,
                         });
            return query;
        }
        public IQueryable GetReservationOfPlayer(string token)
        {
            var query = (from r in FacilityContext.Reservations
                         join u in FacilityContext.Users on r.UserID equals u.ID
                         join f in FacilityContext.Fields on r.FieldID equals f.ID
                         where u.Token == token
                         select new ReservationDTO
                         {
                             ID = r.Id,
                             FieldId = f.ID,
                             Hour = r.StartHour.Hour,
                             Day = r.StartHour.Day,
                             Month = r.StartHour.Month,
                             Year = r.StartHour.Year,
                             Status = r.Status,
                             Field=f.Name,
                             Token=token, 
                         });
            return query;
        }

        public FacilityContext FacilityContext
        {
            get { return Context as FacilityContext; }
        }
    }
}
