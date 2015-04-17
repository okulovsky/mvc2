using Lecture6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lecture6
{
    public class CatalogController : Controller
    {

        public ActionResult Index(string ViewName, string author)
        {
            if (ViewName == null) ViewName = "Index1";
            return View(ViewName,(object)author);
        }


        public ActionResult FilteredBooks(string author)
        {
            var data = Book.GetBooks();
            if (!string.IsNullOrEmpty(author))
                data=data.Where(z => z.Author== author);
            return PartialView("FilteredBooks",data);
        }

    }
}
