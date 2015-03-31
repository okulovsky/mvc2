using Lecture3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lecture3.Controllers
{
    public class BadComingSoonController : Controller
    {
        public ActionResult Index()
        {
			var now = DateTime.Now;
			var upperBound = now.AddDays(40);
			var books = new BookshopContext().Books
				.Where(z => z.AvailabilityDate > now && z.AvailabilityDate < upperBound);

			return View(books);
        }
    }
}