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
    public class TabelaWynikowController : ApiController
    {
        private quizsEntities db = new quizsEntities();

        // GET: api/TabelaWynikow
        public IQueryable<TabelaWynikow> GetTabelaWynikow()
        {
            return db.TabelaWynikow;s
        }

        // GET: api/TabelaWynikow/5
        [ResponseType(typeof(TabelaWynikow))]
        public IHttpActionResult GetTabelaWynikow(int id)
        {
            TabelaWynikow tabelaWynikow = db.TabelaWynikow.Find(id);
            if (tabelaWynikow == null)
            {
                return NotFound();
            }

            return Ok(tabelaWynikow);
        }

        // PUT: api/TabelaWynikow/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTabelaWynikow(int id, TabelaWynikow tabelaWynikow)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tabelaWynikow.idTabelaWynikow)
            {
                return BadRequest();
            }

            db.Entry(tabelaWynikow).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TabelaWynikowExists(id))
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

        // POST: api/TabelaWynikow
        [ResponseType(typeof(TabelaWynikow))]
        public IHttpActionResult PostTabelaWynikow(TabelaWynikow tabelaWynikow)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TabelaWynikow.Add(tabelaWynikow);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tabelaWynikow.idTabelaWynikow }, tabelaWynikow);
        }

        // DELETE: api/TabelaWynikow/5
        [ResponseType(typeof(TabelaWynikow))]
        public IHttpActionResult DeleteTabelaWynikow(int id)
        {
            TabelaWynikow tabelaWynikow = db.TabelaWynikow.Find(id);
            if (tabelaWynikow == null)
            {
                return NotFound();
            }

            db.TabelaWynikow.Remove(tabelaWynikow);
            db.SaveChanges();

            return Ok(tabelaWynikow);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TabelaWynikowExists(int id)
        {
            return db.TabelaWynikow.Count(e => e.idTabelaWynikow == id) > 0;
        }
    }
}