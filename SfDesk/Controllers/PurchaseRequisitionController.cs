using SfDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SfDesk.Controllers
{
    [Session]
    public class PurchaseRequisitionController : Controller
    {
        private static PurchaseInventory old;
        private static List<PI_Details> details =new List<PI_Details>();

        public ActionResult master(int? id)
         {
            if (id != null)
            {
                PurchaseInventory p = new PurchaseInventory() { PI_ID = id.Value ,App_Status="I"};
                p = p.PR_Get_All().Find(x => x.PI_ID == id);
                if(p!=null)
                {
                    old = p;
                    return View(p);
                }
            }
            return View(new PurchaseInventory() {PR_No=new PurchaseInventory().PR_Get_New_PR_NO() });
        }
        [HttpPost]
        public ActionResult master(PurchaseInventory c)
            {
            // try
            //{
            int id = c.PI_ID;
            if (c.PI_ID == 0)
                id = c.Purchase_Inventory_Add();




            //if (pi != null)
            //    foreach (var item in c.details)
            //    {
            //        item.PI_ID = id;
            //        item.PI_Detail_Add();
            //    }
            //if (pie != null)
            //    foreach (var item in pie)
            //    {

            //        item.PI_Detail_Update();
            //    }

            if (c.details != null && c.details.Count > 0)
            {
                foreach (var item in c.details)
                {
                    if (item.action == "I")
                    {
                        item.PI_ID = id;
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


            return Json(id, JsonRequestBehavior.AllowGet);
           // }
            //catch (Exception ex)
            //{
            //    string a = ex.Message;
            //    return Json("Error Occure", JsonRequestBehavior.AllowGet);
            //}
        }
        public ActionResult showAll()
        {
            return View(new PurchaseInventory() { App_Status = "I" }.PR_Get_All());
        }
        [HttpPost]
        public ActionResult Approve(PurchaseInventory p)
        {
           
            if (p.details != null && p.details.Count > 0)
            {
                foreach (var item in p.details)
                {
                    if (item.action == "I")
                    {
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
            p.App_Status = "PR_Approve";

            p.PR_Approve();
            return Json("kuch bhi", JsonRequestBehavior.AllowGet);

        }
        public ActionResult detail(int? id)
        {
            return PartialView("detail", new List<PurchaseInventory>());
        }
        public ActionResult Index(int PI_ID)
        {
            details = new PI_Details() { PI_ID = PI_ID }.PI_Detail_Get_All();
            return Json(details, JsonRequestBehavior.AllowGet);
        }

        #region Detail

  
        [HttpGet]
        public ActionResult Vehcile_Get_By_Transporter(int id)
        {
            return Json(new Vehicle() { T_ID = id }.Vehcile_Get_By_Transporter(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Save_Charges(PurchaseInventory p)
        {
            p.PI_Charges_Add();
            return Json("");
        }
        #endregion
    }
}