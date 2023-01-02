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
using Microsoft.AspNet.Identity;

namespace MasterDegree.Controllers.API
{
    [RoutePrefix("api")]
    [Authorize]
    public class StudentThesisController : ApiController
    {
        private MasterDegreeEntities1 db = new MasterDegreeEntities1();

        // GET: api/StudentThesis
        [Route("AllStudentsThesis")]
        public IHttpActionResult GetStudentThesis()
        {
            var StudentThesisQeury = db.StudentThesis.Select(a => new
            {
                StudentName = db.AspNetUsers.Where(b => b.Id == a.StudentID).Select(c => c.UserName).FirstOrDefault(),
                StudentThesis = a.Thesis.ThesisName

            });
            return Ok(StudentThesisQeury);
        }

        // GET: api/StudentThesis/5
        [Route("SingleStudentThesis")]
        [ResponseType(typeof(StudentThesi))]
        public IHttpActionResult GetStudentThesi(StudentThesisBindingModels model)
        {
            var StudentThesisQeury = db.StudentThesis.Where(x => x.StudentID == model.StudentId).Select(a => new
            {
                StudentName = db.AspNetUsers.Where(b => b.Id == a.StudentID).Select(c => c.UserName).FirstOrDefault(),
                StudentThesis = a.Thesis.ThesisName

            });

            return Ok(StudentThesisQeury);
        }


        // POST: api/StudentThesis
        [Route("AddStudentsThesis")]
        [ResponseType(typeof(StudentThesi))]
        public IHttpActionResult PostStudentThesi(StudentThesisBindingModels model)
        {
            
            string Id = RequestContext.Principal.Identity.GetUserId();

            if (Id != model.StudentId)
            {
                return StatusCode(HttpStatusCode.NotAcceptable);
            }


            StudentThesi studentThesi = new StudentThesi();

            studentThesi.StudentID = model.StudentId;
            studentThesi.ThesisCode = model.ThesisCode;

            db.StudentThesis.Add(studentThesi);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (StudentThesiExists(studentThesi.StudentID))
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

        // DELETE: api/StudentThesis/5
        [Route("DeleteStudentsThesis")]
        [ResponseType(typeof(StudentThesi))]
        public IHttpActionResult DeleteStudentThesi(StudentThesisBindingModels model)
        {
            string Id = RequestContext.Principal.Identity.GetUserId();

            if (Id != model.StudentId)
            {
                return StatusCode(HttpStatusCode.NotAcceptable);
            }

            StudentThesi studentThesi = db.StudentThesis.Where(a => (a.StudentID == model.StudentId) || (a.ThesisCode == model.ThesisCode)).FirstOrDefault();

            if (studentThesi == null)
            {
                return NotFound();
            }

            db.StudentThesis.Remove(studentThesi);
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

        private bool StudentThesiExists(string id)
        {
            return db.StudentThesis.Count(e => e.StudentID == id) > 0;
        }
    }
}