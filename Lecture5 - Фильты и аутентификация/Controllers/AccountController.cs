using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Lecture5.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string user, string password, string returnUrl)
        {
            var  result = FormsAuthentication.Authenticate(user, password);
            if (result)
            {
                FormsAuthentication.SetAuthCookie(user, false);
            }
            return Redirect(returnUrl);

        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return View();
        }
    }
}