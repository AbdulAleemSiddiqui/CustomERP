using DatabaseTVP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class PO_Details
    {
        private const string Module = "Purchase";


        #region Detail
        [TVP]
        public int PO_D_ID { get; set; }
        [TVP]
        public int PO_ID { get; set; }
        [TVP]
        public int PI_ID { get; set; }

        [TVP]
        [DisplayName("PO Quantitiy")]
        public int PO_Qty { get; set; }

        [TVP]
        public int Item_ID { get; set; }

        public string PI_NO { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PI_Date { get; set; }
    
        [DisplayName("Item Name")]
        public string Item_Name { get; set; } = "";
        [DisplayName("Item Desc.")]
        public string Item_Description { get; set; } = "";
        [DisplayName("PI Quantitiy")]
        public decimal PI_Qty { get; set; }
    
        public string action { get; set; }
        public bool is_Selected { get; set; }

        public int Item_Cat_ID { get; set; }
        #endregion



        [TVP]
        public int CreatedBy { get; set; }

        //View Only Properties
        public string ReturnMessage { get; set; }


        public string Purchase_PO_Detail_Add(int UserId)
        {
            try
            {
                //place your Model Logic and DB Calls here:
                this.CreatedBy = UserId;  
                string Message = DataBase.ExecuteQuery<PO_Details>(new { x = this }, Connection.GetConnection()).FirstOrDefault().ReturnMessage;
                // Logging Here=> Type of Log, Message, Data (complete objects or paramters except userid), PageName, Purchase (for Multiple Areas), Connection to Log DB, UserId
                Logger.Logging.DB_Log(Logger.eLogType.Log_Positive, "", new { x = this }, "", Module, Connection.GetLogConnection(), UserId);
                return Message;
            }
            catch (Exception ex)
            {
                // Logging Here=> Type of Log, Message, Data (complete objects or paramters except userid), PageName, Purchase (for Multiple Areas), Connection to Log DB, Userid
                Logger.Logging.DB_Log(Logger.eLogType.Log_Negative, ex.Message, new { x = this }, "", Module, Connection.GetLogConnection(), UserId);
                return null;
            }
        }

        public List<PO_Details> Purchase_PO_Detail_Get_By_Cat(List<Item_Category> lst, int UserId)
        {
            try
            {
                //place your Model Logic and DB Calls here:
                this.CreatedBy = UserId;  
                List<PO_Details> ret = DataBase.ExecuteQuery<PO_Details>(new { x = lst,a=this.CreatedBy }, Connection.GetConnection());
                // Logging Here=> Type of Log, Message, Data (complete objects or paramters except userid), PageName, Purchase (for Multiple Areas), Connection to Log DB, UserId
                Logger.Logging.DB_Log(Logger.eLogType.Log_Positive, "", new { x = lst }, "", Module, Connection.GetLogConnection(), UserId);
                return ret;
            }
            catch (Exception ex)
            {
                // Logging Here=> Type of Log, Message, Data (complete objects or paramters except userid), PageName, Purchase (for Multiple Areas), Connection to Log DB, Userid
                Logger.Logging.DB_Log(Logger.eLogType.Log_Negative, ex.Message, new { x = lst }, "", Module, Connection.GetLogConnection(), UserId);
                return null;
            }
        }


        public List<PO_Details> Purchase_PO_Detail_Get_All(int UserId)
        {
            try
            {
                //place your Model Logic and DB Calls here:
                this.CreatedBy = UserId;  
                List<PO_Details> ret = DataBase.ExecuteQuery<PO_Details>(new { x = UserId }, Connection.GetConnection());
                // Logging Here=> Type of Log, Message, Data (complete objects or paramters except userid), PageName, Purchase (for Multiple Areas), Connection to Log DB, UserId
                Logger.Logging.DB_Log(Logger.eLogType.Log_Positive, "", new { x = UserId }, "", Module, Connection.GetLogConnection(), UserId);
                return ret;
            }
            catch (Exception ex)
            {
                // Logging Here=> Type of Log, Message, Data (complete objects or paramters except userid), PageName, Purchase (for Multiple Areas), Connection to Log DB, Userid
                Logger.Logging.DB_Log(Logger.eLogType.Log_Negative, ex.Message, new { x = UserId }, "", Module, Connection.GetLogConnection(), UserId);
                return null;
            }
        }

        public string Purchase_PO_Detail_Update(int UserId)
        {
            try
            {
                //place your Model Logic and DB Calls here:
                this.CreatedBy = UserId;  
                string Message = DataBase.ExecuteQuery<PO_Details>(new { x = this }, Connection.GetConnection()).FirstOrDefault().ReturnMessage;
                // Logging Here=> Type of Log, Message, Data (complete objects or paramters except userid), PageName, Purchase (for Multiple Areas), Connection to Log DB, UserId
                Logger.Logging.DB_Log(Logger.eLogType.Log_Positive, "", new { x = this }, "", Module, Connection.GetLogConnection(), UserId);
                return Message;
            }
            catch (Exception ex)
            {
                // Logging Here=> Type of Log, Message, Data (complete objects or paramters except userid), PageName, Purchase (for Multiple Areas), Connection to Log DB, Userid
                Logger.Logging.DB_Log(Logger.eLogType.Log_Negative, ex.Message, new { x = this }, "", Module, Connection.GetLogConnection(), UserId);
                return null;
            }
        }



    }
}