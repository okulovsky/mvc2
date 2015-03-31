using Lecture3.Infrastructure;
using Lecture3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lecture3.Controllers
{
    public class TestableComingSoonController : Controller
    {
		IBookRepository bookRepository;
		ICurrentDateProvider currentDateProvider;

		public TestableComingSoonController(IBookRepository bookRepository, ICurrentDateProvider currentDateProvider)
		{
			this.bookRepository = bookRepository;
			this.currentDateProvider = currentDateProvider;
		}
        // GET: TestableComingSoon
        public ActionResult Index()
        {
			var now = currentDateProvider.Now;
			var upperBound = now.AddDays(40);
			var books = bookRepository.Books
				.Where(z => z.AvailabilityDate > now && z.AvailabilityDate < upperBound);
			return View(books);
        }
    }
}