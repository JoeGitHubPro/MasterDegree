using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using MasterDegree;
using MasterDegree.UserDefined;
using MasterDegree.Models;
using static MasterDegree.Models.UserBindingModels;

namespace TravelAgancyPro.Controllers.API
{
    [RoutePrefix("api/Users")]
    [Authorize(Roles = RoleName.Admin)]
    public class UsersController : ApiController
    {
        private MasterDegreeEntities1 db = new MasterDegreeEntities1();

        [HttpGet]
        [Route("NoUsers")]
        public IHttpActionResult GetNoUsers()
        {
            // get the user manager from the owin context
            ApplicationUserManager userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();

            List<AspNetUser> User = new List<AspNetUser>();
            foreach (var item in db.AspNetUsers)
            {
                string Role = userManager.GetRoles(item.Id).SingleOrDefault();
                if (Role == RoleName.User)
                {
                    User.Add(item);
                }
            }
            int No = User.Count();
            User.Clear();
            userManager.Dispose();

            return Ok(No);
        }

        [HttpGet]
        [Route("NoManger")]
        public IHttpActionResult GetNoManger()
        {
            // get the user manager from the owin context
            ApplicationUserManager userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();

            List<AspNetUser> User = new List<AspNetUser>();
            foreach (var item in db.AspNetUsers)
            {
                string Role = userManager.GetRoles(item.Id).SingleOrDefault();
                if (Role == RoleName.Manger)
                {
                    User.Add(item);
                }
            }
            int No = User.Count();
            User.Clear();
            userManager.Dispose();

            return Ok(No);
        }

        [HttpGet]
        [Route("NoAdmin")]
        public IHttpActionResult GetNoAdmin()
        {
            // get the user manager from the owin context
            ApplicationUserManager userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();

            List<AspNetUser> User = new List<AspNetUser>();
            foreach (var item in db.AspNetUsers)
            {
                string Role = userManager.GetRoles(item.Id).SingleOrDefault();
                if (Role == RoleName.Admin)
                {
                    User.Add(item);
                }
            }
            int No = User.Count();
            User.Clear();
            userManager.Dispose();

            return Ok(No);
        }

        [HttpGet]
        [Route("NoOfAllUsers")]
        public IHttpActionResult GetAllUsers()
        {
            // get the user manager from the owin context
            ApplicationUserManager userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();

            List<AspNetUser> User = new List<AspNetUser>();
            foreach (var item in db.AspNetUsers)
            {
                string Role = userManager.GetRoles(item.Id).SingleOrDefault();
                User.Add(item);

            }
            int No = User.Count();
            User.Clear();

            return Ok(No);
        }

        [HttpGet]
        [Route("FullAccountUsers")]
        public IHttpActionResult GetAccUsers(UserBindingModel model)
        {
            // get the user manager from the owin context
            ApplicationUserManager userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();

            List<AspNetUser> User = new List<AspNetUser>();
            foreach (var item in db.AspNetUsers)
            {
                string Role = userManager.GetRoles(item.Id).SingleOrDefault();
                if (Role == model.RoleName)
                {
                    User.Add(item);
                }


            }


            return Ok(User.Select(a => new { a.Id, a.UserName, a.Email, a.PhoneNumber }));
        }

        // GET: api/Users
        [Route("AllAccountUsers")]
        public IHttpActionResult GetAspNetUsers()
        {



            return Ok(db.AspNetUsers.Select(e => new
            {
                Id = e.Id,
                UserName = e.UserName,
                Email = e.Email,
                PhoneNumber = e.PhoneNumber,
                DepartmentCode = e.DepartmentCode,
                ResearchSpeciality = e.ResearchSpeciality,
                Degree = e.Degree,
                Birthdate = e.Birthdate,

                Rolename = e.AspNetRoles.Select(a => a.Name).FirstOrDefault()
            }));
        }

        // GET: api/Users/5
        [Route("SingleAccountUser")]
        [ResponseType(typeof(AspNetUser))]
        public IHttpActionResult GetAspNetUser(UserBindingModel model)
        {
           

            var aspNetUser = db.AspNetUsers.Where(e => e.Id == model.Id).Select(e => new
            {
                Id = e.Id,
                UserName = e.UserName,
                Email = e.Email,
                PhoneNumber = e.PhoneNumber,
                DepartmentCode = e.DepartmentCode,
                ResearchSpeciality = e.ResearchSpeciality,
                Degree = e.Degree,
                Birthdate = e.Birthdate,
              //  StudentThesis = db.StudentThesis.Where(a=>a.StudentID==e.Id).Select(b=>b.Thesis.ThesisName).FirstOrDefault(),

                Rolename = e.AspNetRoles.Select(a => a.Name).FirstOrDefault()
            }).FirstOrDefault();

            if (aspNetUser == null)
            {
                return NotFound();
            }

            return Ok(aspNetUser);
        }

        [Route("EditAccountUsers")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAspNetUserModel(UserBindingModel model)
        {
            AspNetUser aspNetUser = db.AspNetUsers.Find(model.Id);

            aspNetUser.UserName = model.UserName;
            aspNetUser.Email = model.Email;
            aspNetUser.PhoneNumber = model.PhoneNumber;
            aspNetUser.DepartmentCode = model.DepartmentCode;
            aspNetUser.ResearchSpeciality = model.ResearchSpeciality;
            aspNetUser.Degree = model.Degree;
            aspNetUser.Birthdate = model.Birthdate;




            if (model.Id != aspNetUser.Id)
            {
                return BadRequest();
            }

            db.Entry(aspNetUser).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AspNetUserExists(model.Id))
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

        // DELETE: api/Users/5
        [Route("DeleteAccountUsers")]
        [ResponseType(typeof(AspNetUser))]
        public IHttpActionResult DeleteAspNetUser(UserBindingModel model)
        {
            AspNetUser aspNetUser = db.AspNetUsers.Find(model.Id);
            if (aspNetUser == null)
            {
                return NotFound();
            }

            db.AspNetUsers.Remove(aspNetUser);
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

        private bool AspNetUserExists(string id)
        {
            return db.AspNetUsers.Count(e => e.Id == id) > 0;
        }
    }
}