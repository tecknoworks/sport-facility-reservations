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
        public IEnumerable<Field> GetFields()
        {
            var fields = _unitOfWork.FieldRepository.GetAll();
            return fields;
        }
        // public IQueryable GetFieldOfOwner(string token)
        //{

        //    return _unitOfWork.ReservationRepository.GetFieldsOfOwner(token);
        //}
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
        public IEnumerable<Field> GetFieldBy(string token, string name, string location)
        {
            var users = _unitOfWork.UserRepository.GetAll();
            foreach (var user in users)
                if (user.Token.Equals(token))
                {
                    var fields = GetFields();
                    if (!string.IsNullOrEmpty(location) && string.IsNullOrEmpty(name))
                        return fields.Where(x => x.Location.Equals(location, StringComparison.OrdinalIgnoreCase));
                    else if (!string.IsNullOrEmpty(name) && string.IsNullOrEmpty(location))
                        return fields.Where(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                    else if (!string.IsNullOrEmpty(location) && !string.IsNullOrEmpty(name))
                        return fields.Where(x => x.Location.Equals(location, StringComparison.OrdinalIgnoreCase))
                                       .Where(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                    else
                        return fields;
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
        public IQueryable GetReservations(string token)
        {
            return _unitOfWork.ReservationRepository.GetView(token);
        }
     
    }

}
