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
    public class GDN
    {
        private const string Module = "Sale";
        public int GDN_ID { get; set; }
        public string GDN_NO { get; set; }
        public int SO_ID { get; set; }

        [TVP]
        public int Transporter_ID { get; set; }

        [TVP]
        public int Customer_ID { get; set; }
        [TVP]
        public int Store_ID { get; set; }
        [TVP]
        public int Currency_ID { get; set; }
        [TVP]
        public int Branch_ID { get; set; }
        [TVP]
        public int Vehicle_ID { get; set; }
      
      
   

        [DisplayName("Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public string Img_Path { get; set; }

        [DisplayName("Shipping Address")]
        public string ShippingAddress { get; set; } = "";
        public string Currency_Name { get; set; }

        public string Branch_Name { get; set; }
        public string Store_Name { get; set; }

        public string Vehicle_No { get; set; }
        [DisplayName("Transporter Name")]
        public string Transporter_Name { get; set; }
        public string Customer_Name { get; set; }

        public string Comments { get; set; }
        public int CreatedBy { get; set; }

        public List<SO> Sale_GDN_Get_All_SO(int UserId)
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

        public GDN Sale_GDN_Get_SO(int Id, int UserId)
        {
            try
            {
                //place your Model Logic and DB Calls here:
                this.CreatedBy = UserId;
                GDN ret = DataBase.ExecuteQuery<GDN>(new { x = Id, xq = UserId }, Connection.GetConnection()).FirstOrDefault();
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
    }
}