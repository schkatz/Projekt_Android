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
using RESTfulService.Models;

namespace RESTfulService.Controllers
{
    public class PytaniaController : ApiController
    {
        private quizsEntities db = new quizsEntities();

        // GET: api/Pytania
        public IQueryable<Pytania> GetPytania()
        {
            return db.Pytania;
        }

        // GET: api/Pytania/5
        [ResponseType(typeof(Pytania))]
        public IHttpActionResult GetPytania(int id)
        {
            Pytania pytania = db.Pytania.Find(id);
            if (pytania == null)
            {
                return NotFound();
            }

            return Ok(pytania);
        }

        // PUT: api/Pytania/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPytania(int id, Pytania pytania)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pytania.idPytania)
            {
                return BadRequest();
            }

            db.Entry(pytania).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PytaniaExists(id))
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

        // POST: api/Pytania
        [ResponseType(typeof(Pytania))]
        public IHttpActionResult PostPytania(Pytania pytania)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pytania.Add(pytania);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pytania.idPytania }, pytania);
        }

        // DELETE: api/Pytania/5
        [ResponseType(typeof(Pytania))]
        public IHttpActionResult DeletePytania(int id)
        {
            Pytania pytania = db.Pytania.Find(id);
            if (pytania == null)
            {
                return NotFound();
            }

            db.Pytania.Remove(pytania);
            db.SaveChanges();

            return Ok(pytania);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PytaniaExists(int id)
        {
            return db.Pytania.Count(e => e.idPytania == id) > 0;
        }
    }
}