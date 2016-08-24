using Repository;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Web.Http.Results;

namespace Server.Controllers
{
    public class MainPageController : ApiController
    {
        //UnitOfWork _unitOfWork = new UnitOfWork(new Repository.Domain.FacilityContext());
        IUnitOfWork _unitOfWork;
        public MainPageController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IEnumerable<Field> GetFieldsByType(int type)
        {
            var fields = _unitOfWork.FieldRepository.GetFieldsByColumn(filter: q => q.Type == type);
            return fields;
        }
        public IEnumerable<Field> GetFilteredFields(string name, string location, int type, int length, int width)
        {
            return _unitOfWork.FieldRepository.FilterFieldsBy(name, location, type, length, width);
        }
        public IQueryable GetReservationOfPlayer(string token)
        {
            return _unitOfWork.ReservationRepository.GetReservationOfPlayer(token);
        }
        public IEnumerable<Field> GetFields()
        {
            var fields = _unitOfWork.FieldRepository.GetAll();
            return fields;
        }
        [HttpGet]
        public IHttpActionResult GetFieldOfOwner([FromUri]string token)
        {
            var user = _unitOfWork.UserRepository.GetAll().First(p => p.Token == token);
            if (user.Status == true)
            {
                var field = _unitOfWork.FieldRepository.GetAll().FirstOrDefault(p => p.OwnerName.Equals(user.UserName));
                if (field == null)
                {
                    return NotFound();
                }
                return Ok(field);
            }
            else return BadRequest();
        }
        public IHttpActionResult GetFieldByName(string name)
        {
            var field = GetFields().FirstOrDefault((q) => q.Name.Equals(name));
            if (field == null)
            {
                return NotFound();
            }
            return Ok(field);
        }
        public List<Field> GetFieldByCity(string token, string city)
        {
            var users = _unitOfWork.UserRepository.GetAll();
            foreach (var user in users)
                if (user.Token.Equals(token))
                {
                    var fields = GetFields();
                    List<Field> fieldss = new List<Field>();
                    foreach (var field in fields)
                        if (field.Location.Equals(city))
                            fieldss.Add(field);
                    return fieldss;
                }
            return null;
        }
        public IEnumerable<Field> GetFieldBy(string token, string name, string location, int type)
        {
            var users = _unitOfWork.UserRepository.GetAll();
            foreach (var user in users)
                if (user.Token.Equals(token))
                {
                    var fields = GetFields();
                    if (!string.IsNullOrEmpty(location) && string.IsNullOrEmpty(name))
                        return fields.Where(x => x.Location.Equals(location, StringComparison.OrdinalIgnoreCase)
                                                && (x.Type.Equals(type)));
                    else if (!string.IsNullOrEmpty(name) && string.IsNullOrEmpty(location))
                        return fields.Where(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase)
                                                && (x.Type.Equals(type)));
                    else if (!string.IsNullOrEmpty(location) && !string.IsNullOrEmpty(name))
                        return fields.Where(x => x.Type.Equals(type) &&
                                     (x.Location.Equals(location, StringComparison.OrdinalIgnoreCase)) &&
                                     (x.Name.Equals(name, StringComparison.OrdinalIgnoreCase)));
                    else
                        return fields.Where(x => x.Type.Equals(type));
                }
            return null;
        }
        [HttpGet]
        public IEnumerable<Field> OrderBy()
        {
            return _unitOfWork.FieldRepository.GetFieldsOrderedByPrice();
        }
        [HttpPost]
        public HttpResponseMessage AddField(Field field)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            _unitOfWork.FieldRepository.Add(field);
            _unitOfWork.Complete();
            return Request.CreateResponse(HttpStatusCode.OK, field);
        }
        [HttpDelete]
        [ResponseType(typeof(Field))]
        public IHttpActionResult DeleteField(string name)
        {
            Field field = _unitOfWork.FieldRepository.GetAll().FirstOrDefault(p => p.Name == name);
            if (field == null)
            {
                return NotFound();
            }
            _unitOfWork.FieldRepository.Remove(field);
            _unitOfWork.Complete();
            return Ok(field);
        }
        [HttpPut]
        public HttpResponseMessage UpdateField(Field field)
        {
            var dbField = _unitOfWork.FieldRepository.GetAll().First(p => p.ID == field.ID);
            if (dbField == null)
                return new HttpResponseMessage(HttpStatusCode.NotFound) { ReasonPhrase = "Field does not exist" };
            dbField.Location = field.Location;
            dbField.Length = field.Length;
            dbField.Name = field.Name;
            dbField.OwnerName = field.OwnerName;
            dbField.Price = field.Price;
            dbField.StartTime = field.StartTime;
            dbField.EndTime = field.EndTime;
            dbField.Width = field.Width;
            dbField.Length = field.Length;
            dbField.Type = field.Type;

            _unitOfWork.FieldRepository.Update(dbField);
            _unitOfWork.Complete();
            return new HttpResponseMessage(HttpStatusCode.OK) { ReasonPhrase = "Field updated" };
        }
    }
}
