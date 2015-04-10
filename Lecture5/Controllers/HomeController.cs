using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lecture5.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        [Infrastructure.Profiler]
        public ActionResult ProfiledAction()
        {
            return View();
        }

    }
}