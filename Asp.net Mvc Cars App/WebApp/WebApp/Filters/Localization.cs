using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Filters
{
    public class Localization : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string culture = null;
            HttpCookie cookie = filterContext.RequestContext.HttpContext.Request.Cookies["_culture"];
            if (cookie != null)
            {
                culture = cookie.Value;
                Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);
                Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

            }

        }
    }
}