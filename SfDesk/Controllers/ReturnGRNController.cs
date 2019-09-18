using SfDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SfDesk.Controllers
{
    public class ReturnGRNController : Controller
    {
        public ActionResult Master(int? id)
        {
         
                return View(new ReturnGrn() );
         
        }
        [HttpPost]
        public ActionResult Master(ReturnGrn ReturnGrn)
        {
         //   ReturnGrn.ReturnGrn_Add();
            return View();
        }
        public ActionResult Detail()
        {
            return PartialView("Detail", new List<ReturnGrn>());

        }
     
     
        public ActionResult Index()
        {
            List<ReturnGrnDetails> pd = new List<ReturnGrnDetails>();
            for (int i = 0; i < 10; i++)
            {
                pd.Add(new ReturnGrnDetails() { Item_Code = i, Item_Name = $"product {i}", Item_Description = $"product no {i}", Qty = 12 * i, Net_Weight = 12.2m, Gross_Weight = 23.23m });
            }

            return Json(pd, JsonRequestBehavior.AllowGet);
        }
    }
}