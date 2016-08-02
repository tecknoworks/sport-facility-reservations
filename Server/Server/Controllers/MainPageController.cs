using Repository;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Server.Controllers
{
    public class MainPageController : ApiController
    {
        UnitOfWork _unitOfWork = new UnitOfWork(new Repository.Domain.FacilityContext());
        [HttpGet]
        public IEnumerable<Field> GetFieldsByType(string type)
        {
            var fields = _unitOfWork.FieldRepository.GetFieldsByColumn(filter: q => q.Type == type);
            return fields;
        }
        public IEnumerable<Field> GetFields()
        {
            return _unitOfWork.FieldRepository.GetAll();
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
        public List<Field> GetFieldByCity(string city)
        {
            var fields = GetFields();
            List<Field> fieldss = new List<Field>();
            foreach (var field in fields)
                if (field.Location.Equals(city))
                    fieldss.Add(field);
            return fieldss;
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
            IEnumerable<Field> fields = GetFields();
            foreach (Field field1 in fields)
            {
                if (field1.Name.Equals(field.Name))
                {
                    var message = string.Format("Field  {0} already added", field.Name);
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
                }
            }
            _unitOfWork.FieldRepository.Add(field);
            _unitOfWork.Complete();
            return Request.CreateResponse(HttpStatusCode.OK, field);
        }
    }
}
