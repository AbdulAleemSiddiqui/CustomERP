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
    public class PR_Details
    {
        private const string Module = "Purchase";

        #region Detail
        [TVP]
        public int PR_D_ID { get; set; }
        [TVP]
        public int PR_ID { get; set; }
        public string PR_NO { get; set; }
        [TVP]
        public int Item_ID { get; set; }
        [TVP]
        [DisplayName("Product Description")]
        public string Description { get; set; } = "";
        [TVP]
        [DisplayName("Quantity")]
        public decimal Quantity { get; set; }
        [TVP]
        public int CreatedBy { get; set; }

        [DisplayName("Store / Godown")]
        public string Store { get; set; } = "";
        [DisplayName("Item Code")]
        public string Item_Code { get; set; }
        [DisplayName("Product Name")]
        public string Item_Name { get; set; } = "";     
        public string action { get; set; }
        public string ReturnMessage { get; set; }
        public DateTime PR_Date { get; set; }
        #endregion
        public string Purchase_PR_Details_Add(int UserId)
        {
            try
            {
                //place your Model Logic and DB Calls here:
                this.CreatedBy = UserId; 
                string Message = DataBase.ExecuteQuery<PR_Details>(new { x = this }, Connection.GetConnection()).FirstOrDefault().PR_D_ID.ToString();
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
        
        public List<PR_Details> Purchase_PR_Details_Get_By_PI(int PI_ID,int Item_ID, int UserId)
        {
            try
            {
                //place your Model Logic and DB Calls here:
                this.CreatedBy = UserId;
                List<PR_Details> ret = DataBase.ExecuteQuery<PR_Details>(new { x = PI_ID,x1=Item_ID,x2=UserId }, Connection.GetConnection());
                // Logging Here=> Type of Log, Message, Data (complete objects or paramters except userid), PageName, Purchase (for Multiple Areas), Connection to Log DB, UserId
                Logger.Logging.DB_Log(Logger.eLogType.Log_Positive, "", new { x = PI_ID }, "", Module, Connection.GetLogConnection(), UserId);
                return ret;
            }
            catch (Exception ex)
            {
                // Logging Here=> Type of Log, Message, Data (complete objects or paramters except userid), PageName, Purchase (for Multiple Areas), Connection to Log DB, Userid
                Logger.Logging.DB_Log(Logger.eLogType.Log_Negative, ex.Message, new { x = PI_ID }, "", Module, Connection.GetLogConnection(), UserId);
                return null;
            }
        }

        
        public List<PR_Details> Purchase_PR_Details_Get_By_PR(int UserId,int PR_ID)
        {
            try
            {
                //place your Model Logic and DB Calls here:
                this.CreatedBy = UserId;
                List<PR_Details> ret = DataBase.ExecuteQuery<PR_Details>(new {  a=PR_ID, x = UserId }, Connection.GetConnection());
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



        public List<PR_Details> Purchase_PR_Details_GetAll(int UserId)
        {
            try
            {
                //place your Model Logic and DB Calls here:
                this.CreatedBy = UserId; 
                List<PR_Details> ret = DataBase.ExecuteQuery<PR_Details>(new { x = UserId }, Connection.GetConnection());
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

        public string Purchase_PR_Details_Update(int UserId)
        {
            try
            {
                //place your Model Logic and DB Calls here:
                this.CreatedBy = UserId;
                string Message = DataBase.ExecuteQuery<PR_Details>(new { x = this }, Connection.GetConnection()).FirstOrDefault().ReturnMessage;
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
        public string Purchase_PR_Details_Delete(int UserId)
        {
            try
            {
                //place your Model Logic and DB Calls here:
                this.CreatedBy = UserId;
                string Message = DataBase.ExecuteQuery<PR_Details>(new { x = this }, Connection.GetConnection()).FirstOrDefault().ReturnMessage;
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