using SfDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SfDesk.Controllers
{
    public class GRNController : Controller
    {
        // GET: GRN
        public ActionResult Master(int? id)
        {
            if(id==null)
            {
                return View();
            }
            return View(new GRN() { PI_ID = (int)id });
        }
        [HttpPost]
        public ActionResult Master(GRN grn)
        {
            grn.GRN_Add();
            return View();
        }
        public ActionResult Detail()
        {
            return PartialView("Detail", new List<GRN>());

        }
        public ActionResult Detail2()
        {
            return PartialView("Detail2", new List<GRN>());

        }
        public ActionResult Get_Taxes()
        {
            return Json(new SalesTax().SalesTax_Get_All(), JsonRequestBehavior.AllowGet);
        }
    }
}