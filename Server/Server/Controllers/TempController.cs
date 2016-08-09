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
        public IQueryable GetReservations(string userName, string fieldName)
        {

            return _unitOfWork.ReservationRepository.GetView(userName, fieldName);

        }
        [HttpPost]
        public HttpResponseMessage AddReservations(ReservationDTO reservation)
        {
            var user = _unitOfWork.UserRepository.GetAll().FirstOrDefault(p => p.Token == reservation.Token);
            if (user == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "User not found");
            var field = _unitOfWork.FieldRepository.GetAll().FirstOrDefault(p => p.Name == reservation.FieldName);
            if (field == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Field not found");
            _unitOfWork.ReservationRepository.Add(new Reservation
            {
                FieldID = field.ID,
                UserID = user.ID,
                StartHour = reservation.StartHour
            });
            _unitOfWork.Complete();
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
        public class ReservationDTO
        {
            public string FieldName;
            public string Token;
            public DateTime StartHour;
        }
    }
}
