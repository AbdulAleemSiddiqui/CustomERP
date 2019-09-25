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
            ViewBag.Customers = new Customer().Customer_Get_All(App.App_ID);
            ViewBag.SalesMan = new SalesMan().SalesMan_Get_All(App.App_ID);
            ViewBag.Currency = new Currency().Currency_Get_All(App.App_ID);
            ViewBag.Branch = new Branch().Branch_Get_All(App.App_ID);
            return View(new Quotation() { Date = DateTime.Now });
        }
        [HttpPost]
        public ActionResult master(Quotation c)
        {
            return View();
        }
        public ActionResult detail()
        {
            return PartialView("detail", new List<Q_Detail>());
        }
        // GET: Quotation
        public ActionResult Index(int? Q_ID)
        {
            List<Q_Detail> pd = new List<Q_Detail>();
           

            return Json(pd, JsonRequestBehavior.AllowGet);
            //  return Json(new PO_Details() { PO_ID = PO_ID }.PO_Detail_Get_All(), JsonRequestBehavior.AllowGet);
        }

    }
}