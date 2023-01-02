using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MasterDegree.Models
{
    public class ReportBindingModels
    {
        [Display(Name = "ReportCode")]
        public int ReportCode { get; set; }

        [Display(Name = "Evaluation")]
        public double Evaluation { get; set; }

        [Display(Name = "StartDate")]
        public DateTime StartDate { get; set; }

        [Display(Name = "StudentID")]
        public string StudentID { get; set; }


        [Display(Name = "ProfessorID")]
        public string ProfessorID { get; set; }
    }
}