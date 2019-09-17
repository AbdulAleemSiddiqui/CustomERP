using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class Account_Group
    {
        public int G_ID { get; set; }
        public string G_Name { get; set; }
        public string Nature { get; set; }

        public List<Account_Group> Account_Group_Get_All()
        {
            List<Account_Group> lst = new List<Account_Group>();
            SqlCommand sc = new SqlCommand("Account_Group_Get_All", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                Account_Group u = new Account_Group();
                u.G_ID = (int)sdr["G_ID"];
                u.G_Name = (string)sdr["G_Name"];
                lst.Add(u);

            }
            sdr.Close();
            return lst;
        }
    }
}