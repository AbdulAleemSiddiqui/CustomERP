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
            return View(new Quotation() { Date = DateTime.Now,Q_NO = Utility.Get_New_No("Quotation", "Q_ID", "Q", App.App_ID) });
        }
        [HttpPost]
        public ActionResult master(Quotation c)
        {
            if (c.Q_ID == 0)
            {
                c.Sale_Quotation_Add(App.App_ID);
            }
            else
            {
                c.Sale_Quotation_Approve(App.App_ID);
            }
            return RedirectToAction("Show_all");
        }
        public ActionResult Approve(int id)
        {
            ViewBag.Customers = new Customer().Customer_Get_All(App.App_ID);
            ViewBag.SalesMan = new SalesMan().SalesMan_Get_All(App.App_ID);
            ViewBag.Currency = new Currency().Currency_Get_All(App.App_ID);
            ViewBag.Branch = new Branch().Branch_Get_All(App.App_ID);
            return View(new Quotation().Sale_Quotation_Get_By_Id(id,App.App_ID));
        }
        public ActionResult detail()
        {
            return PartialView("detail", new List<Q_Detail>());
        }
        public ActionResult ShowAll()
        {
            return View(new Quotation().Sale_Quotation_Get_All(App.App_ID));
        }
        // GET: Quotation
        public ActionResult Index(int id)
        {
            List<Q_Detail> pd = new Q_Detail().Sale_Q_Detail_Get_By_Q(id,App.App_ID);
           

            return Json(pd, JsonRequestBehavior.AllowGet);
            //  return Json(new PO_Details() { PO_ID = PO_ID }.PO_Detail_Get_All(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Get_All_Taxes()
        {
            return Json(new SalesTax().SalesTax_Get_All(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Get_All_Transasction()
        {
            List<Transaction> lst = new Transaction().Transaction_Get_All();
            //lst.Add(new Transaction() { Name = "Middle Man" });
            //lst.Add(new Transaction() { Name = "Transporter" });

            lst.Remove(lst.Find(x => x.Name.ToLower() == "sales man"));
            return Json(lst, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Get_Taxes_by_Q(int id)
        {
            return Json(new Q_Tax().Sale_Q_Tax_Get_By_Q(id,App.App_ID), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Get_Transasction_by_Q(int id)
        {
            List<Q_Charge> lst = new Q_Charge().Sale_Q_Charge_Get_By_Q(id,App.App_ID);
            //lst.Add(new Transaction() { Name = "Middle Man" });
            //lst.Add(new Transaction() { Name = "Transporter" });

           
            return Json(lst, JsonRequestBehavior.AllowGet);
        }

    }
}