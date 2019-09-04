using SfDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SfDesk.Controllers
{
    public class GDNController : Controller
    {
        // GET: GDN
        public ActionResult Master(int? id)
        {
            if (id == null)
            {
                return View();
            }
            return View(new GDN() { SO_ID = (int)id });
        }
        [HttpPost]
        public ActionResult Master(GDN GDN)
        {
            GDN.GDN_Add();
            return View();
        }
        public ActionResult Detail()
        {
            return PartialView("Detail", new List<GDN>());

        }
        public ActionResult Detail2()
        {
            return PartialView("Detail2", new List<GDN>());

        }
        public ActionResult Get_Taxes()
        {
            return Json(new SalesTax().SalesTax_Get_All(), JsonRequestBehavior.AllowGet);
        }  // GET: GDN
        public ActionResult Index()
        {
            return View();
        }
    }
}