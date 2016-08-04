using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Repository.Domain;
using Repository.Models;
using Repository;

namespace Server.Controllers
{
    public class LoginController : ApiController
    {
        // public FacilityContext _context = new FacilityContext();
        private readonly UnitOfWork _unitOfWork = new UnitOfWork(new FacilityContext());
        // GET: api/Login
        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            return _unitOfWork.UserRepository.GetAll();
        }
        [Route("GetUserById")]
        public IHttpActionResult GetUserById(int id)
        {
            var user = _unitOfWork.UserRepository.Get(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpGet]
        [ResponseType(typeof(User))]
        public HttpResponseMessage LoginRequest(string name, string password)
        {
            var user = GetUsers().FirstOrDefault((q) => q.UserName.Equals(name) && q.Password.Equals(password));
            if (user == null)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
        [HttpDelete]
        public void DeleteUser(int id)
        {
            var user = _unitOfWork.UserRepository.Get(id);
            _unitOfWork.UserRepository.Remove(user);
            _unitOfWork.Complete();
        }
        [HttpPost]
        [ResponseType(typeof(User))]
        public HttpResponseMessage AddUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            IEnumerable<User> users = GetUsers();
            foreach (User user1 in users)
            {
                if (user1.UserName.Equals(user.UserName))
                {
                    var message = string.Format("User Name {0} is taken ", user.UserName);
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
                }
            }
            user.Token = Guid.NewGuid().ToString();  // TODO: Token
            _unitOfWork.UserRepository.Add(user);
            _unitOfWork.Complete();
            return Request.CreateResponse(HttpStatusCode.OK, user);

        }

        //GET: api/Login/5
        //[ActionName("GetBy")]
        [HttpGet]
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            User user = _unitOfWork.UserRepository.Get(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        //[HttpPut]
        //public void UpdateUser(string token, string name)
        //{
        //    var user = _unitOfWork.UserRepository.GetAll().FirstOrDefault(p => p.Token == token);
        //    user.FirstName = name;
        //    _unitOfWork.UserRepository.Update(user);
        //    _unitOfWork.Complete();
        //}
    }
}
