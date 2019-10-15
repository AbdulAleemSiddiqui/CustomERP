using DatabaseTVP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class GDN_Detail
    {
        private const string Module = "Sale";

        public int GRN_D_ID { get; set; }
        [TVP]
        public int GRN_ID { get; set; }
        public int Item_ID { get; set; }

        [DisplayName("Item Code")]
        public string Item_Code { get; set; }

        [DisplayName("Item Name")]
        public string Item_Name { get; set; } = "";
        [DisplayName("Item Desc.")]
        public string Item_Description { get; set; } = "";

        [DisplayName("Quantity")]
        public int Qty { get; set; }
        public decimal Net_Weight { get; set; }
        public decimal Gross_Weight { get; set; }
        public string action { get; set; }



        //Your Properties for Model Here
        [TVP]
        public int CreatedBy { get; set; }

        //View Only Properties
        public string ReturnMessage { get; set; }


        public string Sale_GDN_DetailsSave(int UserId)
        {
            try
            {
                //place your Model Logic and DB Calls here:
                this.CreatedBy = UserId; 
                string Message = DataBase.ExecuteQuery<GDN_Detail>(new { x = this }, Connection.GetConnection()).FirstOrDefault().ReturnMessage;
                // Logging Here=> Type of Log, Message, Data (complete objects or paramters except userid), PageName, Module (for Multiple Areas), Connection to Log DB, UserId
                Logger.Logging.DB_Log(Logger.eLogType.Log_Positive, "", new { x = this }, "", Module, Connection.GetLogConnection(), UserId);
                return Message;
            }
            catch (Exception ex)
            {
                // Logging Here=> Type of Log, Message, Data (complete objects or paramters except userid), PageName, Module (for Multiple Areas), Connection to Log DB, Userid
                Logger.Logging.DB_Log(Logger.eLogType.Log_Negative, ex.Message, new { x = this }, "", Module, Connection.GetLogConnection(), UserId);
                return null;
            }
        }

        public GDN_Detail Sale_GDN_DetailsGetById(int Id, int UserId)
        {
            try
            {
                //place your Model Logic and DB Calls here:
                this.CreatedBy = UserId; 
                GDN_Detail ret = DataBase.ExecuteQuery<GDN_Detail>(new { x = Id }, Connection.GetConnection()).FirstOrDefault();
                // Logging Here=> Type of Log, Message, Data (complete objects or paramters except userid), PageName, Module (for Multiple Areas), Connection to Log DB, UserId
                Logger.Logging.DB_Log(Logger.eLogType.Log_Positive, "", new { x = Id }, "", Module, Connection.GetLogConnection(), UserId);
                return ret;
            }
            catch (Exception ex)
            {
                // Logging Here=> Type of Log, Message, Data (complete objects or paramters except userid), PageName, Module (for Multiple Areas), Connection to Log DB, Userid
                Logger.Logging.DB_Log(Logger.eLogType.Log_Negative, ex.Message, new { x = Id }, "", Module, Connection.GetLogConnection(), UserId);
                return null;
            }
        }


        public List<GDN_Detail> Sale_GDN_DetailsGetAll(int UserId)
        {
            try
            {
                //place your Model Logic and DB Calls here:
                this.CreatedBy = UserId; 
                List<GDN_Detail> ret = DataBase.ExecuteQuery<GDN_Detail>(new { x = UserId }, Connection.GetConnection());
                // Logging Here=> Type of Log, Message, Data (complete objects or paramters except userid), PageName, Module (for Multiple Areas), Connection to Log DB, UserId
                Logger.Logging.DB_Log(Logger.eLogType.Log_Positive, "", new { x = UserId }, "", Module, Connection.GetLogConnection(), UserId);
                return ret;
            }
            catch (Exception ex)
            {
                // Logging Here=> Type of Log, Message, Data (complete objects or paramters except userid), PageName, Module (for Multiple Areas), Connection to Log DB, Userid
                Logger.Logging.DB_Log(Logger.eLogType.Log_Negative, ex.Message, new { x = UserId }, "", Module, Connection.GetLogConnection(), UserId);
                return null;
            }
        }

        public string Sale_GDN_DetailsUpdate(int UserId)
        {
            try
            {
                //place your Model Logic and DB Calls here:
                this.CreatedBy = UserId; 
                string Message = DataBase.ExecuteQuery<GDN_Detail>(new { x = this }, Connection.GetConnection()).FirstOrDefault().ReturnMessage;
                // Logging Here=> Type of Log, Message, Data (complete objects or paramters except userid), PageName, Module (for Multiple Areas), Connection to Log DB, UserId
                Logger.Logging.DB_Log(Logger.eLogType.Log_Positive, "", new { x = this }, "", Module, Connection.GetLogConnection(), UserId);
                return Message;
            }
            catch (Exception ex)
            {
                // Logging Here=> Type of Log, Message, Data (complete objects or paramters except userid), PageName, Module (for Multiple Areas), Connection to Log DB, Userid
                Logger.Logging.DB_Log(Logger.eLogType.Log_Negative, ex.Message, new { x = this }, "", Module, Connection.GetLogConnection(), UserId);
                return null;
            }
        }



    }
}