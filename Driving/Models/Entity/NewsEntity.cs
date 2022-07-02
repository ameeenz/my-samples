using Driving.Models;
using Driving.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Driving.Model.Entity
{
    public class NewsEntity:BaseContent
    {
        public string Author { get; set; }

        [ForeignKey("NewsCategory_Id")]
        public virtual NewsCategoryEntity NewsCategory { get; set; }
        public long NewsCategory_Id { get; set; }
        public virtual ICollection<NewsLike> NewsLikes { get; set; }
        public virtual ICollection<NewsVisit> NewsVisits { get; set; }
        public virtual ICollection<NewsComment> NewsComments { get; set; }
    }
}