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
        public static SqlConnection Get()
        {
            if(sc==null || sc.State== System.Data.ConnectionState.Closed)
            {
                sc = new SqlConnection();
                sc.ConnectionString = ConfigurationManager.ConnectionStrings["SfDeskConnection"].ToString(); 
                sc.Open();
            }
            return sc;
        }
        public static string SafeGetString(this SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetString(colIndex);
            return string.Empty;
        }
    }
}