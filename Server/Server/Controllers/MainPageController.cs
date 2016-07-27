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
    }
}
