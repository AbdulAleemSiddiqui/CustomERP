using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
 
    public class PR
    {
        public int ID { get; set; }
        public string Prop1 { get; set; }
        public string Prop2 { get; set; }
        public string Prop3 { get; set; }
        public string Prop4 { get; set; }
        public string Prop5 { get; set; }
        public string Prop6 { get; set; }


        #region default Properties
        public int Created_By { get; set; }
        public DateTime Created_Date { get; set; }
        public string Machine_Ip { get; set; }
        public string Mac_Address { get; set; }
        #endregion
        public PR()
        {
            this.Machine_Ip = Utility.GetIPAddress();
            this.Mac_Address = Utility.GetMacAddress();
        }


        public List<PR> PR_Get_All()
        {
            List<PR> lst = new List<PR>();
            SqlCommand sc = new SqlCommand("PR_Get_All", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                PR u = new PR();
                u.ID = (int)sdr["ID"];
                u.Prop1 = (string)sdr["Prop1"];
                u.Prop2 = (string)sdr["Prop2"];
                u.Prop3 = (string)sdr["Prop3"];
                u.Prop4 = (string)sdr["Prop4"];
                u.Prop5 = (string)sdr["Prop5"];
                u.Prop6 = (string)sdr["Prop6"];
                u.Created_By = (int)sdr["CreatedBy"];
                u.Created_Date = (DateTime)sdr["CreatedDate"];
                u.Machine_Ip = (string)sdr["Machine_Ip"];
                u.Mac_Address = (string)sdr["Mac_Address"];
                lst.Add(u);
            }
            sdr.Close();
            return lst;
        }
        public PR PR_Get_By_ID()
        {
            PR u = new PR();
            SqlCommand sc = new SqlCommand("PR_Get_By_ID", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@ID", ID);
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                u.ID = (int)sdr["ID"];
                u.Prop1 = (string)sdr["Prop1"];
                u.Prop2 = (string)sdr["Prop2"];
                u.Prop3 = (string)sdr["Prop3"];
                u.Prop4 = (string)sdr["Prop4"];
                u.Prop5 = (string)sdr["Prop5"];
                u.Prop6 = (string)sdr["Prop6"];
                u.Created_By = (int)sdr["CreatedBy"];
                u.Created_Date = (DateTime)sdr["CreatedDate"];
                u.Machine_Ip = (string)sdr["Machine_Ip"];
                u.Mac_Address = (string)sdr["Mac_Address"];
            }
            sdr.Close();
            return u;
        }

        public void PR_Add()
        {
            SqlCommand sc = new SqlCommand("PR_Add", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@Prop1", Prop1);
            sc.Parameters.AddWithValue("@Prop2", Prop2);
            sc.Parameters.AddWithValue("@Prop3", Prop3);
            sc.Parameters.AddWithValue("@Prop4", Prop4);
            sc.Parameters.AddWithValue("@Prop5", Prop5);
            sc.Parameters.AddWithValue("@Prop6", Prop6);
            sc.Parameters.AddWithValue("@Machine_Ip", Machine_Ip);
            sc.Parameters.AddWithValue("@Mac_Address", Mac_Address);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);
            sc.ExecuteNonQuery();

        }
        public void PR_Update()
        {
            SqlCommand sc = new SqlCommand("PR_Update", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@ID", ID);
            sc.Parameters.AddWithValue("@Prop1", Prop1);
            sc.Parameters.AddWithValue("@Prop2", Prop2);
            sc.Parameters.AddWithValue("@Prop3", Prop3);
            sc.Parameters.AddWithValue("@Prop4", Prop4);
            sc.Parameters.AddWithValue("@Prop5", Prop5);
            sc.Parameters.AddWithValue("@Prop6", Prop6);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);
            sc.ExecuteNonQuery();
        }
        public void PR_Delete()
        {
            SqlCommand sc = new SqlCommand("PR_Delete", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@ID", ID);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);
            sc.ExecuteNonQuery();
        }
    }
}