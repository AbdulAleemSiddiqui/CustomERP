using SfDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SfDesk.Controllers
{
    public class QuotationController : Controller
    {
        public ActionResult master()
        {
            
            return View(new Quotation());
        }
        public ActionResult detail()
        {
            return PartialView("detail", new List<Quotation_Detail>());
        }
        // GET: Quotation
        public ActionResult Index(int? Q_ID)
        {
            List<Quotation_Detail> pd = new List<Quotation_Detail>();
           

            return Json(pd, JsonRequestBehavior.AllowGet);
            //  return Json(new PO_Details() { PO_ID = PO_ID }.PO_Detail_Get_All(), JsonRequestBehavior.AllowGet);
        }

    }
}