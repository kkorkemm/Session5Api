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
    public class WellLayersController : ApiController
    {
        private KazanNeftSession5DBEntities db = new KazanNeftSession5DBEntities();

        // GET: api/WellLayers
        public IQueryable<WellLayers> GetWellLayers()
        {
            return db.WellLayers;
        }

        // GET: api/WellLayers/5
        [ResponseType(typeof(WellLayers))]
        public IHttpActionResult GetWellLayers(long id)
        {
            WellLayers wellLayers = db.WellLayers.Find(id);
            if (wellLayers == null)
            {
                return NotFound();
            }

            return Ok(wellLayers);
        }

        // PUT: api/WellLayers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWellLayers(long id, WellLayers wellLayers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != wellLayers.ID)
            {
                return BadRequest();
            }

            db.Entry(wellLayers).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WellLayersExists(id))
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

        // POST: api/WellLayers
        [ResponseType(typeof(WellLayers))]
        public IHttpActionResult PostWellLayers(WellLayers wellLayers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.WellLayers.Add(wellLayers);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = wellLayers.ID }, wellLayers);
        }

        // DELETE: api/WellLayers/5
        [ResponseType(typeof(WellLayers))]
        public IHttpActionResult DeleteWellLayers(long id)
        {
            WellLayers wellLayers = db.WellLayers.Find(id);
            if (wellLayers == null)
            {
                return NotFound();
            }

            db.WellLayers.Remove(wellLayers);
            db.SaveChanges();

            return Ok(wellLayers);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WellLayersExists(long id)
        {
            return db.WellLayers.Count(e => e.ID == id) > 0;
        }
    }
}