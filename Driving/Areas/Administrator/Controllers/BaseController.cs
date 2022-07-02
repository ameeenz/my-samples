using Driving.Model;
using Driving.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Driving.Areas.Administrator.Controllers
{
    [CustomAuthorize]
    public class BaseController:Controller
    {
        protected DataContext context = new DataContext();
        public BaseController()
        {
            
                if(!string.IsNullOrEmpty(System.Web.HttpContext.Current.User.Identity.Name))
                {
                    try
                    {
                        if (string.IsNullOrEmpty(System.Web.HttpContext.Current.Session["MyMenu"].ToString()))
                        {
                            System.Web.HttpContext.Current.Session.Add("MyMenu", Tools.WebApplication.GenerateMenu(System.Web.HttpContext.Current.User.Identity.Name));
                        }
                    }
                    catch (Exception)
                    {

                        System.Web.HttpContext.Current.Session.Add("MyMenu", Tools.WebApplication.GenerateMenu(System.Web.HttpContext.Current.User.Identity.Name));
                    }

                    ViewBag.Menu = System.Web.HttpContext.Current.Session["MyMenu"];
                }
                else
                {
                    ViewBag.Menu = "";
                }
        }
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }
    }
}