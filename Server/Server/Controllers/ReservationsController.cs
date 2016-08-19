using Repository;
using Repository.DTOs;
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
        [HttpGet]
        public ReservationDTO GetOneReservation(string token)
        {
            var user = _unitOfWork.UserRepository.GetAll().FirstOrDefault(p => p.Token == token);
            var reservation = _unitOfWork.ReservationRepository.GetAll().FirstOrDefault(p => p.UserID == user.ID);
            return new ReservationDTO
            {
                ID = reservation.Id,
                Status = reservation.Status,
                Token = token,
                Hour = reservation.StartHour.Hour,
                Day = reservation.StartHour.Day,
                Month = reservation.StartHour.Month,
                Year = reservation.StartHour.Year
            };
        }
        public UserDTO GetNameOfPlayer(int ReservationId)
        {
            var reservation = _unitOfWork.ReservationRepository.GetAll().FirstOrDefault(p => p.Id == ReservationId);
            var user = _unitOfWork.UserRepository.GetAll().First(p => p.ID == reservation.UserID);
            var userDTO = new UserDTO
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,


            };
            return userDTO;
        }
        [HttpPost]
        public HttpResponseMessage AddReservations([FromBody] ReservationDTO reservation)
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
                    Status = "pending",
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

     
        public class UserDTO
        {
            public string FirstName;
            public string LastName;
            public string PhoneNumber;
        }
        [HttpPut]
        public HttpResponseMessage UpdateReservation([FromUri] string id)
        {
            int Id = Int32.Parse(id);
            //var user = _unitOfWork.UserRepository.GetAll().FirstOrDefault(p => p.Token == reservation.Token);
            var dbReservation = _unitOfWork.ReservationRepository.GetAll().FirstOrDefault(p => p.Id == Id);
            if (dbReservation == null)
                return new HttpResponseMessage(HttpStatusCode.NotFound) { ReasonPhrase = "Reservation does not exist" };

            dbReservation.Status = "accepted";
            //if (user.Status.Equals("false") && dbReservation.Status.Equals("accepted"))
            //    return new HttpResponseMessage(HttpStatusCode.NotAcceptable) { ReasonPhrase = "Reservation not editable. " };
            //if(reservation.)

            _unitOfWork.ReservationRepository.Update(dbReservation);
            _unitOfWork.Complete();
            return new HttpResponseMessage(HttpStatusCode.OK) { ReasonPhrase = "Reservation updated" };

        }
        [HttpPut]
        public HttpResponseMessage RejectReservation([FromUri] string id)
        {
            int Id = Int32.Parse(id);
            //var user = _unitOfWork.UserRepository.GetAll().FirstOrDefault(p => p.Token == reservation.Token);
            var dbReservation = _unitOfWork.ReservationRepository.GetAll().FirstOrDefault(p => p.Id == Id);
            if (dbReservation == null)
                return new HttpResponseMessage(HttpStatusCode.NotFound) { ReasonPhrase = "Reservation does not exist" };

            dbReservation.Status = "rejected";
            //if (user.Status.Equals("false") && dbReservation.Status.Equals("accepted"))
            //    return new HttpResponseMessage(HttpStatusCode.NotAcceptable) { ReasonPhrase = "Reservation not editable. " };
            //if(reservation.)

            _unitOfWork.ReservationRepository.Update(dbReservation);
            _unitOfWork.Complete();
            return new HttpResponseMessage(HttpStatusCode.OK) { ReasonPhrase = "Reservation updated" };

        }
        [HttpDelete]
        public HttpResponseMessage DeleteReservation(int id)
        {
            var reservation = _unitOfWork.ReservationRepository.Get(id);
            _unitOfWork.ReservationRepository.Remove(reservation);
            _unitOfWork.Complete();
            return new HttpResponseMessage(HttpStatusCode.OK) { ReasonPhrase = "Reservation deleted" };
        }
    }
}
