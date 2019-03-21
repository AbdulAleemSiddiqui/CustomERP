using SfDesk.Models;
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
            string a = filterContext.ActionDescriptor.ActionName;
            string b = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            HttpContext ctx = HttpContext.Current;
            if (HttpContext.Current.Session["ID"] == null)
            {
                HttpContext.Current.Session["isMenuCreated"] = null;
                filterContext.Result = new RedirectResult("~/LoginUser/Login");
                return;
            }
            //else if (new user() { U_Id = ((user)HttpContext.Current.Session["ID"]).U_Id }.Validate_Action(a, b))
            //{
                base.OnActionExecuting(filterContext);
            //}
            //else
            //{
            //    filterContext.Result = new RedirectResult("~/LoginUser/Login");
            //}
        }
    }

}