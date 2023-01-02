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
    [Authorize]
    public class ReportsController : ApiController
    {
        private MasterDegreeEntities1 db = new MasterDegreeEntities1();


        // GET: api/Reports
        [Route("AllReports")]
        [Authorize(Roles = RoleName.Admin)]
        public IHttpActionResult GetReports()
        {
            var ReportsInfoQuery = db.Reports.Select(a => new
            {
                ReportCode = a.ReportCode,
                Evaluation = a.Evaluation,
                ProfessorName = a.ReportMakers.Where(b => b.ProfessorID == b.AspNetUser.Id).Select(x => x.AspNetUser.UserName).FirstOrDefault(),
                StudentName = a.ReportOwnerships.Where(b => b.StudentID == b.AspNetUser.Id).Select(x => x.AspNetUser.UserName).FirstOrDefault(),
                StartDate = a.StartDate
            });

            return Ok(ReportsInfoQuery);

      

        }

        // GET: api/Report
        [Route("SingleReport")]
        [ResponseType(typeof(Report))]
        public IHttpActionResult GetReport(ReportBindingModels model)
        {
           
            
          
            string Id = RequestContext.Principal.Identity.GetUserId();

            bool IsInRole = RequestContext.Principal.IsInRole(RoleName.Admin);
           
            
          
                var ReportInfoQuery = db.Reports.Select(a => new
            {
                ReportCode = a.ReportCode,
                Evaluation = a.Evaluation,
                ProfessorID = a.ReportMakers.Where(b => b.ProfessorID == b.AspNetUser.Id).Select(x => x.AspNetUser.Id).FirstOrDefault(),
                StudentID = a.ReportOwnerships.Where(b => b.StudentID == b.AspNetUser.Id).Select(x => x.AspNetUser.Id).FirstOrDefault(),
                ProfessorName = a.ReportMakers.Where(b => b.ProfessorID == b.AspNetUser.Id).Select(x => x.AspNetUser.UserName).FirstOrDefault(),
                StudentName = a.ReportOwnerships.Where(b => b.StudentID == b.AspNetUser.Id).Select(x => x.AspNetUser.UserName).FirstOrDefault(),
                StartDate = a.StartDate

            }).Where(q => q.StudentID == Id || IsInRole || ((q.ProfessorID == Id) && (q.ReportCode == model.ReportCode))).SingleOrDefault();




            return Ok(ReportInfoQuery);
                
            
           
            

           // return BadRequest("Not Found Or Unauthorized");


        }

        // PUT: api/Reports/5
        [Route("EditReport")]
        [ResponseType(typeof(void))]
        [Authorize(Roles = RoleName.Admin + "," + RoleName.Manger)]
        public IHttpActionResult PutReport(ReportBindingModels model)
        {

            Report report = db.Reports.Find(model.ReportCode);

            report.Evaluation = model.Evaluation;
            report.StartDate = model.StartDate;

            ReportMaker reportMaker = db.ReportMakers.Where(a => a.ReportCode == model.ReportCode).SingleOrDefault();
            reportMaker.ProfessorID = RequestContext.Principal.Identity.GetUserId();
            reportMaker.ReportCode = report.ReportCode;

            ReportOwnership reportOwnership = db.ReportOwnerships.Where(a => a.ReportCode == model.ReportCode).SingleOrDefault();
            reportOwnership.StudentID = model.StudentID;
            reportOwnership.ReportCode = report.ReportCode;


            db.Entry(report).State = EntityState.Modified;
            db.Entry(reportMaker).State = EntityState.Modified;
            db.Entry(reportOwnership).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReportExists(model.ReportCode))
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

        // POST: api/Reports
        [Route("AddReport")]
        [Authorize(Roles = RoleName.Manger)]
        [ResponseType(typeof(Report))]
        public IHttpActionResult PostReport(ReportBindingModels model)
        {

            Report report = new Report();
            report.Evaluation = model.Evaluation;
            report.StartDate = model.StartDate;

            ReportMaker reportMaker = new ReportMaker();
            reportMaker.ProfessorID = RequestContext.Principal.Identity.GetUserId();
            reportMaker.ReportCode = report.ReportCode;

            ReportOwnership reportOwnership = new ReportOwnership();
            reportOwnership.StudentID = model.StudentID;
            reportOwnership.ReportCode = report.ReportCode;


            db.Reports.Add(report);
            db.ReportMakers.Add(reportMaker);
            db.ReportOwnerships.Add(reportOwnership);

            try
            {

                db.SaveChanges();

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
            return StatusCode(HttpStatusCode.Created);



        }

        // DELETE: api/Reports/5
        [Route("DeleteReport")]
        [Authorize(Roles = RoleName.Admin)]
        [ResponseType(typeof(Report))]
        public IHttpActionResult DeleteReport(ReportBindingModels model)
        {
            Report report = db.Reports.Find(model.ReportCode);
            if (report == null)
            {
                return NotFound();
            }

            db.Reports.Remove(report);
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

        private bool ReportExists(int id)
        {
            return db.Reports.Count(e => e.ReportCode == id) > 0;
        }
    }
}