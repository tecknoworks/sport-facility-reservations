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
         
        public IHttpActionResult GetUserById(string token)
        {
            var user = _unitOfWork.UserRepository.GetAll().First(p=>p.Token==token);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpGet]
        [ResponseType(typeof(User))]
        public IHttpActionResult LoginRequest(string name, string password)
        {
            if (name == null || password == null)
                return BadRequest();
            var user = GetUsers().FirstOrDefault((q) => q.UserName.Equals(name) && q.Password.Equals(password));
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);


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
                    return Request.CreateErrorResponse(HttpStatusCode.Conflict, message);
                }
            }
            if(user.Token == null)
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
        [HttpPut]
        public HttpResponseMessage UpdateUser(User user)
        {
            var dbUser = _unitOfWork.UserRepository.GetAll().First( p => p.UserName == user.UserName);
            user.ID=dbUser.ID;
            DeleteUser(user.ID);
            _unitOfWork.UserRepository.Add(user);
            _unitOfWork.Complete();
            return Request.CreateResponse(HttpStatusCode.BadRequest, "User details updated");
        }
    }
}
