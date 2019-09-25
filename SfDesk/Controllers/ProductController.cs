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
            return View();
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