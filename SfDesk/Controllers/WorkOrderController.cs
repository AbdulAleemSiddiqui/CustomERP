using SfDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SfDesk.Controllers
{
    public class WorkOrderController : Controller
    {
        // GET: WorkOrder
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Master()
        {
            ViewBag.Item = new Item().Item_Get_All(App.App_ID);
            return View();
        }
        [HttpPost]
        public ActionResult Master(WorkOrder c)
        {
            return View();
        }

        public ActionResult COA_Get_All()
        {
            return Json(new ChartOfAccount().COA_Get_All(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Product_Get_All()
        {
            return Json(new Item_Category().Item_Category_Get_All(App.App_ID), JsonRequestBehavior.AllowGet);
        }
    }
}