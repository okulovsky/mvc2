using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lecture3.Models
{

	public class BookshopContext : DbContext
	{
		public DbSet<Book> Books { get; set; }
		public BookshopContext()
			: base("DefaultConnection")
		{
			Database.SetInitializer<BookshopContext>(new BookshopInitializer());

		}
	}
}