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
        public ActionResult master(int? id)
        {

            if (id != null)
            {
                PurchaseInventory p = new PurchaseInventory() { PI_ID = id.Value, App_Status = "PO_Approve" };
                p = p.PO_Get_All().Find(x => x.PI_ID == id);
                return View(p == null ? new PurchaseInventory() : p);
            }
            return View(new PurchaseInventory()  );
        }
        [HttpPost]
        public ActionResult master(PurchaseInventory c)
        {
            int id = c.Purchase_Inventory_Add();
            return Json(id, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ShowAll()
        {
            return View(new PurchaseInventory() { App_Status = "PO_Approve" }.PR_Get_All());
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
        [HttpGet]
        public ActionResult Get_Taxes()
        {
            return Json(new SalesTax().SalesTax_Get_All(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Save_Charges(int PI_ID, SalesTax s)
        {
          //  p.PI_Charges_Add();
            return Json("");
        }
    }
}