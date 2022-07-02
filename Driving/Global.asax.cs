using Driving.App_Start;
using Driving.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Driving
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Session_Start()
        {
            using (DataContext context=new DataContext())
            {
                context.Visits.Add(new Models.Entity.Visit() { CreateDate = DateTime.Now, Ip = HttpContext.Current.Request.UserHostAddress });
                context.SaveChanges();
            }
            try
            {
                List<string> data = (List<string>)System.Web.HttpContext.Current.Application["OnlineUser"];
                data.Add(HttpContext.Current.Request.UserHostAddress);
                System.Web.HttpContext.Current.Application["OnlineUser"] = data;
            }
            catch (Exception)
            {

                List<string> data = new List<string>();
                data.Add(HttpContext.Current.Request.UserHostAddress);
                System.Web.HttpContext.Current.Application.Add("OnlineUser",data);
            }
        }
        protected void Session_End()
        {
            try
            {
                List<string> data = (List<string>)System.Web.HttpContext.Current.Application["OnlineUser"];
                data.Remove(data.Last());
                System.Web.HttpContext.Current.Application["OnlineUser"] = data;
            }
            catch (Exception )
            {
               
                    System.Web.HttpContext.Current.Application.Add("OnlineUser", new List<string>());
                

            }
        }
    }
}
