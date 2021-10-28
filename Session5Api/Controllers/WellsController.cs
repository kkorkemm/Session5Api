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
using Session5Api.Base;

namespace Session5Api.Controllers
{
    public class WellsController : ApiController
    {
        private KazanNeftSession5DBEntities db = new KazanNeftSession5DBEntities();

        // GET: api/Wells
        public IQueryable<Wells> GetWells()
        {
            return db.Wells;
        }

        // GET: api/Wells/5
        [ResponseType(typeof(Wells))]
        public IHttpActionResult GetWells(long id)
        {
            Wells wells = db.Wells.Find(id);
            if (wells == null)
            {
                return NotFound();
            }

            return Ok(wells);
        }

        // PUT: api/Wells/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWells(long id, Wells wells)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != wells.ID)
            {
                return BadRequest();
            }

            db.Entry(wells).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WellsExists(id))
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

        // POST: api/Wells
        [ResponseType(typeof(Wells))]
        public IHttpActionResult PostWells(Wells wells)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Wells.Add(wells);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = wells.ID }, wells);
        }

        // DELETE: api/Wells/5
        [ResponseType(typeof(Wells))]
        public IHttpActionResult DeleteWells(long id)
        {
            Wells wells = db.Wells.Find(id);
            if (wells == null)
            {
                return NotFound();
            }

            db.Wells.Remove(wells);
            db.SaveChanges();

            return Ok(wells);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WellsExists(long id)
        {
            return db.Wells.Count(e => e.ID == id) > 0;
        }
    }
}