using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lecture5.Controllers
{
    public class ErroneousController : Controller
    {
        // GET: Errouneous
        public ActionResult Exception()
        {
            throw new Exception();
        }

        [HandleError(ExceptionType=typeof(NullReferenceException), View="SpecialError")]
        public ActionResult NullException()
        {
            throw new NullReferenceException();
        }

        public ActionResult ArgumentException()
        {
            throw new ArgumentException();
        }
    }
}