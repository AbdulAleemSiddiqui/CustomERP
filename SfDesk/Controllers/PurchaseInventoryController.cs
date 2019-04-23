using SfDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SfDesk.Controllers
{
    [Session]
    public class PurchaseInventoryController : Controller
    {
        // GET: PurchaseInventory
        public ActionResult master()
        {
            return View(new PurchaseInventory() { Invoice_No = "123" });
        }
        [HttpPost]
        public ActionResult master(PurchaseInventory c)
        {
            int id = c.Purchase_Inventory_Add();
            return Json(2,JsonRequestBehavior.AllowGet);
        }
    
        public ActionResult detail()
        {
            return PartialView("detail",new List<PurchaseInventory>());
        }
        public ActionResult Index(int PI_ID)
        {
            return Json(new PurchaseInventory() { PI_ID = PI_ID }.PI_Detail_Get_All(),JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult add(PurchaseInventory pi)
        {
            ViewBag.detail_id= pi.PI_Detail_Add();
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
        public ActionResult Save_Charges(PurchaseInventory p)
        {
            p.PI_Charges_Add();
            return Json("");
        }
    }
}