using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Driving.Models.Entity
{
    public class Widget
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public long Widgetcategory_Id { get; set; }
        [ForeignKey("Widgetcategory_Id")]
        public virtual WidgetCategory WidgetCategory { get; set; }
        public virtual ICollection<WidgetAccess> widgetaccess { get; set; }
        public Widget()
        {
            widgetaccess = new List<WidgetAccess>();
        }
        
    }
}