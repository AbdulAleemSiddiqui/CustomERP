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
    public class PO
    {
        #region purchase Order master

        private const string Module = "Purchase";
        [TVP]
        public int PO_ID { get; set; }

        [TVP]
        [DisplayName("P.O #")]
        public string PO_No { get; set; }
      
        [TVP]
        [DisplayName("Supllier Name")]
        public int Suplier_ID { get; set; }
        public string Suplier_Name { get; set; }

        [TVP]
        [DataType(DataType.Date)]
        [DisplayName("Date")]
        public DateTime PO_Date { get; set; } = DateTime.Parse("2001/01/01");

        [TVP]
        [DataType(DataType.Date)]
        [DisplayName("Due Date")]
        public DateTime PO_Due_Date { get; set; } = DateTime.Parse("2001/01/01");

        [TVP]
        [DataType(DataType.MultilineText)]
        public string PO_Comments { get; set; } = "";
    
        [TVP]
        [DisplayName("Middle Man")]
        public int Middle_Man_ID { get; set; }
        public string Middle_Man_Name { get; set; }

        [TVP]
        public decimal Advance { get; set; }


        //public decimal TotalAmount { get; set; }
        //public decimal AllocatedAmount { get; set; }
        //public decimal DueAmount { get; set; }
        //public string AllocatedStatus { get; set; }
        #endregion

        [TVP]
        public string ImagePath { get; set; }
        #region Default
        [TVP]
        public int CreatedBy { get; set; }


        #endregion
        public List<PO_Details> details { get; set; }

        //View Only Properties
        public string ReturnMessage { get; set; }


        public string Purchase_PO_Add(int UserId)
        {
            try
            {
                //place your Model Logic and DB Calls here:
                this.CreatedBy = UserId; 
                string Message = DataBase.ExecuteQuery<PO>(new { x = this }, Connection.GetConnection()).FirstOrDefault().ReturnMessage;
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

        public PO Purchase_PO_Get_By_Id(int Id, int UserId)
        {
            try
            {
                //place your Model Logic and DB Calls here:
                this.CreatedBy = UserId; 
                PO ret = DataBase.ExecuteQuery<PO>(new { x = Id }, Connection.GetConnection()).FirstOrDefault();
                // Logging Here=> Type of Log, Message, Data (complete objects or paramters except userid), PageName, Purchase (for Multiple Areas), Connection to Log DB, UserId
                Logger.Logging.DB_Log(Logger.eLogType.Log_Positive, "", new { x = Id }, "", Module, Connection.GetLogConnection(), UserId);
                return ret;
            }
            catch (Exception ex)
            {
                // Logging Here=> Type of Log, Message, Data (complete objects or paramters except userid), PageName, Purchase (for Multiple Areas), Connection to Log DB, Userid
                Logger.Logging.DB_Log(Logger.eLogType.Log_Negative, ex.Message, new { x = Id }, "", Module, Connection.GetLogConnection(), UserId);
                return null;
            }
        }


        public List<PO> Purchase_PO_Get_All(int UserId)
        {
            try
            {
                //place your Model Logic and DB Calls here:
                this.CreatedBy = UserId; 
                List<PO> ret = DataBase.ExecuteQuery<PO>(new { x = UserId }, Connection.GetConnection());
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

        public string Purchase_PO_Update(int UserId)
        {
            try
            {
                //place your Model Logic and DB Calls here:
                this.CreatedBy = UserId; 
                string Message = DataBase.ExecuteQuery<PO>(new { x = this }, Connection.GetConnection()).FirstOrDefault().ReturnMessage;
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