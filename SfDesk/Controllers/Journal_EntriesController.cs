using SfDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SfDesk.Controllers
{
    public class Journal_EntriesController : Controller
    {
        // GET: Journal_Entries
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Master()
        {
            ViewBag.COA = new ChartOfAccount().COA_Get_All();
            ViewBag.Contacts = new Expense().Accounts_Expense_Get_Contacts(App.App_ID);
            return View();
        }
        [HttpPost]
        public ActionResult Master(Journal_Entries c)
        {
            return View();
        }
        public ActionResult Detail()
        {
            return View();
        }

    }
}