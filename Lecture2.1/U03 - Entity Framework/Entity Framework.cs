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
    }
}