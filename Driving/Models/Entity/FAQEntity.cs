using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Driving.Model.Entity
{
    public class FAQEntity
    {
        public long Id { get; set; }
        public string Answer { get; set; }
        public string Question { get; set; }
    }
}