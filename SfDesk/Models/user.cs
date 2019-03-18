using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class user
    {
        [DisplayName("User ID")]
        public int U_Id { get; set; }
        public string Password { get; set; }
        public string New_Password { get; set; }

        public string Email { get; set; }
        public DateTime Last_Login_Date { get; set; }
        public DateTime Last_Pass_Change_Date { get; set; }
        public string State { get; set; }
        [DisplayName("Company")]
        public int CompanyCode { get; set; }

        public string CompanyName { get; set; }

        //[DisplayName("User Role")]
        //public int UserRoleID { get; set; }
        //public string UserRoleName { get; set; }a

        public int Created_By { get; set; }
        public DateTime Created_Date { get; set; }
        public string Machine_Ip { get; set; } 
        public string Mac_Address { get; set; }

        public user()
        {
            this.Machine_Ip = Utility.GetIPAddress();
            this.Mac_Address = Utility.GetMacAddress();
        }
        public void User_Add()
        {
            SqlCommand sc = new SqlCommand("User_Add", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@Password", Password);
            sc.Parameters.AddWithValue("@Email", Email);
            sc.Parameters.AddWithValue("@CCode", CompanyCode);
            sc.Parameters.AddWithValue("@Machine_Ip", Machine_Ip);
            sc.Parameters.AddWithValue("@Mac_Address", Mac_Address);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);

            sc.ExecuteNonQuery();
        }
        public string User_Login()
        {
            SqlCommand sc = new SqlCommand("User_Login", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@Password", Password);
            sc.Parameters.AddWithValue("@Email", Email);
            SqlDataReader sdr = sc.ExecuteReader();
            string msg = "";
            while (sdr.Read())
            {
                U_Id = (int)sdr[0];
                Password = (string)sdr[1];
                Email = (string)sdr[2];
                Last_Login_Date = (DateTime)sdr[3];
                Last_Pass_Change_Date = (DateTime)sdr[4];
                State = (string)sdr[5];
                CompanyCode = (int)sdr[6];
                CompanyName = (string)sdr[7];
                Created_By = (int)sdr[8];
                Created_Date = (DateTime)sdr[9];
                Machine_Ip = (string)sdr[10];
                Mac_Address = (string)sdr[11];
                switch (State)
                {
                    case "N":
                        msg = "Change Password";
                        break;
                    case "I":
                        msg = "In-Active User";
                        break;
                    case "A":

                        double diff = (DateTime.Now - Last_Login_Date).TotalDays;
                        double diff1 = (DateTime.Now - Last_Pass_Change_Date).TotalDays;
                        if (diff >= 30)
                        {
                            msg = "In-Active User";
                        }
                        else if (diff1 >= 20)
                        {
                            msg = "Change Password";
                        }
                        else
                        {
                            msg = "OK";

                        }
                        break;
                }

            }
            sdr.Close();
            return msg;
        }
        public List<user> User_Get_All()
        {
            List<user> lst = new List<user>();

            SqlCommand sc = new SqlCommand("User_Get_All", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@App_ID", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                user u = new user();
                u.U_Id = (int)sdr[0];
                u.Password = (string)sdr[1];
                u.Email = (string)sdr[2];
                u.Last_Login_Date = (DateTime)sdr[3];
                u.Last_Pass_Change_Date = (DateTime)sdr[4];
                u.State = (string)sdr[5];
                u.CompanyCode = (int)sdr[6];
                u.CompanyName = (string)sdr[7];
                u.Created_By = (int)sdr[8];
                u.Created_Date = (DateTime)sdr[9];
                u.Machine_Ip = (string)sdr[10];
                u.Mac_Address = (string)sdr[11];
                lst.Add(u);
            }
            sdr.Close();
            return lst;
        }
        public user User_Get_By_ID(int id)
        {
            user u = new user();

            SqlCommand sc = new SqlCommand("User_Get_By_ID", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@id", id);
            sc.Parameters.AddWithValue("@App_ID", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                u = new user()
                {
                    U_Id = (int)sdr[0],
                    Password = (string)sdr[1],
                    Email = (string)sdr[2],
                    Last_Login_Date = (DateTime)sdr[3],
                    Last_Pass_Change_Date = (DateTime)sdr[4],
                    State = (string)sdr[5],
                    CompanyCode = (int)sdr[6],
                    CompanyName = (string)sdr[7],
                    Created_By = (int)sdr[8],
                    Created_Date = (DateTime)sdr[9],
                    Machine_Ip = (string)sdr[10],
                    Mac_Address = (string)sdr[11]
                };
            }
            sdr.Close();
            return u;
        }
        public void User_Update()
        {
            SqlCommand sc = new SqlCommand("User_Update", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@U_Id", U_Id);
            sc.Parameters.AddWithValue("@Password", Password);
            sc.Parameters.AddWithValue("@Email", Email);
            sc.Parameters.AddWithValue("@CCode", CompanyCode);
            sc.ExecuteNonQuery();
        }
        public void User_Delete()
        {
            SqlCommand sc = new SqlCommand("User_Delete", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@id", U_Id);
            sc.ExecuteNonQuery();
        }

        public void User_Update_Login_Date()
        {
            SqlCommand sc = new SqlCommand("User_Update_Login_Date", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@U_ID", U_Id);
            sc.ExecuteNonQuery();
        }
        public bool User_Update_Password()
        {
            if (Validate_Password())
            {
                SqlCommand sc = new SqlCommand("User_Update_Password", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
                sc.Parameters.AddWithValue("@U_ID", U_Id);
                sc.Parameters.AddWithValue("@password", New_Password);

                sc.ExecuteNonQuery();
                return true;
            }
            return false;
        }
        public bool Validate_Password()
        {
            string oldpassword = User_Get_By_ID(U_Id).Password;
            if (oldpassword == Password)
            {
                return true;
            }
            return false;
        }
        public  bool Validate_Action(string Action,string Controller)
        {
            SqlCommand sc = new SqlCommand("Validate_Action", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@U_ID", U_Id);
            sc.Parameters.AddWithValue("@Action", Action);
            sc.Parameters.AddWithValue("@Controller", Controller);
            object a =sc.ExecuteScalar();
            if(a==null)
            {
                return false;
            }
            return true;
        }
    }
}