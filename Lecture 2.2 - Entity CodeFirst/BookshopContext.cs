using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class BookshopContext : DbContext
{
    public DbSet<Shop> Shops { get; set; }
    public DbSet<Book> Books { get; set; }

    public DbSet<Author> Authors { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public BookshopContext()
        : base("DefaultConnection")
    {
        Database.SetInitializer<BookshopContext>(new BookshopInitializer());

    }
}