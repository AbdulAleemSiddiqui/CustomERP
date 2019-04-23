using SfDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SfDesk.Controllers
{
    public class PurchaseRequisitionController : Controller
    {
        public ActionResult master()
        {
            return View(new PurchaseInventory()  );
        }
        [HttpPost]
        public ActionResult master(PurchaseInventory c)
        {
            try
            {
             
                int id =c.Purchase_Inventory_Add();
                return Json(id, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                string a =ex.Message;
                return Json("Error Occure", JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult showAll()
        {
            //new PurchaseInventory().PR_Show_All();
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
        public ActionResult Save_Charges(PurchaseInventory p)
        {
            p.PI_Charges_Add();
            return Json("");
        }
    }
}