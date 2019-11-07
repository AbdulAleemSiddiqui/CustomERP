﻿using DatabaseTVP;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{

    public class Item
    {
        private const string Module = "Purchase";

        [TVP]
        public int Item_ID { get; set; }
        [TVP]
        public string Item_Name { get; set; }

        [TVP]
        public string Item_Code { get; set; }

        [TVP]
        public int Cat_ID { get; set; }
        [TVP]
        public string Unit { get; set; }

        [TVP]
        public int COA_ID { get; set; }

        [TVP]
        public int Min_Stock { get; set; }
        [TVP]
        public bool is_Fractional_Unit { get; set; }
        [TVP]
        public bool is_Item_Qty_Cal { get; set; }
        [TVP]
        public bool is_Inventory_Track{ get; set; }
        [TVP]
        public bool is_Manage_Batch_Product{ get; set; }

       
        public string Cat_Name { get; set; }
        public string ICM_Name { get; set; }
        public string COA_Name { get; set; }

        public Item_Detail Sale { get; set; } = new Item_Detail() { Flag = "sale" };
        public Item_Detail Purchase { get; set; } = new Item_Detail() { Flag = "purchase" };

        #region default Properties
        [TVP]
        public int CreatedBy { get; set; }
        public string ReturnMessage { get; set; }

        #endregion


    
        public string Item_Add(int UserId)
        {
            try
            {
                //place your Model Logic and DB Calls here:
                this.CreatedBy = UserId;
               
                ReturnMessage = DataBase.ExecuteQuery<Item>(new { x = this,x1=Purchase,x2=Sale }, Connection.GetConnection()).FirstOrDefault().ReturnMessage;
                 // Logging Here=> Type of Log, Message, Data (complete objects or paramters except userid), PageName, Module (for Multiple Areas), Connection to Log DB, UserId
                 Logger.Logging.DB_Log(Logger.eLogType.Log_Positive, "", new { x = this }, "", Module, Connection.GetLogConnection(), UserId);
                return ReturnMessage;
            }
            catch (Exception ex)
            {
                // Logging Here=> Type of Log, Message, Data (complete objects or paramters except userid), PageName, Module (for Multiple Areas), Connection to Log DB, Userid
                Logger.Logging.DB_Log(Logger.eLogType.Log_Negative, ex.Message, new { x = this }, "", Module, Connection.GetLogConnection(), UserId);
                return "";
            }
        }

        public Item Item_Get_By_ID(int Id, int UserId)
        {
            try
            {
                //place your Model Logic and DB Calls here:
                this.CreatedBy = UserId;
                Item ret = DataBase.ExecuteQuery<Item>(new { x = Id }, Connection.GetConnection()).FirstOrDefault();
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


        public List<Item> Item_Get_All(int UserId)
        {
            try
            {
                //place your Model Logic and DB Calls here:
                this.CreatedBy = UserId;
                List<Item> ret = DataBase.ExecuteQuery<Item>(new { x = UserId }, Connection.GetConnection());
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

        public string Item_Update(int UserId)
        {
            try
            {
                //place your Model Logic and DB Calls here:
                this.CreatedBy = UserId;
                string Message = DataBase.ExecuteQuery<Item>(new { x = this }, Connection.GetConnection()).FirstOrDefault().ReturnMessage;
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

        public List<Item> Item_Get_All_Finish_Good(int UserId)
        {
            try
            {
                //place your Model Logic and DB Calls here:
                this.CreatedBy = UserId;
                List<Item> ret = DataBase.ExecuteQuery<Item>(new { x = UserId }, Connection.GetConnection());
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
    public class Item_Detail
    {
        [TVP]
        public int Item_D_ID { get; set; }
        [TVP]
        public int Item_ID { get; set; }
        [TVP]
        public decimal Price { get; set; }
        [TVP]
        public int Account_ID { get; set; }
        [TVP]
        public int Discount_Account_ID { get; set; }
        [TVP]
        public int Tax_ID { get; set; }
        [TVP]
        public string Flag{ get; set; }
        #region default Properties
        [TVP]
        public int CreatedBy { get; set; }
        public string ReturnMessage { get; set; }

        #endregion
    }
    }