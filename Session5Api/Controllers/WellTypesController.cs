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
    public class WellTypesController : ApiController
    {
        private KazanNeftSession5DBEntities db = new KazanNeftSession5DBEntities();

        // GET: api/WellTypes
        [ResponseType(typeof(WellTypes))]
        public IHttpActionResult GetWellTypes()
        {
            return Ok(db.WellTypes);
        }

        // GET: api/WellTypes/5
        [ResponseType(typeof(WellTypes))]
        public IHttpActionResult GetWellTypes(long id)
        {
            WellTypes wellTypes = db.WellTypes.Find(id);
            if (wellTypes == null)
            {
                return NotFound();
            }

            return Ok(wellTypes);
        }
    }
}