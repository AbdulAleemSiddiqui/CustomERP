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
        public ActionResult master()
        {
            return View();
        }
        [HttpPost]
        public ActionResult master(SaleOrder ps)
        {
            return Json("");
        }
        public ActionResult detail()
        {
            List<SaleOrder> ls = new List<SaleOrder>();
            ls.Add(new SaleOrder() { Store = "asdas", Item_Code = 1111, Product_Name = "mouse", Product_Description = "this is my mousee", Quantitiy = 100, Commision = 99, Rate = 99.0m, Amount = 00, Discount = 9.9m, Discount_Amount = 99999.999m, Net_Amount = 9098 });
            ls.Add(new SaleOrder() { Store = "asdas", Item_Code = 1111, Product_Name = "mouse", Product_Description = "this is my mousee", Quantitiy = 100, Commision = 99, Rate = 99.0m, Amount = 00, Discount = 9.9m, Discount_Amount = 99999.999m, Net_Amount = 9098 });
            ls.Add(new SaleOrder() { Store = "asdas", Item_Code = 1111, Product_Name = "mouse", Product_Description = "this is my mousee", Quantitiy = 100, Commision = 99, Rate = 99.0m, Amount = 00, Discount = 9.9m, Discount_Amount = 99999.999m, Net_Amount = 9098 });
            return PartialView("detail", ls);
        }
        [HttpPost]
        public JsonResult add(SaleOrder pi)
        {
            return Json("added sucessfully");
        }
        [HttpPost]
        public ActionResult update()
        {
            return View();
        }
        [HttpGet]
        public ActionResult delete(int id)
        {
            return View();
        }

    }
}