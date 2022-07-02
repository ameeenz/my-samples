using Driving.Model.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Driving.Models.Entity
{
    public class CourseComment
    {
        public long Id { get; set; }
        public string Text { get; set; }
        [ForeignKey("CourseEntity_Id")]
        public virtual CourseEntity CourseEntity { get; set; }
        public long CourseEntity_Id { get; set; }
    }
}