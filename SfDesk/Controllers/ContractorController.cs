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
        public ActionResult Contractor_GET_BY_Type(string m)
        {
            List<Contractor> ls = new List<Contractor>();
            ls.Add(new Contractor() { C_Name = "con1", C_ID = 1, C_Type = "Contractor", C_Unit = "kgs" }); ls.Add(new Contractor() { C_Name = "con2", C_ID = 2, C_Type = "Pakaging Contractor", C_Unit = "unit" }); ls.Add(new Contractor() { C_Name = "con3", C_ID = 3, C_Type = "Contractor", C_Unit = "kgs" });

            ls = ls.FindAll(x => x.C_Type == m);
            return Json(ls, JsonRequestBehavior.AllowGet);

        }
        public ActionResult Contractor_GET_ALL()
        {
            List<Contractor> ls = new List<Contractor>();
            ls.Add(new Contractor() { C_Name = "con1", C_ID = 1, C_Type = "Contractor", C_Unit = "kgs" }); ls.Add(new Contractor() { C_Name = "con2", C_ID = 2, C_Type = "Contractor", C_Unit = "unit" }); ls.Add(new Contractor() { C_Name = "con3", C_ID = 3, C_Type = "Contractor", C_Unit = "kgs" });

            return Json(ls, JsonRequestBehavior.AllowGet);

        }
    }
}