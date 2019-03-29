using SfDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SfDesk.Controllers
{
    public class MaterialController : Controller
    {
        public ActionResult Index()
        {
            return View(new Material().Material_Get_All());
        }
        [HttpGet]
        public ActionResult Add()
        {
            return PartialView("add");
        }
        [HttpPost]
        public ActionResult Add(Material c)
        {
            c.Material_Add();
            return RedirectToAction("index");
        }
        public ActionResult Edit(int id)
        {
            return PartialView("Edit", new Material() { M_ID = id }.Material_Get_By_ID());
        }
        [HttpPost]
        public ActionResult Edit(Material c)
        {
            c.Material_Update();
            return RedirectToAction("index");
        }
        public ActionResult Delete(int id)
        {
            new Material() { M_ID = id }.Material_Delete();
            return RedirectToAction("index");
        }
    }
}