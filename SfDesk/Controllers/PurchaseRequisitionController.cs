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
      
      

        public ActionResult master()
         {
            
            // return View(new PR() {PR_No=new PR().PR_Get_New_PR_NO() });
            return View(new PR() { PR_NO=Utility.Get_New_No("PR","PR_ID","PR",App.App_ID)});
        }
        [HttpPost]
        public ActionResult master(PR c)
            {
            // try
            //{
            int id = c.PR_ID;
            if (c.PR_ID == 0)
            {
                id = int.Parse(c.Purchase_PR_Add(App.App_ID));
            }
            else
            {
                c.Purchase_PR_Update(App.App_ID);
            }
            if (c.details != null && c.details.Count > 0)
            {
                foreach (var item in c.details)
                {
                    if (item.action == "I")
                    {
                        item.PR_ID = id;
                        item.Purchase_PR_Details_Add(App.App_ID);
                    }
                    else if (item.action == "U")
                    {
                        item.Purchase_PR_Details_Update(App.App_ID);
                    }
                    else if (item.action == "D")
                    {
                        item.Purchase_PR_Details_Delete(App.App_ID);
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
            return View(new PR().Purchase_PR_GetAll(App.App_ID));
        }
       
        public ActionResult Approve(int? id)
        {
            if (id != null)
            {
                PR p = new PR() { PR_ID = id.Value };
                p = p.Purchase_PR_GetAll(App.App_ID).Find(x => x.PR_ID == id);
                if (p != null)
                {

                    return View(p);
                }
            }

            return View();

        }
        public ActionResult detail(int? id)
        {
            return PartialView("detail", new List<PR>());
        }
        public ActionResult PR_Detail_Get_By_PR(int PR_ID)
        {
            List<PR_Details> details = null;
            if (PR_ID != 0)
            {
                details = new PR_Details() { PR_ID = PR_ID }.Purchase_PR_Details_Get_By_PR(App.App_ID, PR_ID);
            }
            return Json(details==null?new List<PR_Details>():details, JsonRequestBehavior.AllowGet);
        }

        #region Detail
        public ActionResult Item_Get_All()
        {
            return Json(new Item().Item_Get_All(), JsonRequestBehavior.AllowGet);
        }

   
        #endregion
    }




}