using SfDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SfDesk.Controllers
{
    public class PurchaseIndendController : Controller
    {
        // GET: PurchaseIndend
        public ActionResult Master()
        {
            return View(new PI());
        }
        [HttpPost]
        public ActionResult Master(PI pi)
        {
            return View(new PI());
        }
        public ActionResult Get_PI_Detail(int Cat_ID)
        {
            return Json(new PI_Detail_ViewModel().PI_Detail_Get_All(Cat_ID) ,JsonRequestBehavior.AllowGet);
        }
    }
}