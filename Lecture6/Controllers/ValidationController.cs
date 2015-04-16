using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lecture06.Models;
using System.Text.RegularExpressions;

namespace Lecture06.Controllers
{
    public class ValidationController : Controller
    {
        public ActionResult Server()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Server(ContactsPlain contacts)
        {
            if (ModelState.IsValid)
                ViewBag.Correct = true;
            
            return View(contacts);
        }




        public ActionResult Client()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Client(ContactsDDD contacts)
        {
            if (ModelState.IsValid)
                ViewBag.Correct = true;
            return View(contacts);
        }

    }
}
