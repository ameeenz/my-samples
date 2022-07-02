using Driving.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Driving.Areas.Administrator.Controllers
{
    public class AdminWidgetController : BaseController
    {
        // GET: Administrator/AdminWidget
        public ActionResult Index()
        {
            return View(context.Widgets.Include("WidgetCategory").ToList());
        }
        public ActionResult Create()
        {
            ViewBag.Categories = context.WidgetCategories.ToList();
            return View();
        }
        [HttpPost()]
        public ActionResult Create(Widget model)
        {
            context.Widgets.Add(model);
            context.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult Edit(long Id)
        {
            return View(context.Widgets.Find(Id));
        }
        [HttpPost()]
        public ActionResult Edit(Widget model)
        {
            context.Entry<Widget>(model).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult Delete(long Id)
        {
            context.Widgets.Remove(context.Widgets.Find(Id));
            context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}