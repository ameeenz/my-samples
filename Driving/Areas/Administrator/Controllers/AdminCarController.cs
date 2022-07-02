using Driving.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Driving.Areas.Administrator.Controllers
{
    public class AdminCarController : BaseController
    {

        // GET: Administrator/AdminNewsCategory
        public ActionResult Index()
        {
            return View(context.Cars.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost()]
        public ActionResult Create(CarEntity model)
        {
            context.Cars.Add(model);
            context.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult Edit(long Id)
        {
            return View(context.Cars.Find(Id));
        }
        [HttpPost]
        public ActionResult Edit(CarEntity model)
        {


            context.Entry(model).State = System.Data.Entity.EntityState.Modified;

            context.SaveChanges();



            return RedirectToAction("index");
        }

        public ActionResult Delete(long Id)
        {
            context.Cars.Remove(context.Cars.Find(Id));
            context.SaveChanges();
            return RedirectToAction("index");
        }

    }
}