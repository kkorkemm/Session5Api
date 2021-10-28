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
    public class RockTypesController : ApiController
    {
        private KazanNeftSession5DBEntities db = new KazanNeftSession5DBEntities();

        // GET: api/RockTypes
        [ResponseType(typeof(RockTypes))]
        public IHttpActionResult GetRockTypes()
        {
            return Ok(db.RockTypes);
        }

        // GET: api/RockTypes/5
        [ResponseType(typeof(RockTypes))]
        public IHttpActionResult GetRockTypes(long id)
        {
            RockTypes rockTypes = db.RockTypes.Find(id);
            if (rockTypes == null)
            {
                return NotFound();
            }

            return Ok(rockTypes);
        }
    }
}