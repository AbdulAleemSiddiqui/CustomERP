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
    public class PurchaseInventory
    {
        #region purchase Order master
        public int PI_ID { get; set; }

        [DisplayName("P.R #")]
        public string PR_No { get; set; } = "0";
        [DisplayName("P.O #")]
        public string PO_No { get; set; } = "0";
        [DisplayName("Invoice #")]
        public string Invoice_No { get; set; } = "pending";
        public string App_Status { get; set; }
        [DisplayName("Department")]
        public int Department_ID { get; set; }
        [DisplayName("Department")]
        public string Department_Name { get; set; }

        [DisplayName("Purchase Type")]
        public int Purchase_Type_ID { get; set; }
        public string Purchase_Type_Name { get; set; } = "";

        [DisplayName("Purchase A/c")]
        public int Purchase_Account_ID { get; set; }
        public string Purchase_Account_Name { get; set; } = "";

        [DisplayName("Supllier Name")]
        public int Suplier_ID { get; set; }
        public string Suplier_Name { get; set; }
        [DisplayName("Account Payable")]
        public int Account_Payable_ID { get; set; }
        public string Account_Payable_Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Parse("2001/01/01");
        [DataType(DataType.Date)]
        [DisplayName("Due Date")]
        public DateTime Due_Date { get; set; } = DateTime.Parse("2001/01/01");
        [DataType(DataType.MultilineText)]
        public string Comments { get; set; } = "";

        [DisplayName("Vehicle #")]
        public int Vehicle_ID { get; set; }
        public string Vehicle_No { get; set; }
        [DisplayName("Transporter Name")]
        public int Transporter_ID{ get; set; }
        public string Transporter_Name { get; set; }
        [DisplayName("Middle Man")]
        public int Middle_Man_ID { get; set; }
        public string Middle_Man_Name { get; set; }
        #endregion
        #region Detail
        public int Detail_ID { get; set; }
        [DisplayName("Store / Godown")]
        public string Store { get; set; } = "";
        [DisplayName("Item Code")]
        public int Item_Code { get; set; }
        [DisplayName("Product Name")]
        public string Product_Name { get; set; } = "";
        [DisplayName("Product Description")]
        public string Product_Description { get; set; } = "";
        [DisplayName("Purchase Quantitiy")]
        public int Purchase_Quantitiy { get; set; }
        [DisplayName("Received Quantitiy")]
        public int Received_Quantitiy { get; set; }
       
        public decimal Commision { get; set; }
        
        public decimal Rate { get; set; }
        [DisplayName("Gross Amount")]
        public decimal Gross_Amount { get; set; }
        public decimal Discount { get; set; }
        [DisplayName("Discount Amount")]
        public decimal Discount_Amount { get; set; }
        [DisplayName("Net Amount")]
        public decimal Net_Amount { get; set; }


        #endregion
        #region Tax
        [DisplayName("Less / Add Commision")]
        public decimal Less_add_Commision { get; set; }
     
        public decimal GST { get; set; }
        [DisplayName("Further Tax")]
        public decimal Further_tax { get; set; }

        #endregion
        #region Default
        public int Created_By { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Created_Date { get; set; } = DateTime.Parse("2001/01/01");

        public string Machine_Ip { get; set; }

        public string Mac_Address { get; set; }
        #endregion
        public List<PI_Charge> charges { get; set; }
        public PurchaseInventory()
        {
            this.Machine_Ip = Utility.GetIPAddress();
            this.Mac_Address = Utility.GetMacAddress();
            charges = new List<PI_Charge>();
        }
        
        #region PR
        public int Purchase_Inventory_Add()
        {
            SqlCommand sc = new SqlCommand("Purchase_Inventory_Add", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
           
            sc.Parameters.AddWithValue("@PR_No", PR_No);
            sc.Parameters.AddWithValue("@PO_No", PO_No);
            sc.Parameters.AddWithValue("@Invoice_No", Invoice_No);
            sc.Parameters.AddWithValue("@Department_ID", Department_ID);
            sc.Parameters.AddWithValue("@Purchase_Type_ID", Purchase_Type_ID);
            sc.Parameters.AddWithValue("@Account_Payable_ID", Account_Payable_ID);
            sc.Parameters.AddWithValue("@Purchase_Account_ID", Purchase_Account_ID);
            sc.Parameters.AddWithValue("@Supplier_ID", Suplier_ID);
            sc.Parameters.AddWithValue("@Date", Date);
            sc.Parameters.AddWithValue("@Due_Date", Due_Date);
            sc.Parameters.AddWithValue("@Comments", Comments);
            sc.Parameters.AddWithValue("@Transporter_ID", Transporter_ID);
            sc.Parameters.AddWithValue("@Vehicle_ID", Vehicle_ID);
            sc.Parameters.AddWithValue("@Middle_Man_ID", Middle_Man_ID);
            sc.Parameters.AddWithValue("@Machine_Ip", Machine_Ip);
            sc.Parameters.AddWithValue("@Mac_Address", Mac_Address);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);

          return Convert.ToInt32((decimal)sc.ExecuteScalar());
        }

        public List<PurchaseInventory> PR_Get_All()
        {
            List<PurchaseInventory> lst = new List<PurchaseInventory>();
            SqlCommand sc = new SqlCommand("PR_Get_All", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@App_ID", App.App_ID);
            sc.Parameters.AddWithValue("@App_Status", App_Status);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                PurchaseInventory u = new PurchaseInventory();
                u.PI_ID = (int)sdr["PI_ID"];
                u.PR_No = (string)sdr["PR_No"];
                u.Department_ID = (int)sdr["Department_ID"];
                u.Department_Name = (string)sdr["D_Name"];
                u.Date = (DateTime)sdr["Date"];
                u.Comments = (string)sdr["Comments"];
                u.Created_By = (int)sdr["CreatedBy"];
                u.Created_Date = (DateTime)sdr["CreatedDate"];
                u.Machine_Ip = (string)sdr["Machine_Ip"];
                u.Mac_Address = (string)sdr["Mac_Address"];
                lst.Add(u);
            }
            sdr.Close();
            return lst;
        }

        public List<PurchaseInventory> PO_Get_All()
        {
            List<PurchaseInventory> lst = new List<PurchaseInventory>();
            SqlCommand sc = new SqlCommand("PO_Get_All", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@App_ID", App.App_ID);
            sc.Parameters.AddWithValue("@App_Status", App_Status);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                PurchaseInventory u = new PurchaseInventory();
                u.PI_ID = (int)sdr["PI_ID"];
                u.PR_No = (string)sdr["PR_No"];
                u.PO_No = (string)sdr["PO_No"];

                u.Department_ID = (int)sdr["Department_ID"];
                u.Department_Name = (string)sdr["D_Name"];

                u.Purchase_Type_ID = (int)sdr["PT_ID"];
                u.Purchase_Type_Name= (string)sdr["PT_Name"];

                u.Account_Payable_ID = (int)sdr["Account_Payable_ID"];
                u.Account_Payable_Name = (string)sdr["Account_Payable_Name"];

                u.Purchase_Account_ID= (int)sdr["Purchase_Account_ID"];
                u.Purchase_Account_Name= (string)sdr["Purchase_Account_Name"];

                u.Suplier_ID = (int)sdr["Suplier_ID"];
                u.Suplier_Name = (string)sdr["Suplier_Name"];

                u.Transporter_ID = (int)sdr["Transporter_ID"];
                u.Transporter_Name= (string)sdr["Transporter_Name"];

                u.Vehicle_ID = (int)sdr["Vehicle_ID"];
                u.Vehicle_No = (string)sdr["Vehicle_No"];

                u.Middle_Man_ID = (int)sdr["Middle_Man_ID"];
                u.Middle_Man_Name = (string)sdr["Middle_Man_Name"];

                u.Date = (DateTime)sdr["Date"];
                u.Comments = (string)sdr["Comments"];


                u.Created_By = (int)sdr["CreatedBy"];
                u.Created_Date = (DateTime)sdr["CreatedDate"];
                u.Machine_Ip = (string)sdr["Machine_Ip"];
                u.Mac_Address = (string)sdr["Mac_Address"];
                lst.Add(u);
            }
            sdr.Close();
            return lst;
        }
        public void PR_Approve()
        {
            SqlCommand sc = new SqlCommand("PR_Approve", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;

            sc.Parameters.AddWithValue("@PI_ID", PI_ID);
            sc.Parameters.AddWithValue("@App_Status", App_Status);
            sc.Parameters.AddWithValue("@Department_ID", Department_ID);
            sc.Parameters.AddWithValue("@Purchase_Type_ID", Purchase_Type_ID);
            sc.Parameters.AddWithValue("@Account_Payable_ID", Account_Payable_ID);
            sc.Parameters.AddWithValue("@Purchase_Account_ID", Purchase_Account_ID);
            sc.Parameters.AddWithValue("@Supplier_ID", Suplier_ID);
            sc.Parameters.AddWithValue("@Date", Date);
            sc.Parameters.AddWithValue("@Due_Date", Due_Date);
            sc.Parameters.AddWithValue("@Comments", Comments);
            sc.Parameters.AddWithValue("@Transporter_ID", Transporter_ID);
            sc.Parameters.AddWithValue("@Vehicle_ID", Vehicle_ID);
            sc.Parameters.AddWithValue("@Middle_Man_ID", Middle_Man_ID);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);

            sc.ExecuteNonQuery();
        }

        #endregion


        public string PR_Get_New_PR_NO()
        {
            SqlCommand sc = new SqlCommand("PR_Get_New_ID", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@App_ID", App.App_ID);
            sc.Parameters.Add("@a", SqlDbType.Int);
            sc.Parameters["@a"].Direction = ParameterDirection.Output;
            sc.ExecuteNonQuery();
            return ((int)sc.Parameters["@a"].Value).ToString();
        }
        public int PO_Add()
        {
            SqlCommand sc = new SqlCommand("PO_Add", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;

            sc.Parameters.AddWithValue("@PI_ID", PI_ID);
            sc.Parameters.AddWithValue("@App_Status", App_Status);
            sc.Parameters.AddWithValue("@Department_ID", Department_ID);
            sc.Parameters.AddWithValue("@Purchase_Type_ID", Purchase_Type_ID);
            sc.Parameters.AddWithValue("@Account_Payable_ID", Account_Payable_ID);
            sc.Parameters.AddWithValue("@Purchase_Account_ID", Purchase_Account_ID);
            sc.Parameters.AddWithValue("@Supplier_ID", Suplier_ID);
            sc.Parameters.AddWithValue("@Date", Date);
            sc.Parameters.AddWithValue("@Due_Date", Due_Date);
            sc.Parameters.AddWithValue("@Comments", Comments);
            sc.Parameters.AddWithValue("@Transporter_ID", Transporter_ID);
            sc.Parameters.AddWithValue("@Vehicle_ID", Vehicle_ID);
            sc.Parameters.AddWithValue("@Middle_Man_ID", Middle_Man_ID);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);

            sc.ExecuteNonQuery();
            return PI_ID;
        }

        #region Detail

        public int PI_Detail_Add()
        {
            SqlCommand sc = new SqlCommand("PI_Detail_Add", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;

            sc.Parameters.AddWithValue("@PI_ID", PI_ID);
            sc.Parameters.AddWithValue("@Store", Store);
            sc.Parameters.AddWithValue("@Item_Code", Item_Code);
            sc.Parameters.AddWithValue("@Product_Name", Product_Name);
            sc.Parameters.AddWithValue("@Description", Product_Description);
            sc.Parameters.AddWithValue("@P_Quantity", Purchase_Quantitiy);
            sc.Parameters.AddWithValue("@R_Quantity", Received_Quantitiy);
            sc.Parameters.AddWithValue("@Commision", Commision);
            sc.Parameters.AddWithValue("@Rate", Rate);
            sc.Parameters.AddWithValue("@Gross_Amount", Gross_Amount);
            sc.Parameters.AddWithValue("@Discount", Discount);
            sc.Parameters.AddWithValue("@Discount_Amount", Discount_Amount);
            sc.Parameters.AddWithValue("@Net_Amount", Net_Amount);
            sc.Parameters.AddWithValue("@Machine_Ip", Machine_Ip);
            sc.Parameters.AddWithValue("@Mac_Address", Mac_Address);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);


            
            return Convert.ToInt32((decimal)sc.ExecuteScalar());
        }
        public void PI_Detail_Update()
        {
            SqlCommand sc = new SqlCommand("PI_Detail_Update", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;

            sc.Parameters.AddWithValue("@Detail_ID", Detail_ID);
            sc.Parameters.AddWithValue("@Store", Store);
            sc.Parameters.AddWithValue("@Item_Code", Item_Code);
            sc.Parameters.AddWithValue("@Product_Name", Product_Name);
            sc.Parameters.AddWithValue("@Description", Product_Description);
            sc.Parameters.AddWithValue("@P_Quantity", Purchase_Quantitiy);
            sc.Parameters.AddWithValue("@R_Quantity", Received_Quantitiy);
            sc.Parameters.AddWithValue("@Commision", Commision);
            sc.Parameters.AddWithValue("@Rate", Rate);
            sc.Parameters.AddWithValue("@Gross_Amount", Gross_Amount);
            sc.Parameters.AddWithValue("@Discount", Discount);
            sc.Parameters.AddWithValue("@Discount_Amount", Discount_Amount);
            sc.Parameters.AddWithValue("@Net_Amount", Net_Amount);
            sc.Parameters.AddWithValue("@App_ID", App.App_ID);
            sc.ExecuteNonQuery();
        }
        public void PI_Detail_Delete()
        {
            SqlCommand sc = new SqlCommand("PI_Detail_Delete", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;

            sc.Parameters.AddWithValue("@Detail_ID", Detail_ID);
            sc.Parameters.AddWithValue("@App_ID", App.App_ID);
            sc.ExecuteNonQuery();
        }
        public List<PurchaseInventory> PI_Detail_Get_All()
        {

            List<PurchaseInventory> ls = new List<PurchaseInventory>();
            SqlCommand sc = new SqlCommand("PI_Detail_Get_All", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);
            sc.Parameters.AddWithValue("@PI_ID", PI_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                PurchaseInventory u = new PurchaseInventory();
                u.PI_ID = (int)sdr["PI_ID"];
                u.Detail_ID= (int)sdr["Detail_ID"];
                u.Store= (string)sdr["Store"];
                u.Item_Code= (int)sdr["Item_Code"];
                u.Product_Name= (string)sdr["Product_Name"];
                u.Product_Description= (string)sdr["Description"];
                u.Purchase_Quantitiy = (int)sdr["Purchase_Quantity"];
                u.Received_Quantitiy = (int)sdr["Received_Quantity"];
                u.Commision = (decimal)sdr["Commision"];
                u.Rate = (decimal)sdr["Rate"];
                u.Gross_Amount = (decimal)sdr["Gross_Amount"];
                u.Discount = (decimal)sdr["Discount"];
                u.Discount_Amount = (decimal)sdr["Discount_Amount"];
                u.Net_Amount = (decimal)sdr["Net_Amount"];

                u.Created_By = (int)sdr["CreatedBy"];
                u.Created_Date = (DateTime)sdr["CreatedDate"];
                u.Machine_Ip = (string)sdr["Machine_Ip"];
                u.Mac_Address = (string)sdr["Mac_Address"];
                ls.Add(u);
            }
            sdr.Close();
            return ls;
        }
        public void PI_Charges_Add()
        {
            foreach (var item in charges)
            {
                item.PI_ID = this.PI_ID;
                item.PI_Charge_Add();
            }
        }
        #endregion
    }
}