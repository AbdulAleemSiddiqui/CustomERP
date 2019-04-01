using SfDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SfDesk.Controllers
{
    public class RecipeController : Controller
    {
        // GET: Recipe
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Recipe r)
        {

            return Json("jiye muthedaaa");
        }
        public ActionResult Add()
        {
            
            return PartialView();
        }
    }
}