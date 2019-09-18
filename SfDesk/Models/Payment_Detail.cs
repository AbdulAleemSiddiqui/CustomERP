using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class Payment_Detail
    {
        #region Properties
        public int PD_ID { get; set; }
        public int P_ID { get; set; }
        public int COA_ID { get; set; }
        public string Payment_Mode { get; set; }
        public string Account { get; set; }
        public string Bank_Name { get; set; }
        public string Instument_NO { get; set; }
        public string Instrument_Date { get; set; }
        public decimal Amount { get; set; }
        public int Created_By { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Created_Date { get; set; } = DateTime.Parse("2001/01/01");

        public string Machine_Ip { get; set; }

        public string Mac_Address { get; set; }

    
        #endregion
        public List<PurchaseInventory> Bill_Get_By_SID(int id)
        {
            List<PurchaseInventory> bills = new List<PurchaseInventory>();
            SqlCommand sc = new SqlCommand("Bill_Get_By_ID", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);
            sc.Parameters.AddWithValue("@Supplier_ID", id);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                PurchaseInventory u = new PurchaseInventory();
                u.PI_ID = (int)sdr["PI_ID"];
                u.PR_No = (string)sdr["PR_No"];
                u.Suplier_Name = (string)sdr["Business_Name"];
                u.strngDate = ((DateTime)sdr["Date"]).ToShortDateString();
                u.TotalAmount = (decimal)sdr["TotalAmount"];
                u.Total_Tax = (decimal)sdr["Total_Tax"];
                u.AllocatedAmount = (decimal)sdr["AllocatedAmount"];
                u.DueAmount = u.TotalAmount - u.AllocatedAmount;
                u.AllocatedStatus = (string)sdr["App_Status"];
                bills.Add(u);
            }
            sdr.Close();

            return bills;
        }
        public List<PurchaseInventory> Bill_Get_All()
        {
            List<PurchaseInventory> bills = new List<PurchaseInventory>();
            SqlCommand sc = new SqlCommand("Bill_Get_All", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                PurchaseInventory u = new PurchaseInventory();
                u.PI_ID = (int)sdr["PI_ID"];
                u.PR_No = (string)sdr["PR_No"];
                u.Suplier_Name = (string)sdr["Business_Name"];
                u.strngDate = ((DateTime)sdr["Date"]).ToShortDateString();
                u.TotalAmount = (decimal)sdr["TotalAmount"];
                u.Total_Tax = (decimal)sdr["Total_Tax"];
                u.AllocatedAmount = (decimal)sdr["AllocatedAmount"];
                u.DueAmount = u.TotalAmount - u.AllocatedAmount;
                u.AllocatedStatus = (string)sdr["App_Status"];
                bills.Add(u);
            }
            sdr.Close();

            return bills;
        }


        public List<Payment_Detail> Payment_Detail_Get_All()
        {
            List<Payment_Detail> lst = new List<Payment_Detail>();
            SqlCommand sc = new SqlCommand("Payment_Detail_Get_All", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@App_ID", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                Payment_Detail u = new Payment_Detail();
                u.PD_ID = (int)sdr["PD_ID"];
                u.P_ID = (int)sdr["P_ID"];
                //u.PI_ID = (int)sdr["PI_ID"];
                //u.P_Name = (string)sdr["P_Name "];
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
        public Payment_Detail Payment_Detail_Get_By_ID()
        {
            Payment_Detail u = new Payment_Detail();
            SqlCommand sc = new SqlCommand("Payment_Detail_Get_By_Payment_Detail_ID", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@PD_ID", PD_ID);
            sc.Parameters.AddWithValue("@App_ID", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                u.PD_ID = (int)sdr["PD_ID"];
                u.P_ID = (int)sdr["P_ID"];
                //u.PI_ID = (int)sdr["PI_ID"];
                //u.P_Name = (string)sdr["P_Name "];
                u.Amount = (decimal)sdr["Amount"];

                u.Created_By = (int)sdr["CreatedBy"];
                u.Created_Date = (DateTime)sdr["CreatedDate"];
                u.Machine_Ip = (string)sdr["Machine_Ip"];
                u.Mac_Address = (string)sdr["Mac_Address"];
            }
            sdr.Close();
            return u;
        }

        public void Payment_Detail_Add()
        {
            SqlCommand sc = new SqlCommand("Payment_Detail_Add", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@P_ID", P_ID);
            //sc.Parameters.AddWithValue("@PI_ID", PI_ID);
            sc.Parameters.AddWithValue("@Amount", Amount);

            sc.Parameters.AddWithValue("@Machine_Ip", Machine_Ip);
            sc.Parameters.AddWithValue("@Mac_Address", Mac_Address);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);
            sc.ExecuteNonQuery();

        }

        public void Payment_Detail_Delete()
        {
            SqlCommand sc = new SqlCommand("Payment_Detail_Delete", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@PD_ID", PD_ID);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);
            sc.ExecuteNonQuery();
        }
    }
}