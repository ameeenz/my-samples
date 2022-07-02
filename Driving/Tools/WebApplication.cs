using Driving.Model;
using Driving.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Driving.Tools
{
    public static class WebApplication
    {
        public static string GenerateMenu(string UserName)
        {
            string result = "";
            using (DataContext context = new DataContext())
            {
                string RoleId = Translate.GetFirstRoleId(UserName);
                List<WidgetAccess> Elements = context.WidgetAccesses.Where(it => it.Role_Id == RoleId).ToList();
                var Categories = Elements.GroupBy(it => it.widget.WidgetCategory).Select(it => it.Key);
                foreach (var item in Categories)
                {
                    string Links = "";
                    foreach (var item2 in Elements.Where(it=>it.widget.Widgetcategory_Id==item.Id))
                    {
                        Links += string.Format("<li class=\"nav-item\"><a href=\"{0}\" class=\"nav-link \"><i class=\"far fa-circle nav-icon\"></i><p>{1}</p></a></li>",item2.widget.Url,item2.widget.Name);
                    }
                    result += string.Format("<li class=\"nav-item has-treeview \"><a href=\"#\" class=\"nav-link \"><i class=\"nav-icon fas fa-{1}\"></i><p>{0}<i class=\"right fas fa-angle-left\"></i></p></a><ul class=\"nav nav-treeview\">{2}</ul></li>", item.Title, item.Icon, Links);
                }
            }
            return result;
        }
    }
}