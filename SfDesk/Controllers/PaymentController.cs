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
        public ActionResult PaymentDetail()
        {
            return PartialView("PaymentDetail", new List<Payment_Detail>());

        }
        public ActionResult detail()
        {
            return PartialView("detail", new List<Payment_Mode>());
        }
      
        public ActionResult Bill_Get_By_SID(int id)
        {
            return Json( new Payment_Detail().Bill_Get_By_SID(id),JsonRequestBehavior.AllowGet);
        }


    }
}