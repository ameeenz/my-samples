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
    public class AdminNewsController : BaseController
    {
        
        // GET: Administrator/AdminNews
        public ActionResult Index(string Search)
        {
            var Data = context.NewsCollection.Include("NewsCategory").Include("NewsComments").Include("NewsLikes").Include("NewsVisits").ToList();
            if (!string.IsNullOrEmpty(Search))
            {
                Data = Data.Where(it => it.Ttile.Contains(Search) || it.Description.Contains(Search)).ToList();
            }
            return View(Data);
        }

        public ActionResult Create()
        {
            ViewBag.SelectList = context.NewsCategoryCollection.ToList();
            return View();
        }

        [HttpPost()]
        public ActionResult Create(NewsEntity model, HttpPostedFileBase PictureFile)
        {
            string DefaultAddress = "";
            if (PictureFile !=null)
            {
                DefaultAddress = "/Upload/News/" + Guid.NewGuid().ToString().Substring(0, 8)+PictureFile.FileName;
                PictureFile.SaveAs(Server.MapPath("~" + DefaultAddress));
                model.PictureURL = DefaultAddress;
            }

            context.NewsCollection.Add(model);
            context.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult Edit(long Id)
        {
            return View(context.NewsCollection.Find(Id));
        }
        [HttpPost]
        public ActionResult Edit(NewsEntity model,HttpPostedFileBase PictureFile)
        {
            NewsEntity Data = context.NewsCollection.Find(model.Id);
            if (PictureFile!=null)
            {
                FileInfo info = new FileInfo(Server.MapPath("~" + Data.PictureURL));
                if (info.Exists)
                {
                    info.Delete();
                }
                string DefaultAddress= "/Upload/News/" + Guid.NewGuid().ToString().Substring(0, 8) + PictureFile.FileName;
                PictureFile.SaveAs(Server.MapPath("~" + DefaultAddress));
                Data.PictureURL = DefaultAddress;
            }
            Data.Author = model.Author;
            Data.Description = model.Description;
            Data.NewsCategory_Id = model.NewsCategory_Id;
            Data.Ttile = model.Ttile;
            context.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult Delete(long Id)
        {
            NewsEntity Data = context.NewsCollection.Find(Id);
            FileInfo info = new FileInfo(Server.MapPath("~" + Data.PictureURL));
            if (info.Exists)
            {
                info.Delete();
            }
            context.NewsCollection.Remove(Data);
            context.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult Details(long Id)
        {
            return View(context.NewsCollection.Find(Id));
        }
        public void DeleteComment(long id)
        {
            context.NewsComments.Remove(context.NewsComments.Find(id));
            context.SaveChanges();
        }
    }
}
