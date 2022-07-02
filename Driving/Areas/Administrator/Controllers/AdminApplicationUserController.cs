using Driving.Model;
using Driving.Models.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Driving.Areas.Administrator.Controllers
{
    
    public class AdminApplicationUserController : BaseController
    {
        
        // GET: Administrator/AdminApplicationUser
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public ActionResult Index()
        {
            return View(context.Users.Include("Roles").ToList());
        }
        public ActionResult Edit(string Id)
        {
            ViewBag.Roles = context.Roles.ToList();
            return View(context.Users.Find(Id));
        }
        [HttpPost]
        public ActionResult Edit(ApplicationUser model, string Password, string RePassword, HttpPostedFileBase PictureFile, string RolesName)
        {
            if (Password != RePassword)
            {
                ViewBag.Message = "Password doesn't match the RePassword";
            }
            else
            {
                var item = context.Users.Find(model.Id);
                item.Name = model.Name;
                item.Family = model.Family;
                item.Email = model.Email;
                item.UserName = model.UserName;
                if (PictureFile!=null)
                {
                    if (item.PictureURL != "/Content/Admin/dist/img/avatar04")
                    {
                        FileInfo myfile = new FileInfo(Server.MapPath("~" + item.PictureURL));
                        if (myfile.Exists)
                        {
                            myfile.Delete();
                        }
                    }
                    string DefaultURL = "/Upload/ApplicationUser/" + Guid.NewGuid().ToString().Substring(0, 8) + PictureFile.FileName;
                    PictureFile.SaveAs(Server.MapPath("~" + DefaultURL));
                    item.PictureURL = DefaultURL;
                }
                
                context.SaveChanges();
                try
                {
                    UserManager.RemoveFromRoles(item.Id, Tools.Translate.RoleIdToRoleName(item.Roles.First().RoleId));
                }
                catch (Exception)
                {

                    
                }
                UserManager.AddToRole(item.Id, RolesName);
                UserManager.RemovePassword(item.Id);
                UserManager.AddPassword(item.Id,Password);
                return RedirectToAction("index");
            }
            ViewBag.Roles = context.Roles.ToList();
            return View();
        }
        public ActionResult Delete(string Id)
        {
            var myobj = context.Users.Find(Id);
            if (myobj.PictureURL!= "/Content/Admin/dist/img/avatar04")
            {
                FileInfo myfile = new FileInfo(Server.MapPath("~" + myobj.PictureURL));
                if (myfile.Exists)
                {
                    myfile.Delete();
                }
            }
            context.Users.Remove(context.Users.Find(Id));
            context.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult Create()
        {
            ViewBag.Roles = context.Roles.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(ApplicationUser model,string Password,string RePassword,HttpPostedFileBase PictureFile,string RolesName)
        {
            if (Password!=RePassword)
            {
                ViewBag.Message = "Password doesn't match the RePassword";
            }
            else
            {
                string DefaultURL = "/Content/Admin/dist/img/avatar04";
                model.PictureURL = "/Content/Admin/dist/img/avatar04";
                if (PictureFile!=null)
                {
                    DefaultURL = "/Upload/ApplicationUser/" + Guid.NewGuid().ToString().Substring(0, 8) + PictureFile.FileName;
                    PictureFile.SaveAs(Server.MapPath("~" + DefaultURL));
                    model.PictureURL = DefaultURL;
                }
                var Result = UserManager.Create(model, Password);
                if (Result.Succeeded)
                {
                    UserManager.AddToRole(model.Id, RolesName);
                    return RedirectToAction("index");
                }
                else
                {
                    ViewBag.Message = "We have an error ";
                    foreach (string item in Result.Errors)
                    {
                        ViewBag.Message += " " + item + " ";
                    }
                }
               
            }
            ViewBag.Roles = context.Roles.ToList();
            return View();
        }
        
    }
}