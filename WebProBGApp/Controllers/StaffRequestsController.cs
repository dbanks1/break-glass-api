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
using WebProBGApp;

namespace WebProBGApp.Controllers
{
    public class StaffRequestsController : ApiController
    {
        public StaffRequestsController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        private webprobgdbEntities db = new webprobgdbEntities();

        // GET: api/StaffRequests
        public IQueryable<StaffRequest> GetStaffRequests()
        {
            return db.StaffRequests;
        }

        // GET: api/StaffRequests/5
        [ResponseType(typeof(StaffRequest))]
        public IHttpActionResult GetStaffRequest(int id)
        {
            StaffRequest staffRequest = db.StaffRequests.Find(id);
            if (staffRequest == null)
            {
                return NotFound();
            }

            return Ok(staffRequest);
        }

        // PUT: api/StaffRequests/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStaffRequest(int id, StaffRequest staffRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != staffRequest.StaffRequestsId)
            {
                return BadRequest();
            }

            db.Entry(staffRequest).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffRequestExists(id))
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

        // POST: api/StaffRequests
        [ResponseType(typeof(StaffRequest))]
        public IHttpActionResult PostStaffRequest(StaffRequest staffRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StaffRequests.Add(staffRequest);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = staffRequest.StaffRequestsId }, staffRequest);
        }

        // DELETE: api/StaffRequests/5
        [ResponseType(typeof(StaffRequest))]
        public IHttpActionResult DeleteStaffRequest(int id)
        {
            StaffRequest staffRequest = db.StaffRequests.Find(id);
            if (staffRequest == null)
            {
                return NotFound();
            }

            db.StaffRequests.Remove(staffRequest);
            db.SaveChanges();

            return Ok(staffRequest);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StaffRequestExists(int id)
        {
            return db.StaffRequests.Count(e => e.StaffRequestsId == id) > 0;
        }
    }
}