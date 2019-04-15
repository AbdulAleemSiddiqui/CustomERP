using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class PI_Charge
    {
        public int PI_Charge_ID { get; set; }
        public int PI_ID { get; set; }
        public string Charge_Name { get; set; }
        public decimal Charge_Percent { get; set; }
        public decimal Charge_Total { get; set; }


        #region default Properties
        public int Created_By { get; set; }
        public DateTime Created_Date { get; set; }
        public string Machine_Ip { get; set; }
        public string Mac_Address { get; set; }
        #endregion
        public PI_Charge()
        {
            this.Machine_Ip = Utility.GetIPAddress();
            this.Mac_Address = Utility.GetMacAddress();
        }

        public List<PI_Charge> PI_Charge_Get_All()
        {
            List<PI_Charge> lst = new List<PI_Charge>();
            SqlCommand sc = new SqlCommand("PI_Charge_Get_All", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@App_PI_Charge_ID", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                PI_Charge u = new PI_Charge();
                u.PI_Charge_ID = (int)sdr["PI_Charge_ID"];
                u.PI_ID = (int)sdr["PI_ID"];
                u.Charge_Name = (string)sdr["Charge_Name"];
                u.Charge_Percent = (decimal)sdr["Charge_Percent"];
                u.Charge_Total = (decimal)sdr["Charge_Total"];
                u.Created_By = (int)sdr["CreatedBy"];
                u.Created_Date = (DateTime)sdr["CreatedDate"];
                u.Machine_Ip = (string)sdr["Machine_Ip"];
                u.Mac_Address = (string)sdr["Mac_Address"];
                lst.Add(u);
            }
            sdr.Close();
            return lst;
        }
        public PI_Charge PI_Charge_Get_By_PI_Charge_ID()
        {
            PI_Charge u = new PI_Charge();
            SqlCommand sc = new SqlCommand("PI_Charge_Get_By_PI_Charge_ID", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@PI_Charge_ID", PI_Charge_ID);
            sc.Parameters.AddWithValue("@App_PI_Charge_ID", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                u.PI_Charge_ID = (int)sdr["PI_Charge_ID"];
                u.PI_ID = (int)sdr["PI_ID"];
                u.Charge_Name = (string)sdr["Charge_Name"];
                u.Charge_Percent = (decimal)sdr["Charge_Percent"];
                u.Charge_Total = (decimal)sdr["Charge_Total"];
                u.Created_By = (int)sdr["CreatedBy"];
                u.Created_Date = (DateTime)sdr["CreatedDate"];
                u.Machine_Ip = (string)sdr["Machine_Ip"];
                u.Mac_Address = (string)sdr["Mac_Address"];
            }
            sdr.Close();
            return u;
        }
        public void PI_Charge_Add()
        {
            SqlCommand sc = new SqlCommand("PI_Charge_Add", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@PI_ID", PI_ID);
            sc.Parameters.AddWithValue("@Charge_Name", Charge_Name);
            sc.Parameters.AddWithValue("@Charge_Percent", Charge_Percent);
            sc.Parameters.AddWithValue("@Charge_Total", Charge_Total);
            sc.Parameters.AddWithValue("@Machine_Ip", Machine_Ip);
            sc.Parameters.AddWithValue("@Mac_Address", Mac_Address);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);
            sc.ExecuteNonQuery();

        }
        public void PI_Charge_Update()
        {
            SqlCommand sc = new SqlCommand("PI_Charge_Update", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@PI_Charge_ID", PI_Charge_ID);
            sc.Parameters.AddWithValue("@PI_ID", PI_ID);
            sc.Parameters.AddWithValue("@Charge_Name", Charge_Name);
            sc.Parameters.AddWithValue("@Charge_Percent", Charge_Percent);
            sc.Parameters.AddWithValue("@Charge_Total", Charge_Total);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);
            sc.ExecuteNonQuery();
        }
        public void PI_Charge_Delete()
        {
            SqlCommand sc = new SqlCommand("PI_Charge_Delete", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@PI_Charge_ID", PI_Charge_ID);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);
            sc.ExecuteNonQuery();
        }
    }
}