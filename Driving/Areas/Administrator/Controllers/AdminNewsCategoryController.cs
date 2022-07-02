using Driving.Model;
using Driving.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Driving.Areas.Administrator.Controllers
{
    public class AdminNewsCategoryController : BaseController
    {
        
        // GET: Administrator/AdminNewsCategory
        public ActionResult Index()
        {
            return View(context.NewsCategoryCollection.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost()]
        public ActionResult Create(NewsCategoryEntity model)
        {
            context.NewsCategoryCollection.Add(model);
            context.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult Edit(long Id)
        {
            return View(context.NewsCategoryCollection.Find(Id));
        }
        [HttpPost]
        public ActionResult Edit(NewsCategoryEntity model)
        {
           
            
                context.Entry(model).State = System.Data.Entity.EntityState.Modified;

                context.SaveChanges();
          
            
           
            return RedirectToAction("index");
        }

        public ActionResult Delete(long Id)
        {
            context.NewsCategoryCollection.Remove(context.NewsCategoryCollection.Find(Id));
            context.SaveChanges();
            return RedirectToAction("index");
        }
        
    }
}