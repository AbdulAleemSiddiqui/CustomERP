using SfDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SfDesk.Controllers
{
    public class ExpenseController : Controller
    {
        // GET: Expense
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Master()
        {
            return View();
        }
        public ActionResult Detail()
        {
            return PartialView("Detail");

        }
        [HttpPost]
        public ActionResult Master(Expense c)
        {
            return View();
        }
    }
}