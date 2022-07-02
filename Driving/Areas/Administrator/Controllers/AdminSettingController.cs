using Driving.Models.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Driving.Areas.Administrator.Controllers
{
    public class AdminSettingController : BaseController
    {
        // GET: Administrator/AdminSetting
        public ActionResult Index()
        {
            try
            {
                if (context.SettingEntities.First() != null)
                {
                    return RedirectToAction("Edit", new { Id = context.SettingEntities.First().Id });
                }
                else
                {
                    return RedirectToAction("Create");
                }
            }
            catch (Exception)
            {

                return RedirectToAction("Create");
            }
            
        }
        public ActionResult Create()
        {
            List<SelectListItem> myLayout = new List<SelectListItem>();
            foreach (var item in Directory.GetFiles(Server.MapPath("~/Views/Shared/")))
            {
                FileInfo info = new FileInfo(item);
                myLayout.Add(new SelectListItem() { Text = info.Name.Replace(info.Extension, ""), Value = info.Name });
            }
            ViewBag.Layouts = myLayout;
            return View();
        }
        [HttpPost]
        public ActionResult Create(SettingEntity model)
        {
            context.SettingEntities.Add(model);
            context.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult Edit(long Id)
        {
            var model = context.SettingEntities.Find(Id);
            List<SelectListItem> myLayout = new List<SelectListItem>();
            foreach (var item in Directory.GetFiles(Server.MapPath("~/Views/Shared/")))
            {
                FileInfo info = new FileInfo(item);
                myLayout.Add(new SelectListItem() { Text = info.Name.Replace(info.Extension, ""), Value = info.Name });
            }
            ViewBag.Layouts = myLayout;
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult Edit(SettingEntity model)
        {
            context.Entry<SettingEntity>(model).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}