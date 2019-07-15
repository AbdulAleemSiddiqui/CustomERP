using SfDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SfDesk.Controllers
{
    [Session]
    public class PurchaseOrderController : Controller
    {
        private PurchaseInventory old;
        public ActionResult master(int? id)
        {
            if (id != null)
            {
                PurchaseInventory p = new PurchaseInventory() { PI_ID = id.Value, App_Status = "PR_Approve" };
                p = p.PR_Get_All().Find(x => x.PI_ID == id);
                
                if(p==null)
                {
                    
                    p = new PurchaseInventory() { PI_ID = id.Value, App_Status = "PO_Created" };
                    p = p.PO_Get_All().Find(x => x.PI_ID == id);
                    ViewBag.vehicle = new Vehicle() { V_ID = p.Vehicle_ID, Vehicle_No = p.Vehicle_No };
                }
                old = p;
                return View(p == null ? new PurchaseInventory() : p);
            }
            return View(new PurchaseInventory());
        }
        [HttpPost]
        public ActionResult master(PurchaseInventory c, List<PI_Details> pi, List<PI_Details> pie)
        {
            c.App_Status = "PO_Created";
            if(c!=old)
                c.PO_Add();
            //if (pi != null)
            //    foreach (var item in c.details)
            //    {
            //        item.PI_ID = c.PI_ID;
            //        item.PI_Detail_Add();
            //    }
            //if (pie != null)
            //    foreach (var item in pie)
            //    {

            //        item.PI_Detail_Update();
            //    }

            if (c.details != null &&c.details.Count > 0)
            {
                foreach (var item in c.details)
                {
                    if (item.action == "I")
                    {
                        item.PI_ID = c.PI_ID;
                        item.PI_Detail_Add();
                    }
                    else if (item.action == "U")
                    {
                        item.PI_Detail_Update();
                    }
                    else if (item.action == "D")
                    {
                        item.PI_Detail_Delete();
                    }

                }
            }
            if (c.taxes != null && c.taxes.Count > 0)
            {
                foreach (var p in c.taxes)
                {
                    p.PI_ID = c.PI_ID;
                    if (p.action == "I")
                    {
                        p.PI_ID = c.PI_ID;
                        p.PI_Charge_Add();
                    }
                    else if (p.action == "U")
                    {
                        p.PI_Charge_Update();
                    }
                    else if (p.action == "D")
                    {
                        p.PI_Charge_Delete();
                    }
                    

                }
            }
            if (c.transactions != null && c.transactions.Count > 0)
            {
                foreach (var p in c.transactions)
                {
                    p.PI_ID = c.PI_ID;
                    if (p.action == "I")
                    {
                        p.PI_ID = c.PI_ID;
                        p.PI_Transactions_Add();
                    }
                    else if (p.action == "U")
                    {
                        p.PI_Transactions_Update();
                    }
                    else if (p.action == "D")
                    {
                        p.PI_Transactions_Delete();
                    }

                }
            }

            //change krna hai 
            return Json(c.PI_ID, JsonRequestBehavior.AllowGet);
        }
        public ActionResult showAll()
        {
            return View(new PurchaseInventory() { App_Status = "PR_Approve" }.PR_Get_All());
        }
        public ActionResult showAll_Created()
        {
            return View(new PurchaseInventory() { App_Status = "PO_Created" }.PO_Get_All());
        }
        [HttpPost]
        public ActionResult Approve(PurchaseInventory c)
        {
            c.App_Status = "Un-Allocated";
            c.PR_Approve();
            if (c.details != null && c.details.Count > 0)
            {
                foreach (var item in c.details)
                {
                    if (item.action == "I")
                    {
                        item.PI_ID = c.PI_ID;
                        item.PI_Detail_Add();
                    }
                    else if (item.action == "U")
                    {
                        item.PI_Detail_Update();
                    }
                    else if (item.action == "D")
                    {
                        item.PI_Detail_Delete();
                    }

                }
            }
            if (c.taxes != null && c.taxes.Count > 0)
            {
                foreach (var p in c.taxes)
                {
                    p.PI_ID = c.PI_ID;
                    if (p.action == "I")
                    {
                        p.PI_ID = c.PI_ID;
                        p.PI_Charge_Add();
                    }
                    else if (p.action == "U")
                    {
                        p.PI_Charge_Update();
                    }
                    else if (p.action == "D")
                    {
                        p.PI_Charge_Delete();
                    }


                }
            }
            if (c.transactions != null && c.transactions.Count > 0)
            {
                foreach (var p in c.transactions)
                {
                    p.PI_ID = c.PI_ID;
                    if (p.action == "I")
                    {
                        p.PI_ID = c.PI_ID;
                        p.PI_Transactions_Add();
                    }
                    else if (p.action == "U")
                    {
                        p.PI_Transactions_Update();
                    }
                    else if (p.action == "D")
                    {
                        p.PI_Transactions_Delete();
                    }

                }
            }
            return Json("", JsonRequestBehavior.AllowGet);

        }
        public ActionResult detail()
        {
            return PartialView("detail", new List<PurchaseInventory>());
        }
        public ActionResult Index(int PI_ID)
        {
            return Json(new PurchaseInventory() { PI_ID = PI_ID }.PI_Detail_Get_All(), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult add(PurchaseInventory pi)
        {
           // ViewBag.detail_id = pi.PI_Detail_Add();
            return Json("added sucessfully");
        }
        [HttpPost]
        public ActionResult update(PurchaseInventory pi)
        {
         //   pi.Store = pi.Store == null ? "" : pi.Store;
            pi.PI_Detail_Update();
            return Json("updated sucessfully");
        }
        [HttpGet]
        public ActionResult delete(int Detail_ID)
        {
          //  new PurchaseInventory() { Detail_ID = Detail_ID }.PI_Detail_Delete();
            return Json("delete sucessfully");
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
        public ActionResult Get_taxes_by_ID(int PI_ID)
        {
            PI_Charge p = new PI_Charge() { PI_ID = PI_ID };
            return Json(p.PI_Charge_Get_All(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Get_trans_by_ID(int PI_ID)
        {
            PI_Transactions p = new PI_Transactions() { PI_ID = PI_ID };
            return Json(p.PI_Transactions_Get_All(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Get_Transasction()
        {
            List<Transaction> lst = new Transaction().Transaction_Get_All();
            //lst.Add(new Transaction() { Name = "Middle Man" });
            //lst.Add(new Transaction() { Name = "Transporter" });
            return Json(lst, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Save_Charges(int PI_ID, SalesTax s)
        {
            PI_Charge p = new PI_Charge();
            p.PI_ID = PI_ID;
            p.SalesTax_ID = s.SalesTax_ID;
            p.PI_Charge_Add();
            return Json("");
        }
        public ActionResult Save_Transaction(int PI_ID, PI_Transactions s)
        {
            s.is_MiddleMan = s.Name.ToLower() == "middle man";
            s.is_Transporter = s.Name.ToLower() == "transporter";

            s.PI_Transactions_Add();
            return Json("");
        }
        [HttpGet]
        public ActionResult Mm_Get_By_ID(int id)
        {
            return Json(new MiddleMan() { MM_ID = id }.MiddleMan_Get_By_ID(), JsonRequestBehavior.AllowGet);

        }
        public ActionResult Vehicle_Get_By_ID(int id)
        {
            return Json(new Vehicle() { V_ID = id }.Vehcile_Get_By_ID(), JsonRequestBehavior.AllowGet);

        }
        public ActionResult Delete_Charges(PI_Charge s)
        {
            s.PI_Charge_Delete();
            return Json("");
        }
        public ActionResult Delete_Transaction(PI_Transactions s)
        {
            s.PI_Transactions_Delete();
            return Json("");
        }
    }
}