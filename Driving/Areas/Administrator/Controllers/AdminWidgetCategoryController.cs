using Driving.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Driving.Areas.Administrator.Controllers
{
    public class AdminWidgetCategoryController : BaseController
    {
        // GET: Administrator/AdminWidgetCategory
        public ActionResult Index()
        {
            return View(context.WidgetCategories.ToList());
        }
        public ActionResult Create()
        {
            
            return View();
        }
        [HttpPost()]
        public ActionResult Create(WidgetCategory model)
        {
            context.WidgetCategories.Add(model);
            context.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult Edit(long Id)
        {
            return View(context.WidgetCategories.Find(Id));
        }
        [HttpPost()]
        public ActionResult Edit(WidgetCategory model)
        {
            context.Entry<WidgetCategory>(model).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult Delete(long Id)
        {
            context.WidgetCategories.Remove(context.WidgetCategories.Find(Id));
            context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}