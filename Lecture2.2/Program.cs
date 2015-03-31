using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            var relative = @"..\..\";
            var absolute = Path.GetFullPath(relative);
            AppDomain.CurrentDomain.SetData("DataDirectory", @absolute);

            var context = new BookshopContext();
            foreach (var e in context.Shops)
                Console.WriteLine("{0,-6}{1,-15}{2,-15}{3,-5}{4,-10}", e.Id, e.Name, e.Street, e.HouseNumber, e.OpeningDate);
        }
    }
}
