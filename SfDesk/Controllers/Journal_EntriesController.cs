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
    }
}