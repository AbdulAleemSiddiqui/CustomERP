using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class Currency
    {
        public int C_ID { get; set; }
        public string C_Name { get; set; }
        public string Prefix { get; set; }

        public List<Currency> Currency_Get_All(int UserID)
        {
            List<Currency> lst = new List<Currency>();

            SqlCommand sc = new SqlCommand("Currency_Get_All", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@ParamTable1", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {

                Currency u = new Currency();
                u.C_ID = (int)sdr["C_ID"];
                u.C_Name = (string)sdr["Name"];
                u.Prefix = (string)sdr["Prefix"];
                lst.Add(u);
            }
            sdr.Close();
            return lst;
        }
    }
}