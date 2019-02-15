using System;
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
        public List<Role> Role_Get_By_Company(int C_ID)
        {
            List<Role> lst = new List<Role>();

            SqlCommand sc = new SqlCommand("Role_Get_By_Company", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
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

            SqlCommand sc = new SqlCommand("Role_Get_All", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                Role u = new Role();
                u.R_ID = (int)sdr[0];
                u.Name = (string)sdr[1];
                u.CompanyCode = (int)sdr[2]; 

                lst.Add(u);
            }
            sdr.Close();
            return lst;
        }
        public void Role_Add()
        {
            SqlCommand sc = new SqlCommand("Role_Add", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@Role_Name", Name);
            sc.Parameters.AddWithValue("@CCode", CompanyCode);
            sc.Parameters.AddWithValue("@CreatedBy", Created_By);
            sc.ExecuteNonQuery();
        }
    }
}