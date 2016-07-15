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
using Repository.Models;
using Repository;

namespace Server.Controllers
{
    public class ClientsController : ApiController
    {
      
        private UnitOfWork unitOfWork = new UnitOfWork();
        // private SportFacilityEntities1 db = new SportFacilityEntities1();

        // GET: api/Clients
        public IEnumerable<Client> GetClients()
        {
            var clients = unitOfWork.clientRepository.GetAll();
            return clients;
        }

        //    // GET: api/Clients/5
        //    [ResponseType(typeof(Client))]
        //    public IHttpActionResult GetClient(int id)
        //    {
        //        Client client = db.Clients.Find(id);
        //        if (client == null)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(client);
        //    }

        //    // PUT: api/Clients/5
        //    [ResponseType(typeof(void))]
        //    public IHttpActionResult PutClient(int id, Client client)
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }

        //        if (id != client.id)
        //        {
        //            return BadRequest();
        //        }

        //        db.Entry(client).State = EntityState.Modified;

        //        try
        //        {
        //            db.SaveChanges();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ClientExists(id))
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

        //    // POST: api/Clients
        //    [ResponseType(typeof(Client))]
        //    public IHttpActionResult PostClient(Client client)
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }

        //        db.Clients.Add(client);

        //        try
        //        {
        //            db.SaveChanges();
        //        }
        //        catch (DbUpdateException)
        //        {
        //            if (ClientExists(client.id))
        //            {
        //                return Conflict();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }

        //        return CreatedAtRoute("DefaultApi", new { id = client.id }, client);
        //    }

        //    // DELETE: api/Clients/5
        //    [ResponseType(typeof(Client))]
        //    public IHttpActionResult DeleteClient(int id)
        //    {
        //        Client client = db.Clients.Find(id);
        //        if (client == null)
        //        {
        //            return NotFound();
        //        }

        //        db.Clients.Remove(client);
        //        db.SaveChanges();

        //        return Ok(client);
        //    }

        //    protected override void Dispose(bool disposing)
        //    {
        //        if (disposing)
        //        {
        //            db.Dispose();
        //        }
        //        base.Dispose(disposing);
        //    }

        //    private bool ClientExists(int id)
        //    {
        //        return db.Clients.Count(e => e.id == id) > 0;
        //    }
        //}
    }
}