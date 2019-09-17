using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{

    public class Payment_Mode
    {
        public int PM_ID { get; set; }
        public int P_ID { get; set; }
        public string PaymentMode  { get; set; }
        public int Account_ID { get; set; }
        public string Account_Name { get; set; }
        public string Description  { get; set; }
        public string CheckNo { get; set; }
        public decimal Amount { get; set; }


        #region default Properties
        public int Created_By { get; set; }
        public DateTime Created_Date { get; set; }
        public string Machine_Ip { get; set; }
        public string Mac_Address { get; set; }
        #endregion
        public Payment_Mode()
        {
            this.Machine_Ip = Utility.GetIPAddress();
            this.Mac_Address = Utility.GetMacAddress();
        }


        public List<Payment_Mode> Payment_Mode_Get_All()
        {
            List<Payment_Mode> lst = new List<Payment_Mode>();
            SqlCommand sc = new SqlCommand("Payment_Mode_Get_All", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@App_ID", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                Payment_Mode u = new Payment_Mode();
                u.PM_ID = (int)sdr["PM_ID"];
                u.PaymentMode  = (string)sdr["PaymentMode "];
                u.P_ID = (int)sdr["P_ID"];
                u.Account_ID = (int)sdr["Account_ID"];
                u.Account_Name = (string)sdr["Account_Name"];
                u.Description  = (string)sdr["Description "];
                u.CheckNo = (string)sdr["CheckNo"];
                u.Amount = (decimal)sdr["Amount"];
                u.Created_By = (int)sdr["CreatedBy"];
                u.Created_Date = (DateTime)sdr["CreatedDate"];
                u.Machine_Ip = (string)sdr["Machine_Ip"];
                u.Mac_Address = (string)sdr["Mac_Address"];
                lst.Add(u);
            }
            sdr.Close();
            return lst;
        }
        public Payment_Mode Payment_Mode_Get_By_PM_ID()
        {
            Payment_Mode u = new Payment_Mode();
            SqlCommand sc = new SqlCommand("Payment_Mode_Get_By_PM_ID", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@PM_ID", PM_ID);
            sc.Parameters.AddWithValue("@App_ID", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                u.PM_ID = (int)sdr["PM_ID"];
                u.PaymentMode  = (string)sdr["PaymentMode "];
                u.P_ID = (int)sdr["P_ID"];
                u.Account_ID = (int)sdr["Account_ID"];
                u.Account_Name = (string)sdr["Account_Name"];
                u.Description  = (string)sdr["Description "];
                u.CheckNo = (string)sdr["CheckNo"];
                u.Amount = (decimal)sdr["Amount"];
                u.Created_By = (int)sdr["CreatedBy"];
                u.Created_Date = (DateTime)sdr["CreatedDate"];
                u.Machine_Ip = (string)sdr["Machine_Ip"];
                u.Mac_Address = (string)sdr["Mac_Address"];
            }
            sdr.Close();
            return u;
        }

        public void Payment_Mode_Add()
        {
            SqlCommand sc = new SqlCommand("Payment_Mode_Add", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@PaymentMode ", PaymentMode );
            sc.Parameters.AddWithValue("@P_ID", P_ID);
            sc.Parameters.AddWithValue("@Account_ID", Account_ID);
            sc.Parameters.AddWithValue("@Description ", Description );
            sc.Parameters.AddWithValue("@CheckNo", CheckNo);
            sc.Parameters.AddWithValue("@Amount", Amount);
            sc.Parameters.AddWithValue("@Machine_Ip", Machine_Ip);
            sc.Parameters.AddWithValue("@Mac_Address", Mac_Address);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);
            sc.ExecuteNonQuery();

        }
        public void Payment_Mode_Update()
        {
            SqlCommand sc = new SqlCommand("Payment_Mode_Update", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@PM_ID", PM_ID);
            sc.Parameters.AddWithValue("@PaymentMode ", PaymentMode );
            sc.Parameters.AddWithValue("@P_ID", P_ID);
            sc.Parameters.AddWithValue("@Account_ID", Account_ID);
            sc.Parameters.AddWithValue("@Account_Name", Account_Name);
            sc.Parameters.AddWithValue("@Description ", Description );
            sc.Parameters.AddWithValue("@CheckNo", CheckNo);
            sc.Parameters.AddWithValue("@Amount", Amount);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);
            sc.ExecuteNonQuery();
        }
        public void Payment_Mode_Delete()
        {
            SqlCommand sc = new SqlCommand("Payment_Mode_Delete", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@PM_ID", PM_ID);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);
            sc.ExecuteNonQuery();
        }
    }
}