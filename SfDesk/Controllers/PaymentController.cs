using SfDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SfDesk.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Master()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Master(Payment d )
        {
            int id =Convert.ToInt32(d.Payment_Add());
            return Json(id,JsonRequestBehavior.AllowGet);
        }
        public ActionResult PaymentDetail()
        {
            return PartialView("PaymentDetail", new List<Payment_Detail>());

        }
        public ActionResult detail()
        {
            return PartialView("detail", new List<Payment_Mode>());
        }
        [HttpPost]
        public ActionResult detail( PaymentViewModel p)
        {
            foreach (var item in p.mode)
            {
                item.P_ID = p.id;
                item.CheckNo = "123";
                item.Payment_Mode_Add();
            }
            foreach (var item in p.detail)
            {
                item.P_ID = p.id;
                item.Payment_Detail_Add();
            }
            return PartialView("detail", new List<Payment_Mode>());
        }
        public ActionResult Bill_Get_By_SID(int id)
        {
            return Json( new Payment_Detail().Bill_Get_By_SID(id),JsonRequestBehavior.AllowGet);
        }


    }
}