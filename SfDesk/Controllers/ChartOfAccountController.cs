using SfDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SfDesk.Controllers
{
    [Session]
    public class ChartOfAccountController : Controller
    {
        // GET: ChartOfAccount
        public ActionResult Index()
        {
          //  Session["COA"] = new ChartOfAccount().COA_Get_All();
            return View(Session["COA"]);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return PartialView("add");
        }
        [HttpPost]
        public ActionResult Add(ChartOfAccount c)
        {
            c.COA_Add();
            return RedirectToAction("index");
        }
        public ActionResult Edit(int id)
        {
            return PartialView("Edit", new ChartOfAccount() { COA_ID=id}.COA_Get_By_ID());
        }
        [HttpPost]
        public ActionResult Edit(ChartOfAccount c)
        {
            c.COA_Update();
            return RedirectToAction("index");
        }
        public ActionResult Delete(int id)
        {
            new ChartOfAccount() { COA_ID= id}.COA_Delete();
            return RedirectToAction("index");
        }

        public ActionResult Get_Last_Code(int type_id)
        {
            return Json(new ChartOfAccount() { Type_ID = type_id }.COA_Get_Last_Code(), JsonRequestBehavior.AllowGet);
        }
    }
}