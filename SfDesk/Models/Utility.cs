using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Web;

namespace SfDesk.Models
{
    public class Utility
    {
        public static string GetMacAddress()
        {
            return
              (
                  from nic in NetworkInterface.GetAllNetworkInterfaces()
                  where nic.OperationalStatus == OperationalStatus.Up
                  select nic.GetPhysicalAddress().ToString()
              ).FirstOrDefault();
        }
        public static string GetIPAddress()
        {
            string hostName = Dns.GetHostName();
            return Dns.GetHostByName(hostName).AddressList[0].ToString();
        }
        public static string GetMenu(int U_ID)
        {
            return "";
        }
        public static string Get_New_No(string tbl, string col, string code, int App_ID)
        {
            try
            {
                SqlCommand sc = new SqlCommand("Get_New_No", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure };
                sc.Parameters.AddWithValue("@Tabel", tbl);
                sc.Parameters.AddWithValue("@Column", col);
                sc.Parameters.AddWithValue("@Code", code);
                sc.Parameters.AddWithValue("@App_ID", App_ID);
                sc.Parameters.Add("@Result", SqlDbType.NVarChar,50);
                sc.Parameters["@Result"].Direction = ParameterDirection.Output;
                sc.ExecuteNonQuery();
                return ((string)sc.Parameters["@Result"].Value).ToString();
            }
            catch (Exception ex)
            {
                // Logging Here=> Type of Log, Message, Data (complete objects or paramters except userid), PageName, Purchase (for Multiple Areas), Connection to Log DB, Userid
                Logger.Logging.DB_Log(Logger.eLogType.Log_Negative, ex.Message, new { x = App_ID }, "", "Utility", Connection.GetLogConnection(), App_ID);
                return null;
            }
        }
    }
}