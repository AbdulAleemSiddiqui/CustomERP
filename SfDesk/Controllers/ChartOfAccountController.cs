using SfDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SfDesk.Controllers
{
    public class ChartOfAccountController : Controller
    {
        // GET: ChartOfAccount
        public ActionResult Index()
        {
            return View(new ChartOfAccount().COA_Get_All());
        }
        [HttpGet]
        public ActionResult Add()
        {
            return PartialView("add");
        }
        [HttpPost]
        public ActionResult Add(ChartOfAccount c)
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            return PartialView("Detail", new ChartOfAccount().COA_Get_By_ID(id));
        }
        [HttpPost]
        public ActionResult Edit(ChartOfAccount c)
        {
            return View();
        }
        public ActionResult Delete()
        {
            return View();
        }
    }
}