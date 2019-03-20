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

        [DisplayName("Customer ID")]
        public int Customer_ID { get; set; }

        [DisplayName("Customer Type")]
        public string[] Customer_Type { get; set; } = { "Company", "Individual", "Partnership" };
        #region business Details
        [DisplayName("Business Name")]
        public string Business_Name { get; set; }

        [DisplayName("Address Line 1")]
        public string Address1 { get; set; }
        [DisplayName("Address Line 2")]
        public string Address2 { get; set; }
        [EmailAddress(ErrorMessage = "The email address is not valid")]
        public string Email { get; set; }
        [DataType(DataType.MultilineText)]
        public string Comments { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }

        [DisplayName("Phone#")]
        public string Phone_No { get; set; }
        #endregion

        #region Tax Detail

        public string NTN { get; set; }
        public string STRN { get; set; }
        [DisplayName("Status")]
        public string[] NTN_Status { get; set; } = { "filer", "non filer" };
        [DisplayName("Status")]
        public string[] STRN_Status { get; set; } = { "filer", "non filer" };

        [DisplayName("Transaction type")]
        public string[] Transaction_type { get; set; } = { "Cash", "Acc. Receivable", "Both" };

        #endregion

        #region Contact Person
        [DisplayName("Name")]
        public string Person_Name { get; set; }
        [DisplayName("Phone#")]
        public string Person_Phone { get; set; }
        [DisplayName("Email")]
        public string Person_Email { get; set; }
        [DisplayName("Designation")]
        public string Person_Designation { get; set; }

        #endregion
        #region Banking Details
        [DisplayName("Name")]
        public string Bank_Name { get; set; }
        public string Title { get; set; }
        [DisplayName("Account#")]
        public string Account_No { get; set; }
        [DisplayName("IBAN#")]
        public string IBAN_No { get; set; }

        [DisplayName("Opening Balance")]
        public double Opening_Balance { get; set; }

        #endregion
        public int Created_By { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Created_Date { get; set; } = DateTime.Parse("2001/01/01");

        public string Machine_Ip { get; set; }

        public string Mac_Address { get; set; }
        public void Customer_Add()
        {
            SqlCommand sc = new SqlCommand("Customer_Add", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;

            sc.Parameters.AddWithValue("@Customer_ID", Customer_ID);
            sc.Parameters.AddWithValue("@Customer_Type", Customer_Type);
            sc.Parameters.AddWithValue("@Business Name", Business_Name);
            sc.Parameters.AddWithValue("@Address1", Address1);
            sc.Parameters.AddWithValue("@Address2", Address2);
            sc.Parameters.AddWithValue("@City",City);
            sc.Parameters.AddWithValue("@Province", Province);
            sc.Parameters.AddWithValue("@Country", Country);
            sc.Parameters.AddWithValue("@Phone_No", Phone_No);
            sc.Parameters.AddWithValue("@Email", Email);
            sc.Parameters.AddWithValue("@Comments", Comments);
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
            sc.Parameters.AddWithValue("@Title", Title);
            sc.Parameters.AddWithValue("@IBAN_No", IBAN_No);
            sc.Parameters.AddWithValue("@Account_No", Account_No);
            sc.Parameters.AddWithValue("@Opening_Balance", Opening_Balance);
            sc.Parameters.AddWithValue("@Machine_Ip", Machine_Ip);
            sc.Parameters.AddWithValue("@Mac_Address", Mac_Address);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);

            sc.ExecuteNonQuery();

        }

    }
}