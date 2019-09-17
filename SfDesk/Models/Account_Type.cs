using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class Account_Type
    {
        public int Type_ID { get; set; }
        public string Type_Name { get; set; }

        public List<Account_Type> Account_Type_Get_All()
        {
            List<Account_Type> lst = new List<Account_Type>();
            SqlCommand sc = new SqlCommand("Account_Type_Get_All", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                Account_Type u = new Account_Type();
                u.Type_ID = (int)sdr["Type_ID"];
                u.Type_Name = (string)sdr["Type_Name"];
                lst.Add(u);

            }
            sdr.Close();
            return lst;
        }
    }
}