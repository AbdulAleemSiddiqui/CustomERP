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
        public string T_Name { get; set; }
        [DisplayName("Charge Nature")]
        public string T_Charge_Nature { get; set; }
        [DisplayName("Rate")]
        public decimal T_Rate{ get; set; }
        [DisplayName("Rate Type")]
        public string T_Rate_Type { get; set; }
        [DisplayName("Is Taxable")]
        public bool Is_Taxable{ get; set; }
        [DisplayName("PER. Effect CGS")]
        public string Purchase_ECGS { get; set; }
        [DisplayName("SAL. Effect CGS")]
        public string Sale_EGCS { get; set; }
        [DisplayName("Ammount")]
        public decimal Sale_Amount{ get; set; }
        [DisplayName("SAL. Effect Party")]
        public string Purchase_Effect_Party { get; set; }
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
            SqlCommand sc = new SqlCommand("Transaction_Get_All", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                Transaction u = new Transaction();
                u.T_ID = (int)sdr["Transaction_ID"];
                u.T_Name = (string)sdr["Transaction_Name"];
                u.T_Charge_Nature = (string)sdr["T_Charge_Nature"];
                u.Is_Taxable = (bool)sdr["Is_Taxable"];
                u.T_Rate = (decimal)sdr["Rate"];
                u.T_Rate_Type = (string)sdr["RateType"];
                u.Sale_EGCS = (string)sdr["Sale_EOCS"];
                u.Purchase_ECGS = (string)sdr["Purchase_EOCS"];
                u.Purchase_Effect_Party = (string)sdr["Purchase_Effect_Party"];
                u.Sale_Amount = (decimal)sdr["Sale_Amount"];

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
            SqlCommand sc = new SqlCommand("Transaction_Get_By_ID", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@Transaction_ID", T_ID);
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                u.T_ID = (int)sdr["Transaction_ID"];
                u.T_Name = (string)sdr["Transaction_Name"];
                u.T_Charge_Nature = (string)sdr["T_Charge_Nature"];
                u.Is_Taxable = (bool)sdr["Is_Taxable"];
                u.T_Rate = (decimal)sdr["Rate"];
                u.T_Rate_Type = (string)sdr["RateType"];
                u.Sale_EGCS = (string)sdr["Sale_EOCS"];
                u.Purchase_ECGS = (string)sdr["Purchase_EOCS"];
                u.Purchase_Effect_Party = (string)sdr["Purchase_Effect_Party"];
                u.Sale_Amount = (decimal)sdr["Sale_Amount"];

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
            SqlCommand sc = new SqlCommand("Transaction_Add", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            
            sc.Parameters.AddWithValue("@Transaction_Name", T_Name);
            sc.Parameters.AddWithValue("@T_Charge_Nature", T_Charge_Nature);
            sc.Parameters.AddWithValue("@Is_Taxable", Is_Taxable);
            sc.Parameters.AddWithValue("@Rate", T_Rate);
            sc.Parameters.AddWithValue("@RateType", T_Rate_Type);
            sc.Parameters.AddWithValue("@Sale_EOCS", Sale_EGCS);
            sc.Parameters.AddWithValue("@Purchase_Effect_Party", Purchase_Effect_Party);
            sc.Parameters.AddWithValue("@Sale_Amount", Sale_Amount);
            sc.Parameters.AddWithValue("@Purchase_EOCS", Purchase_ECGS);
            sc.Parameters.AddWithValue("@Machine_Ip", Machine_Ip);
            sc.Parameters.AddWithValue("@Mac_Address", Mac_Address);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);

            sc.ExecuteNonQuery();

        }
        public void Transaction_Update()
        {
            SqlCommand sc = new SqlCommand("Transaction_Update", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };

            sc.Parameters.AddWithValue("@Transaction_ID", T_ID);
            sc.Parameters.AddWithValue("@Transaction_Name", T_Name);
            sc.Parameters.AddWithValue("@T_Charge_Nature", T_Charge_Nature);
            sc.Parameters.AddWithValue("@Is_Taxable", Is_Taxable);
            sc.Parameters.AddWithValue("@Rate", T_Rate);
            sc.Parameters.AddWithValue("@RateType", T_Rate_Type);
            sc.Parameters.AddWithValue("@Sale_EOCS", Sale_EGCS);
            sc.Parameters.AddWithValue("@Purchase_Effect_Party", Purchase_Effect_Party);
            sc.Parameters.AddWithValue("@Sale_Amount", Sale_Amount);
            sc.Parameters.AddWithValue("@Purchase_EOCS", Purchase_ECGS);
            sc.ExecuteNonQuery();


        }
        public void Transaction_Delete()
        {
            SqlCommand sc = new SqlCommand("Transaction_Delete", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@id", T_ID);
            sc.ExecuteNonQuery();
        }

    }
}