using SfDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public JsonResult Company_Get_By_User(int id)
        {
            return Json(new Company().Company_Get_By_User(id), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Role_Get_By_Company(int id)
        {
            return Json(new Role().Role_Get_By_Company(id), JsonRequestBehavior.AllowGet);
        }

        public ActionResult User_Role(Nullable<int> id)
        {
            if (id != null)
            {
                User_Role u = new User_Role() { U_ID = (int)id };
                return View(u);
            }
            return View(new User_Role());
        }
        [HttpPost]
        public ActionResult User_Role(User_Role ur)
        {
            ur.Machine_Ip = this.Request.UserHostAddress;
            ur.Mac_Address = Utility.GetMacAddress();
            ur.User_Role_Add();
            return View(ur);
        }
        public ActionResult User_Role_Show()
        {
            return PartialView("User_Role_Show", new User_Role().User_Role_Get_All());
        }
        [OutputCache(Duration = int.MaxValue)]
        public ActionResult User_Role_Details(int id)
        {
            User_Role ur = new User_Role() { U_ID = id };
          
            return PartialView("User_Role_Details",ur.User_Role_Get_By_U_ID());
        }
        public ActionResult Delete_User_Role(int id)
        {
            User_Role ur = new User_Role() { UR_ID = id };
            ur.User_Role_Delete();
            return View();
        }
        public ActionResult Edit_User_Role(int id  )
        {
             User_Role ur = new Models.User_Role();
             ur = ur.User_Role_Get_By_ID(id);
             return PartialView("Edit_User_Role", ur);
            
        }
        [HttpPost]
        public ActionResult Edit_User_Role(User_Role ur)
        {
            ur.User_Role_Update();
           return RedirectToAction("User_Role");


        }
        #endregion

        //#region Login 
        //public ActionResult Login()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Login(user u)
        //{
        //    switch (u.User_Login())
        //    {
        //        case "Change Password":
        //            ViewBag.i = "You are going to change your password";
        //            return RedirectToAction("Change_Password", new { id = u.U_Id });
        //        case "In-Active User":
        //            ViewBag.i = "In-Active User trying to login";
        //            return View();
        //        case "OK":
        //            u.User_Update_Login_Date();
        //            return RedirectToAction("Dashboard");
        //        default:
        //            ViewBag.i = "Wronge Email or Password";
        //            break;
        //    }
        //    return View();
        //}
        //public ActionResult Change_Password(int id)
        //{
        //    return View(new user().User_Get_By_ID(id));
        //}
        //[HttpPost]
        //public ActionResult Change_Password(user u)
        //{
        //    if (u.User_Update_Password())
        //        return RedirectToAction("Dashboard");
        //    ViewBag.message = "Old password is incorrect";
        //    return View();
        //}
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}