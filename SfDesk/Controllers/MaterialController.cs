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
        public ActionResult Material_GET_BY_Type(string m)
        {
            List<Material> ls = new List<Material>();
            ls.Add(new Material() { M_Name = "mat1", M_ID = 1 , M_Type = "Material", M_Unit="kgs" }); ls.Add(new Material() { M_Name = "mat2", M_ID = 2, M_Type = "Pakaging Material", M_Unit = "unit" }); ls.Add(new Material() { M_Name = "mat3", M_ID = 3,M_Type= "Material", M_Unit = "kgs" });
      
            ls = ls.FindAll(x => x.M_Type == m);
            return Json(ls, JsonRequestBehavior.AllowGet);

        }
        public ActionResult Material_GET_ALL()
        {
            List<Material> ls = new Material().Material_Get_All();
            return Json(ls, JsonRequestBehavior.AllowGet);

        }
    }
}