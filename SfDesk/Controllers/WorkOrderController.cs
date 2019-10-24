﻿using SfDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SfDesk.Controllers
{
    public class WorkOrderController : Controller
    {
        // GET: WorkOrder
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Master()
        {
            ViewBag.Item = new Item().Item_Get_All_Finish_Good(App.App_ID);
            return View();
        }
        [HttpPost]
        public ActionResult Master(WorkOrder c)
        {

            return View();
        }

        public ActionResult COA_Get_All()
        {
            return Json(new ChartOfAccount().COA_Get_All(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Product_Get_All()
        {
            return Json(new Item_Category().Item_Category_Get_All(App.App_ID), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Recipe_Get_By_Item(int Item_ID)
        {
            Recipe r = new Recipe();
            r.R_ID = r.Get_Recipe_By_Item(Item_ID, App.App_ID);
            r.Input_products = new Recipe_Detail().Recipe_Input_Get_By_ID(r.R_ID,App.App_ID);
            r.Output_products = new Recipe_Detail().Recipe_Output_Get_By_ID(r.R_ID,App.App_ID);
            r.Account_expences = new Recipe_Expense().Recipe_Expense_Get_By_ID(r.R_ID,App.App_ID);

            return Json(r, JsonRequestBehavior.AllowGet);
        }
    }
}