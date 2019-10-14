using SfDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SfDesk.Controllers
{
    public class GDNController : Controller
    {
        // GET: GDN
        public ActionResult Master(int? id)
        {
            ViewBag.Customers = new Customer().Customer_Get_All(App.App_ID);
            ViewBag.Stores = new Store().Store_Get_All(App.App_ID);
            ViewBag.Currency = new Currency().Currency_Get_All(App.App_ID);
            ViewBag.Branch = new Branch().Branch_Get_All(App.App_ID);
            ViewBag.Transporter = new Transporter().Transporter_Get_All();
            if(id!=null)
            {
                GDN item = new GDN().Sale_GDN_Get_SO(id.Value, App.App_ID);
                item.GDN_NO = Utility.Get_New_No("GDN", "GDN_ID", "GDN", App.App_ID);
                return View(item);
            }
            return View(new GDN());
         
        }
        [HttpPost]
        public ActionResult Master(GDN GDN)
        {
         //   GDN.GDN_Add();
            return View();
        }
        public ActionResult ShowAll()
        {
            return View(new GDN().Sale_GDN_Get_All_SO(App.App_ID));
        }
        public ActionResult Detail()
        {
            return PartialView("Detail", new List<GDN>());

        }
        public ActionResult Detail2()
        {
            return PartialView("Detail2", new List<GDN>());

        }
        public ActionResult Get_Taxes()
        {
            return Json(new SalesTax().SalesTax_Get_All(), JsonRequestBehavior.AllowGet);
        }  // GET: GDN
        public ActionResult Index()
        {
            List<GDN_Details> pd = new List<GDN_Details>();
            for (int i = 0; i < 10; i++)
            {
                pd.Add(new GDN_Details() { Item_Code = i, Item_Name = $"product {i}", Item_Description = $"product no {i}", Qty = 12 * i, Net_Weight = 12.2m, Gross_Weight = 23.23m });
            }

            return Json(pd, JsonRequestBehavior.AllowGet);
        }

    }
}