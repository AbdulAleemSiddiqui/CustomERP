using SfDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SfDesk.Controllers
{
    public class PurchaseIndendController : Controller
    {
        // GET: PurchaseIndend
        public ActionResult Master()
        {
            return View(new PI());
        }
    }
}