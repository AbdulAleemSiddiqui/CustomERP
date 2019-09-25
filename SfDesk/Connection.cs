using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SfDesk
{
    public static class Connection
    {
        static SqlConnection sc;
        static SqlConnection sc_Log;
        public static SqlConnection GetConnection()
        {
            if(sc== null || sc.State == System.Data.ConnectionState.Closed)
            {
                sc = new SqlConnection();
                sc.ConnectionString = ConfigurationManager.ConnectionStrings["SfDeskConnection"].ToString(); 
                sc.Open();
            }
            return sc;
        }
        public static SqlConnection GetLogConnection()
        {
            if (sc_Log == null || sc_Log.State == System.Data.ConnectionState.Closed)
            {
                sc_Log = new SqlConnection();
                sc_Log.ConnectionString = ConfigurationManager.ConnectionStrings["SfDesk_LogConnection"].ToString();
                sc_Log.Open();
            }
            return sc_Log;
        }

        public static string SafeGetString(this SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetString(colIndex);
            return string.Empty;
        }
    }
}