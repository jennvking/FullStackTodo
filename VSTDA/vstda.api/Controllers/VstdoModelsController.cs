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
using vstda.api.Infrastructure;
using vstda.api.Models;

namespace vstda.api.Controllers
{
    public class VstdoModelsController : ApiController
    {
        private TodoDataContext db = new TodoDataContext();

        // GET: api/VstdoModels
        public IQueryable<VstdoModel> GetToDoes()
        {
            return db.ToDoes;
        }

        // GET: api/VstdoModels/5
        [ResponseType(typeof(VstdoModel))]
        public IHttpActionResult GetVstdoModel(int id)
        {
            VstdoModel vstdoModel = db.ToDoes.Find(id);
            if (vstdoModel == null)
            {
                return NotFound();
            }

            return Ok(vstdoModel);
        }

        // PUT: api/VstdoModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVstdoModel(int id, VstdoModel vstdoModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vstdoModel.KeyID)
            {
                return BadRequest();
            }

            db.Entry(vstdoModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VstdoModelExists(id))
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

        // POST: api/VstdoModels
        [ResponseType(typeof(VstdoModel))]
        public IHttpActionResult PostVstdoModel(VstdoModel vstdoModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ToDoes.Add(vstdoModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = vstdoModel.KeyID }, vstdoModel);
        }

        // DELETE: api/VstdoModels/5
        [ResponseType(typeof(VstdoModel))]
        public IHttpActionResult DeleteVstdoModel(int id)
        {
            VstdoModel vstdoModel = db.ToDoes.Find(id);
            if (vstdoModel == null)
            {
                return NotFound();
            }

            db.ToDoes.Remove(vstdoModel);
            db.SaveChanges();

            return Ok(vstdoModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VstdoModelExists(int id)
        {
            return db.ToDoes.Count(e => e.KeyID == id) > 0;
        }
    }
}