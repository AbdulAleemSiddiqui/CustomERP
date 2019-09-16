using SfDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SfDesk.Controllers
{
    public class GRNController : Controller
    {
        // GET: GRN
        public ActionResult Master(int? id)
        {
            if(id==null)
            {
                return View();
            }
            return View(new GRN() { PO_ID = (int)id });
        }
        [HttpPost]
        public ActionResult Master(GRN grn)
        {
           // grn.GRN_Add();
            return View();
        }
        public ActionResult Detail()
        {
            return PartialView("Detail", new List<GRN>());
             
        }
        public ActionResult Detail2()
        {
            return PartialView("Detail2", new List<GRN>());

        }
        public ActionResult Get_Taxes()
        {
            return Json(new SalesTax().SalesTax_Get_All(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Index(int? PO_ID)
        {
            List<GRN_Details> pd = new List<GRN_Details>();
            for (int i = 0; i < 10; i++)
            {
                pd.Add(new GRN_Details() { Item_Code = i, Item_Name = $"product {i}", Item_Description = $"product no {i}", Qty = 12 * i,Net_Weight=12.2m,Gross_Weight=23.23m });
            }

            return Json(pd, JsonRequestBehavior.AllowGet);
            //  return Json(new PO_Details() { PO_ID = PO_ID }.PO_Detail_Get_All(), JsonRequestBehavior.AllowGet);
        }
    }
}