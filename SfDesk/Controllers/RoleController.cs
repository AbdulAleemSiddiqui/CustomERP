        using SfDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SfDesk.Controllers
{
    public class RoleController : Controller
    {
        // GET: Role
        public ActionResult Index()
        {
            return View(new Role().Role_Get_All());
        }
        public ActionResult Add()
        {
            return View();
        }
 
        [HttpPost]
        public ActionResult Add(Role r)
        {
            r.Role_Add();
            return View();
        }

        
        public ActionResult Create()
            {
            RoleDetails model = (RoleDetails) TempData["model"];
            if (model==null)
            {
               model = new RoleDetails();
            }
            return View(model);
        }
        public ActionResult Detail(int id)
        {
            return PartialView("Detail", new Company().Company_Get_By_ID(id));
        }
        [HttpPost]
        public ActionResult Create(RoleDetails model)
        {
            model.Role_Detail_Add();
            return RedirectToAction("Create",FormMethod.Get);
        }

        public ActionResult Delete(int id)
        {
            Role  u = new Role() { R_ID = id };
            u.Role_Delete();   ///Deleting existing Role (updating state to 0 in database)
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View(new Role().Role_Get_By_ID(id)); // get role by id 

        }
        [HttpPost]
        public ActionResult Edit(Role u)
        {
            u.Role_Update();   // Update existing role records
            return View();
        }
        public JsonResult Update_Role_ID(int id)
        {
            RoleDetails r = new RoleDetails() { R_ID = id };
            r.Role_Detail_Get_All();
            TempData["model"] =  r ;
            return Json(r, JsonRequestBehavior.AllowGet);

        }
    }
}