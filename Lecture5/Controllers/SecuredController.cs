using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Lecture5.Controllers
{
    public class SecuredController : Controller
    {
        [Authorize]
        // GET: Secured
        public ActionResult Index()
        {
            return View(User.Identity);
        }
    }
}