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
        public ActionResult master(PO c)
        {
            try
            {
                if (PageAuth.URM_AuthenticatePage(Convert.ToInt32(Session["User_Id"]), "PO_Create"))
                {
                    c.Purchase_PO_Add(App.App_ID);
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
        public ActionResult Mm_Get_By_ID(int id)
        {
            return Json(new MiddleMan() { MM_ID = id }.MiddleMan_Get_By_ID(), JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public ActionResult Show_details(int PI_ID,int Item_ID)
        {
            return View(new PR_Details().Purchase_PR_Details_Get_By_PI(PI_ID, Item_ID,App.App_ID));
        }

    }
}

