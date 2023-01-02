using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace MasterDegree.Models
{
    public class UserBindingModels
    {
        public class UserBindingModel
        {
            [Display(Name = "Id")]
            public string Id { get; set; }

            [Display(Name = "UserName")]
            public string UserName { get; set; }

            [Display(Name = "RoleName")]
            public string RoleName { get; set; }


            [DataType(DataType.EmailAddress)]
            [Display(Name = "Email")]
            public string Email { get; set; }

           
            [DataType(DataType.PhoneNumber)]
            [Display(Name = "PhoneNumber")]
            public string PhoneNumber { get; set; }

            
            [Display(Name = "TargetRole")]
            public string TargetRole { get; set; }

          
            [Display(Name = "DepartmentCode")]
            public string DepartmentCode { get; set; }
            
            [Display(Name = "ResearchSpeciality")]
            public string ResearchSpeciality { get; set; }
           
            [Display(Name = "Degree")]
            public string Degree { get; set; }
         
            [Display(Name = "Birthdate")]
            public DateTime Birthdate { get; set; }

           
        }
    }
}