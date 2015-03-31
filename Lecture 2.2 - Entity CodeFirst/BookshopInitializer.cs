using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class BookshopInitializer : DropCreateDatabaseAlways<BookshopContext>
{
    protected override void Seed(BookshopContext context)
    {
        context.Shops.Add(new Shop { Id = 1, Name = "Центральный", Street = "Ленина", HouseNumber = 52, OpeningDate = new DateTime(2003, 10, 3) });
        context.Shops.Add(new Shop { Id = 2, Name = "Ботанический", Street = "Шварца", HouseNumber = 17, OpeningDate = new DateTime(2011, 3, 5) });
        context.Shops.Add(new Shop { Id = 2, Name = "Академический", Street = "ДеГенина", HouseNumber = 2, OpeningDate = new DateTime(2005, 6, 6) });

        var martin = new Author { Id = 1, FirstName = "Джордж", LastName = "Мартин" };
        var tatl = new Author { Id = 2, FirstName = "Лиза", LastName = "Татл" };

        var bantam = new Publisher { Id = 1 , Name = "Bantam Books", Url="http://bantam-dell.atrandom.com/"};

        var game = new Book { Id = 1, Title = "Игры престолов", Authors = new List<Author> { martin }, Publisher = bantam };
        var storm = new Book { Id = 2, Title = "Шторм в Гавани Ветров", Authors = new List<Author> { martin, tatl }, Publisher = bantam };

        context.Authors.Add(martin);
        context.Authors.Add(tatl);
        context.Publishers.Add(bantam);
        context.Books.Add(game);
        context.Books.Add(storm);
        
        base.Seed(context);
    }
}