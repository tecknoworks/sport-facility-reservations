using Repository;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Server.Controllers
{
    public class TempController : ApiController
    {
        UnitOfWork _unitOfWork = new UnitOfWork(new Repository.Domain.FacilityContext());
        [HttpGet]
        public IQueryable GetReservations(string token)
        {

            return _unitOfWork.ReservationRepository.GetView(token);

        }
        [HttpPost]
        public HttpResponseMessage AddReservations(ReservationDTO reservation)
        {
            try
            {
                var user = _unitOfWork.UserRepository.GetAll().FirstOrDefault(p => p.Token == reservation.Token);
                if (user == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "User not found");

                _unitOfWork.ReservationRepository.Add(new Reservation
                {
                    FieldID = reservation.FieldId,
                    UserID = user.ID,
                    StartHour = new DateTime(2016,8,10,reservation.Hour,0,0)
                });
                _unitOfWork.Complete();
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch(Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError) { ReasonPhrase = ex.Message };
            }
        }
        public class ReservationDTO
        {
            public int FieldId;
            public string Token;
            public int Hour;
        }
    }
}
