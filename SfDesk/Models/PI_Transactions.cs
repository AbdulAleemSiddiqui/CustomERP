using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{

    public class PI_Transactions
    {
        public int PI_ID { get; set; }
        public int PIT_ID { get; set; }
        public int T_ID { get; set; }
        public string T_Name { get; set; }
        public decimal Rate { get; set; }

        #region default Properties
        public int Created_By { get; set; }
        public DateTime Created_Date { get; set; }
        public string Machine_Ip { get; set; }
        public string Mac_Address { get; set; }
        #endregion
        public PI_Transactions()
        {
            this.Machine_Ip = Utility.GetIPAddress();
            this.Mac_Address = Utility.GetMacAddress();
        }

        public List<PI_Transactions> PI_Transactions_Get_All()
        {
            List<PI_Transactions> lst = new List<PI_Transactions>();
            SqlCommand sc = new SqlCommand("PI_Transactions_Get_All", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@PI_ID", PI_ID);
            sc.Parameters.AddWithValue("@App_ID", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                PI_Transactions u = new PI_Transactions();
                u.PIT_ID = (int)sdr["PIT_ID"];
                u.PI_ID = (int)sdr["PI_ID"];
                u.T_ID = (int)sdr["T_ID"];
                u.T_Name = (string)sdr["Name"];
                u.Rate = (decimal)sdr["Rate"];
                u.Created_By = (int)sdr["CreatedBy"];
                u.Created_Date = (DateTime)sdr["CreatedDate"];
                u.Machine_Ip = (string)sdr["Machine_Ip"];
                u.Mac_Address = (string)sdr["Mac_Address"];
                lst.Add(u);
            }
            sdr.Close();
            return lst;
        }

        public PI_Transactions PI_Transactions_Get_BY_ID()
        {
            PI_Transactions u = new PI_Transactions();
            SqlCommand sc = new SqlCommand("PI_Transactions_Get_BY_ID", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@PIT_ID", PIT_ID);
            sc.Parameters.AddWithValue("@App_PIT_ID", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                u.PIT_ID = (int)sdr["PIT_ID"];
                u.PI_ID = (int)sdr["PI_ID"];
                u.T_ID = (int)sdr["ST_ID"];
                u.T_Name = (string)sdr["ST_Name"];
                u.Rate = (decimal)sdr["Rate"];
                u.Created_By = (int)sdr["CreatedBy"];
                u.Created_Date = (DateTime)sdr["CreatedDate"];
                u.Machine_Ip = (string)sdr["Machine_Ip"];
                u.Mac_Address = (string)sdr["Mac_Address"];
            }
            sdr.Close();
            return u;
        }
        public void PI_Transactions_Add()
        {
            SqlCommand sc = new SqlCommand("PI_Transaction_Add", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@PI_ID", PI_ID);
            sc.Parameters.AddWithValue("@T_ID", T_ID);
            sc.Parameters.AddWithValue("@Machine_Ip", Machine_Ip);
            sc.Parameters.AddWithValue("@Mac_Address", Mac_Address);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);
            sc.ExecuteNonQuery();

        }
        public void PI_Transactions_Update()
        {
            SqlCommand sc = new SqlCommand("PI_Transactions_Update", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@PIT_ID", PIT_ID);
            sc.Parameters.AddWithValue("@PI_ID", PI_ID);
            sc.Parameters.AddWithValue("@ST_ID", T_ID);
            sc.ExecuteNonQuery();
        }
        public void PI_Transactions_Delete()
        {
            SqlCommand sc = new SqlCommand("PI_Transaction_Delete", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@PIT_ID", PIT_ID);
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);
            sc.ExecuteNonQuery();
        }
    }
}