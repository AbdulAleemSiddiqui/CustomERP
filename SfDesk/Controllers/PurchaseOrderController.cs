using SfDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace SfDesk.Controllers
{
    [Session]
    public class PurchaseOrderController : Controller
    {
        private const string Module = "Purchase";

        public ActionResult master()
        {
            try
            {
                PO po = (PO)TempData["PO"];
                po.PO_No = Utility.Get_New_No("PO", "PO_ID", "PO", App.App_ID);
                return View(po);
            }
            catch
            {
                return RedirectToAction("PO_Create");
            }
        }

        [HttpPost]
        public ActionResult master(PO c, List<PO_Details> pi, List<PO_Details> pie)
        {
            ////c.App_Status = "PO_Created";
            //if (c != old)

            //    if (c.details != null && c.details.Count > 0)
            //    {
            //        foreach (var item in c.details)
            //        {
            //            if (item.action == "I")
            //            {
            //                item.PO_ID = c.PO_ID;
            //                item.PO_Detail_Add();
            //            }
            //            else if (item.action == "U")
            //            {
            //                item.PO_Detail_Update();
            //            }
            //            else if (item.action == "D")
            //            {
            //                item.PO_Detail_Delete();
            //            }

            //        }
            //    }
            //if (c.taxes != null && c.taxes.Count > 0)
            //{
            //    foreach (var p in c.taxes)
            //    {
            //        p.PO_ID = c.PO_ID;
            //        if (p.action == "I")
            //        {
            //            p.PO_ID = c.PO_ID;
            //            p.PI_Charge_Add();
            //        }
            //        else if (p.action == "U")
            //        {
            //            p.PI_Charge_Update();
            //        }
            //        else if (p.action == "D")
            //        {
            //            p.PI_Charge_Delete();
            //        }


            //    }
            //}
            //if (c.transactions != null && c.transactions.Count > 0)
            //{
            //    foreach (var p in c.transactions)
            //    {
            //        p.PO_ID = c.PO_ID;
            //        if (p.action == "I")
            //        {
            //            p.PO_ID = c.PO_ID;
            //            p.PI_Transactions_Add();
            //        }
            //        else if (p.action == "U")
            //        {
            //            p.PI_Transactions_Update();
            //        }
            //        else if (p.action == "D")
            //        {
            //            p.PI_Transactions_Delete();
            //        }

            //    }
            //}

            //change krna hai 
            return Json(c.PO_ID, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PO_Create()
        {
            return View(new PO());
        }

        [HttpPost]
        public ActionResult PO_Create(PO c)
        {
            try
            {
                if (PageAuth.URM_AuthenticatePage(Convert.ToInt32(Session["User_Id"]), "PO_Create"))
                {
                    c.details = c.details.FindAll(x => x.is_Selected == true);
                    //Your API Call here:
                    TempData["PO"] = c;
                    Logger.Logging.DB_LogVisit(Convert.ToInt32(Session["User_Id"]), "PO_Create", Connection.GetLogConnection());

                    return RedirectToAction("Master", "PurchaseOrder");
                }
                else throw new Exception("Access Denied");
            }
            catch (Exception ex)
            {
                Logger.Logging.DB_Log(Logger.eLogType.Log_Negative, ex.Message, new { x = "" }, "", Module, Connection.GetLogConnection(), Convert.ToInt32(Session["User_Id"]));
                return null;// ex.Message;
            }
        }


        //[HttpPost]
        //public ActionResult PO_Create(PO c)
        //{
        //    TempData["PO"] = c;
        //    return RedirectToAction("Master", "PurchaseOrder");
        //}
        [HttpPost]
        public ActionResult Get_PO_Detail(List<Item_Category> Cat_ID)
        {
            //string [] ids =((object[])new JavaScriptSerializer().DeserializeObject(Cat_ID)).Cast<string>().ToArray();
            if (Cat_ID != null)
            {
                return Json(new PO_Details().Purchase_PO_Detail_Get_By_Cat(Cat_ID, 1), JsonRequestBehavior.AllowGet);
            }
            return Json("No item", JsonRequestBehavior.AllowGet);
        }
        public ActionResult showAll()
        {
            return View();//(new PO() { App_Status = "PR_Approve" }.PR_Get_All());
        }
        public ActionResult showAll_Created()
        {
            return View(new PO());// { App_Status = "PO_Created" }.PO_Get_All());
        }
        [HttpPost]
        public ActionResult Approve(PO c)
        {
            //  c.App_Status = "Un-Allocated";
            //  c.PR_Approve();
            //if (c.details != null && c.details.Count > 0)
            //{
            //    foreach (var item in c.details)
            //    {
            //        if (item.action == "I")
            //        {
            //            item.PO_ID = c.PO_ID;
            //            item.PO_Detail_Add();
            //        }
            //        else if (item.action == "U")
            //        {
            //            item.PO_Detail_Update();
            //        }
            //        else if (item.action == "D")
            //        {
            //            item.PO_Detail_Delete();
            //        }

            //    }
            //}
            //if (c.taxes != null && c.taxes.Count > 0)
            //{
            //    foreach (var p in c.taxes)
            //    {
            //        p.PO_ID = c.PO_ID;
            //        if (p.action == "I")
            //        {
            //            p.PO_ID = c.PO_ID;
            //            p.PI_Charge_Add();
            //        }
            //        else if (p.action == "U")
            //        {
            //            p.PI_Charge_Update();
            //        }
            //        else if (p.action == "D")
            //        {
            //            p.PI_Charge_Delete();
            //        }


            //    }
            //}
            //if (c.transactions != null && c.transactions.Count > 0)
            //{
            //    foreach (var p in c.transactions)
            //    {
            //        p.PO_ID = c.PO_ID;
            //        if (p.action == "I")
            //        {
            //            p.PO_ID = c.PO_ID;
            //            p.PI_Transactions_Add();
            //        }
            //        else if (p.action == "U")
            //        {
            //            p.PI_Transactions_Update();
            //        }
            //        else if (p.action == "D")
            //        {
            //            p.PI_Transactions_Delete();
            //        }

            //    }
            //}
            return Json("", JsonRequestBehavior.AllowGet);

        }
        public ActionResult detail()
        {
            return PartialView("detail", new List<PO>());
        }
        public ActionResult Index(int? PO_ID)
        {
            List<PO_Details> pd = new List<PO_Details>();


            return Json(pd, JsonRequestBehavior.AllowGet);
            //  return Json(new PO_Details() { PO_ID = PO_ID }.PO_Detail_Get_All(), JsonRequestBehavior.AllowGet);
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
        public ActionResult Get_taxes_by_ID(int PO_ID)
        {
            PI_Charge p = new PI_Charge();// { PO_ID = PO_ID };
            return Json(p.PI_Charge_Get_All(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Get_trans_by_ID(int PO_ID)
        {
            PI_Transactions p = new PI_Transactions();// { PO_ID = PO_ID };
            return Json(p.PI_Transactions_Get_All(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Get_Transasction()
        {
            List<Transaction> lst = new Transaction().Transaction_Get_All();

            lst.Remove(lst.Find(x => x.Name.ToLower() == "sales man"));
            //lst.Add(new Transaction() { Name = "Middle Man" });
            //lst.Add(new Transaction() { Name = "Transporter" });
            return Json(lst, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Save_Charges(int PO_ID, SalesTax s)
        {
            PI_Charge p = new PI_Charge();
            //  p.PO_ID = PO_ID;
            p.SalesTax_ID = s.SalesTax_ID;
            p.PI_Charge_Add();
            return Json("");
        }
        public ActionResult Save_Transaction(int PO_ID, PI_Transactions s)
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

