using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class Customer
    {
        public Customer()
        {
            this.Machine_Ip = Utility.GetIPAddress();
            this.Mac_Address = Utility.GetMacAddress();
        }
        [DisplayName("Customer ID")]
        public int Customer_ID { get; set; }
        [DisplayName("Customer Type")]
        public string Customer_Type { get; set; } 
        #region business Details
        [DisplayName("Business Name")]
        public string Business_Name { get; set; }
        [DisplayName("Incorporation No")]
        public string Incorporation_No { get; set; }
        [DisplayName("Address Line 1")]
        public string Address_Line_1 { get; set; }
        [DisplayName("Address Line 2")]
        public string Address_Line_2 { get; set; }
        [EmailAddress(ErrorMessage = "The Email address is not valid")]
        [DisplayName("Business Email")]

        public string Business_Email { get; set; }
        [DataType(DataType.MultilineText)]
        [DisplayName("Comment")]
        public string Business_Comment { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }

        [DisplayName("Phone#")]
        public string Business_Phone_No { get; set; }
        #endregion
        #region Tax Detail

        public string NTN { get; set; }
        public string STRN { get; set; }
        [DisplayName("Status")]
        public string NTN_Status { get; set; }
        [DisplayName("Status")]
        public string STRN_Status { get; set; }

        [DisplayName("Transaction type")]
        public string Transaction_type { get; set; }
        #endregion
        #region Contact Person
        [DisplayName("Person Name")]
        public string Person_Name { get; set; }
        [DisplayName("Person Phone#")]
        public string Person_Phone { get; set; }
        [DisplayName("Person Email")]
        public string Person_Email { get; set; }
        [DisplayName("Designation")]
        public string Person_Designation { get; set; }

        #endregion
        #region Banking Details
        [DisplayName("Bank Name")]
        public string Bank_Name { get; set; }
        [DisplayName("Title")]
        public string Bank_Title { get; set; }
        [DisplayName("Account#")]
        public string Bank_Account_No { get; set; }
        [DisplayName("IBAN#")]
        public string Bank_IBAN_No { get; set; }

        [DisplayName("Opening Balance")]
        public decimal Bank_Opening_Balance { get; set; }
        #endregion
        public int Created_By { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Created_Date { get; set; } = DateTime.Parse("2001/01/01");

        public string Machine_Ip { get; set; }

        public string Mac_Address { get; set; }
#region CRUD
        public void Customer_Add()
        {
            SqlCommand sc = new SqlCommand("Customer_Add", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure }; ;

            
            sc.Parameters.AddWithValue("@Customer_Type", Customer_Type);
            sc.Parameters.AddWithValue("@Business_Name", Business_Name);
            sc.Parameters.AddWithValue("@Incorporation_No", Incorporation_No);
            sc.Parameters.AddWithValue("@Address1", Address_Line_1);
            sc.Parameters.AddWithValue("@Address2", Address_Line_2);
            sc.Parameters.AddWithValue("@City", City);
            sc.Parameters.AddWithValue("@Province", Province);
            sc.Parameters.AddWithValue("@Country", Country);
            sc.Parameters.AddWithValue("@Phone_No", Business_Phone_No);
            sc.Parameters.AddWithValue("@Email", Business_Email);
            sc.Parameters.AddWithValue("@Comments", Business_Comment);
            sc.Parameters.AddWithValue("@NTN", NTN);
            sc.Parameters.AddWithValue("@NTN_Status", NTN_Status);
            sc.Parameters.AddWithValue("@STRN", STRN);
            sc.Parameters.AddWithValue("@STRN_Status", STRN_Status);
            sc.Parameters.AddWithValue("@Transaction_Type", Transaction_type);
            sc.Parameters.AddWithValue("@Person_Name", Person_Name);
            sc.Parameters.AddWithValue("@Person_Phone", Person_Phone);
            sc.Parameters.AddWithValue("@Person_Email", Person_Email);
            sc.Parameters.AddWithValue("@Person_Designation", Person_Designation);
            sc.Parameters.AddWithValue("@Bank_Name", Bank_Name);
            sc.Parameters.AddWithValue("@Title", Bank_Title);
            sc.Parameters.AddWithValue("@IBAN_No", Bank_IBAN_No);
            sc.Parameters.AddWithValue("@Account_No", Bank_Account_No);
            sc.Parameters.AddWithValue("@Opening_Balance", Bank_Opening_Balance);
            sc.Parameters.AddWithValue("@Machine_Ip", Machine_Ip);
            sc.Parameters.AddWithValue("@Mac_Address", Mac_Address);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);

            sc.ExecuteNonQuery();

        }
        public void Customer_Update()
        {
            SqlCommand sc = new SqlCommand("Customer_Update", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure }; ;

            sc.Parameters.AddWithValue("@Customer_ID", Customer_ID);
            sc.Parameters.AddWithValue("@Customer_Type", Customer_Type);
            sc.Parameters.AddWithValue("@Business_Name", Business_Name);
            sc.Parameters.AddWithValue("@Incorporation_No", Incorporation_No);
            sc.Parameters.AddWithValue("@Address1", Address_Line_1);
            sc.Parameters.AddWithValue("@Address2", Address_Line_2);
            sc.Parameters.AddWithValue("@City", City);
            sc.Parameters.AddWithValue("@Province", Province);
            sc.Parameters.AddWithValue("@Country", Country);
            sc.Parameters.AddWithValue("@Phone_No", Business_Phone_No);
            sc.Parameters.AddWithValue("@Email", Business_Email);
            sc.Parameters.AddWithValue("@Comments", Business_Comment);
            sc.Parameters.AddWithValue("@NTN", NTN);
            sc.Parameters.AddWithValue("@NTN_Status", NTN_Status);
            sc.Parameters.AddWithValue("@STRN", STRN);
            sc.Parameters.AddWithValue("@STRN_Status", STRN_Status);
            sc.Parameters.AddWithValue("@Transaction_Type", Transaction_type);
            sc.Parameters.AddWithValue("@Person_Name", Person_Name);
            sc.Parameters.AddWithValue("@Person_Phone", Person_Phone);
            sc.Parameters.AddWithValue("@Person_Email", Person_Email);
            sc.Parameters.AddWithValue("@Person_Designation", Person_Designation);
            sc.Parameters.AddWithValue("@Bank_Name", Bank_Name);
            sc.Parameters.AddWithValue("@Title", Bank_Title);
            sc.Parameters.AddWithValue("@IBAN_No", Bank_IBAN_No);
            sc.Parameters.AddWithValue("@Account_No", Bank_Account_No);
            sc.Parameters.AddWithValue("@Opening_Balance", Bank_Opening_Balance);
            sc.Parameters.AddWithValue("@Machine_Ip", Machine_Ip);
            sc.Parameters.AddWithValue("@Mac_Address", Mac_Address);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);

            sc.ExecuteNonQuery();
        }
        public void Customer_Delete()
        {
            SqlCommand sc = new SqlCommand("Customer_Delete", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@Customer_ID", Customer_ID);
            sc.ExecuteNonQuery();
        }
        public Customer Customer_Get_BY_ID(int id)
        {
            Customer u = new Customer();
            SqlCommand sc = new SqlCommand("Customer_Get_By_ID", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@Customer_ID", id);
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                u.Customer_ID = (int)sdr["Customer_ID"];


                u.Customer_Type = (string)sdr["Customer_Type"];
                u.Business_Name = (string)sdr["Business_Name"];
                u.Address_Line_1 = (string)sdr["Address_Line_1"];
                u.Address_Line_2 = (string)sdr["Address_Line_2"];
                u.City = (string)sdr["City"];
                u.Province = (string)sdr["Province"];
                u.Country = (string)sdr["Country"];
                u.Business_Phone_No = (string)sdr["Business_Phone_No"];
                u.Business_Email = (string)sdr["Business_Email"];
                u.Business_Comment = (string)sdr["Business_Comment"];
                u.Incorporation_No= (string)sdr["Incorporation_No"];
                u.NTN = (string)sdr["NTN"];
                u.NTN_Status = (string)sdr["NTN_Status"];
                u.STRN = (string)sdr["STRN"];
                u.STRN_Status = (string)sdr["STRN_Status"];
                u.Transaction_type = (string)sdr["Transaction_type"];
                u.Person_Name = (string)sdr["Person_Name"];
                u.Person_Phone = (string)sdr["Person_Phone"];
                u.Person_Designation = (string)sdr["Person_Designation"];
                u.Person_Email = (string)sdr["Person_Email"];
                u.Bank_Name = (string)sdr["Bank_Name"];
                u.Bank_IBAN_No = (string)sdr["Bank_IBAN_No"];
                u.Bank_Account_No = (string)sdr["Bank_Account_No"];
                u.Bank_Title = (string)sdr["Bank_Title"];
                u.Bank_Opening_Balance = (decimal)sdr["Bank_Opening_Balance"];


                u.Created_By = (int)sdr["CreatedBy"];
                u.Created_Date = (DateTime)sdr["CreatedDate"];
                u.Machine_Ip = (string)sdr["Machine_Ip"];
                u.Mac_Address = (string)sdr["Mac_Address"];

            }
            sdr.Close();
            return u;
        }
        public List<Customer> Customer_Get_All()
        {
          
            List<Customer> ls = new List<Customer>();
            SqlCommand sc = new SqlCommand("Customer_Get_All", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                Customer u = new Customer();
                u.Customer_ID = (int)sdr["Customer_ID"];
                u.Customer_Type = (string)sdr["Customer_Type"];
                u.Business_Name = (string)sdr["Business_Name"];
                u.Address_Line_1 = (string)sdr["Address_Line_1"];
                u.Address_Line_2 = (string)sdr["Address_Line_2"];
                u.City = (string)sdr["City"];
                u.Province = (string)sdr["Province"];
                u.Country = (string)sdr["Country"];
                u.Business_Phone_No = (string)sdr["Business_Phone_No"];
                u.Business_Email = (string)sdr["Business_Email"];
                u.Business_Comment= (string)sdr["Business_Comment"];
                u.Incorporation_No = (string)sdr["Incorporation_No"];
                u.NTN = (string)sdr["NTN"];
                u.NTN_Status = (string)sdr["NTN_Status"];
                u.STRN = (string)sdr["STRN"];
                u.STRN_Status = (string)sdr["STRN_Status"];
                u.Transaction_type = (string)sdr["Transaction_type"];
                u.Person_Name = (string)sdr["Person_Name"];
                u.Person_Phone = (string)sdr["Person_Phone"];
                u.Person_Designation = (string)sdr["Person_Designation"];
                u.Person_Email = (string)sdr["Person_Email"];
                u.Bank_Name = (string)sdr["Bank_Name"];
                u.Bank_IBAN_No = (string)sdr["Bank_IBAN_No"];
                u.Bank_Account_No = (string)sdr["Bank_Account_No"];
                u.Bank_Title = (string)sdr["Bank_Title"];
                u.Bank_Opening_Balance = (decimal)sdr["Bank_Opening_Balance"];


                u.Created_By = (int)sdr["CreatedBy"];
                u.Created_Date = (DateTime)sdr["CreatedDate"];
                u.Machine_Ip = (string)sdr["Machine_Ip"];
                u.Mac_Address = (string)sdr["Mac_Address"];
                ls.Add(u);
            }
            sdr.Close();
            return ls;
        }
        #endregion
    }
}