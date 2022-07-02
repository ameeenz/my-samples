using Driving.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Driving.Tools
{
    public static class Translate
    {
        public static string RoleIdToRoleName(string Id)
        {
            string temp = "";
            using (DataContext context = new DataContext())
            {
                temp = context.Roles.Find(Id).Name;
            }
            return temp;
        }
        public static bool RoleInWidget(string RoleId, long WidgetId)
        {
            bool temp = false;
            using (DataContext context = new DataContext())
            {
                temp = context.WidgetAccesses.Where(it => it.Role_Id == RoleId && it.widget_Id == WidgetId).Count() > 0;
            }
            return temp;
        }

        public static string GetFirstRoleId(string UserName)
        {
            string temp = "";
            using (DataContext context = new DataContext())
            {
                temp = context.Users.Where(it => it.UserName == UserName).First().Roles.First().RoleId;
            }
            return temp;
        }
    }
}