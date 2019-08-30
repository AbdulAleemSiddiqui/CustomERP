using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class SaleOrder
    {
        public SaleOrder()
        {
            this.Machine_Ip = Utility.GetIPAddress();
            this.Mac_Address = Utility.GetMacAddress();
            taxes = new List<SO_Charges>();
        }
        #region Sales Order master
        [DisplayName("S ID #")]
        public int SO_ID { get; set; }
        [DisplayName("S.O #")]
        public string SO_No { get; set; }
        [DisplayName("PR #")]
        public string PR_No { get; set; }
        [DisplayName("Sale Mode")]
        public string Sale_Mode { get; set; }
        public int Sale_Account_ID { get; set; }
        [DisplayName("Sale A/c")]
        public string Sale_Account_Name { get; set; }

       

        [DisplayName("Account Receivable")]
        public int Account_Receivable_ID { get; set; }
        public string Account_Receivable_Name { get; set; }
        public int Customer_ID { get; set; }
        [DisplayName("Customer Name")]
        public string Customer_Name { get; set; }
        public DateTime Date { get; set; }
        [DisplayName("Due Date")]
        public DateTime Due_Date { get; set; }
        [DataType(DataType.MultilineText)]
        public string Comments { get; set; }
        [DisplayName("Department")]
        public int Department_ID { get; set; }
        [DisplayName("Department")]
        public string Department_Name { get; set; }
        [DisplayName("Vehicle #")]
        public int Vehicle_ID { get; set; }
        public string Vehicle_No { get; set; }
        [DisplayName("Transporter Name")]
        public int Transporter_ID { get; set; }
        public string Transporter_Name { get; set; }
        [DisplayName("Sales Man")]
        public int Sales_Man_ID { get; set; }
        public string Sales_Man_Name { get; set; }
        public string App_Status { get; set; }
        #endregion
        public List<SO_Details> details { get; set; }
        public List<SO_Transactions> transactions { get; set; }
        public List<SO_Charges> taxes { get; set; }
        public string ImagePath { get; set; }
        #region Tax
     
        public decimal Total_Tax { get; set; }

        #endregion
        #region Default
        public int Created_By { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Created_Date { get; set; } = DateTime.Parse("2001/01/01");

        public string Machine_Ip { get; set; }

        public string Mac_Address { get; set; }
        #endregion

        #region SO
        public int SI_Add()
        {
            SqlCommand sc = new SqlCommand("Sale_Inventory_Add", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;

            sc.Parameters.AddWithValue("@PR_No", PR_No);
            sc.Parameters.AddWithValue("@SO_No",SO_No);
            sc.Parameters.AddWithValue("@SO_ID", SO_ID);
            sc.Parameters.AddWithValue("@Department_ID", Department_ID);
            sc.Parameters.AddWithValue("@Sale_Mode", Sale_Mode);
            sc.Parameters.AddWithValue("@Account_Receivable_ID", Account_Receivable_ID);
            sc.Parameters.AddWithValue("@Sale_Account_ID", Sale_Account_ID);
            sc.Parameters.AddWithValue("@Customer_ID", Customer_ID);
            sc.Parameters.AddWithValue("@Date", Date);
            sc.Parameters.AddWithValue("@Due_Date", Due_Date);
            sc.Parameters.AddWithValue("@Comments", Comments);
            sc.Parameters.AddWithValue("@Transporter_ID", Transporter_ID);
            sc.Parameters.AddWithValue("@Vehicle_ID", Vehicle_ID);
            sc.Parameters.AddWithValue("@Sales_Man_ID", Sales_Man_ID);
            sc.Parameters.AddWithValue("@Machine_Ip", Machine_Ip);
            sc.Parameters.AddWithValue("@Mac_Address", Mac_Address);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);

            return Convert.ToInt32((decimal)sc.ExecuteScalar());
        }
        public int SO_Add()
        {
            SqlCommand sc = new SqlCommand("SO_Add", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;

            sc.Parameters.AddWithValue("@PR_No", PR_No);
            sc.Parameters.AddWithValue("@App_Status", App_Status);
            sc.Parameters.AddWithValue("@Department_ID", Department_ID);
            sc.Parameters.AddWithValue("@SaleMode", Sale_Mode);
            sc.Parameters.AddWithValue("@Account_Receivable_ID", Account_Receivable_ID);
            sc.Parameters.AddWithValue("@Sale_Account_ID", Sale_Account_ID);
            sc.Parameters.AddWithValue("@Customer_ID", Customer_ID);
            sc.Parameters.AddWithValue("@Date", Date);
            sc.Parameters.AddWithValue("@Due_Date", Due_Date);
            sc.Parameters.AddWithValue("@Comments", Comments);
            sc.Parameters.AddWithValue("@Transporter_ID", Transporter_ID);
            sc.Parameters.AddWithValue("@Vehicle_ID", Vehicle_ID);
            sc.Parameters.AddWithValue("@Sales_Man_ID", Sales_Man_ID);
            sc.Parameters.AddWithValue("@Machine_Ip", Machine_Ip);
            sc.Parameters.AddWithValue("@Mac_Address", Mac_Address);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);

            return Convert.ToInt32((decimal)sc.ExecuteScalar());
        }
        public void SO_Approve()
        {
            SqlCommand sc = new SqlCommand("SO_Approve", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;

            sc.Parameters.AddWithValue("@SO_ID", SO_ID);
            sc.Parameters.AddWithValue("@App_Status", App_Status);
            sc.Parameters.AddWithValue("@Sale_Mode", Sale_Mode);
            sc.Parameters.AddWithValue("@Account_Receivable_ID", Account_Receivable_ID);
            sc.Parameters.AddWithValue("@Sale_Account_ID", Sale_Account_ID);
            sc.Parameters.AddWithValue("@Customer_ID", Customer_ID);
            sc.Parameters.AddWithValue("@Date", Date);
            sc.Parameters.AddWithValue("@Due_Date", Due_Date);
            sc.Parameters.AddWithValue("@Comments", Comments);
            sc.Parameters.AddWithValue("@Transporter_ID", Transporter_ID);
            sc.Parameters.AddWithValue("@Vehicle_ID", Vehicle_ID);
            sc.Parameters.AddWithValue("@Sales_Man_ID", Sales_Man_ID);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);

            sc.ExecuteNonQuery();
        }

        public List<SaleOrder> SO_Get_All()
        {
            List<SaleOrder> lst = new List<SaleOrder>();
            SqlCommand sc = new SqlCommand("SO_Get_All", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@App_ID", App.App_ID);
            sc.Parameters.AddWithValue("@App_Status", App_Status);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                SaleOrder u = new SaleOrder();
                u.SO_ID = (int)sdr["SO_ID"];
                u.PR_No = (string)sdr["PR_No"];
                u.SO_No = (string)sdr["SO_No"];
                u.SO_ID = (int)sdr["SO_ID"];
                u.App_Status = App_Status;
                u.Sale_Mode = (string)sdr["Sale_Mode"];

                u.Account_Receivable_ID = (int)sdr["Account_Receivable_ID"];
                u.Account_Receivable_Name = (string)sdr["Account_Receivable_Name"];

                u.Sale_Account_ID = (int)sdr["Sale_Account_ID"];
                u.Sale_Account_Name = (string)sdr["Sale_Account_Name"];

                u.Customer_ID = (int)sdr["Customer_ID"];
                u.Customer_Name = (string)sdr["Customer_Name"];

                u.Transporter_ID = (int)sdr["Transporter_ID"];
                u.Transporter_Name = (string)sdr["Transporter_Name"];

                u.Vehicle_ID = (int)sdr["Vehicle_ID"];
                u.Vehicle_No = (string)sdr["Vehicle_No"];

                u.Sales_Man_ID = (int)sdr["Sales_Man_ID"];
                u.Sales_Man_Name = (string)sdr["Sales_Man_Name"];

                u.Date = (DateTime)sdr["Date"];
                u.Comments = Connection.SafeGetString(sdr, 15);


                u.Created_By = (int)sdr["CreatedBy"];
                u.Created_Date = (DateTime)sdr["CreatedDate"];
                u.Machine_Ip = (string)sdr["Machine_Ip"];
                u.Mac_Address = (string)sdr["Mac_Address"];
                lst.Add(u);
            }
            sdr.Close();
            return lst;
        }
  
        #endregion
        public void SO_SaveImage()
        {
            SqlCommand sc = new SqlCommand("SO_SaveImage", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;

            sc.Parameters.AddWithValue("@imagePath", ImagePath);
            sc.Parameters.AddWithValue("@SO_ID", SO_ID);
            sc.Parameters.AddWithValue("@App_ID", App.App_ID);
            sc.ExecuteNonQuery();
        }

       
        public string SO_Get_New_ID()
        {
            SqlCommand sc = new SqlCommand("SO_Get_New_ID", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@App_ID", App.App_ID);
            sc.Parameters.Add("@a", SqlDbType.Int);
            sc.Parameters["@a"].Direction = ParameterDirection.Output;
            sc.ExecuteNonQuery();
            return ((int)sc.Parameters["@a"].Value).ToString();
        }

        public void SO_Charges_Add()
        {
            foreach (var item in taxes)
            {
                item.SO_ID = this.SO_ID;
                item.SO_Charges_Add();
            }
        }
       
    }
}
