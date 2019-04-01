using SfDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SfDesk.Controllers
{
    public class ContractorController : Controller
    {
        public ActionResult Index()
        {
            return View(new Contractor().Contractor_Get_All());
        }
        [HttpGet]
        public ActionResult Add()
        {
            return PartialView("add");
        }
        [HttpPost]
        public ActionResult Add(Contractor c)
        {
            c.Contractor_Add();
            return RedirectToAction("index");
        }
        public ActionResult Edit(int id)
        {
            return PartialView("Edit", new Contractor() { C_ID = id }.Contractor_Get_By_ID());
        }
        [HttpPost]
        public ActionResult Edit(Contractor c)
        {
            c.Contractor_Update();
            return RedirectToAction("index");
        }
        public ActionResult Delete(int id)
        {
            new Contractor() { C_ID = id }.Contractor_Delete();
            return RedirectToAction("index");
        }

    }
}