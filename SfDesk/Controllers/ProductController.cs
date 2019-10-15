using SfDesk.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SfDesk.Models
{
    [Session]
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View(new Product().Product_Get_All());
        }
        [HttpGet]
        public ActionResult Add()
        {
            return PartialView("add");
        }
        [HttpGet]
        public ActionResult AddProduct()
        {
            ViewBag.Tax = new SalesTax().SalesTax_Get_All();
            ViewBag.Cat = new Item_Category().Item_Category_Get_All(App.App_ID);
            return View();
        }
        public ActionResult COA_Get_All()
        {
            return Json(new ChartOfAccount().COA_Get_All(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Product_Get_All()
        {
            return Json(new Item_Category().Item_Category_Get_All(App.App_ID),JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Add_Product_Assembly()
        {

            return PartialView("Add_Product_Assembly", new List<Product_Assembly>());

        }
        [HttpPost]
        public ActionResult Add(Product c)
        {
            c.Product_Add();
            return RedirectToAction("index");
        }
        public ActionResult Edit(int id)
        {
            return PartialView("Edit", new Product() { P_ID = id }.Product_Get_By_ID());
        }
        [HttpPost]
        public ActionResult Edit(Product c)
        {
            c.Product_Update();
            return RedirectToAction("index");
        }
        public ActionResult Delete(int id)
        {
            new Product() { P_ID = id }.Product_Delete();
            return RedirectToAction("index");
        }


    }
}