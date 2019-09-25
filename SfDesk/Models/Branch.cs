using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class Branch
    {
        public int B_ID { get; set; }
        public string B_Name { get; set; }
        public int C_ID { get; set; }
        public string C_Name { get; set; }

        public List<Branch> Branch_Get_All(int UserID)
        {
            List<Branch> lst = new List<Branch>();

            SqlCommand sc = new SqlCommand("Branch_Get_All", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@ParamTable1", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {

                Branch u = new Branch();
                u.B_ID= (int)sdr["B_ID"];
                u.B_Name = (string)sdr["B_Name"];
                u.C_ID = (int)sdr["C_ID"];
                lst.Add(u);
            }
            sdr.Close();
            return lst;
        }
    }
}