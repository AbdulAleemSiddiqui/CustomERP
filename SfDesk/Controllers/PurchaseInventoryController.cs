using SfDesk.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SfDesk.Controllers
{
    [Session]
    public class PurchaseInventoryController : Controller
    {

        // GET: PurchaseInventory
        public ActionResult master(int? id)
        {

            if (id != null)
            {
                PurchaseInventory p = new PurchaseInventory() { PI_ID = id.Value, App_Status = "Un-Allocated" };
                p = p.PO_Get_All().Find(x => x.PI_ID == id);
                return View(p == null ? new PurchaseInventory() : p);
            }
            return View(new PurchaseInventory());
        }
        [HttpPost]
        public ActionResult master(PurchaseInventory c)
        {
            if (c.PI_ID == 0)
            {
                c.PI_ID = c.PI_Add();
            }
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

            return Json(c.PI_ID, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SaveImage(HttpPostedFileBase file, int P_ID)
        {
            if (file != null)
            {
                var fileName = Path.GetFileName(file.FileName);
                fileName = "PI_" + fileName;
                var path = Path.Combine(Server.MapPath("~/Images/PI_Images"), fileName);
                file.SaveAs(path);

                PurchaseInventory c = new PurchaseInventory();
                c.PI_ID = P_ID;
                c.ImagePath = "~/Images/PI_Images/" + fileName;
                c.PI_SaveImage();
            }
            return View();
        }
        public ActionResult ShowAll()
        {
            return View(new Payment_Detail().Bill_Get_All());
        }
        public ActionResult detail()
        {
            return PartialView("detail", new List<PurchaseInventory>());
        }
        public ActionResult Index(int PI_ID)
        {
            return Json(new PI_Details() { PI_ID = PI_ID }.PI_Detail_Get_All(), JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult add(PurchaseInventory pi)
        {
            //  ViewBag.detail_id = pi.PI_Detail_Add();
            return Json("added sucessfully");
        }
        [HttpPost]
        public ActionResult update(PurchaseInventory pi)
        {
           // pi.PI_Detail_Update();
            return Json("updated sucessfully");
        }
        [HttpGet]
        public ActionResult delete(int Detail_ID)
        {
            //       new PurchaseInventory() { Detail_ID = Detail_ID }.PI_Detail_Delete();
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