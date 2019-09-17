﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class Role
    {
        public int R_ID { get; set; }
        public string Name { get; set; }
        public int CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public int Created_By { get; set; }
        public DateTime Created_Date { get; set; }
        public string Machine_Ip { get; set; }
        public string Mac_Address { get; set; }
        public Role()
        {
            this.Machine_Ip = Utility.GetIPAddress();
            this.Mac_Address = Utility.GetMacAddress();
        }


        public List<Role> Role_Get_By_Company(int C_ID)
        {
            List<Role> lst = new List<Role>();

            SqlCommand sc = new SqlCommand("Role_Get_By_Company", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@C_ID", C_ID);
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                Role u = new Role();
                u.R_ID = (int)sdr[0];
                u.Name = (string)sdr[1];
                u.CompanyCode = (int)sdr[2];
                u.Created_By = (int)sdr["CreatedBy"];
                u.Created_Date = (DateTime)sdr["CreatedDate"];
                u.Machine_Ip = (string)sdr["Machine_Ip"];
                u.Mac_Address = (string)sdr["Mac_Address"];
                lst.Add(u);
            }
            sdr.Close();
            return lst;
        }
        public List<Role> Role_Get_All()
        {
            List<Role> lst = new List<Role>();

            SqlCommand sc = new SqlCommand("Role_Get_All", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                Role u = new Role();
                u.R_ID = (int)sdr[0];
                u.Name = (string)sdr[1];
                u.CompanyCode = (int)sdr[2];
                u.CompanyName = (string)sdr["Company_Name"];
                lst.Add(u);
            }
            sdr.Close();
            return lst;
        }
        public Role Role_Get_By_ID(int id)
        {

            Role u = new Role();
            SqlCommand sc = new SqlCommand("Role_Get_By_ID", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);
            sc.Parameters.AddWithValue("@R_ID", id);
            SqlDataReader sdr = sc.ExecuteReader();
            if (sdr.Read())
            {
                
                u.R_ID = (int)sdr[0];
                u.Name = (string)sdr[1];
                u.CompanyCode = (int)sdr[2];

           
            }
            sdr.Close();
            return u;
        }
        public void Role_Add()
        {
            SqlCommand sc = new SqlCommand("Role_Add", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@Role_Name", Name);
            sc.Parameters.AddWithValue("@CCode", CompanyCode);
            sc.Parameters.AddWithValue("@Machine_Ip", Machine_Ip);
            sc.Parameters.AddWithValue("@Mac_Address", Mac_Address);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);
            sc.ExecuteNonQuery();
        }
        public void Role_Delete()
        {
            SqlCommand sc = new SqlCommand("Role_Delete", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@id", R_ID);
            sc.ExecuteNonQuery();
        }
        public void Role_Update()
        {
            SqlCommand sc = new SqlCommand("Role_Update", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure };

            sc.Parameters.AddWithValue("@Role_Name", Name);
            sc.Parameters.AddWithValue("@CCode", CompanyCode);
            sc.Parameters.AddWithValue("@R_ID", R_ID);
          
            sc.ExecuteNonQuery();
        }
    }
}