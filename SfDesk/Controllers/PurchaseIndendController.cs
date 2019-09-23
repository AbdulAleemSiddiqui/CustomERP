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

        public ActionResult Show_all()
        {
            return View(new P_Indent().Purchase_P_Indent_Get_All(App.App_ID));
        }
        public ActionResult Master()
        {
            return View(new P_Indent());
        }
        [HttpPost]
        public ActionResult Master(P_Indent pi)
        {

            if(pi.PI_Details.Any(x=>(x.PI_ID ==0 && x.is_Selected)))
            {
                int id=pi.Purchase_P_Indent_Add(App.App_ID);
                pi.PI_Details.FindAll(x=>x.PI_ID==0).ForEach(x => x.PI_ID = id);
            }
            pi.PI_Details = pi.PI_Details.FindAll(x => x.is_Selected);
            pi.PI_Details.ForEach(x => x.Purchase_P_Indent_Detail_Add(App.App_ID));
            return View(new P_Indent());
        }
        public ActionResult Get_PI_Detail(int Cat_ID)
        {
            return Json(new P_Indent_Detail().Purchase_P_Indent_Detail_Get_By_Cat(Cat_ID,App.App_ID) ,JsonRequestBehavior.AllowGet);
        }
    }
}