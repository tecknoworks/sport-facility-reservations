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
    [RoutePrefix("api/Login")]
    public class LoginController : ApiController
    {
        // public FacilityContext _context = new FacilityContext();
        public UnitOfWork unitOfWork = new UnitOfWork(new FacilityContext());
        // GET: api/Login
        public IEnumerable<User> GetUsers()
        {
            return unitOfWork.userRepository.GetAll();
        }
        
        [Route("GetUserById")]
        public IHttpActionResult GetUserById(int id)
        {
            var user = GetUsers().FirstOrDefault((p) => p.ID == id);
            if(user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [Route("GetUserByName")]
        public IHttpActionResult GetUserByName(string name, string password)
        {
            var userr = GetUsers().FirstOrDefault((q) => q.Name.Equals(name)&& q.Password.Equals(password));
            if(userr == null)
            {
                return NotFound();
            }
            return Ok(userr);
        }
        
       [HttpPut]
        public void Put(string name/*, string password*/)
        {

            User user1 = new User();
            user1.Name = name;
           // user1.Password = password;
            unitOfWork.userRepository.Add(user1);
            // FacilityContext.Users.AddOrUpdate(user1);
            
        }

        //[Route("CreateUser")]
        //public IHttpActionResult CreateUser(int id, string name, string password, bool status)
        //{
        //    User user1 = new User();
        //    user1.Name = name;
        //    user1.Password = password;
        //    user1.Status = status;
        //    unitOfWork.userRepository.Add(user1);
        //   // FacilityContext.Users.AddOrUpdate(user1);

        //    if (user1 == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(user1);
        //}

        [Route("Update")]
        public IHttpActionResult Update(int id, string name, string password, bool status)
        {
            User user2 = GetUsers().FirstOrDefault((p) => p.ID == id);
            user2.Name = name;
            user2.Password = password;
            user2.Status = status;
            unitOfWork.userRepository.Add(user2);

            if (user2 == null)
            {
                return NotFound();
            }
            return Ok(user2);

        }
        //// POST: api/Login
        //[ResponseType(typeof(User))]
        //public IHttpActionResult PostUser(User user)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    unitOfWork.userRepository.Add(user);
        //   // unitOfWork.userRepository.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = user.ID }, user);
        //}


        //    // GET: api/Login/5
        //    [ResponseType(typeof(User))]
        //    public IHttpActionResult GetUser(int id)
        //    {
        //        User user = db.Users.Find(id);
        //        if (user == null)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(user);
        //    }

        //    // PUT: api/Login/5
        //    [ResponseType(typeof(void))]
        //    public IHttpActionResult PutUser(int id, User user)
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }

        //        if (id != user.ID)
        //        {
        //            return BadRequest();
        //        }

        //        db.Entry(user).State = EntityState.Modified;

        //        try
        //        {
        //            db.SaveChanges();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!UserExists(id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }

        //        return StatusCode(HttpStatusCode.NoContent);
        //    }

        //    // POST: api/Login
        //    [ResponseType(typeof(User))]
        //    public IHttpActionResult PostUser(User user)
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }

        //        db.Users.Add(user);
        //        db.SaveChanges();

        //        return CreatedAtRoute("DefaultApi", new { id = user.ID }, user);
        //    }



        //    protected override void Dispose(bool disposing)
        //    {
        //        if (disposing)
        //        {
        //            db.Dispose();
        //        }
        //        base.Dispose(disposing);
        //    }

        //    private bool UserExists(int id)
        //    {
        //        return db.Users.Count(e => e.ID == id) > 0;
        //    }
        //}
    }
}
