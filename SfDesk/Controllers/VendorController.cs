using SfDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SfDesk.Controllers
{
    public class VendorController : Controller
    {
        // GET: Vendor
        public ActionResult Index()
        {
            return View(new Vendor().Vendor_Get_All());
        }
        public ActionResult Add()
        {
            ViewBag.ctype = new string[] { "Company", "Individual", "Partnership" };
            ViewBag.status = new string[] { "Filer", "Non-Filer" };
            ViewBag.tt = new string[] { "Cash" , "Acc. Receivable" , "Both" };
            return View();
        }
        [HttpPost]
        public ActionResult Add(Vendor c)
        {
            c.Vendor_Add();
            return RedirectToAction("index");
        }
        public ActionResult Edit(int id)
        {
            ViewBag.ctype = new string[] { "Company", "Individual", "Partnership" };
            ViewBag.status = new string[] { "Filer", "Non-Filer" };
            ViewBag.tt = new string[] { "Cash", "Acc. Receivable", "Both" }; ;
            return View(new Vendor().Vendor_Get_BY_ID(id));
        }
        [HttpPost]
        public ActionResult Edit(Vendor c)
        {
            c.Vendor_Update();
            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Vendor u = new Vendor() { Vendor_ID = id };
            u.Vendor_Delete();   ///Deleting existing company (updating state to 0 in database)
            return RedirectToAction("Index");
        }
        public ActionResult Detail(int id)
        {
            return PartialView("Detail", new Vendor().Vendor_Get_BY_ID(id));
        }
    }
}
