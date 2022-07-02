using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Driving.Models.Entity
{
    public class MessageEntity
    {
        public long Id { get; set; }
        public string Title { get; set; }
        [AllowHtml]
        public string Description { get; set; }
        public string WebSite { get; set; }
        public string PhoneNumber { get; set; }
    }
}