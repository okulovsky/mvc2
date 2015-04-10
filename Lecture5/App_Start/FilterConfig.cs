﻿using Lecture5.Infrastructure;
using System;
using System.Web;
using System.Web.Mvc;

namespace Lecture5
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ArgumentExceptionHandlerAttribute());
            filters.Add(new HandleErrorAttribute());
        }
    }
}
