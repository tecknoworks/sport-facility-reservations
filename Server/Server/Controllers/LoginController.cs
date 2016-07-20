﻿using System;
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
        public UnitOfWork unitOfWork = new UnitOfWork(new FacilityContext());
        // GET: api/Login
        public IEnumerable<User> GetUsers()
        {
            return unitOfWork.userRepository.GetAll();
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
