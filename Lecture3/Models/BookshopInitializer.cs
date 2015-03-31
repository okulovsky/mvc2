using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture3.Models
{
	public class BookshopInitializer : DropCreateDatabaseAlways<BookshopContext>
	{
		protected override void Seed(BookshopContext context)
		{
			context.Books.Add(new Book
				{
					Title = "Меч Истины",
					AvailabilityDate = DateTime.Now.AddYears(-1)
				});
			context.Books.Add(new Book
				{
					Title = "Серебрянные небеса",
					AvailabilityDate = DateTime.Now.AddMonths(1)
				});
			context.Books.Add(new Book
				{
					Title = "Короны и мечи",
					AvailabilityDate = DateTime.Now.AddMonths(2)
				});

			base.Seed(context);
		}
	}
}