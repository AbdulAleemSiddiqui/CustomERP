﻿using SfDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace SfDesk.Controllers
{
    [Session]
    public class CompanyController : Controller
    {
        
        #region company CRUD
        public ActionResult Index()
        {
            return View(new Company().Company_Get_All()); // get all companies where state in 1
        }
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult Verify(string name)
        {
            return Json(new Company() { Company_Name=name}.Verify()==true?"verified":"Sorry, this company is already exsist.",JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Add(Company c)
        {
            if (c.Verify())
            {
                c.Company_Add();
            }
            else
            {
                ViewBag.message = "Old password is incorrect";
            }
            return RedirectToAction("index");
        }
   
        public ActionResult Edit(int id)
        {
            return View(new Company().Company_Get_By_ID(id)); // get company by id 
        }
        [HttpPost]
        public ActionResult Edit(Company u)
        {
            u.Company_Update();   // Update existing company records
            return View();
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Company u = new Company() { Company_ID = id };
            u.Company_Delete();   ///Deleting existing company (updating state to 0 in database)
            return RedirectToAction("Index");
        }
      
        public ActionResult Detail(int id)
        {
            return PartialView("Detail",new Company().Company_Get_By_ID(id));
        }
        #endregion
    }
}