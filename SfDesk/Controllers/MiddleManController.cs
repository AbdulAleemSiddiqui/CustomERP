using SfDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SfDesk.Controllers
{
    public class MiddleManController : Controller
    {
        // GET: MiddleMan
         public ActionResult Add()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Add(MiddleMan t)
        {
           
          t.MM_ID=  t.MiddleMan_Add();
            return Json(t,JsonRequestBehavior.AllowGet);
        }

        
      
        public ActionResult Index()
        {
            return View(new MiddleMan().MiddleMan_Get_All());
        }
        public ActionResult Update(int id)
        {
            return PartialView("Update", new MiddleMan() { MM_ID = id }.MiddleMan_Get_By_ID());

        }
        [HttpPost]
        public ActionResult Update(MiddleMan c)
      {
            c.MiddleMan_Update();
            return RedirectToAction("index");
        }
        public ActionResult Delete(int id)
        {
            new MiddleMan() { MM_ID= id }.MiddleMan_Delete();
            return RedirectToAction("index");
        }

    }
}