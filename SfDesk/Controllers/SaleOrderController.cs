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
       private SO old;
        public ActionResult master(int? id)
        {
            //if (id != null)
            //{
            //    SO p = new SO() { SO_ID = id.Value, App_Status = "SO_Created" };
            //    p = p.SO_Get_All().Find(x => x.SO_ID == id);
            //    return View(p);
            //}
            ViewBag.Customers = new Customer().Customer_Get_All(App.App_ID);
            ViewBag.SalesMan = new SalesMan().SalesMan_Get_All(App.App_ID);
            return View(new SO());//{ SO_No = new SO().SO_Get_New_ID(),Date=DateTime.Now });
         }
          
        [HttpPost]
        public ActionResult master(SO c, List<SO_Detail> SO, List<SO_Detail> SOe)
        {
            //c.App_Status = "SO_Created";
            //if(c!=old)
            //   c.SO_ID= c.SO_Add();

            //if (c.details != null &&c.details.Count > 0)
            //{
            //    foreach (var item in c.details)
            //    {
            //        if (item.action == "I")
            //        {
            //            item.SO_ID = c.SO_ID;
            //            item.SO_Detail_Add();
            //        }
            //        else if (item.action == "U")
            //        {
            //            item.SO_Detail_Update();
            //        }
            //        else if (item.action == "D")
            //        {
            //            item.SO_Detail_Delete();
            //        }

            //    }
            //}
            //if (c.taxes != null && c.taxes.Count > 0)
            //{
            //    foreach (var p in c.taxes)
            //    {
            //        p.SO_ID = c.SO_ID;
            //        if (p.action == "I")
            //        {
            //            p.SO_ID = c.SO_ID;
            //            p.SO_Charges_Add();
            //        }
            //        else if (p.action == "U")
            //        {
            //            p.SO_Charges_Update();
            //        }
            //        else if (p.action == "D")
            //        {
            //            p.SO_Charges_Delete();
            //        }


            //    }
            //}
            //if (c.transactions != null && c.transactions.Count > 0)
            //{
            //    foreach (var p in c.transactions)
            //    {
            //        p.SO_ID = c.SO_ID;
            //        if (p.action == "I")
            //        {
            //            p.SO_ID = c.SO_ID;
            //            p.SO_Transactions_Add();
            //        }
            //        else if (p.action == "U")
            //        {
            //            p.SO_Transactions_Update();
            //        }
            //        else if (p.action == "D")
            //        {
            //            p.SO_Transactions_Delete();
            //        }

            //    }
            //}

            ////change krna hai 
            return Json("");//c.SO_ID, JsonRequestBehavior.AllowGet);
        }
         

        public ActionResult SO_Approved(int id)
        {
            //if (id != 0)
            //{
            //    SO p = new SO() { SO_ID = id, App_Status = "SO_Created" };
            //    p = p.SO_Get_All().Find(x => x.SO_ID == id);
            //    return View(p);
            //}
            return View(new SO());//{ SO_No = new SO().SO_Get_New_ID(), Date = DateTime.Now });
        }

        public ActionResult showAll()
        {
            return View(new SO());//s { App_Status = "SO_Created" }.SO_Get_All());
        }
  
        [HttpPost]
        public ActionResult Approve(SO c)
        {
            //c.App_Status = "Un-Allocated";
            //c.SO_Approve();
            //if (c.details != null && c.details.Count > 0)
            //{
            //    foreach (var item in c.details)
            //    {
            //        if (item.action == "I")
            //        {
            //            item.SO_ID = c.SO_ID;
            //            item.SO_Detail_Add();
            //        }
            //        else if (item.action == "U")
            //        {
            //            item.SO_Detail_Update();
            //        }
            //        else if (item.action == "D")
            //        {
            //            item.SO_Detail_Delete();
            //        }

            //    }
            //}
            //if (c.taxes != null && c.taxes.Count > 0)
            //{
            //    foreach (var p in c.taxes)
            //    {
            //        p.SO_ID = c.SO_ID;
            //        if (p.action == "I")
            //        {
            //            p.SO_ID = c.SO_ID;
            //            p.SO_Charges_Add();
            //        }
            //        else if (p.action == "U")
            //        {
            //            p.SO_Charges_Update();
            //        }
            //        else if (p.action == "D")
            //        {
            //            p.SO_Charges_Delete();
            //        }


            //    }
            //}
            //if (c.transactions != null && c.transactions.Count > 0)
            //{
            //    foreach (var p in c.transactions)
            //    {
            //        p.SO_ID = c.SO_ID;
            //        if (p.action == "I")
            //        {
            //            p.SO_ID = c.SO_ID;
            //            p.SO_Transactions_Add();
            //        }
            //        else if (p.action == "U")
            //        {
            //            p.SO_Transactions_Update();
            //        }
            //        else if (p.action == "D")
            //        {
            //            p.SO_Transactions_Delete();
            //        }

            //    }
            //}
            return Json("", JsonRequestBehavior.AllowGet);

        }
        public ActionResult detail()
        {
            return PartialView("detail", new List<SO>());
        }
        public ActionResult Index(int SO_ID)
        {
            return Json(new SO_Detail());//{ SO_ID = SO_ID }.SO_Detail_Get_All(), JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
       
        public ActionResult Vehcile_Get_By_Transporter(int id)
        {
            return Json(new Vehicle() { T_ID = id }.Vehcile_Get_By_Transporter(), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Get_Taxes()
        {
            return Json(new SalesTax().SalesTax_Get_All(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Get_taxes_by_ID(int SO_ID)
        {
            return Json(new SO_Tax().Sale_SO_Tax_Get_By_SO(SO_ID,App.App_ID), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Get_trans_by_ID(int SO_ID)
        {
            return Json(new SO_Tax().Sale_SO_Tax_Get_By_SO(SO_ID,App.App_ID), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Get_Transasction()
        {
            List<Transaction> lst = new Transaction().Transaction_Get_All();
            //lst.Add(new Transaction() { Name = "Middle Man" });
            //lst.Add(new Transaction() { Name = "Transporter" });

            lst.Remove(lst.Find(x => x.Name.ToLower() == "middle man"));
            return Json(lst, JsonRequestBehavior.AllowGet);
        }

  
        [HttpGet]
        public ActionResult Sm_Get_By_ID(int id)
        {
            return Json(new SalesMan() { S_ID = id }.SalesMan_Get_By_ID(), JsonRequestBehavior.AllowGet);

        }
        public ActionResult Vehicle_Get_By_ID(int id)
        {
            return Json(new Vehicle() { V_ID = id }.Vehcile_Get_By_ID(), JsonRequestBehavior.AllowGet);

        }

    }
}