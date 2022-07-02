using Driving.Model;
using Driving.Model.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Driving.Areas.Administrator.Controllers
{
    public class AdminCourseController : BaseController
    {
        
        // GET: Administrator/AdminCourse
        public ActionResult Index()
        {
            return View(context.CourseCollection.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost()]
        public ActionResult Create(string Title, string Description, double Price, HttpPostedFileBase PictureFile)
        {
            string DefaultAddress = "";
            if (PictureFile != null)
            {
                DefaultAddress = "/Upload/Course/" + Guid.NewGuid().ToString().Substring(0,8) + PictureFile.FileName;
                PictureFile.SaveAs(Server.MapPath("~"+ DefaultAddress));
            }
                context.CourseCollection.Add(new Model.Entity.CourseEntity() { Ttile = Title, Description = Description, Price = Price, PictureURL = DefaultAddress });
                context.SaveChanges();
            
            return RedirectToAction("index");
        }
        public ActionResult Delete(long Id)
        {
            FileInfo info = new FileInfo(Server.MapPath("~" + context.CourseCollection.Find(Id).PictureURL));
            if (info.Exists)
            {
                info.Delete();
            }
            context.CourseCollection.Remove(context.CourseCollection.Find(Id));
            context.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult Edit(long Id)
        {
            CourseEntity entity = context.CourseCollection.Find(Id);
            return View(entity);
        }

        [HttpPost()]
        public ActionResult Edit(long Id,string Title, string Description, double Price, HttpPostedFileBase PictureFile)
        {
            CourseEntity data = context.CourseCollection.Find(Id);
            if (PictureFile !=null)
            {
                FileInfo info = new FileInfo(Server.MapPath("~" + data.PictureURL));
                if (info.Exists)
                {
                    info.Delete();
                }
                string DefaultAddress= "/Upload/Course/" + Guid.NewGuid().ToString().Substring(0, 8) + PictureFile.FileName;
                PictureFile.SaveAs(Server.MapPath("~" + DefaultAddress));
                data.PictureURL = DefaultAddress;
            }
            data.Ttile = Title;
            data.Price = Price;
            data.Description = Description;
            context.SaveChanges();
            return RedirectToAction("index");
        }
        
    }
}