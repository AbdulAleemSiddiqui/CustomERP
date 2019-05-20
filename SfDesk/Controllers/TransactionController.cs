using SfDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SfDesk.Controllers
{
    [Session]
    public class TransactionController : Controller
    {
        // GET: Transaction
        public ActionResult Index()
        {
            return View(new Transaction().Transaction_Get_All());
        }
        public ActionResult Add()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Add(Transaction s)
        {
            s.Transaction_Add();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            return PartialView("Edit", new Transaction() { T_ID = id }.Transaction_Get_By_ID());
        }
        [HttpPost]
        public ActionResult Edit(Transaction c)
        {
            c.Transaction_Update();
            return RedirectToAction("index");
        }
        public ActionResult Delete(int id)
        {
            new Transaction() {T_ID = id }.Transaction_Delete();
            return RedirectToAction("index");
        }
    }
}