using SfDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SfDesk.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Customer_Add()
        {
            ViewBag.ctype = new string[] { "Company", "Individual", "Partnership" };
            ViewBag.status = new string[] { "Filer", "Non-Filer" };
            ViewBag.tt = new string[] { "Cash", "Acc. Receivable", "Both" }; ;
            return View();
        }
    }
}