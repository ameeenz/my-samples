using Driving.Model;
using Driving.Models.Entity;
using Microsoft.Security.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Driving.Controllers
{
    public class ErrorController : Controller
    {
        DataContext context = new DataContext();
        public ErrorController()
        {
            ViewBag.NewsCat = context.NewsCategoryCollection.ToList();
            try
            {
                var Setting = context.SettingEntities.First();
                ViewBag.Setting = Setting;
            }
            catch (Exception)
            {

                ViewBag.Setting = new SettingEntity();
            }
        }
        // GET: Error
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult E404()
        {
            return View();
        }

        [HttpPost()]
        public ActionResult E404(MessageEntity model)
        {
            model.Description = Encoder.JavaScriptEncode(model.Description);
            context.MessageEntities.Add(model);
            context.SaveChanges();
            return View();
        }
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }
    }
}