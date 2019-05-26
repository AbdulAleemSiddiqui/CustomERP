using SfDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Mvc;

namespace SfDesk.Controllers
{
    public class LoginUserController : Controller
    {
        // GET: LoginUser

        public ActionResult Login()
        {

            var macAddr =
                (
                    from nic in NetworkInterface.GetAllNetworkInterfaces()
                    where nic.OperationalStatus == OperationalStatus.Up
                    select nic.GetPhysicalAddress().ToString()
                ).FirstOrDefault();
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
                    Session["ID"] = u;
                    Session["COA"] = new ChartOfAccount().COA_Get_All();
                    return RedirectToAction("Index","user");
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
            {
                Session["ID"] = u;
                Session["COA"] = new ChartOfAccount().COA_Get_All();
                return RedirectToAction("Index", "Company");
            }
            ViewBag.message = "Old password is incorrect";
            return View();
        }

        public ActionResult Logout()
        {
            try
            {
                var action = Url.Action("generate_Menu", "form", new { id = ((SfDesk.Models.user)Session["ID"]).U_Id });
                Response.RemoveOutputCacheItem(action);
                Session["ID"] = null;
            }
            catch { }
            return RedirectToAction("Login");
        }
    }
}