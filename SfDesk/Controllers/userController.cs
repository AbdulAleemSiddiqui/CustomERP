using SfDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SfDesk.Controllers
{
    public class userController : Controller
    {
        #region User CRUD
        public ActionResult Index()
        {
            return View(new user().User_Get_All());
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(user u)
        {
            u.User_Add();
            return View();
        }

        public ActionResult Edit(int id)
        {
            return View(new user().User_Get_By_ID(id));
        }
        [HttpPost]
        public ActionResult Edit(user u)
        {
            u.User_Update();
            return View(u);
        }

        public ActionResult Delete(int id)
        {
            user u = new user() { U_Id = id };
            u.User_Delete();
            return RedirectToAction("Index");
        }


        public JsonResult Role_Get_By_Company(int id)
        {
            return Json(new Role().Role_Get_By_Company(id),JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Login 
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(user u)
        {
            switch (u.User_Login())
            {
                case "Change Password":
                    ViewBag.i = "You are going to change your password";
                    return RedirectToAction("Change_Password", new { id = u.U_Id });
                case "In-Active User":
                    ViewBag.i = "In-Active User trying to login";
                    return View();
                case "OK":
                    u.User_Update_Login_Date();
                    return RedirectToAction("Dashboard");
                default:
                    ViewBag.i = "Wronge Email or Password";
                    break;
            }
            return View();
        }
        public ActionResult Change_Password(int id)
        {
            return View(new user().User_Get_By_ID(id));
        }
        [HttpPost]
        public ActionResult Change_Password(user u)
        {
            if (u.User_Update_Password())
                return RedirectToAction("Dashboard");
            ViewBag.message = "Old password is incorrect";
            return View();
        }
        public ActionResult Dashboard()
        {
            return View();
        }
        #endregion
    }
}