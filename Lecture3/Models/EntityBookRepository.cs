using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lecture3.Models
{
	public class EntityBookRepository : IBookRepository
	{
		BookshopContext context = new BookshopContext();

		public IEnumerable<Book> Books
		{
			get
			{
				return context.Books;
			}
		}
	}
}