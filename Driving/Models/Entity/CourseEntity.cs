using Driving.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Driving.Model.Entity
{
    public class CourseEntity:BaseContent
    {
        public double Price { get; set; }
        public virtual ICollection<CourseComment> CourseComments { get; set; }
        public CourseEntity()
        {
            CourseComments = new List<CourseComment>();
        }
    }
}