using SfDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SfDesk.Controllers
{
    [Session]
    public class PurchaseRequisitionController : Controller
    {
        private static PR old;
        private static List<PR_Details> details =new List<PR_Details>();

        public ActionResult master(int? id)
         {
            if (id != null)
            {
                PR p = new PR() { PR_ID = id.Value ,App_Status="I"};
                p = p.PR_Get_All().Find(x => x.PR_ID == id);
                if(p!=null)
                {
                    old = p;
                    return View(p);
                }
            }
            // return View(new PR() {PR_No=new PR().PR_Get_New_PR_NO() });
            return View(new PR());
        }
        [HttpPost]
        public ActionResult master(PR c)
            {
            // try
            //{
            int id = c.PR_ID;
            if (c.PR_ID == 0)
               c.PR_Add();




            //if (pi != null)
            //    foreach (var item in c.details)
            //    {
            //        item.PR_ID = id;
            //        item.PR_Detail_Add();
            //    }
            //if (pie != null)
            //    foreach (var item in pie)
            //    {

            //        item.PR_Detail_Update();
            //    }

            if (c.details != null && c.details.Count > 0)
            {
                foreach (var item in c.details)
                {
                    if (item.action == "I")
                    {
                        item.PR_ID = id;
                        item.PR_Detail_Add();
                    }
                    else if (item.action == "U")
                    {
                        item.PR_Detail_Update();
                    }
                    else if (item.action == "D")
                    {
                        item.PR_Detail_Delete();
                    }

                }

            }


            return Json(id, JsonRequestBehavior.AllowGet);
           // }
            //catch (Exception ex)
            //{
            //    string a = ex.Message;
            //    return Json("Error Occure", JsonRequestBehavior.AllowGet);
            //}
        }
        public ActionResult showAll()
        {
            return View(new PR() { App_Status = "I" }.PR_Get_All());
        }
        [HttpPost]
        public ActionResult Approve(PR p)
        {
           
            if (p.details != null && p.details.Count > 0)
            {
                foreach (var item in p.details)
                {
                    if (item.action == "I")
                    {
                        item.PR_Detail_Add();
                    }
                    else if (item.action == "U")
                    {
                        item.PR_Detail_Update();
                    }
                    else if (item.action == "D")
                    {
                        item.PR_Detail_Delete();
                    }

                }

            }
            p.App_Status = "PR_Approve";

           // p.PR_Approve();
            return Json("kuch bhi", JsonRequestBehavior.AllowGet);

        }
        public ActionResult detail(int? id)
        {
            return PartialView("detail", new List<PR>());
        }
        public ActionResult Index()//int PR_ID)
        {
           // details = new PR_Details() { PR_ID = PR_ID }.PR_Detail_Get_All();
            return Json(details, JsonRequestBehavior.AllowGet);
        }

        #region Detail
        public ActionResult Item_Get_All()
        {
            return Json(new Item().Item_Get_All(), JsonRequestBehavior.AllowGet);
        }

   
        #endregion
    }
}