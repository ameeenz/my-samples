using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Driving.Models.Entity
{
    public class WidgetCategory
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public virtual ICollection<Widget> Widgets { get; set; }
        public WidgetCategory()
        {
            Widgets = new List<Widget>();
        }
    }
}