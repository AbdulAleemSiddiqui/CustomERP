using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class Vendor
    {
        [DisplayName("Vendor ID")]
        public int Vendor_ID { get; set; }
        [DisplayName("Vendor Type")]
        public string Vendor_Type { get; set; } 
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
        public string NTN_Status { get; set; }
        [DisplayName("Status")]
        public string STRN_Status { get; set; } 

        [DisplayName("Transaction type")]
        public string Transaction_type { get; set; }

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
        [DisplayName("Incorporation No")]
        public string Incorporation_No{ get; set; }

        public string Title { get; set; }
        [DisplayName("Account#")]
        public string Account_No { get; set; }
        [DisplayName("IBAN#")]
        public string IBAN_No { get; set; }

        [DisplayName("Opening Balance")]
        public decimal Opening_Balance { get; set; }

        #endregion
        public int Created_By { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Created_Date { get; set; } = DateTime.Parse("2001/01/01");
        public string Machine_Ip { get; set; }
        public string Mac_Address { get; set; }
        #region CRUD
        public void Vendor_Add()
        {
            SqlCommand sc = new SqlCommand("Vendor_Add", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;


            sc.Parameters.AddWithValue("@Vendor_Type", Vendor_Type);
            sc.Parameters.AddWithValue("@Business_Name", Business_Name);
            sc.Parameters.AddWithValue("@Incorporation_No", Incorporation_No);
            sc.Parameters.AddWithValue("@Address1", Address1);
            sc.Parameters.AddWithValue("@Address2", Address2);
            sc.Parameters.AddWithValue("@City", City);
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
        public void Vendor_Update()
        {
            SqlCommand sc = new SqlCommand("Vendor_Update", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;

            sc.Parameters.AddWithValue("@Vendor_ID", Vendor_ID);
            sc.Parameters.AddWithValue("@Vendor_Type", Vendor_Type);
            sc.Parameters.AddWithValue("@Business Name", Business_Name);
            sc.Parameters.AddWithValue("@Incorporation_No", Incorporation_No);
            sc.Parameters.AddWithValue("@Address1", Address1);
            sc.Parameters.AddWithValue("@Address2", Address2);
            sc.Parameters.AddWithValue("@City", City);
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
        public void Vendor_Delete()
        {
            SqlCommand sc = new SqlCommand("Vendor_Delete", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@Vendor_ID", Vendor_ID);
            sc.ExecuteNonQuery();
        }
        public Vendor Vendor_Get_BY_ID(int id)
        {
            Vendor u = new Vendor();
            SqlCommand sc = new SqlCommand("Vendor_Get_By_ID", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@Company_ID", id);
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                u.Vendor_ID = (int)sdr["Vendor_ID"];
                u.Vendor_Type = (string)sdr["Vendor_Type"];
                u.Business_Name = (string)sdr["Business_Name"];
                u.Address1 = (string)sdr["Address1"];
                u.Address2 = (string)sdr["Address2"];
                u.City = (string)sdr["City"];
                u.Province = (string)sdr["Province"];
                u.Country = (string)sdr["Country"];
                u.Phone_No = (string)sdr["Phone_No"];
                u.Email = (string)sdr["Email"];
                u.Comments = (string)sdr["Comments"];
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
                u.IBAN_No = (string)sdr["IBAN_No"];
                u.Account_No = (string)sdr["Account_No"];
                u.Title = (string)sdr["Title"];
                u.Opening_Balance = (decimal)sdr["Opening_Balance"];


                u.Created_By = (int)sdr["CreatedBy"];
                u.Created_Date = (DateTime)sdr["CreatedDate"];
                u.Machine_Ip = (string)sdr["Machine_Ip"];
                u.Mac_Address = (string)sdr["Mac_Address"];

            }
            sdr.Close();
            return u;
        }
        public List<Vendor> Vendor_Get_All()
        {

            List<Vendor> ls = new List<Vendor>();
            SqlCommand sc = new SqlCommand("Vendor_Get_All", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                Vendor u = new Vendor();
                u.Vendor_ID = (int)sdr["Vendor_ID"];
                u.Vendor_Type = (string)sdr["Vendor_Type"];
                u.Business_Name = (string)sdr["Business_Name"];
                u.Address1 = (string)sdr["Address1"];
                u.Address2 = (string)sdr["Address2"];
                u.City = (string)sdr["City"];
                u.Province = (string)sdr["Province"];
                u.Country = (string)sdr["Country"];
                u.Phone_No = (string)sdr["Phone_No"];
                u.Email = (string)sdr["Email"];
                u.Comments = (string)sdr["Comments"];
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
                u.IBAN_No = (string)sdr["IBAN_No"];
                u.Account_No = (string)sdr["Account_No"];
                u.Title = (string)sdr["Title"];
                u.Opening_Balance = (decimal)sdr["Opening_Balance"];


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