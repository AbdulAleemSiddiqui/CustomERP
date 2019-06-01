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
        public int PD_ID { get; set; }
        public int P_ID { get; set; }
        public int PI_ID { get; set; }

        public string P_Name { get; set; }
        public decimal Amount { get; set; }
        public int Created_By { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Created_Date { get; set; } = DateTime.Parse("2001/01/01");

        public string Machine_Ip { get; set; }

        public string Mac_Address { get; set; }

        public Payment_Detail()
        {
            this.Machine_Ip = Utility.GetIPAddress();
            this.Mac_Address = Utility.GetMacAddress();
        }
        public List<PurchaseInventory> Bill_Get_By_SID(int id)
        {
            List<PurchaseInventory> bills = new List<PurchaseInventory>();
            SqlCommand sc = new SqlCommand("Bill_Get_By_ID", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
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
                u.DueAmount = u.Total_Tax - u.AllocatedAmount;
                u.AllocatedStatus = (string)sdr["App_Status"];
                bills.Add(u);
            }
            sdr.Close();

            return bills;
        }



    }
}