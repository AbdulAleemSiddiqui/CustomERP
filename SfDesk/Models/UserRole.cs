using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class User_Role
    {
        #region Properties

        public int UR_ID { get; set; }
        [DisplayName("User ID")]
        public int U_ID { get; set; }
        [DisplayName("Name")]
        public string U_Name { get; set; }
        public int R_ID { get; set; }
        [DisplayName("Role")]
        public string R_Name { get; set; }
        [DisplayName("Form")]
        public string F_Name { get; set; }
        public string M_Name { get; set; }
        [DisplayName("Action")]
        public string A_Name { get; set; }
        public int C_ID { get; set; }
        [DisplayName("Company")]
        public string C_Name { get; set; }
        public int Created_By { get; set; }
        public DateTime Created_Date { get; set; }
        public string Machine_Ip { get; set; }
        public string Mac_Address { get; set; }

        public User_Role()
        {
            this.Machine_Ip = Utility.GetIPAddress();
            this.Mac_Address = Utility.GetMacAddress();
        }
        #endregion

        #region CRUD

        public List<User_Role> User_Role_Get_All()
        {
            List<User_Role> lst = new List<User_Role>();

            SqlCommand sc = new SqlCommand("User_Role_Get_All", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                User_Role u = new User_Role();
                u.UR_ID = (int)sdr[0];
                u.U_ID = (int)sdr[1];
                u.R_ID = (int)sdr[2];
                u.R_Name = (string)sdr[3];
                u.C_ID = (int)sdr[4];
                u.C_Name = (string)sdr[5];
                lst.Add(u);
            }
            sdr.Close();
            return lst;
        }
    public List<User_Role> User_Role_Get_By_U_ID()
        {
            List<User_Role> lst = new List<User_Role>();

            SqlCommand sc = new SqlCommand("User_Role_Get_By_U_ID", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@U_ID", U_ID);
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                User_Role u = new User_Role();
                u.U_ID = U_ID;
                u.UR_ID = (int)sdr[0];
                u.R_ID = (int)sdr[1];
                u.R_Name = (string)sdr[2];
                u.F_Name = (string)sdr[3];
                u.A_Name = (string)sdr[4];
                u.M_Name = (string)sdr[5];
                lst.Add(u);
            }
            sdr.Close();
            return lst;
        }
    public User_Role User_Role_Get_By_ID(int UR_ID)
        {

            User_Role u = new User_Role();
            SqlCommand sc = new SqlCommand("User_Role_Get_By_ID", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@UR_ID", UR_ID);
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);

            SqlDataReader sdr = sc.ExecuteReader();
            if (sdr.Read())
            {

                u.UR_ID = (int)sdr[0];
                u.U_ID = (int)sdr[1];
                u.R_ID = (int)sdr[2];
                u.R_Name = (string)sdr[3];
                u.C_ID = (int)sdr[4];
                u.C_Name = (string)sdr[5];

            }
            sdr.Close();
            return u;
        }
        public void User_Role_Add()
        {
            SqlCommand sc = new SqlCommand("User_Role_Add", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@U_ID", U_ID);
            sc.Parameters.AddWithValue("@R_ID", R_ID);
            sc.Parameters.AddWithValue("@C_ID", C_ID);
            sc.Parameters.AddWithValue("@Machine_Ip", Machine_Ip);
            sc.Parameters.AddWithValue("@Mac_Address", Mac_Address);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);
            sc.ExecuteNonQuery();
        }
        public void User_Role_Delete()
        {
            SqlCommand sc = new SqlCommand("User_Role_Delete", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@UR_ID", UR_ID);
            sc.ExecuteNonQuery();
        }
        public void User_Role_Update()
        {
            SqlCommand sc = new SqlCommand("User_Role_Update", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };

            sc.Parameters.AddWithValue("@UR_ID", UR_ID);
            sc.Parameters.AddWithValue("@U_ID", U_ID);
            sc.Parameters.AddWithValue("@R_ID", R_ID);
            sc.Parameters.AddWithValue("@C_ID", C_ID);

            sc.ExecuteNonQuery();
        }
        #endregion
    }
}