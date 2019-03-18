using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        public string email { get; set; }
        [DataType(DataType.MultilineText)]
        public string Comments { get; set; }
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

    }
}