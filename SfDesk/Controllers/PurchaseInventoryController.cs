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
        public ActionResult master(PurchaseInventory ps)
        {
            return Json("");
        }
        public ActionResult detail()
        {
            List<PurchaseInventory> ls = new List<PurchaseInventory>();
            ls.Add(new PurchaseInventory() { Store = "asdas", Item_Code = 1111, Product_Name = "mouse", Product_Description = "this is my mousee", Purchase_Quantitiy = 100, Received_Quantitiy = 99, Commision = 99, Rate = 99.0m, Gross_Amount = 00, Discount = 9.9m, Discount_Amount = 99999.999m, Net_Amount = 9098 });
            ls.Add(new PurchaseInventory() { Store = "asdas", Item_Code = 1111, Product_Name = "mouse", Product_Description = "this is my mousee", Purchase_Quantitiy = 100, Received_Quantitiy = 99, Commision = 99, Rate = 99.0m, Gross_Amount = 00, Discount = 9.9m, Discount_Amount = 99999.999m, Net_Amount = 9098 });
            ls.Add(new PurchaseInventory() { Store = "asdas", Item_Code = 1111, Product_Name = "mouse", Product_Description = "this is my mousee", Purchase_Quantitiy = 100, Received_Quantitiy = 99, Commision = 99, Rate = 99.0m, Gross_Amount = 00, Discount = 9.9m, Discount_Amount = 99999.999m, Net_Amount = 9098 });
            return PartialView("detail", ls);
        }
        [HttpPost]
        public JsonResult add(PurchaseInventory pi)
        {
            return Json("added sucessfully");
        }
        [HttpPost]
        public ActionResult update()
        {
            return View();
        }
        [HttpGet]
        public ActionResult delete(int id )
        {
            return View();
        }
        [HttpGet]
        public ActionResult Vehcile_Get_By_Transporter(int id)
        {
            return Json(new Vehicle() { T_ID = id }.Vehcile_Get_By_Transporter(),JsonRequestBehavior.AllowGet);
        }
    }
}