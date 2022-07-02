using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Driving.Models.Entity
{
    public class WidgetAccess
    {
        public long Id { get; set; }

        [ForeignKey("widget_Id")]
        public virtual Widget widget { get; set; }
        public long widget_Id { get; set; }

        [ForeignKey("Role_Id")]
        public virtual IdentityRole Role { get; set; }
        public string Role_Id { get; set; }
    }
}