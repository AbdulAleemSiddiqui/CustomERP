using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class SalesTax
    {
        [DisplayName("ID")]
        public int SalesTax_ID { get; set; }
        [DisplayName("Type")]

        public string TaxType { get; set; }
        public string Code{ get; set; }
        [DisplayName("Tax_Id Name")]

        public string SalesTax_Name { get; set; }
        [DisplayName("Account Name")]
        public string Account_Name { get; set; }
        [DisplayName("Rate Type")]
        public string Rate_Type { get; set; }
        [DisplayName("Account")]
        public int Account_ID { get; set; }
        public decimal Rate { get; set; }
        [DisplayName("Opening Balance")]
        public decimal Opening_Balance { get; set; }
        [DisplayName("is Claimable")]
        public bool Is_Claimable { get; set; }
        public int Created_By { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Created_Date { get; set; } = DateTime.Parse("2001/01/01");

        public string Machine_Ip { get; set; }

        public string Mac_Address { get; set; }

        public SalesTax()
        {
            this.Machine_Ip = Utility.GetIPAddress();
            this.Mac_Address = Utility.GetMacAddress();
        }

        public List<SalesTax> SalesTax_Get_All()
        {
            List<SalesTax> lst = new List<SalesTax>();
            SqlCommand sc = new SqlCommand("SalesTax_Get_All", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                SalesTax u = new SalesTax();
                u.SalesTax_ID = (int)sdr["SalesTax_ID"];
                u.SalesTax_Name = (string)sdr["Name"];
                u.Code = (string)sdr["Code"];
                u.Account_ID = (int)sdr["Account_ID"];
                u.TaxType = (string)sdr["TaxType"];
                u.Rate = (decimal)sdr["Rate"];
                u.Rate_Type = (string)sdr["RateType"];
                u.Opening_Balance = (decimal)sdr["Opening Balance"];
                u.Is_Claimable = (bool)sdr["Is_Claimable"];

                u.Created_By = (int)sdr["CreatedBy"];
                u.Created_Date = (DateTime)sdr["CreatedDate"];
                u.Machine_Ip = (string)sdr["Machine_Ip"];
                u.Mac_Address = (string)sdr["Mac_Address"];

                lst.Add(u);
            }
            sdr.Close();
            return lst;
        }
        public SalesTax SalesTax_Get_By_ID()
        {
            SalesTax u = new SalesTax();
            SqlCommand sc = new SqlCommand("SalesTax_Get_By_ID", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@SalesTax_ID", SalesTax_ID);
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                u.SalesTax_ID = (int)sdr["SalesTax_ID"];
                u.SalesTax_Name = (string)sdr["Name"];
                u.Code = (string)sdr["Code"];
                u.Account_ID = (int)sdr["Account_ID"];
                u.TaxType = (string)sdr["TaxType"];
                u.Rate = (decimal)sdr["Rate"];
                u.Rate_Type = (string)sdr["RateType"];
                u.Opening_Balance = (decimal)sdr["Opening Balance"];
                u.Is_Claimable = (bool)sdr["Is_Claimable"];

                u.Created_By = (int)sdr["CreatedBy"];
                u.Created_Date = (DateTime)sdr["CreatedDate"];
                u.Machine_Ip = (string)sdr["Machine_Ip"];
                u.Mac_Address = (string)sdr["Mac_Address"];

            }
            sdr.Close();
            return u;
        }
        public void SalesTax_Add()
        {
            SqlCommand sc = new SqlCommand("SalesTax_Add", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            
            sc.Parameters.AddWithValue("@Name", SalesTax_Name);
            sc.Parameters.AddWithValue("@Code", Code);
            sc.Parameters.AddWithValue("@TaxType", TaxType);
            sc.Parameters.AddWithValue("@Account_ID", Account_ID);
            sc.Parameters.AddWithValue("@ST_Rate", Rate);
            sc.Parameters.AddWithValue("@RateType", Rate_Type);
            sc.Parameters.AddWithValue("@Opening_Balance", Opening_Balance );
            sc.Parameters.AddWithValue("@Is_Claimable", Is_Claimable);

            sc.Parameters.AddWithValue("@Machine_Ip", Machine_Ip);
            sc.Parameters.AddWithValue("@Mac_Address", Mac_Address);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);

            sc.ExecuteNonQuery();

        }
        public void SalesTax_Update()
        {
            SqlCommand sc = new SqlCommand("SalesTax_Update", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure };

            sc.Parameters.AddWithValue("@SalesTax_ID", SalesTax_ID);
             sc.Parameters.AddWithValue("@Name", SalesTax_Name);
            sc.Parameters.AddWithValue("@Code", Code);
            sc.Parameters.AddWithValue("@TaxType", TaxType);
            sc.Parameters.AddWithValue("@Account_ID", Account_ID);
            sc.Parameters.AddWithValue("@ST_Rate", Rate);
            sc.Parameters.AddWithValue("@RateType", Rate_Type);
            sc.Parameters.AddWithValue("@Opening_Balance", Opening_Balance);
            sc.Parameters.AddWithValue("@Is_Claimable", Is_Claimable);


            sc.ExecuteNonQuery();


        }
        public void SalesTax_Delete()
        {
            SqlCommand sc = new SqlCommand("SalesTax_Delete", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@SalesTax_ID", SalesTax_ID);
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);
            sc.ExecuteNonQuery();
        }


    }
}