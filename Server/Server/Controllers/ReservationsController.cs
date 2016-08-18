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
    public class ReservationsController : ApiController
    {
        UnitOfWork _unitOfWork = new UnitOfWork(new Repository.Domain.FacilityContext());
        [HttpGet]
        public IQueryable GetReservations(string token)
        {

            return _unitOfWork.ReservationRepository.GetView(token);

        }
        public User GetNameOfPlayer(int ReservationId)
        {
            var reservation = _unitOfWork.ReservationRepository.Get(ReservationId);
            var user = _unitOfWork.UserRepository.Get(reservation.UserID);
            return user;
        }
        [HttpPost]
        public HttpResponseMessage AddReservations(ReservationDTO reservation)
        {
            try
            {
                var user = _unitOfWork.UserRepository.GetAll().FirstOrDefault(p => p.Token == reservation.Token);
                if (user == null)
                    return new HttpResponseMessage(HttpStatusCode.BadRequest) { ReasonPhrase = "User does not exist " };

                _unitOfWork.ReservationRepository.Add(new Reservation
                {
                    FieldID = reservation.FieldId,
                    UserID = user.ID,
                    StartHour = new DateTime(reservation.Year, reservation.Month, reservation.Day, reservation.Hour, 0, 0)
                });
                _unitOfWork.Complete();
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError) { ReasonPhrase = ex.Message };
            }
        }
        public class ReservationDTO
        {
            public int ID;
            public int FieldId;
            public string Token;
            public string Status;
            public int Year;
            public int Month;
            public int Day;
            public int Hour;

        }

        public HttpResponseMessage UpdateReservation(ReservationDTO reservation)
        {
            var user = _unitOfWork.UserRepository.GetAll().FirstOrDefault(p => p.Token == reservation.Token);
            var dbReservation = _unitOfWork.ReservationRepository.GetAll().FirstOrDefault(p => p.Id == reservation.ID);
            if (user.Status.Equals("true"))
                {
                dbReservation.Status = reservation.Status;
                _unitOfWork.ReservationRepository.Update(dbReservation);
                return new HttpResponseMessage(HttpStatusCode.OK) { ReasonPhrase = "Reservation updated" };
            }
            return new HttpResponseMessage(HttpStatusCode.NotAcceptable) { ReasonPhrase = "User not allowed to edit" };
        }
        [HttpDelete]
        public void DeleteUser(int id)
        {
            var reservation = _unitOfWork.ReservationRepository.Get(id);
            _unitOfWork.ReservationRepository.Remove(reservation);
            _unitOfWork.Complete();
        }
    }
}
