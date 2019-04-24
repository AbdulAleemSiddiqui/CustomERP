using SfDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SfDesk.Controllers
{
    public class PurchaseOrderController : Controller
    {
        public ActionResult master(int? id)
        {
            if (id != null)
            {
                PurchaseInventory p = new PurchaseInventory() { PI_ID = id.Value, App_Status = "PR_Approve" };
                p = p.PR_Get_All().Find(x => x.PI_ID == id);
                return View(p == null ? new PurchaseInventory() : p);
            }
            return View(new PurchaseInventory());
        }
        [HttpPost]
        public ActionResult master(PurchaseInventory c)
        {
            c.App_Status = "PO_Created";
            c.PO_Add();
            //change krna hai 
            return Json(c.PI_ID, JsonRequestBehavior.AllowGet);
        }
        public ActionResult showAll()
        {
            return View(new PurchaseInventory() { App_Status = "PR_Approve" }.PR_Get_All());
        }
        [HttpPost]
        public ActionResult Approve(PurchaseInventory p)
        {
            p.App_Status = "PO_Created";
            p.PR_Approve();
            return View();
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
            ViewBag.detail_id = pi.PI_Detail_Add();
            return Json("added sucessfully");
        }
        [HttpPost]
        public ActionResult update(PurchaseInventory pi)
        {
            pi.PI_Detail_Update();
            return Json("updated sucessfully");
        }
        [HttpGet]
        public ActionResult delete(int Detail_ID)
        {
            new PurchaseInventory() { Detail_ID = Detail_ID }.PI_Detail_Delete();
            return Json("delete sucessfully");
        }
        [HttpGet]
        public ActionResult Vehcile_Get_By_Transporter(int id)
        {
            return Json(new Vehicle() { T_ID = id }.Vehcile_Get_By_Transporter(), JsonRequestBehavior.AllowGet);
        }
    }
}