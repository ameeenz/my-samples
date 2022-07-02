using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Driving.Model.Entity
{
    public class NewsCategoryEntity
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<NewsEntity> NewsEntities { get; set; }
        public NewsCategoryEntity()
        {
            NewsEntities = new List<NewsEntity>();
        }
    }
}