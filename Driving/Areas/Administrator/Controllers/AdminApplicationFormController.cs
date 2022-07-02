using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Driving.Areas.Administrator.Controllers
{
    public class AdminApplicationFormController : BaseController
    {
        // GET: Administrator/AdminApplicationForm
        public ActionResult Index()
        {
            return View(context.ApplicationForms.Include("Car").Include("Course").ToList());
        }
        public ActionResult Delete(long Id)
        {
            context.ApplicationForms.Remove(context.ApplicationForms.Find(Id));
            context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}