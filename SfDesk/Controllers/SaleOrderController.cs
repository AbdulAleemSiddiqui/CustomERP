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
       private SaleOrder old;
        public ActionResult master()
        {
            return View(new SaleOrder() { SO_No = new SaleOrder().SO_Get_New_ID(),Date=DateTime.Now });
         }
          
        [HttpPost]
        public ActionResult master(SaleOrder c, List<SO_Details> SO, List<SO_Details> SOe)
        {
            c.App_Status = "SO_Created";
            if(c!=old)
               c.SO_ID= c.SO_Add();
            
            if (c.details != null &&c.details.Count > 0)
            {
                foreach (var item in c.details)
                {
                    if (item.action == "I")
                    {
                        item.SO_ID = c.SO_ID;
                        item.SO_Detail_Add();
                    }
                    else if (item.action == "U")
                    {
                        item.SO_Detail_Update();
                    }
                    else if (item.action == "D")
                    {
                        item.SO_Detail_Delete();
                    }

                }
            }
            if (c.taxes != null && c.taxes.Count > 0)
            {
                foreach (var p in c.taxes)
                {
                    p.SO_ID = c.SO_ID;
                    if (p.action == "I")
                    {
                        p.SO_ID = c.SO_ID;
                        p.SO_Charges_Add();
                    }
                    else if (p.action == "U")
                    {
                        p.SO_Charges_Update();
                    }
                    else if (p.action == "D")
                    {
                        p.SO_Charges_Delete();
                    }
                    

                }
            }
            if (c.transactions != null && c.transactions.Count > 0)
            {
                foreach (var p in c.transactions)
                {
                    p.SO_ID = c.SO_ID;
                    if (p.action == "I")
                    {
                        p.SO_ID = c.SO_ID;
                        p.SO_Transactions_Add();
                    }
                    else if (p.action == "U")
                    {
                        p.SO_Transactions_Update();
                    }
                    else if (p.action == "D")
                    {
                        p.SO_Transactions_Delete();
                    }

                }
            }

            //change krna hai 
            return Json(c.SO_ID, JsonRequestBehavior.AllowGet);
        }
         

      

        public ActionResult showAll()
        {
            return View(new SaleOrder() { App_Status = "SO_Created" }.SO_Get_All());
        }
  
        [HttpPost]
        public ActionResult Approve(SaleOrder c)
        {
            c.App_Status = "Un-Allocated";
            c.SO_Approve();
            if (c.details != null && c.details.Count > 0)
            {
                foreach (var item in c.details)
                {
                    if (item.action == "I")
                    {
                        item.SO_ID = c.SO_ID;
                        item.SO_Detail_Add();
                    }
                    else if (item.action == "U")
                    {
                        item.SO_Detail_Update();
                    }
                    else if (item.action == "D")
                    {
                        item.SO_Detail_Delete();
                    }

                }
            }
            if (c.taxes != null && c.taxes.Count > 0)
            {
                foreach (var p in c.taxes)
                {
                    p.SO_ID = c.SO_ID;
                    if (p.action == "I")
                    {
                        p.SO_ID = c.SO_ID;
                        p.SO_Charges_Add();
                    }
                    else if (p.action == "U")
                    {
                        p.SO_Charges_Update();
                    }
                    else if (p.action == "D")
                    {
                        p.SO_Charges_Delete();
                    }


                }
            }
            if (c.transactions != null && c.transactions.Count > 0)
            {
                foreach (var p in c.transactions)
                {
                    p.SO_ID = c.SO_ID;
                    if (p.action == "I")
                    {
                        p.SO_ID = c.SO_ID;
                        p.SO_Transactions_Add();
                    }
                    else if (p.action == "U")
                    {
                        p.SO_Transactions_Update();
                    }
                    else if (p.action == "D")
                    {
                        p.SO_Transactions_Delete();
                    }

                }
            }
            return Json("", JsonRequestBehavior.AllowGet);

        }
        public ActionResult detail()
        {
            return PartialView("detail", new List<SaleOrder>());
        }
        public ActionResult Index(int SO_ID)
        {
            return Json(new SO_Details() { SO_ID = SO_ID }.SO_Detail_Get_All(), JsonRequestBehavior.AllowGet);
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
            SO_Charges p = new SO_Charges() { SO_ID = SO_ID };
            return Json(p.SO_Charges_Get_All(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Get_trans_by_ID(int SO_ID)
        {
            SO_Transactions p = new SO_Transactions() { SO_ID = SO_ID };
            return Json(p.SO_Transactions_Get_All(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Get_Transasction()
        {
            List<Transaction> lst = new Transaction().Transaction_Get_All();
            //lst.Add(new Transaction() { Name = "Middle Man" });
            //lst.Add(new Transaction() { Name = "Transporter" });

            lst.Remove(lst.Find(x => x.Name.ToLower() == "middle man"));
            return Json(lst, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Save_Charges(int SO_ID, SalesTax s)
        {
            SO_Charges p = new SO_Charges();
            p.SO_ID = SO_ID;
            p.SalesTax_ID = s.SalesTax_ID;
            p.SO_Charges_Add();
            return Json("");
        }
        public ActionResult Save_Transaction(int SO_ID, SO_Transactions s)
        {
            s.is_MiddleMan = s.Name.ToLower() == "Sales man";
            s.is_Transporter = s.Name.ToLower() == "transporter";

            s.SO_Transactions_Add();
            return Json("");
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
        public ActionResult Delete_Charges(SO_Charges s)
        {
            s.SO_Charges_Delete();
            return Json("");
        }
        public ActionResult Delete_Transaction(SO_Transactions s)
        {
            s.SO_Transactions_Delete();
            return Json("");
        }

    }
}