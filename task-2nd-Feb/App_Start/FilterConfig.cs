﻿using System.Web;
using System.Web.Mvc;

namespace task_2nd_Feb
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}