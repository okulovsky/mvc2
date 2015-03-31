using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    static class PrintExtension
    {
        public static void Print<T>(this IEnumerable<T> enumerable, params Func<T, object>[] fields)
        {
            
            var data = enumerable.Select(e => fields.Select(f => f(e).ToString()).ToList()).ToList();

            var lengthes = Enumerable
                .Range(0, fields.Length)
                .Select(index => data.Max(row => row[index].Length) + 2)
                .ToList();

            var line = new string('-', lengthes.Sum());

            Console.WriteLine(line);
            foreach (var row in data)
            {
                for (var i = 0; i < row.Count; i++)
                    Console.Write("{0,-" + lengthes[i] + "}", row[i]);
                Console.WriteLine();
            }
            Console.WriteLine(line);
            Console.WriteLine();
            Console.WriteLine();
        }
    }



    class EntityFramework
    {
        public static void Read()
        {
            var context = new dbEntities();
            
            foreach (var e in context.Shops)
                Console.WriteLine("{0,-6}{1,-15}{2,-15}{3,-5}{4,-10}", e.Id, e.Name, e.Street, e.HouseNumber, e.OpeningDate);

            context.Shops.Print(z => z.Name, z => z.Street, z => z.HouseNumber);

            context.Books.Print(z => z.Title);

            context.Books.Where(z => z.Id == 1).Print(z => z.Title);

            //context.Books.Where(z => z.Title[0] == 'И').Print(z=>z.Title); // -- не будет работать, т.к. запрос исполняется на сервере

            context.Books.ToList().Where(z => z.Title[0] == 'И').Print(z=>z.Title); // -- будет работать, т.к. данные передались на клиента

            context.Books.Where(z => z.Title.StartsWith("И")).Print(z => z.Title); // -- будет работать, т.к. метод StartsWith поддержан

            context.Books.Print(z => z.Title, z => z.Publisher.Name);

            context.Books.Print(z => z.Title, z => z.Authors.Select(auth => auth.FirstName[0] + ". " + auth.LastName).Aggregate((a, b) => a + ", " + b));
        }

        public static void Update()
        {
            using (var context = new dbEntities())
            {
                var toDelete = context.Shops.Where(z => z.Id == 1).FirstOrDefault();
                context.Shops.Remove(toDelete);

                var toUpdate = context.Shops.Where(z => z.Id == 2).FirstOrDefault();
                toUpdate.Name = "В Дирижабле";

                context.Shops.Add(new Shop
                    {
                        Name = "В Меге",
                        Street = "Металлургов",
                        HouseNumber = 87,
                        OpeningDate = new DateTime(2013, 1, 1)
                    });

                context.SaveChanges();
            }
            ConnectedLayer.Read();
        }
    }
}