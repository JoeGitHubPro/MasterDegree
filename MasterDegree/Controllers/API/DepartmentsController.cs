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

namespace MasterDegree.Controllers.API
{
    [RoutePrefix("api")]
    [Authorize(Roles = RoleName.Admin)]
    public class DepartmentsController : ApiController
    {
        private MasterDegreeEntities1 db = new MasterDegreeEntities1();

        // GET: api/Departments
        [Route("AllDepartments")]
        public IHttpActionResult GetDepartments()
        {
            var DepartmentQuery = db.Departments.Select(a => new
            {
                DepartmentCode = a.DepartmentCode,
                DepartmentName = a.DepartmentName,
                MainOffice = a.MainOffice,
                DepartmentsMangments = a.DepartmentsMangments.Where(b => b.DepartmentCode == a.DepartmentCode).Select(b => b.AspNetUser.UserName).FirstOrDefault()

            });
            return Ok(DepartmentQuery);
        }

        // GET: api/Departments/5
        [Route("SingleDepartment")]
        [ResponseType(typeof(Department))]
        public IHttpActionResult GetDepartment(DepartmentBindingModels model)
        {
            var DepartmentQuery = db.Departments.Where(q => q.DepartmentCode == model.DepartmentCode).Select(a => new
            {
                DepartmentCode = a.DepartmentCode,
                DepartmentName = a.DepartmentName,
                MainOffice = a.MainOffice,
                DepartmentsMangments = a.DepartmentsMangments.Where(b => b.DepartmentCode == a.DepartmentCode).Select(b => b.AspNetUser.UserName).FirstOrDefault()

            });

            return Ok(DepartmentQuery);
        }

        // PUT: api/Departments/5
        [Route("EditDepartment")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDepartment(DepartmentBindingModels model)
        {

            Department department = db.Departments.Find(model.DepartmentCode);

            department.DepartmentName = model.DepartmentName;   
            department.MainOffice = model.MainOffice;   


            db.Entry(department).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(model.DepartmentCode))
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

        // POST: api/Departments
        [Route("AddDepartment")]
        [ResponseType(typeof(DepartmentBindingModels))]
        public IHttpActionResult PostDepartment(DepartmentBindingModels model)
        {


            Department department = new Department();

            department.DepartmentCode = model.DepartmentCode;
            department.DepartmentName = model.DepartmentName;
            department.MainOffice = model.MainOffice;
            

            DepartmentsMangment departmentsMangment = new DepartmentsMangment();

            departmentsMangment.DepartmentCode = department.DepartmentCode;
            departmentsMangment.ChairmanID = model.ChairmanID;



            db.Departments.Add(department);
            db.DepartmentsMangments.Add(departmentsMangment);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DepartmentExists(department.DepartmentCode))
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

        // DELETE: api/Departments/5
        [Route("DeleteDepartment")]
        [ResponseType(typeof(Department))]
        public IHttpActionResult DeleteDepartment(DepartmentBindingModels model)
        {
            Department department = db.Departments.Find(model.DepartmentCode);
            if (department == null)
            {
                return NotFound();
            }

            db.Departments.Remove(department);
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

        private bool DepartmentExists(string id)
        {
            return db.Departments.Count(e => e.DepartmentCode == id) > 0;
        }
    }
}