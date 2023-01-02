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
using MasterDegree;
using MasterDegree.Models;
using MasterDegree.UserDefined;
using Microsoft.AspNet.Identity;

namespace MasterDegree.Controllers.API
{
    [RoutePrefix("api")]
    [Authorize(Roles = RoleName.Admin)]
    public class ThesesController : ApiController
    {
        private MasterDegreeEntities1 db = new MasterDegreeEntities1();

        // GET: api/Theses
        [Route("AllTheses")]
        public IHttpActionResult GetTheses()
        {
            var ThesesQuery = db.Theses.Select(a => new
            {
                ThesisName = a.ThesisName,
                ProfessorID = a.ThesisSupervisions.Select(b => b.ProfessorID).FirstOrDefault(),
                ThesisCode = a.ThesisCode,
                StartDate = a.StartDate,
                EndDate = a.EndDate



            });
            return Ok(ThesesQuery);
        }

        // GET: api/Theses/5
        [Route("SingleThesis")]
        [ResponseType(typeof(Thesis))]
        public IHttpActionResult GetThesis(ThesesBindingModels model)
        {
            var ThesesQuery = db.Theses.Where(a => a.ThesisCode == model.ThesisCode).Select(a => new
            {
                ThesisName = a.ThesisName,
                ProfessorID = a.ThesisSupervisions.Select(b => b.ProfessorID).FirstOrDefault(),
                ThesisCode = a.ThesisCode,
                StartDate = a.StartDate,
                EndDate = a.EndDate


            }).SingleOrDefault();

            return Ok(ThesesQuery);
        }

        // PUT: api/Theses/5
        [Route("EditThesis")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutThesis(ThesesBindingModels model)
        {
            Thesis thesis = db.Theses.Where(a => a.ThesisCode == model.ThesisCode).SingleOrDefault();

            thesis.ThesisName = model.ThesisName;
            thesis.StartDate = model.StartDate;
            thesis.EndDate = model.EndDate;

            ThesisSupervision thesisSupervision = db.ThesisSupervisions.Where(a => a.ThesisCode == model.ThesisCode).SingleOrDefault();

            thesisSupervision.ThesisCode = model.ThesisCode;
            thesisSupervision.ProfessorID = RequestContext.Principal.Identity.GetUserId();

            db.Entry(thesis).State = EntityState.Modified;
            db.Entry(thesisSupervision).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThesisExists(model.ThesisCode))
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

        // POST: api/Theses
        [Route("AddThesis")]
        [ResponseType(typeof(Thesis))]
        public IHttpActionResult PostThesis(ThesesBindingModels model)
        {

            Thesis thesis = new Thesis();

            thesis.ThesisCode = model.ThesisCode;
            thesis.ThesisName = model.ThesisName;
            thesis.StartDate = model.StartDate;
            thesis.EndDate = model.EndDate;


            ThesisSupervision thesisSupervision = new ThesisSupervision();

            thesisSupervision.ThesisCode = model.ThesisCode;
            thesisSupervision.ProfessorID = RequestContext.Principal.Identity.GetUserId();



            db.Theses.Add(thesis);
            db.ThesisSupervisions.Add(thesisSupervision);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ThesisExists(thesis.ThesisCode))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.Created);
        }

        // DELETE: api/Theses/5
        [Route("DeleteThesis")]
        [ResponseType(typeof(Thesis))]
        public IHttpActionResult DeleteThesis(ThesesBindingModels model)
        {
            Thesis thesis = db.Theses.Find(model.ThesisCode);
            if (thesis == null)
            {
                return NotFound();
            }

            db.Theses.Remove(thesis);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.Accepted);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ThesisExists(string id)
        {
            return db.Theses.Count(e => e.ThesisCode == id) > 0;
        }
    }
}