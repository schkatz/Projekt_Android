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
using RESTfulService.Models;

namespace RESTfulService.Controllers
{
    public class DobreOdpowiedzisController : ApiController
    {
        private quizEntities db = new quizEntities();

        // GET: api/DobreOdpowiedzis
        public IQueryable<DobreOdpowiedzi> GetDobreOdpowiedzi()
        {
            return db.DobreOdpowiedzi;
        }

        // GET: api/DobreOdpowiedzis/5
        [ResponseType(typeof(DobreOdpowiedzi))]
        public IHttpActionResult GetDobreOdpowiedzi(int id)
        {
            DobreOdpowiedzi dobreOdpowiedzi = db.DobreOdpowiedzi.Find(id);
            if (dobreOdpowiedzi == null)
            {
                return NotFound();
            }

            return Ok(dobreOdpowiedzi);
        }

        // PUT: api/DobreOdpowiedzis/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDobreOdpowiedzi(int id, DobreOdpowiedzi dobreOdpowiedzi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dobreOdpowiedzi.idDobreOdpowiedzi)
            {
                return BadRequest();
            }

            db.Entry(dobreOdpowiedzi).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DobreOdpowiedziExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/DobreOdpowiedzis
        [ResponseType(typeof(DobreOdpowiedzi))]
        public IHttpActionResult PostDobreOdpowiedzi(DobreOdpowiedzi dobreOdpowiedzi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DobreOdpowiedzi.Add(dobreOdpowiedzi);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DobreOdpowiedziExists(dobreOdpowiedzi.idDobreOdpowiedzi))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = dobreOdpowiedzi.idDobreOdpowiedzi }, dobreOdpowiedzi);
        }

        // DELETE: api/DobreOdpowiedzis/5
        [ResponseType(typeof(DobreOdpowiedzi))]
        public IHttpActionResult DeleteDobreOdpowiedzi(int id)
        {
            DobreOdpowiedzi dobreOdpowiedzi = db.DobreOdpowiedzi.Find(id);
            if (dobreOdpowiedzi == null)
            {
                return NotFound();
            }

            db.DobreOdpowiedzi.Remove(dobreOdpowiedzi);
            db.SaveChanges();

            return Ok(dobreOdpowiedzi);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DobreOdpowiedziExists(int id)
        {
            return db.DobreOdpowiedzi.Count(e => e.idDobreOdpowiedzi == id) > 0;
        }
    }
}