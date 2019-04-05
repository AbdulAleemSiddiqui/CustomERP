using SfDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SfDesk.Controllers
{
    public class TransporterController : Controller
    {
        // GET: Transporter
        public ActionResult Add()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Add(Transporter t)
        {
           t.T_ID= t.Transporter_Add();
            return Json(t,JsonRequestBehavior.AllowGet);
        }
        public ActionResult Add_Vehicle(int id)
        {
            return PartialView("Add_Vehicle",new Vehicle() { T_ID = id }.Vehcile_Get_By_Transporter());
        }
        [HttpPost]
        public ActionResult Add_Vehicle(Vehicle t)
        {
            t.V_ID = t.Vehcile_Add();
            return Json(t, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Vehcile_Get_By_Transporter(int id)
        {
            return Json(new Vehicle() { T_ID = id }.Vehcile_Get_By_Transporter(),JsonRequestBehavior.AllowGet);
        }


    }
}