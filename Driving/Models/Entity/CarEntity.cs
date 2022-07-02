using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Driving.Models.Entity
{
    public class CarEntity
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public ICollection<ApplicationFormEntity> ApplicationForms { get; set; }
        public CarEntity()
        {
            ApplicationForms = new HashSet<ApplicationFormEntity>();
        }
    }
}