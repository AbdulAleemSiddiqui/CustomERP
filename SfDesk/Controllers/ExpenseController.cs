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
            ViewBag.COA = new ChartOfAccount().COA_Get_All();
            ViewBag.Contacts = new Expense().Accounts_Expense_Get_Contacts(App.App_ID);
            return View(new Expense() { Ex_NO = Utility.Get_New_No("Expense", "Ex_ID", "Ex", App.App_ID) });
        }
     
        [HttpPost]
        public ActionResult Master(Expense c)
        {
            c.Accounts_Expense_Add(App.App_ID);
            return View();
        }
        public ActionResult Detail()
        {
            return PartialView("Detail");

        }
        public ActionResult Product_Get_All()
        {
            return Json(new Item_Category().Item_Category_Get_All(App.App_ID), JsonRequestBehavior.AllowGet);
        }
    }
}