using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MasterDegree.Models
{
    public class StudentThesisBindingModels
    {
        [Display(Name = "StudentId")]
        public string StudentId { get; set; }

        [Display(Name = "ThesisCode")]
        public string ThesisCode { get; set; }

    }
}