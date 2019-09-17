using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class Transaction
    {
        [DisplayName("ID")]
        public int T_ID { get; set; }
        [DisplayName("Name")]
        public string Name { get; set; }
        [DisplayName("Charge Nature")]
        public string Charge_Nature { get; set; }

        [DisplayName("Is Taxable")]
        public bool isTexable { get; set; }

        [DisplayName("Rate")]
        public decimal Rate{ get; set; }

        [DisplayName("Rate Type")]
        public string Rate_Type { get; set; }

        [DisplayName("% apply on (rate * qty)")]
        public bool isPer_Apply { get; set; }



        [DisplayName("Pay. Account")]
        public int Pay_Account_ID{ get; set; }
        public string Pay_Account_Name { get; set; }

        [DisplayName("Expense Account")]
        public int Sales_Account_ID { get; set; }
        public string Sales_Account_Name{ get; set; }


        public int Created_By { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Created_Date { get; set; } = DateTime.Parse("2001/01/01");
        public string Machine_Ip { get; set; }
        public string Mac_Address { get; set; }

        public Transaction()
        {
            this.Machine_Ip = Utility.GetIPAddress();
            this.Mac_Address = Utility.GetMacAddress();
        }

        public List<Transaction> Transaction_Get_All()
        {
            List<Transaction> lst = new List<Transaction>();
            SqlCommand sc = new SqlCommand("Transaction_Get_All", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                Transaction u = new Transaction();
                u.T_ID = (int)sdr["T_ID"];
                u.Name = (string)sdr["Name"];
                u.Charge_Nature = (string)sdr["Charge_Nature"];
                u.isTexable = (bool)sdr["isTexable"];
                u.Rate = (decimal)sdr["Rate"];
                u.Rate_Type = (string)sdr["Rate_Type"];
                u.isPer_Apply = (bool)sdr["isPer_Apply"];

                u.Sales_Account_ID = (int)sdr["Sales_Account_ID"];
                u.Sales_Account_Name  = (string)sdr["Sales_Account_Name"];

                u.Pay_Account_ID = (int)sdr["Pay_Account_ID"];
                u.Pay_Account_Name= (string)sdr["Pay_Account_Name"];

                u.Created_By = (int)sdr["CreatedBy"];
                u.Created_Date = (DateTime)sdr["CreatedDate"];
                u.Machine_Ip = (string)sdr["Machine_Ip"];
                u.Mac_Address = (string)sdr["Mac_Address"];

                lst.Add(u);
            }
            sdr.Close();
            return lst;
        }


        public Transaction Transaction_Get_By_ID()
        {
            Transaction u = new Transaction();
            SqlCommand sc = new SqlCommand("Transaction_Get_By_ID", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@T_ID", T_ID);
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                u.T_ID = (int)sdr["T_ID"];
                u.Name = (string)sdr["Name"];
                u.Charge_Nature = (string)sdr["Charge_Nature"];
                u.isTexable = (bool)sdr["isTexable"];
                u.Rate = (decimal)sdr["Rate"];
                u.Rate_Type = (string)sdr["Rate_Type"];
                u.isPer_Apply = (bool)sdr["isPer_Apply"];


                u.Sales_Account_ID = (int)sdr["Sales_Account_ID"];
                u.Sales_Account_Name = (string)sdr["Sales_Account_Name"];

                u.Pay_Account_ID = (int)sdr["Pay_Account_ID"];
                u.Pay_Account_Name = (string)sdr["Pay_Account_Name"];

                u.Created_By = (int)sdr["CreatedBy"];
                u.Created_Date = (DateTime)sdr["CreatedDate"];
                u.Machine_Ip = (string)sdr["Machine_Ip"];
                u.Mac_Address = (string)sdr["Mac_Address"];


            }
            sdr.Close();
            return u;
        }
        public void Transaction_Add()
        {
            SqlCommand sc = new SqlCommand("Transaction_Add", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            
            sc.Parameters.AddWithValue("@Name", Name);
            sc.Parameters.AddWithValue("@Charge_Nature", Charge_Nature);
            sc.Parameters.AddWithValue("@isTexable", isTexable);
            sc.Parameters.AddWithValue("@Rate", Rate);
            sc.Parameters.AddWithValue("@Rate_Type", Rate_Type);
            sc.Parameters.AddWithValue("@isPer_Apply", isPer_Apply);
            sc.Parameters.AddWithValue("@Sales_Account_ID", Sales_Account_ID);
            sc.Parameters.AddWithValue("@Pay_Account_ID", Pay_Account_ID);
            sc.Parameters.AddWithValue("@Machine_Ip", Machine_Ip);
            sc.Parameters.AddWithValue("@Mac_Address", Mac_Address);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);

            sc.ExecuteNonQuery();

        }
        public void Transaction_Update()
        {
            SqlCommand sc = new SqlCommand("Transaction_Update", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure };

            sc.Parameters.AddWithValue("@T_ID", T_ID);
            sc.Parameters.AddWithValue("@Name", Name);
            sc.Parameters.AddWithValue("@Charge_Nature", Charge_Nature);
            sc.Parameters.AddWithValue("@isTexable", isTexable);
            sc.Parameters.AddWithValue("@Rate", Rate);
            sc.Parameters.AddWithValue("@Rate_Type", Rate_Type);
            sc.Parameters.AddWithValue("@isPer_Apply", isPer_Apply);

            sc.Parameters.AddWithValue("@Sales_Account_ID", Sales_Account_ID);
            sc.Parameters.AddWithValue("@Pay_Account_ID", Pay_Account_ID);
            sc.ExecuteNonQuery();


        }
        public void Transaction_Delete()
        {
            SqlCommand sc = new SqlCommand("Transaction_Delete", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@T_ID", T_ID);
            sc.Parameters.AddWithValue("@App_ID", App.App_ID);
            sc.ExecuteNonQuery();
        }


        public List<Transaction> Transaction_Get_For_LOV()
        {
            List<Transaction> lst = new List<Transaction>();
            SqlCommand sc = new SqlCommand("Transaction_Get_For_LOV", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                Transaction u = new Transaction();
                u.T_ID = (int)sdr["T_ID"];
                u.Name = (string)sdr["Name"];
                u.Rate = (decimal)sdr["Rate"];

                lst.Add(u);
            }
            sdr.Close();
            return lst;
        }
    }
}