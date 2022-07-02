using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Driving.Models.Entity
{
    public class Visit
    {
        public long Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string Ip { get; set; }  
    }
}