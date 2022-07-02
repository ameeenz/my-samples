using Driving.Model.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Driving.Models.Entity
{
    public class NewsVisit
    {
        public long Id { get; set; }
        public string IP { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public long NewsEntity_Id { get; set; }
        [ForeignKey("NewsEntity_Id")]
        public virtual NewsEntity News { get; set; }
    }
}