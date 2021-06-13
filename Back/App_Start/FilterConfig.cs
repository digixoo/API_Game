﻿using System.Web;
using System.Web.Mvc;
using Back.Filters;

namespace Back
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {          
            filters.Add(new HandleErrorAttribute());
        }
    }
}
