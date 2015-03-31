using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    class EntityFramework
    {
        public static void Read()
        {
            using (var context = new dbEntities())
            {
                foreach (var e in context.Shops)
                    Console.WriteLine("{0,-6}{1,-15}{2,-15}{3,-5}{4,-10}", e.Id, e.Name, e.Street, e.HouseNumber, e.OpeningDate);
            }
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