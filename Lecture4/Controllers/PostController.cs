using Lecture4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lecture4.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult SimpleForm()
        {
            return View();
        }

        [HttpPost]
        public string SimpleForm(string SearchRequest, bool AllWordsOnly, BookType BookType, string Genre)
        {
            return 
                "Запрос: " + SearchRequest +
                "<br/>Только все слова: " + AllWordsOnly + 
                "<br/>Тип книги: " + BookType + 
                "<br/>Жанры: " + Genre;
        }
        
        public ActionResult ModelForm(Subsription subscription)
        {
            if (subscription == null || subscription.Id == 0) subscription = new Subsription { Id = 1 };
            return View(subscription);
        }
    }
}