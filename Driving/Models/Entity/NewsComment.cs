using Driving.Model.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Driving.Models.Entity
{
    public class NewsComment
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public long NewsEntity_Id { get; set; }
        [ForeignKey("NewsEntity_Id")]
        public virtual NewsEntity News { get; set; }
    }
}