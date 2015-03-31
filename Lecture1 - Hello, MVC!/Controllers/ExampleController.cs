using Lecture1.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lecture1.Controllers
{
    public class ExampleController : Controller
    {

		public string String()
		{
			return "Hello, MVC!";
		}


		public string RedirectedPage()
		{
			return "Redirected here";
		}


		public RedirectResult Redirect()
		{
			return Redirect("/Example/RedirectedPage");
			//return new RedirectResult("/Hello/RedirectedPage");
		}



		public FileContentResult File()
		{
			return File(
				System.Text.Encoding.UTF8.GetBytes("Hello, file!"),
				"bin/bin");
		}

		public FileContentResult Image()
		{
			var bmp = new Bitmap(100, 100);
			using (var g = Graphics.FromImage(bmp))
			{
				g.DrawLine(Pens.Black, 0, 0, 100, 100);
				g.DrawLine(Pens.Black, 100, 0, 0, 100);
			}
			var ms = new MemoryStream();
			bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
			return File(ms.ToArray(), "image/png");
		}


		public ViewResult Page()
		{
			return View();
		}

		public ViewResult PageAgain()
		{
			return View("Page");
		}

		Book GetBook()
		{
			return new Book
			{
				Title = "ASP.NET MVC 4 с примерами на C# 5.0 для профессионалов",
				Authors = new[] { 
					new Author
					{
						FirstName = "Адам",
						LastName = "Фримен"
					}
				},
				Publisher = "Вильямс",
				Year = 2013,
				ImageId=1
				};

		}

		public ViewResult Model()
		{
			return View(GetBook());
		}

		public ViewResult ViewWithChildAction()
		{
			return View(GetBook());
		}

		public ActionResult ChildAction()
		{
			var anotherBook = new Book
			{
				Title = "Игра престолов",
				Authors = new[] 
				{
					new Author
					{
						FirstName = "Джордж",
						LastName = "Мартин"
					}
				},
				Publisher="АСТ",
				Year = 1996
			};
			return PartialView("BookView", anotherBook);
		}

		public string Parameter(int id)
		{
			return id.ToString();
		}
    }
}