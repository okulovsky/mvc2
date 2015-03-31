using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{


    static void Main(string[] args)
    {
        var relative = @"..\..\";
        var absolute = Path.GetFullPath(relative);
        AppDomain.CurrentDomain.SetData("DataDirectory", @absolute);

        var context = new BookshopContext();

    }
}