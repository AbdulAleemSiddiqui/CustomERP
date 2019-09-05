using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
 
    public class PR
    {
        #region purchase Order master
        public int PR_ID { get; set; }

        [DisplayName("P.R #")]
        public string PR_No { get; set; } = "0";
       
        public string App_Status { get; set; }
        [DisplayName("Department")]
        public int Department_ID { get; set; }
        [DisplayName("Department")]
        public string Department_Name { get; set; }

      

        [DataType(DataType.Date)]
        [DisplayName("Invoice Date")]
        public DateTime Date { get; set; } = DateTime.Parse("2001/01/01");

        public string strngDate { get; set; }

    
        [DataType(DataType.MultilineText)]
        public string Comments { get; set; } = "";


        #endregion
        public List<PR_Details> details { get; set; }
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
            sc.Parameters.AddWithValue("@App_ID", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                PR u = new PR();
                u.PR_ID = (int)sdr["PR_ID"];
                u.PR_No = (string)sdr["PR_No"];
                u.Department_ID = (int)sdr["Department_ID"];
                u.Date = (DateTime)sdr["Date"];
          
                u.Created_By = (int)sdr["CreatedBy"];
                u.Created_Date = (DateTime)sdr["CreatedDate"];
                u.Machine_Ip = (string)sdr["Machine_Ip"];
                u.Mac_Address = (string)sdr["Mac_Address"];
                lst.Add(u);
            }
            sdr.Close();
            return lst;
        }
        public PR PR_Get_By_PR_ID()
        {
            PR u = new PR();
            SqlCommand sc = new SqlCommand("PR_Get_By_PR_ID", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@PR_ID", PR_ID);
            sc.Parameters.AddWithValue("@App_ID", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                u.PR_ID = (int)sdr["PR_ID"];
                u.PR_No = (string)sdr["PR_No"];
                u.Department_ID = (int)sdr["Department_ID"];
                u.Date = (DateTime)sdr["Date"];
                
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
            sc.Parameters.AddWithValue("@PR_No", PR_No);
            sc.Parameters.AddWithValue("@Department_ID", Department_ID);
            sc.Parameters.AddWithValue("@Date", Date);
            sc.Parameters.AddWithValue("@Machine_Ip", Machine_Ip);
            sc.Parameters.AddWithValue("@Mac_Address", Mac_Address);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);
            sc.ExecuteNonQuery();

        }
        public void PR_Update()
        {
            SqlCommand sc = new SqlCommand("PR_Update", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@PR_ID", PR_ID);
            sc.Parameters.AddWithValue("@PR_No", PR_No);
            sc.Parameters.AddWithValue("@Department_ID", Department_ID);
            sc.Parameters.AddWithValue("@Date", Date);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);
            sc.ExecuteNonQuery();
        }
        public void PR_Delete()
        {
            SqlCommand sc = new SqlCommand("PR_Delete", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@PR_ID", PR_ID);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);
            sc.ExecuteNonQuery();
        }
    }
}