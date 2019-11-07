using DatabaseTVP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class WorkOrder
    {
        private const string Module = "";

        [TVP]
        public int WO_ID { get; set; }
        [TVP]
        public string WO_NO { get; set; }
        [TVP]
        public int Item_ID { get; set; }
        public string Item_Name { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Date")]
        [TVP]
        public DateTime Date { get; set; }
        [TVP]
        [DataType(DataType.Date)]
        [DisplayName("Due Date")]
        public DateTime Due_Date { get; set; }
        [TVP]
        public int Quantity { get; set; }
        [TVP]
        public string Reference { get; set; }
        [TVP]
        public decimal Total { get; set; }
      
   
        [TVP]
        public int CreatedBy { get; set; }
        public string ReturnMessage { get; set; }


        public List<WO_Detail> Input_products { get; set; }
        public List<WO_Detail> Output_products { get; set; }
        public List<WO_Expense> Account_expences { get; set; }

        public List<WorkOrder> WO_Get_All(int UserId)
        {
            try
            {
                //place your Model Logic and DB Calls here:
                this.CreatedBy = UserId;
                List<WorkOrder> ret = DataBase.ExecuteQuery<WorkOrder>(new { x = UserId }, Connection.GetConnection());
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
        public string WO_Add(int UserId)
        {
            try
            {
                //place your Model Logic and DB Calls here:
                this.CreatedBy = UserId;
                Account_expences = Account_expences == null ? new List<WO_Expense>() : Account_expences;

                string Message = DataBase.ExecuteQuery<Recipe>(new { x = Input_products, x1 = Output_products, x3 = Account_expences, x4 = this }, Connection.GetConnection()).FirstOrDefault().ReturnMessage;
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
    public class WO_Detail
    {
    
        [TVP]
        public int WOD_ID { get; set; }
        [TVP]
        public int WO_ID { get; set; }
        [TVP]
        public int Item_ID { get; set; }
        [TVP]
        public string Description { get; set; }
        [TVP]
        public int Quantity { get; set; }
        [TVP]
        public string Flag { get; set; }
        [TVP]
        public decimal Cost { get; set; }
        [TVP]
        public decimal Total { get; set; }

        private const string Module = "";

        //Your Properties for Model Here

        [TVP]
        public int CreatedBy { get; set; }

        public string ReturnMessage { get; set; }
        public List<WO_Detail> WO_Detail_Get_Input(int Wo_ID,int UserId)
        {
            try
            {
                //place your Model Logic and DB Calls here:
                this.CreatedBy = UserId;
                List<WO_Detail> ret = DataBase.ExecuteQuery<WO_Detail>(new { x1 = Wo_ID, x = UserId }, Connection.GetConnection());
                // Logging Here=> Type of Log, Message, Data (complete objects or paramters except userid), PageName, Module (for Multiple Areas), Connection to Log DB, UserId
                Logger.Logging.DB_Log(Logger.eLogType.Log_Positive, "", new { x1 = Wo_ID,x = UserId }, "", Module, Connection.GetLogConnection(), UserId);
                return ret;
            }
            catch (Exception ex)
            {
                // Logging Here=> Type of Log, Message, Data (complete objects or paramters except userid), PageName, Module (for Multiple Areas), Connection to Log DB, Userid
                Logger.Logging.DB_Log(Logger.eLogType.Log_Negative, ex.Message, new { x = UserId }, "", Module, Connection.GetLogConnection(), UserId);
                return null;
            }
        }
        public List<WO_Detail> WO_Detail_Get_Output(int Wo_ID, int UserId)
        {
            try
            {
                //place your Model Logic and DB Calls here:
                this.CreatedBy = UserId;
                List<WO_Detail> ret = DataBase.ExecuteQuery<WO_Detail>(new { x1 = Wo_ID,x = UserId }, Connection.GetConnection());
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


    }
    public class WO_Expense
    {
        private const string Module = "";

       
        [TVP]
        public int WOE_ID { get; set; }
        [TVP]
        public int WO_ID { get; set; }
        [TVP]
        public int COA_ID { get; set; }
        public string COA_Name { get; set; }
        [TVP]

        public string Description { get; set; }
        [TVP]

        public decimal Amount { get; set; }

        [TVP]
        public int CreatedBy { get; set; }

        public string ReturnMessage { get; set; }

        public List<WO_Expense> WO_Expense_Get_All(int Wo_ID, int UserId)
        {
            try
            {
                //place your Model Logic and DB Calls here:
                this.CreatedBy = UserId;
                List<WO_Expense> ret = DataBase.ExecuteQuery<WO_Expense>(new { x1=Wo_ID, x = UserId }, Connection.GetConnection());
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

    }
}