using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{

    public class Department
    {
        public int D_ID { get; set; }
        public string D_Name { get; set; }
        public string D_Head { get; set; }


        #region default Properties
        public int Created_By { get; set; }
        public DateTime Created_Date { get; set; }
        public string Machine_Ip { get; set; }
        public string Mac_Address { get; set; }
        #endregion
        public Department()
        {
            this.Machine_Ip = Utility.GetIPAddress();
            this.Mac_Address = Utility.GetMacAddress();
        }


        public List<Department> Department_Get_All()
        {
            List<Department> lst = new List<Department>();
            SqlCommand sc = new SqlCommand("Department_Get_All", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@App_ID", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                Department u = new Department();
                u.D_ID = (int)sdr["D_ID"];
                u.D_Name = (string)sdr["D_Name"];
                u.D_Head = (string)sdr["D_Head"];
                u.Created_By = (int)sdr["CreatedBy"];
                u.Created_Date = (DateTime)sdr["CreatedDate"];
                u.Machine_Ip = (string)sdr["Machine_Ip"];
                u.Mac_Address = (string)sdr["Mac_Address"];
                lst.Add(u);
            }
            sdr.Close();
            return lst;
        }
        public Department Department_Get_By_ID()
        {
            Department u = new Department();
            SqlCommand sc = new SqlCommand("Department_Get_By_ID", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@D_ID", D_ID);
            sc.Parameters.AddWithValue("@App_ID", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                u.D_ID = (int)sdr["D_ID"];
                u.D_Name = (string)sdr["D_Name"];
                u.D_Head = (string)sdr["D_Head"];
                u.Created_By = (int)sdr["CreatedBy"];
                u.Created_Date = (DateTime)sdr["CreatedDate"];
                u.Machine_Ip = (string)sdr["Machine_Ip"];
                u.Mac_Address = (string)sdr["Mac_Address"];
            }
            sdr.Close();
            return u;
        }

        public void Department_Add()
        {
            SqlCommand sc = new SqlCommand("Department_Add", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@D_Name", D_Name);
            sc.Parameters.AddWithValue("@D_Head", D_Head);
            sc.Parameters.AddWithValue("@Machine_Ip", Machine_Ip);
            sc.Parameters.AddWithValue("@Mac_Address", Mac_Address);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);
            sc.ExecuteNonQuery();

        }
        public void Department_Update()
        {
            SqlCommand sc = new SqlCommand("Department_Update", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@D_ID", D_ID);
            sc.Parameters.AddWithValue("@D_Name", D_Name);
            sc.Parameters.AddWithValue("@D_Head", D_Head);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);
            sc.ExecuteNonQuery();
        }
        public void Department_Delete()
        {
            SqlCommand sc = new SqlCommand("Department_Delete", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@D_ID", D_ID);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);
            sc.ExecuteNonQuery();
        }
    }
}