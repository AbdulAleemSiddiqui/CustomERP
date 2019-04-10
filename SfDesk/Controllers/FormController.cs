using SfDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SfDesk.Controllers
{
    public class FormController : Controller
    {
        // GET: Form
        [OutputCache(Duration = int.MaxValue)]
        public ActionResult Generate_Menu(int id)
        {
            return PartialView("Generate_Menu", new Form().Get_All_Menu(id));
         
        }
    }
}