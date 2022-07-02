using Driving.Model;
using Driving.Model.Entity;
using Driving.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Driving.Controllers
{
    public class HomeController : Controller
    {
        DataContext context = new DataContext();
        // GET: Home
        
        public HomeController()
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
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Courses()
        {
            return View(context.CourseCollection.ToList());
        }

        public ActionResult ApplicationForm()
        {
            ViewBag.Car_Id = new SelectList(context.Cars, "Id", "Title");
            ViewBag.Course_Id = new SelectList(context.CourseCollection, "Id", "Ttile");
            return View();
        }
        [HttpPost()]
        public ActionResult ApplicationForm(ApplicationFormEntity model)
        {
            ViewBag.Car_Id = new SelectList(context.Cars, "Id", "Title");
            ViewBag.Course_Id = new SelectList(context.CourseCollection, "Id", "Ttile");
            if (ModelState.IsValid)
            {
                context.ApplicationForms.Add(model);
                context.SaveChanges();
                ViewBag.Message = "Your application has been sent";
            }
            else
            {
                ViewBag.Message = "Please check inputs";
            }
            return View();
        }
        [HttpPost()]
        public ActionResult Courses(string Title, double? Price,string Description)
        {
            var data = context.CourseCollection.Where(it => it.Ttile.Contains(Title) && it.Description.Contains(Description)).ToList();
            if (Price.HasValue)
            {
                data = data.Where(it => Math.Truncate(it.Price) == Math.Truncate(Price.Value)).ToList();
            }
            return View(data);
        }
        public void AddComments(string Text,long Id)
        {
            context.CourseComments.Add(new Models.Entity.CourseComment() { Text = Text, CourseEntity_Id = Id });
            context.SaveChanges();
        }
        public ActionResult CourseInfo(long Id)
        {
            return View(context.CourseCollection.Find(Id));
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult News(long? Id,int? Page)
        {
            List<NewsEntity> model = new List<NewsEntity>();
            int pager = 1;
            ViewBag.Id = 0;
            if (Page.HasValue)
            {
                pager = Page.Value;
            }
            if (Id.HasValue)
            {
                ViewBag.Counter = (context.NewsCollection.Where(it => it.NewsCategory_Id == Id.Value).Count() / 7) % 2 == 0 ? context.NewsCollection.Where(it => it.NewsCategory_Id == Id.Value).Count() / 7 : (context.NewsCollection.Where(it => it.NewsCategory_Id == Id.Value).Count() / 7) + 1;
                ViewBag.Id = Id.Value;
                model = context.NewsCollection.Where(it => it.NewsCategory_Id == Id.Value).OrderByDescending(it => it.Id).Skip((pager - 1) * 7).Take(7).ToList();
            }
            else
            {
                ViewBag.Counter = (context.NewsCollection.Count() / 7) % 2 == 0 ? context.NewsCollection.Count() / 7 : (context.NewsCollection.Count() / 7) + 1;

                model = context.NewsCollection.OrderByDescending(it => it.Id).Skip((pager - 1) * 7).Take(7).ToList();
            }
            return View(model);
        }
        public ActionResult NewsInfo(long Id)
        {
            context.NewsVisits.Add(new NewsVisit() { NewsEntity_Id = Id, IP = System.Web.HttpContext.Current.Request.UserHostAddress });
            context.SaveChanges();
            ViewBag.LastPosts = context.NewsCollection.Include("NewsCategory").OrderByDescending(it => it.Id).Take(3).ToList();
            return View(context.NewsCollection.Find(Id));
        }

        public JsonResult SendComment(long id, string title, string description)
        {
            context.NewsComments.Add(new NewsComment() { NewsEntity_Id = id, Title = title, Description = description });
            context.SaveChanges();
            return Json(new NewsComment() { NewsEntity_Id = id, Title = title, Description = description });
        }

        public JsonResult LikeNews(long id)
        {
            NewsLike like = new NewsLike() { NewsEntity_Id = id, IP = System.Web.HttpContext.Current.Request.UserHostAddress };
            context.NewsLikes.Add(like);
            context.SaveChanges();
            return Json(context.NewsLikes.Where(it=>it.NewsEntity_Id==id).Count());
        }
        public ActionResult Contact()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);    
        }
    }
}