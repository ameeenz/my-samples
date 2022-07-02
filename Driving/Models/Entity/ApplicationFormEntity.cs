using Driving.Model.Entity;
using Driving.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Driving.Models.Entity
{
    public class ApplicationFormEntity
    {
        public long Id { get; set; }
        [Required(ErrorMessage ="Please Enter your FullName")]
        [StringLength(100,ErrorMessage ="Your Name is too long")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Please Enter your Email")]
        [EmailAddress(ErrorMessage ="Enter correct Email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter your PhoneNumber")]
        [Phone(ErrorMessage ="Enter correct PhoneNumber")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Please Enter your BirthDate")]
        public DateTime BirthDate { get; set; }

        [ForeignKey("Course_Id")]
        public virtual CourseEntity Course { get; set; }
        [CustomAgeValidation]
        public long Course_Id { get; set; }

        [ForeignKey("Car_Id")]
        public virtual CarEntity Car { get; set; }
        public long Car_Id { get; set; }    
    }
}