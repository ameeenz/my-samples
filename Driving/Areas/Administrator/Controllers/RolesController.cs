using Driving.Model;
using Driving.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Driving.Areas.Administrator.Controllers
{
    public class RolesController : BaseController
    {
        
        // GET: Administrator/Roles
        public ActionResult Index()
        {
            return View(context.Roles.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(string Name)
        {
            context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole(){ Name=Name});
            context.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult Delete(string Id)
        {
            context.Roles.Remove(context.Roles.Find(Id));
            context.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult Edit(string Id)
        {
            return View(context.Roles.Find(Id));
        }
        [HttpPost]
        public ActionResult Edit(string Id,string Name)
        {
            var item = context.Roles.Find(Id);
            item.Name = Name;
            context.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult WidgetList(string Id)
        {
            ViewBag.myRole = Id;
            return View(context.Widgets.ToList());
        }
        [HttpPost()]
        public ActionResult WidgetList(string Id, string[] SelectedWidget)
        {
            foreach (var item in context.WidgetAccesses.Where(it=>it.Role_Id==Id).ToList())
            {
                context.WidgetAccesses.Remove(item);
                context.SaveChanges();
            }
            foreach (string item in SelectedWidget)
            {
                WidgetAccess wa = new WidgetAccess() {Role_Id=Id, widget_Id=long.Parse(item) };
                context.WidgetAccesses.Add(wa);
                context.SaveChanges();
            }
            return RedirectToAction("index");
        }
    }
}