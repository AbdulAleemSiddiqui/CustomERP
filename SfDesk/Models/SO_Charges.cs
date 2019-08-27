using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class SO_Charges
    {
        public int SO_Charge_ID { get; set; }
        public int SO_ID { get; set; }
        public int SalesTax_ID { get; set; }
        public string SalesTax_Name { get; set; }
        public decimal Rate { get; set; }
        public decimal Total { get; set; }
        public string action { get; set; }
        #region default Properties
        public int Created_By { get; set; }
        public DateTime Created_Date { get; set; }
        public string Machine_Ip { get; set; }
        public string Mac_Address { get; set; }
        #endregion
        public SO_Charges()
        {
            this.Machine_Ip = Utility.GetIPAddress();
            this.Mac_Address = Utility.GetMacAddress();
        }

        public List<SO_Charges> SO_Charges_Get_All()
        {
            List<SO_Charges> lst = new List<SO_Charges>();
            SqlCommand sc = new SqlCommand("SO_Charges_Get_All", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@SO_ID", SO_ID);
            sc.Parameters.AddWithValue("@App_ID", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                SO_Charges u = new SO_Charges();
                u.SO_Charge_ID = (int)sdr["SO_Charge_ID"];
                u.SO_ID = (int)sdr["SO_ID"];
                u.SalesTax_ID = (int)sdr["ST_ID"];
                u.SalesTax_Name = (string)sdr["Name"];
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
        public SO_Charges SO_Charges_Get_BY_ID()
        {
            SO_Charges u = new SO_Charges();
            SqlCommand sc = new SqlCommand("SO_Charges_Get_BY_ID", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@SO_Charge_ID", SO_Charge_ID);
            sc.Parameters.AddWithValue("@App_SO_Charge_ID", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                u.SO_Charge_ID = (int)sdr["SO_Charge_ID"];
                u.SO_ID = (int)sdr["SO_ID"];
                u.SalesTax_ID = (int)sdr["ST_ID"];
                u.SalesTax_Name = (string)sdr["ST_Name"];
                u.Rate = (decimal)sdr["Rate"];
                u.Created_By = (int)sdr["CreatedBy"];
                u.Created_Date = (DateTime)sdr["CreatedDate"];
                u.Machine_Ip = (string)sdr["Machine_Ip"];
                u.Mac_Address = (string)sdr["Mac_Address"];
            }
            sdr.Close();
            return u;
        }
        public void SO_Charges_Add()
        {
            SqlCommand sc = new SqlCommand("SO_Charges_Add", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@SO_ID", SO_ID);
            sc.Parameters.AddWithValue("@ST_ID", SalesTax_ID);
            sc.Parameters.AddWithValue("@Rate", Rate);
            sc.Parameters.AddWithValue("@Total", Total);
            sc.Parameters.AddWithValue("@Machine_Ip", Machine_Ip);
            sc.Parameters.AddWithValue("@Mac_Address", Mac_Address);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);
            sc.ExecuteNonQuery();

        }
        public void SO_Charges_Update()
        {
            SqlCommand sc = new SqlCommand("SO_Charges_Update", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@SO_Charge_ID", SO_Charge_ID);
            sc.Parameters.AddWithValue("@SO_ID", SO_ID);
            sc.Parameters.AddWithValue("@ST_ID", SalesTax_ID);
            sc.ExecuteNonQuery();
        }
        public void SO_Charges_Delete()
        {
            SqlCommand sc = new SqlCommand("SO_Charges_Delete", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@SO_Charge_ID", SO_Charge_ID);
            sc.Parameters.AddWithValue("@App_ID", App.App_ID);
            sc.ExecuteNonQuery();
        }
    }
}