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
        base.Seed(context);
    }
}