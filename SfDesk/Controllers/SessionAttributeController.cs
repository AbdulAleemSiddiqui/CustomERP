using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SfDesk.Controllers
{

    public class SessionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;
            if (HttpContext.Current.Session["ID"] == null)
            {   
                filterContext.Result = new RedirectResult("~/LoginUser/Login");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }

}