using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Driving.Model.Entity
{
    public class BaseContent
    {
        public long Id { get; set; }
        public string Ttile { get; set; }
        [AllowHtml]
        public string Description { get; set; }
        public string PictureURL { get; set; }
        public DateTime CreateDate { get; set; }

        public BaseContent()
        {
            CreateDate = DateTime.Now;
        }
    }
}