using SfDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SfDesk.Controllers
{
    public class SalesManController : Controller
    {
        // GET: SalesMan
        public ActionResult Add()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Add(SalesMan t)
        {

            t.S_ID = t.SalesMan_Add();
            return Json(t, JsonRequestBehavior.AllowGet);
        }



        public ActionResult Index()
        {
            return View(new SalesMan().SalesMan_Get_All());
        }
        public ActionResult Update(int id)
        {
            return PartialView("Update", new SalesMan() { S_ID = id }.SalesMan_Get_By_ID());

        }
        [HttpPost]
        public ActionResult Update(SalesMan c)
        {
            c.SalesMan_Update();
            return RedirectToAction("index");
        }
        public ActionResult Delete(int id)
        {
            new SalesMan() { S_ID = id }.SalesMan_Delete();
            return RedirectToAction("index");
        }

    }
}