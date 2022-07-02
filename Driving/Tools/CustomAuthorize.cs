using Driving.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Driving.Tools
{
    public class CustomAuthorize:AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool result = false;
            try
            {
                var rout = httpContext.Request.RequestContext.RouteData;
                string myController = rout.GetRequiredString("controller");
                string myUser = httpContext.User.Identity.Name;
                using (DataContext context = new DataContext())
                {
                    string RoleId = context.Users.Where(it => it.UserName == myUser).First().Roles.First().RoleId;
                    long WidgetId = context.Widgets.Where(it => it.Name == myController).First().Id;
                    result = context.WidgetAccesses.Where(it => it.Role_Id == RoleId && it.widget_Id == WidgetId).Count() > 0;
                }
            }
            catch (Exception)
            {

               
            }
            return result;
            //return base.AuthorizeCore(httpContext);
        }
    }
}