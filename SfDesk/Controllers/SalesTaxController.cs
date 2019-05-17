using SfDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SfDesk.Controllers
{
    public class SalesTaxController : Controller
    {
        // GET: SalesTax
        public ActionResult Index()
        {
            return View(new SalesTax().SalesTax_Get_All());
        }
        public ActionResult Add()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Add(SalesTax s)
        {
            s.SalesTax_Add();
            return View();
        }
        public ActionResult Edit(int id)
        {
            return PartialView("Edit", new SalesTax() { SalesTax_ID = id }.SalesTax_Get_By_ID());
        }
        [HttpPost]
        public ActionResult Edit(SalesTax c)
        {
            c.SalesTax_Update();
            return RedirectToAction("index");
        }
        public ActionResult Delete(int id)
        {
            new SalesTax() { SalesTax_ID = id }.SalesTax_Delete();
            return RedirectToAction("index");
        }
    }
}