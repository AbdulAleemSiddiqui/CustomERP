using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SfDesk.Controllers
{
    public class VendorController : Controller
    {
        // GET: Vendor
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Vendor_Add()
        {
            ViewBag.ctype = new string[] { "Company", "Individual", "Partnership" };
            ViewBag.status = new string[] { "Filer", "Non-Filer" };
            ViewBag.tt = new string[] { "Cash" , "Acc. Receivable" , "Both" };
            return View();
        }
    }
}