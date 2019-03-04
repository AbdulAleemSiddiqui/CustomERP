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
        public ActionResult AddDetails(int idd)
        {
            ViewBag.id = idd;
            List<int> ids = new List<int>() { 1, 2, 3, 4 };
            List<string> names = new List<string>() { "Add", "Edit", "Delete", "Detail" };

            RoleDetails model = new RoleDetails();
            model.forms = new List<Form>();

            foreach (var id in ids)
            {
                Form child = new Form()
                {
                    Form_ID = id,
                    Form_Name = "Form" + id,
                    actions = new List<Models.Action>()
                };

                for (int i = 0; i < names.Count; i++)
                {
                    child.actions.Add(new Models.Action()
                    {
                        Action_ID = i + 1,
                        Action_Name = names[i],
                        isSelected = false
                    });
                }
                model.forms.Add(child);

            }
            return View(model);
        }
        [HttpPost]
        public ActionResult AddDetails(RoleDetails model)
        {
            return RedirectToAction("Create", FormMethod.Get);
            
        }

        [HttpPost]
        public ActionResult Add(Role r)
        {
            r.Role_Add();
            return View();
        }

        public ActionResult Create()
        {
            List<int> ids = new List<int>() { 1,2,3,4 };
            List<string> names = new List<string>() { "Add","Edit","Delete","Detail"};

            RoleDetails model = new RoleDetails();
            model.forms = new List<Form>();

            foreach (var id in ids)
            {
                Form child = new Form()
                {
                    Form_ID = id,
                    Form_Name = "Form" + id,
                    actions = new List<Models.Action>()
                };

                for (int i = 0; i < names.Count; i++)
                {
                    child.actions.Add(new Models.Action()
                    {
                        Action_ID = i+1,
                        Action_Name = names[i],
                        isSelected = false
                    });
                }
                model.forms.Add(child);

            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(RoleDetails model)
        {
            model.add();
            return RedirectToAction("Create",FormMethod.Get);
        }
        public ActionResult Adddd()
        {
            return View();
        }

    }
}