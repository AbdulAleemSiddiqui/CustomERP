using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class SO_Transactions
    {
        public int _ID { get; set; }
        public int SO_ID { get; set; }
        public int SOT_ID { get; set; }
        public int T_ID { get; set; }
        public string Name { get; set; }
        public decimal Rate { get; set; }
        public decimal Total { get; set; }
        public bool is_Transporter { get; set; }
        public bool is_MiddleMan { get; set; }
        public string action { get; set; }

        #region default Properties
        public int Created_By { get; set; }
        public DateTime Created_Date { get; set; }
        public string Machine_Ip { get; set; }
        public string Mac_Address { get; set; }
        #endregion
        public SO_Transactions()
        {
            this.Machine_Ip = Utility.GetIPAddress();
            this.Mac_Address = Utility.GetMacAddress();
        }

        public List<SO_Transactions> SO_Transactions_Get_All()
        {
            List<SO_Transactions> lst = new List<SO_Transactions>();
            SqlCommand sc = new SqlCommand("SO_Transactions_Get_All", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@SO_ID", SO_ID);
            sc.Parameters.AddWithValue("@App_ID", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                SO_Transactions u = new SO_Transactions();
                u.SOT_ID = (int)sdr["SOT_ID"];
                u.SO_ID = (int)sdr["SO_ID"];
                u.T_ID = (int)sdr["T_ID"];
                u.Name = (string)sdr["Name"];
                u.Rate = (decimal)sdr["Rate"];
                u.Total = (decimal)sdr["Total"];
                u.is_MiddleMan = (bool)sdr["is_MiddleMan"];
                u.is_Transporter = (bool)sdr["is_Transporter"];
                u.Created_By = (int)sdr["CreatedBy"];
                u.Created_Date = (DateTime)sdr["CreatedDate"];
                u.Machine_Ip = (string)sdr["Machine_Ip"];
                u.Mac_Address = (string)sdr["Mac_Address"];
                lst.Add(u);
            }
            sdr.Close();
            return lst;
        }

        public SO_Transactions SO_Transactions_Get_BY_ID()
        {
            SO_Transactions u = new SO_Transactions();
            SqlCommand sc = new SqlCommand("SO_Transactions_Get_BY_ID", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@SOT_ID", SOT_ID);
            sc.Parameters.AddWithValue("@App_SOT_ID", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                u.SOT_ID = (int)sdr["SOT_ID"];
                u.SO_ID = (int)sdr["SO_ID"];
                u.T_ID = (int)sdr["ST_ID"];
                u.Name = (string)sdr["ST_Name"];
                u.Rate = (decimal)sdr["Rate"];
                u.Total = (decimal)sdr["Total"];
                u.is_MiddleMan = (bool)sdr["is_MiddleMan"];
                u.is_Transporter = (bool)sdr["is_Transporter"];
                u.Created_By = (int)sdr["CreatedBy"];
                u.Created_Date = (DateTime)sdr["CreatedDate"];
                u.Machine_Ip = (string)sdr["Machine_Ip"];
                u.Mac_Address = (string)sdr["Mac_Address"];
            }
            sdr.Close();
            return u;
        }
        public void SO_Transactions_Add()
        {
            SqlCommand sc = new SqlCommand("PI_Transaction_Add", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@SO_ID", SO_ID);
            sc.Parameters.AddWithValue("@T_ID", T_ID);
            sc.Parameters.AddWithValue("@is_Transporter", is_Transporter);
            sc.Parameters.AddWithValue("@is_MiddleMan", is_MiddleMan);
            sc.Parameters.AddWithValue("@Rate", Rate);
            sc.Parameters.AddWithValue("@Total", Total);
            sc.Parameters.AddWithValue("@Machine_Ip", Machine_Ip);
            sc.Parameters.AddWithValue("@Mac_Address", Mac_Address);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);
            sc.ExecuteNonQuery();

        }
        public void SO_Transactions_Update()
        {
            SqlCommand sc = new SqlCommand("SO_Transactions_Update", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@SOT_ID", SOT_ID);
            sc.Parameters.AddWithValue("@SO_ID", SO_ID);
            sc.Parameters.AddWithValue("@ST_ID", T_ID);
            sc.Parameters.AddWithValue("@is_MiddleMan", is_MiddleMan);
            sc.Parameters.AddWithValue("@is_Transporter", is_Transporter);
            sc.ExecuteNonQuery();
        }
        public void SO_Transactions_Delete()
        {
            SqlCommand sc = new SqlCommand("PI_Transaction_Delete", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@SOT_ID", SOT_ID);
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);
            sc.ExecuteNonQuery();
        }
    }
}