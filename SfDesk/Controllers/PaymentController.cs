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
        public ActionResult detail()
        {
            return PartialView("detail", new List<Payment_Mode>());
        }
        public ActionResult detail_2()
        {
            return PartialView("detail_2", new List<Payment_Detail>());
        }

    }
}