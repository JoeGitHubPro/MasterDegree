using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MasterDegree.Models
{
    public class ThesesBindingModels
    {

        [Display(Name = "ThesisCode")]
        public string ThesisCode { get; set; }


        [Display(Name = "ThesisName")]
        public string ThesisName { get; set; }


        [Display(Name = "StartDate")]
        public DateTime StartDate { get; set; }


        [Display(Name = "EndDate")]
        public DateTime EndDate { get; set; }


    }
}