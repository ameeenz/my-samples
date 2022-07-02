using Driving.Areas.Administrator.Controllers;
using Driving.Model.Entity;
using Driving.Models.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Driving.Model
{
    public class DataContext: IdentityDbContext<ApplicationUser>
    {
        public DbSet<CourseEntity>CourseCollection { get; set; }
        public DbSet<FAQEntity> FAQCollection { get; set; }
        public DbSet<NewsEntity> NewsCollection { get; set; }
        public DbSet<NewsCategoryEntity> NewsCategoryCollection { get; set; }
        public DbSet<Widget> Widgets { get; set; }
        public DbSet<WidgetAccess> WidgetAccesses { get; set; }
        public DbSet<WidgetCategory> WidgetCategories { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<CourseComment> CourseComments { get; set; }
        public DbSet<ApplicationFormEntity> ApplicationForms { get; set; }
        public DbSet<CarEntity> Cars { get; set; }
        public DbSet<NewsComment> NewsComments { get; set; }
        public DbSet<NewsLike> NewsLikes { get; set; }
        public DbSet<NewsVisit> NewsVisits { get; set; }
        public DbSet<SettingEntity> SettingEntities { get; set; }
        public DbSet<MessageEntity> MessageEntities { get; set; }
        public DataContext():base("baseConnection")
        {

        }
        public static DataContext Create()
        {
            return new DataContext();
        }

    }
}