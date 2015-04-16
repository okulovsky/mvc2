using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lecture5.Infrastructure
{
    public class ArgumentExceptionHandlerAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled && filterContext.Exception is ArgumentException)
            {
                filterContext.ExceptionHandled = true;
                filterContext.Result = new RedirectResult("/Errors/Handled");
            }
        }
    }
}