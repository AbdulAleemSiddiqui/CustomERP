using SfDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SfDesk.Controllers
{
    [Session]
    public class SaleOrderController : Controller
    {
     
        public ActionResult master(int? id)
        {
            ViewBag.Customers = new Customer().Customer_Get_All(App.App_ID);
            ViewBag.SalesMan = new SalesMan().SalesMan_Get_All(App.App_ID);
            ViewBag.Currency = new Currency().Currency_Get_All(App.App_ID);
            ViewBag.Branch = new Branch().Branch_Get_All(App.App_ID);
            if (id == null)
            {
                return View(new SO() { SO_NO = Utility.Get_New_No("Sale_Order", "SO_ID", "SO", App.App_ID), Date = DateTime.Now });
            }
            else
            {
                SO s = new SO().Sale_SO_Get_Quotation(id.Value, App.App_ID);
                if(s!=null)
                { 
                s.SO_NO = Utility.Get_New_No("Sale_Order", "SO_ID", "SO", App.App_ID);
                s.Date = DateTime.Now ;
                    return View(s);

                }
                return View(new SO());

            }
        }

        [HttpPost]
        public ActionResult master(SO c)
        {
            if (c.SO_ID == 0)
            {
                c.Sale_SO_Add(App.App_ID);
            }
            else
            {
                c.Sale_SO_Approve(App.App_ID);
                if (c.SO_Details != null)
                {
                    new SO_Detail() { Data = c.SO_Details.FindAll(x => x.action == "I") }.Sale_SO_Detail_Add(App.App_ID);
                    new SO_Detail() { Data = c.SO_Details.FindAll(x => x.action == "U") }.Sale_SO_Detail_Update(App.App_ID);
                    new SO_Detail() { Data = c.SO_Details.FindAll(x => x.action == "D") }.Sale_SO_Detail_Delete(App.App_ID);
                }
                if(c.SO_Charges!=null)
                { 
                new SO_Charge() { Data = c.SO_Charges.FindAll(x => x.action == "I") }.Sale_SO_Charge_Add(App.App_ID);
                new SO_Charge() { Data = c.SO_Charges.FindAll(x => x.action == "D") }.Sale_SO_Charge_Delete(App.App_ID);
                    }
                if (c.SO_Taxs != null)
                {
                    new SO_Tax() { Data = c.SO_Taxs.FindAll(x => x.action == "I") }.Sale_SO_Tax_Add(App.App_ID);
                    new SO_Tax() { Data = c.SO_Taxs.FindAll(x => x.action == "D") }.Sale_SO_Tax_Delete(App.App_ID);
                }
            }
            return Json("",JsonRequestBehavior.AllowGet);
        }
        public ActionResult Approve(int id)
        {
            ViewBag.Customers = new Customer().Customer_Get_All(App.App_ID);
            ViewBag.SalesMan = new SalesMan().SalesMan_Get_All(App.App_ID);
            ViewBag.Currency = new Currency().Currency_Get_All(App.App_ID);
            ViewBag.Branch = new Branch().Branch_Get_All(App.App_ID);
            return View(new SO().Sale_SO_Get_By_Id(id, App.App_ID));
        }
        public ActionResult ShowAll()
        {
            return View(new Quotation().Sale_Quotation_Get_All_Approve(App.App_ID));
        }
        public ActionResult detail()
        {
            return PartialView("detail", new List<SO_Detail>());
        }
        // GET: SO
        public ActionResult Index(int id)
        {
            List<SO_Detail> pd = new SO_Detail().Sale_SO_Detail_Get_By_SO(id, App.App_ID);


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
        public ActionResult Get_Taxes_By_SO(int id)
        {
            return Json(new SO_Tax().Sale_SO_Tax_Get_By_SO(id, App.App_ID), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Get_Transasction_By_SO(int id)
        {
            List<SO_Charge> lst = new SO_Charge().Sale_SO_Charge_Get_By_SO(id, App.App_ID);
            //lst.Add(new Transaction() { Name = "Middle Man" });
            //lst.Add(new Transaction() { Name = "Transporter" });


            return Json(lst, JsonRequestBehavior.AllowGet);
        }

    }
}