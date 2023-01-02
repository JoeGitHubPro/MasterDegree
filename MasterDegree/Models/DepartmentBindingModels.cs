using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MasterDegree.Models
{
    public class DepartmentBindingModels
    {
        [Display(Name = "DepartmentCode")]
        public string DepartmentCode { get; set; }



        [Display(Name = "DepartmentName")]
        public string DepartmentName { get; set; }



        [Display(Name = "MainOffice")]
        public string MainOffice { get; set; }



        [Display(Name = "ChairmanID")]
        public string ChairmanID { get; set; }
    }
}