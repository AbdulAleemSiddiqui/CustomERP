using SfDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SfDesk.Controllers
{
    [Session]
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
            return PartialView("Edit", new Contractor() { ID = id }.Contractor_Get_By_ID());
        }
        [HttpPost]
        public ActionResult Edit(Contractor c)
        {
            c.Contractor_Update();
            return RedirectToAction("index");
        }
        public ActionResult Delete(int id)
        {
            new Contractor() { ID = id }.Contractor_Delete();
            return RedirectToAction("index");
        }
     
        public ActionResult Contractor_GET_ALL()
        {
            List<Contractor> ls = new Contractor().Contractor_Get_All();
          
            return Json(ls, JsonRequestBehavior.AllowGet);

        }
    }
}