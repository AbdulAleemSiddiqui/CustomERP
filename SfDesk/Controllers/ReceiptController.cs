using SfDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SfDesk.Controllers
{
    public class ReceiptController : Controller
    {
        public ActionResult Index()
        {
            List<ReceiptDetails> pd = new List<ReceiptDetails>();


            return Json(pd, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Tax_adjustment()
        {
            List<Receipt_Tax_adjustment> pd = new List<Receipt_Tax_adjustment>();


            return Json(pd, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Master()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Master(Receipt d)
        {
            //int id =Convert.ToInt32(d.Receipt_Add());
            return Json(0, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ReceiptDetail()
        {
            return PartialView("ReceiptDetail", new List<ReceiptDetails>());

        }
        public ActionResult detail()
        {
            return PartialView("detail", new List<Receipt>());
        }
        [HttpPost]
        public ActionResult detail(Receipt p)
        {
           // foreach (var item in p.mode)
            //{
            //    item.P_ID = p.id;

            //    item.Receipt_Mode_Add();
            //}
            //foreach (var item in p.detail)
            //{
            //    item.P_ID = p.id;
            //    item.ReceiptDetails_Add();
            //}
            return PartialView("detail");
        }
    }
}