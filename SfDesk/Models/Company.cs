using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class Company
    {
        #region Properties

        [DisplayName("ID")]
        public int Company_ID { get; set; }

        [DisplayName("Name")]
        public string Company_Name { get; set; }
        public string Contact { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Area { get; set; }

     

        public string Province { get; set; }
        public string Country { get; set; }

        [DisplayName("Phone#")]
        public string Phone_No { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }

        [DisplayName("Business Start Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime Business_Start_Date { get; set; } = DateTime.Parse("2001/01/01");

        [DisplayName("Book Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Book_Start_Date { get; set; } = DateTime.Parse("2001/01/01");

        [DisplayName("Year Ends")]
        public string Year_Ends { get; set; }
        public string CUIN { get; set; }
        public string NTN { get; set; }
        public string STRN { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("STRN Date")]
        public DateTime STRN_Date { get; set; } = DateTime.Parse("2001/01/01");
        public int Created_By { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Created_Date { get; set; } = DateTime.Parse("2001/01/01");

        public string Machine_Ip { get; set; }

        public string Mac_Address { get; set; }

        public Company()
        {
            this.Machine_Ip = Utility.GetIPAddress();
            this.Mac_Address = Utility.GetMacAddress();
        }
        #endregion

        #region CRUD
     
        public Company Company_Get_By_User(int U_id)
        {
            Company u = new Company();
            SqlCommand sc = new SqlCommand("Company_Get_By_User", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@U_ID", U_id);
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                u.Company_ID = (int)sdr["Company_ID"];
                u.Company_Name = (string)sdr["Company_Name"];
                u.Contact = (string)sdr["Contact"];
                u.Address1 = (string)sdr["Address1"];
                u.Address2 = (string)sdr["Address2"];
                u.Area = (string)sdr["Area"];
                u.Province = (string)sdr["Province"];
                u.Country = (string)sdr["Country"];
                u.Phone_No = (string)sdr["Phone_No"];
                u.Email = (string)sdr["Email"];
                u.Website = (string)sdr["Website"];
                u.Business_Start_Date = (DateTime)sdr["Business_Start_Date"];
                u.Book_Start_Date = (DateTime)sdr["Book_Start_Date"];
                u.Year_Ends = (string)sdr["Year_Ends"];
                u.CUIN = (string)sdr["CUIN"];
                u.NTN = (string)sdr["NTN"];
                u.STRN = (string)sdr["STRN"];
                u.STRN_Date = (DateTime)sdr["STRN_Date"];
                u.Created_By = (int)sdr["CreatedBy"];
                u.Created_Date = (DateTime)sdr["CreatedDate"];
                u.Machine_Ip = (string)sdr["Machine_Ip"];
                u.Mac_Address = (string)sdr["Mac_Address"];

            }
            sdr.Close();
            return u;
        }
        public List<Company> Company_Get_All()
        {
            List<Company> lst = new List<Company>();
            SqlCommand sc = new SqlCommand("Company_Get_All", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                Company u = new Company();
                u.Company_ID = (int)sdr["Company_ID"];
                u.Company_Name = (string)sdr["Company_Name"];
                u.Contact = (string)sdr["Contact"];
                u.Address1 = (string)sdr["Address1"];
                u.Address2 = (string)sdr["Address2"];
                u.Area = (string)sdr["Area"];
                u.Province = (string)sdr["Province"];
                u.Country = (string)sdr["Country"];
                u.Phone_No = (string)sdr["Phone_No"];
                u.Email = (string)sdr["Email"];
                u.Website = (string)sdr["Website"];
                u.Business_Start_Date = (DateTime)sdr["Business_Start_Date"];
                u.Book_Start_Date = (DateTime)sdr["Book_Start_Date"];
                u.Year_Ends = (string)sdr["Year_Ends"];
                u.CUIN = (string)sdr["CUIN"];
                u.NTN = (string)sdr["NTN"];
                u.STRN = (string)sdr["STRN"];
                u.STRN_Date = (DateTime)sdr["STRN_Date"];
                u.Created_By = (int)sdr["CreatedBy"];
                u.Created_Date = (DateTime)sdr["CreatedDate"];
                u.Machine_Ip = (string)sdr["Machine_Ip"];
                u.Mac_Address = (string)sdr["Mac_Address"];

                lst.Add(u);
            }
            sdr.Close();
            return lst;
        }
        public Company Company_Get_By_ID(int id)
        {
            Company u = new Company();
            SqlCommand sc = new SqlCommand("Company_Get_By_ID", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@Company_ID", id);
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                u.Company_ID = (int)sdr["Company_ID"];
                u.Company_Name = (string)sdr["Company_Name"];
                u.Contact = (string)sdr["Contact"];
                u.Address1 = (string)sdr["Address1"];
                u.Address2 = (string)sdr["Address2"];
                u.Area = (string)sdr["Area"];
                u.Province = (string)sdr["Province"];
                u.Country = (string)sdr["Country"];
                u.Phone_No = (string)sdr["Phone_No"];
                u.Email = (string)sdr["Email"];
                u.Website = (string)sdr["Website"];
                u.Business_Start_Date = (DateTime)sdr["Business_Start_Date"];
                u.Book_Start_Date = (DateTime)sdr["Book_Start_Date"];
                u.Year_Ends = (string)sdr["Year_Ends"];
                u.CUIN = (string)sdr["CUIN"];
                u.NTN = (string)sdr["NTN"];
                u.STRN = (string)sdr["STRN"];
                u.STRN_Date = (DateTime)sdr["STRN_Date"];
                u.Created_By = (int)sdr["CreatedBy"];
                u.Created_Date = (DateTime)sdr["CreatedDate"];
                u.Machine_Ip = (string)sdr["Machine_Ip"];
                u.Mac_Address = (string)sdr["Mac_Address"];

            }
            sdr.Close();
            return u;
        }
        public void Company_Add()
        {
            SqlCommand sc = new SqlCommand("Company_Add", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure }; ;

            sc.Parameters.AddWithValue("@Company_Name", Company_Name);
            sc.Parameters.AddWithValue("@Contact", Email);
            sc.Parameters.AddWithValue("@Address1", Address1);
            sc.Parameters.AddWithValue("@Address2", Address2);
            sc.Parameters.AddWithValue("@Area", Area);
            sc.Parameters.AddWithValue("@Province", Province);
            sc.Parameters.AddWithValue("@Country", Country);
            sc.Parameters.AddWithValue("@Phone_No", Phone_No);
            sc.Parameters.AddWithValue("@Email", Email);
            sc.Parameters.AddWithValue("@Website", Website);
            sc.Parameters.AddWithValue("@Business_Start_Date", Business_Start_Date);
            sc.Parameters.AddWithValue("@Book_Start_Date", Book_Start_Date);
            sc.Parameters.AddWithValue("@Year_Ends", Year_Ends);
            sc.Parameters.AddWithValue("@CUIN", CUIN);
            sc.Parameters.AddWithValue("@NTN", NTN);
            sc.Parameters.AddWithValue("@STRN", STRN);
            sc.Parameters.AddWithValue("@STRN_Date", STRN_Date);
            sc.Parameters.AddWithValue("@Machine_Ip", Machine_Ip);
            sc.Parameters.AddWithValue("@Mac_Address", Mac_Address);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);

            sc.ExecuteNonQuery();

        }
        public void Company_Update()
        {
            SqlCommand sc = new SqlCommand("Company_Update", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure };

            sc.Parameters.AddWithValue("@Company_ID", Company_ID);
            sc.Parameters.AddWithValue("@Company_Name", Company_Name);
            sc.Parameters.AddWithValue("@Contact", Email);
            sc.Parameters.AddWithValue("@Address1", Address1);
            sc.Parameters.AddWithValue("@Address2", Address2);
            sc.Parameters.AddWithValue("@Area", Area);
            sc.Parameters.AddWithValue("@Province", Province);
            sc.Parameters.AddWithValue("@Country", Country);
            sc.Parameters.AddWithValue("@Phone_No", Phone_No);
            sc.Parameters.AddWithValue("@Email", Email);
            sc.Parameters.AddWithValue("@Website", Website);
            sc.Parameters.AddWithValue("@Business_Start_Date", Business_Start_Date);
            sc.Parameters.AddWithValue("@Book_Start_Date", Book_Start_Date);
            sc.Parameters.AddWithValue("@Year_Ends", Year_Ends);
            sc.Parameters.AddWithValue("@CUIN", CUIN);
            sc.Parameters.AddWithValue("@NTN", NTN);
            sc.Parameters.AddWithValue("@STRN", STRN);
            sc.Parameters.AddWithValue("@STRN_Date", STRN_Date);
            sc.ExecuteNonQuery();


        }
        public void Company_Delete()
        {
            SqlCommand sc = new SqlCommand("Company_Delete", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@id", Company_ID);
            sc.ExecuteNonQuery();
        }
        #endregion
        public bool Verify()
        {
            SqlCommand sc = new SqlCommand("Company_Check_Duplication", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@Company_Name", Company_Name);
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);
            object return_Data =sc.ExecuteScalar();
            return return_Data == null ? true : false;
        }
    }
   
}
