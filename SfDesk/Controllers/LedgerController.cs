using SfDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SfDesk.Controllers
{
    public class LedgerController : Controller
    {
        // GET: Ledger
        public ActionResult Index()
        {
            return View(new Ledger().Ledger_Get_All());
        }
    }
}