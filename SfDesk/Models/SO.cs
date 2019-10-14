using DatabaseTVP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class SO
    {
        private const string Module = "Sale";
     
        [TVP]
        public int SO_ID { get; set; }
        [TVP]
        public string SO_NO { get; set; }
        [TVP]
        public int Q_ID { get; set; }
        [TVP]
        public int Transporter_ID { get; set; }
        [TVP]
        public int Customer_ID { get; set; }
        [TVP]
        public int SalesMan_ID { get; set; }
        [TVP]
        public int Currency_ID { get; set; }
        [TVP]
        public int Branch_ID { get; set; }

        [TVP]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        [DisplayName("Delivery Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [TVP]
        public DateTime Delivery_Date { get; set; } = DateTime.Now.AddDays(10);
        [TVP]
        public string Img_Path { get; set; }
        [TVP]
        [DataType(DataType.MultilineText)]
        public string Comments { get; set; } = "";
        [TVP]
        public decimal Total { get; set; }
        [TVP]
        public int CreatedBy { get; set; }


        public string Transporter_Name { get; set; }
        public string Branch_Name { get; set; }
        public string Customer_Name { get; set; }
        public string Salesman_Name { get; set; }
        //View Only Properties
        public string ReturnMessage { get; set; }
        public string Currency_Name { get; set; }

        public List<SO_Detail> SO_Details { get; set; }
        public List<SO_Charge> SO_Charges { get; set; }
        public List<SO_Tax> SO_Taxs { get; set; }
        public int Sale_SO_Add(int UserId)
        {
            try
            {
                //place your Model Logic and DB Calls here:
                this.CreatedBy = UserId;
                DataBase.ExecuteQuery<SO>(new { x = this, x1 = SO_Details, x2 = SO_Charges, x3 = SO_Taxs }, Connection.GetConnection());
                // Logging Here=> Type of Log, Message, Data (complete objects or paramters except userid), PageName, Module (for Multiple Areas), Connection to Log DB, UserId
                Logger.Logging.DB_Log(Logger.eLogType.Log_Positive, "", new { x = this }, "", Module, Connection.GetLogConnection(), UserId);
                return 1;
            }
            catch (Exception ex)
            {
                // Logging Here=> Type of Log, Message, Data (complete objects or paramters except userid), PageName, Module (for Multiple Areas), Connection to Log DB, Userid
                Logger.Logging.DB_Log(Logger.eLogType.Log_Negative, ex.Message, new { x = this }, "", Module, Connection.GetLogConnection(), UserId);
                return 0;
            }
        }

        public SO Sale_SO_Get_By_Id(int Id, int UserId)
        {
            try
            {
                //place your Model Logic and DB Calls here:
                this.CreatedBy = UserId;
                SO ret = DataBase.ExecuteQuery<SO>(new { x = Id,x1=UserId }, Connection.GetConnection()).FirstOrDefault();
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

        public List<SO> Sale_SO_Get_All(int UserId)
        {
            try
            {
                //place your Model Logic and DB Calls here:
                this.CreatedBy = UserId;
                List<SO> ret = DataBase.ExecuteQuery<SO>(new { x = UserId }, Connection.GetConnection());
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

        public string Sale_SO_Update(int UserId)
        {
            try
            {
                //place your Model Logic and DB Calls here:
                this.CreatedBy = UserId;
                string Message = DataBase.ExecuteQuery<SO>(new { x = this }, Connection.GetConnection()).FirstOrDefault().ReturnMessage;
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


        // qk hamare ko na SO ka model mangta he 
        public SO Sale_SO_Get_Quotation(int Id, int UserId)
        {
            try
            {
                //place your Model Logic and DB Calls here:
                this.CreatedBy = UserId;
                SO ret = DataBase.ExecuteQuery<SO>(new { x = Id, xq = UserId }, Connection.GetConnection()).FirstOrDefault();
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

        public int Sale_SO_Approve(int UserId)
        {
            try
            {
                //place your Model Logic and DB Calls here:
                this.CreatedBy = UserId;
                DataBase.ExecuteQuery<SO>(new { x = this }, Connection.GetConnection());
                // Logging Here=> Type of Log, Message, Data (complete objects or paramters except userid), PageName, Module (for Multiple Areas), Connection to Log DB, UserId
                Logger.Logging.DB_Log(Logger.eLogType.Log_Positive, "", new { x = this }, "", Module, Connection.GetLogConnection(), UserId);
                return 1;
            }
            catch (Exception ex)
            {
                // Logging Here=> Type of Log, Message, Data (complete objects or paramters except userid), PageName, Module (for Multiple Areas), Connection to Log DB, Userid
                Logger.Logging.DB_Log(Logger.eLogType.Log_Negative, ex.Message, new { x = this }, "", Module, Connection.GetLogConnection(), UserId);
                return 0;
            }
        }

    
    }
}
