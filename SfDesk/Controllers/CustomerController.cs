using SfDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SfDesk.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View(new Customer().Customer_Get_All());
        }
        public ActionResult Add()
        {
            ViewBag.ctype = new string[] { "Company", "Individual", "Partnership" };
            ViewBag.status = new string[] { "Filer", "Non-Filer" };
            ViewBag.tt = new string[] { "Cash", "Acc. Receivable", "Both" }; ;
            return View();
        }
        [HttpPost]
        public ActionResult Add(Customer c)
        {
            c.Customer_Add();
            return RedirectToAction("index");
        }
        public ActionResult Edit(int id )
        {
            ViewBag.ctype = new string[] { "Company", "Individual", "Partnership" };
            ViewBag.status = new string[] { "Filer", "Non-Filer" };
            ViewBag.tt = new string[] { "Cash", "Acc. Receivable", "Both" }; ;
            return View(new Customer().Customer_Get_BY_ID(id));
        }
        [HttpPost]
        public ActionResult Edit(Customer c)
        {
            c.Customer_Update();
            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Customer u = new Customer() { Customer_ID = id };
            u.Customer_Delete();   ///Deleting existing company (updating state to 0 in database)
            return RedirectToAction("Index");
        }
        public ActionResult Detail(int id)
        {
            return PartialView("Detail", new Customer().Customer_Get_BY_ID(id));
        }
    }
}