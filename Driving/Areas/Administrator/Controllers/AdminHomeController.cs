using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaptchaMvc.HtmlHelpers;

namespace Driving.Areas.Administrator.Controllers
{
    public class AdminHomeController : BaseController
    {
        private ApplicationSignInManager _signInManager; 
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }
        // GET: Administrator/AdminHome
        [Authorize]
        public ActionResult Index()
        {
            ViewBag.Visits = context.Visits.Count();
            ViewBag.UserCount = context.Users.Count();
            ViewBag.OnlineUser = ((List<string>)System.Web.HttpContext.Current.Application["OnlineUser"]).Count();
            int[] Months = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            List<int> Counter = new List<int>();
            string Numbers = "[";
            foreach (int item in Months)
            {
                Counter.Add(context.Visits.Where(it => it.CreateDate.Month == item).Count());
                Numbers += context.Visits.Where(it => it.CreateDate.Month == item).Count() + ",";
            }
            Numbers = Numbers.TrimEnd(',');
            Numbers += "]";
            ViewBag.Numbers = Numbers;
            return View();
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(string UserName, string Password)
        {
            if (!this.IsCaptchaValid("Captcha is invalid"))
            {
                ViewBag.Message = "Please Enter Captcha";
            }
            else
            {
                var Result = SignInManager.PasswordSignIn(UserName, Password, false, false);
                switch (Result)
                {
                    case SignInStatus.Success:
                        {
                            return RedirectToAction("index");
                        }
                    case SignInStatus.Failure:
                        {
                            ViewBag.Message = "Username or Password is incorrect";
                            break;
                        }
                    default:
                        break;
                }
            }
            return View();
        }
        public ActionResult LogOut()
        {
            SignInManager.AuthenticationManager.SignOut();
            Session.Abandon();
            return Redirect("/Home/Index");
        }
    }
}