using DatabaseTVP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class P_Indent_Detail
    {
        [TVP]
        public int PI_D_ID { get; set; }
        [TVP]
        public int PI_ID { get; set; }
        [TVP]
        public int PR_D_ID { get; set; }
        [TVP]
        public int Item_ID { get; set; }


        private const string Purchase = "Purchase";

        public string PR_No { get; set; }
        public DateTime PR_Date { get; set; }
        public string Department_Name { get; set; }
        public string Item_Name { get; set; }
        public decimal Quantity { get; set; }
        public bool is_Selected { get; set; }

        //Your Properties for Model Here
        public string Description { get; set; }
        [TVP]
        public int CreatedBy { get; set; }
        //View Only Properties
        public string ReturnMessage { get; set; }


        public string Purchase_P_Indent_Detail_Add(int UserId)
        {
            try
            {
                //place your Model Logic and DB Calls here:
                this.CreatedBy = UserId;
                string Message = DataBase.ExecuteQuery<P_Indent_Detail>(new { x = this }, Connection.GetConnection()).FirstOrDefault().ReturnMessage;
                // Logging Here=> Type of Log, Message, Data (complete objects or paramters except userid), PageName, Purchase (for Multiple Areas), Connection to Log DB, UserId
                Logger.Logging.DB_Log(Logger.eLogType.Log_Positive, "", new { x = this }, "", Purchase, Connection.GetLogConnection(), UserId);
                return Message;
            }
            catch (Exception ex)
            {
                // Logging Here=> Type of Log, Message, Data (complete objects or paramters except userid), PageName, Purchase (for Multiple Areas), Connection to Log DB, Userid
                Logger.Logging.DB_Log(Logger.eLogType.Log_Negative, ex.Message, new { x = this }, "", Purchase, Connection.GetLogConnection(), UserId);
                return null;
            }
        }

        public P_Indent_Detail Purchase_P_Indent_Detail_Get_By_Id(int Id, int UserId)
        {
            try
            {
                //place your Model Logic and DB Calls here:
                this.CreatedBy = UserId;
                P_Indent_Detail ret = DataBase.ExecuteQuery<P_Indent_Detail>(new { x = Id }, Connection.GetConnection()).FirstOrDefault();
                // Logging Here=> Type of Log, Message, Data (complete objects or paramters except userid), PageName, Purchase (for Multiple Areas), Connection to Log DB, UserId
                Logger.Logging.DB_Log(Logger.eLogType.Log_Positive, "", new { x = Id }, "", Purchase, Connection.GetLogConnection(), UserId);
                return ret;
            }
            catch (Exception ex)
            {
                // Logging Here=> Type of Log, Message, Data (complete objects or paramters except userid), PageName, Purchase (for Multiple Areas), Connection to Log DB, Userid
                Logger.Logging.DB_Log(Logger.eLogType.Log_Negative, ex.Message, new { x = Id }, "", Purchase, Connection.GetLogConnection(), UserId);
                return null;
            }
        }


        public List<P_Indent_Detail> Purchase_P_Indent_Detail_Get_By_Cat(int Cat_ID,int UserId)
        {
            try
            {
                //place your Model Logic and DB Calls here:
                this.CreatedBy = UserId;
                List<P_Indent_Detail> ret = DataBase.ExecuteQuery<P_Indent_Detail>(new { a=Cat_ID,x = UserId }, Connection.GetConnection());
                // Logging Here=> Type of Log, Message, Data (complete objects or paramters except userid), PageName, Purchase (for Multiple Areas), Connection to Log DB, UserId
                Logger.Logging.DB_Log(Logger.eLogType.Log_Positive, "", new { x = UserId }, "", Purchase, Connection.GetLogConnection(), UserId);
                return ret;
            }
            catch (Exception ex)
            {
                // Logging Here=> Type of Log, Message, Data (complete objects or paramters except userid), PageName, Purchase (for Multiple Areas), Connection to Log DB, Userid
                Logger.Logging.DB_Log(Logger.eLogType.Log_Negative, ex.Message, new { x = UserId }, "", Purchase, Connection.GetLogConnection(), UserId);
                return null;
            }
        }

        public string Purchase_P_Indent_Detail_Update(int UserId)
        {
            try
            {
                //place your Model Logic and DB Calls here:
                this.CreatedBy = UserId;
                string Message = DataBase.ExecuteQuery<P_Indent_Detail>(new { x = this }, Connection.GetConnection()).FirstOrDefault().ReturnMessage;
                // Logging Here=> Type of Log, Message, Data (complete objects or paramters except userid), PageName, Purchase (for Multiple Areas), Connection to Log DB, UserId
                Logger.Logging.DB_Log(Logger.eLogType.Log_Positive, "", new { x = this }, "", Purchase, Connection.GetLogConnection(), UserId);
                return Message;
            }
            catch (Exception ex)
            {
                // Logging Here=> Type of Log, Message, Data (complete objects or paramters except userid), PageName, Purchase (for Multiple Areas), Connection to Log DB, Userid
                Logger.Logging.DB_Log(Logger.eLogType.Log_Negative, ex.Message, new { x = this }, "", Purchase, Connection.GetLogConnection(), UserId);
                return null;
            }
        }


        public List<P_Indent_Detail> P_Indent_Detail_Get_All(int Cat_ID)
        {
            return new List<P_Indent_Detail>()
            {
            };
        }
    }
}