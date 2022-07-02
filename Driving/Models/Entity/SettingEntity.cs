
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Driving.Models.Entity
{
    public class SettingEntity
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Keywords { get; set; }
        public string Layout { get; set; }
    }
}