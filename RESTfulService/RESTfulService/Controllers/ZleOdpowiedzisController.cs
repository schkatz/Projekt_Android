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
    public class ZleOdpowiedzisController : ApiController
    {
        private quizEntities db = new quizEntities();

        // GET: api/ZleOdpowiedzis
        public IQueryable<ZleOdpowiedzi> GetZleOdpowiedzi()
        {
            return db.ZleOdpowiedzi;
        }

        // GET: api/ZleOdpowiedzis/5
        [ResponseType(typeof(ZleOdpowiedzi))]
        public IHttpActionResult GetZleOdpowiedzi(int id)
        {
            ZleOdpowiedzi zleOdpowiedzi = db.ZleOdpowiedzi.Find(id);
            if (zleOdpowiedzi == null)
            {
                return NotFound();
            }

            return Ok(zleOdpowiedzi);
        }

        // PUT: api/ZleOdpowiedzis/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutZleOdpowiedzi(int id, ZleOdpowiedzi zleOdpowiedzi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != zleOdpowiedzi.idZleOdpowiedzi)
            {
                return BadRequest();
            }

            db.Entry(zleOdpowiedzi).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZleOdpowiedziExists(id))
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

        // POST: api/ZleOdpowiedzis
        [ResponseType(typeof(ZleOdpowiedzi))]
        public IHttpActionResult PostZleOdpowiedzi(ZleOdpowiedzi zleOdpowiedzi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ZleOdpowiedzi.Add(zleOdpowiedzi);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ZleOdpowiedziExists(zleOdpowiedzi.idZleOdpowiedzi))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = zleOdpowiedzi.idZleOdpowiedzi }, zleOdpowiedzi);
        }

        // DELETE: api/ZleOdpowiedzis/5
        [ResponseType(typeof(ZleOdpowiedzi))]
        public IHttpActionResult DeleteZleOdpowiedzi(int id)
        {
            ZleOdpowiedzi zleOdpowiedzi = db.ZleOdpowiedzi.Find(id);
            if (zleOdpowiedzi == null)
            {
                return NotFound();
            }

            db.ZleOdpowiedzi.Remove(zleOdpowiedzi);
            db.SaveChanges();

            return Ok(zleOdpowiedzi);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ZleOdpowiedziExists(int id)
        {
            return db.ZleOdpowiedzi.Count(e => e.idZleOdpowiedzi == id) > 0;
        }
    }
}