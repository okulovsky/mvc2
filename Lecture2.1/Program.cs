//using EntityCodeFirst;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    public const string ConnectionString = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\db.mdf;Integrated Security=True;MultipleActiveResultSets=True";

    //static void Erase()
    //{
    //    File.Delete(@"..\..\db.mdf");
    //    File.Delete(@"..\..\db_log.ldf");
    //    using (var context = new BookshopContext())
    //        foreach (var e in context.Shops) ;
    //}

    static void Main(string[] args)
    {
        var relative = @"..\..\";
        var absolute = Path.GetFullPath(relative);
        AppDomain.CurrentDomain.SetData("DataDirectory", @absolute);

       // Erase();
        //ConnectedLayer.Read();
        //ConnectedLayer.Update();
        //DisconnectedLayer.Read();
        //DisconnectedLayer.Update();
        Entity.EntityFramework.Read();
    }
}
