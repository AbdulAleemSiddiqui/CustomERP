using DatabaseTVP;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class Expense
    {
        [TVP]
        public int Ex_ID { get; set; }
        [TVP]
        public string Ex_NO { get; set; }
        [TVP]
        public int COA_ID { get; set; }
        public string COA_Name { get; set; }
        [DataType(DataType.Date)]
        [TVP]
        public DateTime Date { get; set; }
        [TVP]
        public int Contact_ID { get; set; }
        [TVP]
        public string Contact_Table { get; set; }
        [TVP]
        public string       Contact_Name{ get; set; }
        [TVP]
        public string Reference { get; set; }
        [DataType(DataType.MultilineText)]
        [TVP]
        public string Comment { get; set; }
        [TVP]
        public decimal Total{ get; set; }
        [TVP]
        public string Img_Path { get; set; }
        [TVP]
        public int CreatedBy { get; set; }
        public string ReturnMessage { get; set; }
        public List<Expence_Detail> details { get; set; }

        private const string Module = "Accounts";


        public string Accounts_Expense_Add(int UserId)
        {   
            try
            {
                //place your Model Logic and DB Calls here:
                this.CreatedBy = UserId; 
                string Message = DataBase.ExecuteQuery<Expense>(new { x = this,x1=details }, Connection.GetConnection()).FirstOrDefault().ReturnMessage;
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

        public List<Contact_ViewModel> Accounts_Expense_Get_Contacts( int UserId)
        {
            try
            {
                //place your Model Logic and DB Calls here:
                this.CreatedBy = UserId;
               List<Contact_ViewModel>  ret = DataBase.ExecuteQuery<Contact_ViewModel>(new { x = UserId }, Connection.GetConnection());
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

        public Expense Accounts_Expense_Get_By_Id(int Id, int UserId)
        {
            try
            {
                //place your Model Logic and DB Calls here:
                this.CreatedBy = UserId; 
                Expense ret = DataBase.ExecuteQuery<Expense>(new { x = Id }, Connection.GetConnection()).FirstOrDefault();
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


        public List<Expense> Accounts_Expense_Get_All(int UserId)
        {
            try
            {
                //place your Model Logic and DB Calls here:
                this.CreatedBy = UserId; 
                List<Expense> ret = DataBase.ExecuteQuery<Expense>(new { x = UserId }, Connection.GetConnection());
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

        public string Accounts_Expense_Update(int UserId)
        {
            try
            {
                //place your Model Logic and DB Calls here:
                this.CreatedBy = UserId; 
                string Message = DataBase.ExecuteQuery<Expense>(new { x = this }, Connection.GetConnection()).FirstOrDefault().ReturnMessage;
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
    public class Expence_Detail
    {
        [TVP]
        public int Ex_D_ID { get; set; }
        [TVP]
        public int Ex_ID { get; set; }
        [TVP]
        public int COA_ID { get; set; }
        public string COA_Name { get; set; }
        [TVP]
        public string Description { get; set; }
        [TVP]
        public decimal   Gross_Amount { get; set; }
        [TVP]
        public int Tax_ID { get; set; }
        public string Tax_Name { get; set; }
        [TVP]
        public decimal Net_Amount { get; set; }
        [TVP]
        public int CreatedBy { get; set; }
        public string ReturnMessage { get; set; }

        private const string Module = "Accounts";



        #region methods
        //Your Properties for Model Here




        //public string Accounts_Expence_Detail_Add(int UserId)
        //{   
        //    try
        //    {
        //        //place your Model Logic and DB Calls here:
        //        this.CreatedBy = UserId; 
        //        string Message = DataBase.ExecuteQuery<Expence_Detail>(new { x = this }, Connection.GetConnection()).FirstOrDefault().ReturnMessage;
        //        // Logging Here=> Type of Log, Message, Data (complete objects or paramters except userid), PageName, Module (for Multiple Areas), Connection to Log DB, UserId
        //        Logger.Logging.DB_Log(Logger.eLogType.Log_Positive, "", new { x = this }, "", Module, Connection.GetLogConnection(), UserId);
        //        return Message;
        //    }
        //    catch (Exception ex)
        //    {
        //        // Logging Here=> Type of Log, Message, Data (complete objects or paramters except userid), PageName, Module (for Multiple Areas), Connection to Log DB, Userid
        //        Logger.Logging.DB_Log(Logger.eLogType.Log_Negative, ex.Message, new { x = this }, "", Module, Connection.GetLogConnection(), UserId);
        //        return null;
        //    }
        //}

        //public Expence_Detail Accounts_Expence_Detail_Get_By_Id(int Id, int UserId)
        //{
        //    try
        //    {
        //        //place your Model Logic and DB Calls here:
        //        this.CreatedBy = UserId; 
        //        Expence_Detail ret = DataBase.ExecuteQuery<Expence_Detail>(new { x = Id }, Connection.GetConnection()).FirstOrDefault();
        //        // Logging Here=> Type of Log, Message, Data (complete objects or paramters except userid), PageName, Module (for Multiple Areas), Connection to Log DB, UserId
        //        Logger.Logging.DB_Log(Logger.eLogType.Log_Positive, "", new { x = Id }, "", Module, Connection.GetLogConnection(), UserId);
        //        return ret;
        //    }
        //    catch (Exception ex)
        //    {
        //        // Logging Here=> Type of Log, Message, Data (complete objects or paramters except userid), PageName, Module (for Multiple Areas), Connection to Log DB, Userid
        //        Logger.Logging.DB_Log(Logger.eLogType.Log_Negative, ex.Message, new { x = Id }, "", Module, Connection.GetLogConnection(), UserId);
        //        return null;
        //    }
        //}


        //public List<Expence_Detail> Accounts_Expence_Detail_Get_All(int UserId)
        //{
        //    try
        //    {
        //        //place your Model Logic and DB Calls here:
        //        this.CreatedBy = UserId; 
        //        List<Expence_Detail> ret = DataBase.ExecuteQuery<Expence_Detail>(new { x = UserId }, Connection.GetConnection());
        //        // Logging Here=> Type of Log, Message, Data (complete objects or paramters except userid), PageName, Module (for Multiple Areas), Connection to Log DB, UserId
        //        Logger.Logging.DB_Log(Logger.eLogType.Log_Positive, "", new { x = UserId }, "", Module, Connection.GetLogConnection(), UserId);
        //        return ret;
        //    }
        //    catch (Exception ex)
        //    {
        //        // Logging Here=> Type of Log, Message, Data (complete objects or paramters except userid), PageName, Module (for Multiple Areas), Connection to Log DB, Userid
        //        Logger.Logging.DB_Log(Logger.eLogType.Log_Negative, ex.Message, new { x = UserId }, "", Module, Connection.GetLogConnection(), UserId);
        //        return null;
        //    }
        //}

        //public string Accounts_Expence_Detail_Update(int UserId)
        //{
        //    try
        //    {
        //        //place your Model Logic and DB Calls here:
        //        this.CreatedBy = UserId; 
        //        string Message = DataBase.ExecuteQuery<Expence_Detail>(new { x = this }, Connection.GetConnection()).FirstOrDefault().ReturnMessage;
        //        // Logging Here=> Type of Log, Message, Data (complete objects or paramters except userid), PageName, Module (for Multiple Areas), Connection to Log DB, UserId
        //        Logger.Logging.DB_Log(Logger.eLogType.Log_Positive, "", new { x = this }, "", Module, Connection.GetLogConnection(), UserId);
        //        return Message;
        //    }
        //    catch (Exception ex)
        //    {
        //        // Logging Here=> Type of Log, Message, Data (complete objects or paramters except userid), PageName, Module (for Multiple Areas), Connection to Log DB, Userid
        //        Logger.Logging.DB_Log(Logger.eLogType.Log_Negative, ex.Message, new { x = this }, "", Module, Connection.GetLogConnection(), UserId);
        //        return null;
        //    }
        //}

        #endregion


    }

    public class Contact_ViewModel
    {
        public int Contact_ID { get; set; }
        public string Contact_Name { get; set; }
        public string Contact_Table { get; set; }
    }
}