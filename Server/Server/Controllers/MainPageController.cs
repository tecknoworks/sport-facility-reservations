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
        UnitOfWork unitOfWork = new UnitOfWork(new Repository.Domain.FacilityContext());
        [HttpGet]
        public IEnumerable<Field> GetFieldsByType(string type)
        {
            var fields = unitOfWork.FieldRepository.GetFieldsByColumn(filter: q => q.Type == type);
            return fields;
        }
        public IEnumerable<Field> GetFields()
        {
            return unitOfWork.FieldRepository.GetAll();
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
            List<Field> fieldss=new List<Field>();
            foreach (var field in fields)
                if (field.Location.Equals(city))
                    fieldss.Add(field);
            return fieldss;
            //if (user == null)
            //{
            //    return NotFound();
            //}
            //return Ok(user);
        }

    }
}
