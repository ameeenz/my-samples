using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Driving.Areas.Administrator.Controllers
{
    public class AdminMessageController : BaseController
    {
        // GET: Administrator/AdminMessage
        public ActionResult Index()
        {
            return View(context.MessageEntities.ToList());
        }
    }
}