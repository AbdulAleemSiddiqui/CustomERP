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
    public class ChartOfAccount
    {
        #region Properties
        [DisplayName("ID")]
        public int COA_ID { get; set; }
        public int Code { get; set; }
        [DisplayName("Company Code")]
        public int Company_Code { get; set; }
        public int Type_ID { get; set; }
        public int Group_ID { get; set; }
        [DisplayName("Account Name")]
        public string COA_Name { get; set; }
        [DisplayName("Type")]
        public string Type_Name { get; set; }
        [DisplayName("Group")]
        public string Group_Name { get; set; }

        public string Nature { get; set; }


        public int Created_By { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Created_Date { get; set; } = DateTime.Parse("2001/01/01");

        public string Machine_Ip { get; set; }

        public string Mac_Address { get; set; }

        public ChartOfAccount()
        {
            this.Machine_Ip = Utility.GetIPAddress();
            this.Mac_Address = Utility.GetMacAddress();
        }


        #endregion

        public void COA_Add()
        {
            SqlCommand sc = new SqlCommand("COA_Add", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@Company_Code", ((user)HttpContext.Current.Session["ID"]).CompanyCode);
            sc.Parameters.AddWithValue("@COA_Name", COA_Name);
            sc.Parameters.AddWithValue("@Group_ID", Group_ID);
            sc.Parameters.AddWithValue("@Type_ID", Type_ID);
            sc.Parameters.AddWithValue("@Machine_Ip", Machine_Ip);
            sc.Parameters.AddWithValue("@Mac_Address", Mac_Address);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);

            sc.ExecuteNonQuery();
        }
        public void COA_Update()
        {
            SqlCommand sc = new SqlCommand("COA_Edit", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@App_ID", App.App_ID);
            sc.Parameters.AddWithValue("@COA_Name", COA_Name);
            sc.Parameters.AddWithValue("@COA_ID", COA_ID);
            sc.ExecuteNonQuery();
        }
        public void COA_Delete()
        {
            SqlCommand sc = new SqlCommand("COA_Delete", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@App_ID", App.App_ID);
            sc.Parameters.AddWithValue("@COA_ID", COA_ID);
            sc.ExecuteNonQuery();
        }
        public ChartOfAccount COA_Get_By_ID()
        {
            SqlCommand sc = new SqlCommand("COA_Get_By_ID", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@App_ID", App.App_ID);
            sc.Parameters.AddWithValue("@COA_ID", COA_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            ChartOfAccount u = new ChartOfAccount();
            if (sdr.Read())
            {
                
                u.COA_ID = (int)sdr["Coa_ID"];
                u.COA_Name = (string)sdr["COA_Name"];
                u.Code = (int)sdr["Code"];
                u.Type_ID = (int)sdr["Type_ID"];
                u.Type_Name = (string)sdr["Type_Name"];
                u.Group_ID = (int)sdr["Group_ID"];
                u.Group_Name = (string)sdr["G_Name"];
                u.Nature = (string)sdr["Nature"];
            }
            sdr.Close();
            return u;
        }
        public List<ChartOfAccount> COA_Get_All()
        {
            List<ChartOfAccount> lst = new List<ChartOfAccount>();

            SqlCommand sc = new SqlCommand("COA_Get_All", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@Company_Code", ((user)HttpContext.Current.Session["ID"]).CompanyCode);
            sc.Parameters.AddWithValue("@App_ID", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                ChartOfAccount u = new ChartOfAccount();
                u.COA_ID = (int)sdr["Coa_ID"];
                u.COA_Name = (string)sdr["COA_Name"];
                u.Code = (int)sdr["Code"];
                u.Type_ID = (int)sdr["Type_ID"];
                u.Type_Name = (string)sdr["Type_Name"];
                u.Group_ID = (int)sdr["Group_ID"];
                u.Group_Name = (string)sdr["G_Name"];
                u.Nature = (string)sdr["Nature"];
                lst.Add(u);
            }
            sdr.Close();
            return lst;
        }
        public List<ChartOfAccount> COA_Get_All_For_Account_Payable()
        {
            List<ChartOfAccount> lst = new List<ChartOfAccount>();

            SqlCommand sc = new SqlCommand("COA_Get_All_For_Account_Payable", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@Company_Code", ((user)HttpContext.Current.Session["ID"]).CompanyCode);
            sc.Parameters.AddWithValue("@App_ID", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                ChartOfAccount u = new ChartOfAccount();
                u.COA_ID = (int)sdr["Coa_ID"];
                u.COA_Name = (string)sdr["COA_Name"];
                u.Code = (int)sdr["Code"];
                u.Type_ID = (int)sdr["Type_ID"];
                u.Type_Name = (string)sdr["Type_Name"];
                u.Group_ID = (int)sdr["Group_ID"];
                u.Group_Name = (string)sdr["G_Name"];
                u.Nature = (string)sdr["Nature"];
                lst.Add(u);
            }
            sdr.Close();
            return lst;
        }
        public List<ChartOfAccount>COA_Get_All_For_Purchase_Account()
        {
            List<ChartOfAccount> lst = new List<ChartOfAccount>();

            SqlCommand sc = new SqlCommand("COA_Get_All_For_Purchase_Account", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@Company_Code", ((user)HttpContext.Current.Session["ID"]).CompanyCode);
            sc.Parameters.AddWithValue("@App_ID", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                ChartOfAccount u = new ChartOfAccount();
                u.COA_ID = (int)sdr["Coa_ID"];
                u.COA_Name = (string)sdr["COA_Name"];
                u.Code = (int)sdr["Code"];
                u.Type_ID = (int)sdr["Type_ID"];
                u.Type_Name = (string)sdr["Type_Name"];
                u.Group_ID = (int)sdr["Group_ID"];
                u.Group_Name = (string)sdr["G_Name"];
                u.Nature = (string)sdr["Nature"];
                lst.Add(u);
            }
            sdr.Close();
            return lst;
        }
        public int COA_Get_Last_Code()
        {
            List<ChartOfAccount> lst = new List<ChartOfAccount>();
            SqlCommand sc = new SqlCommand("COA_Get_Last_Code", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@Company_Code", ((user)HttpContext.Current.Session["ID"]).CompanyCode);
            sc.Parameters.AddWithValue("@Type_ID", Type_ID);
            sc.Parameters.AddWithValue("@App_ID", App.App_ID);
            sc.Parameters.Add("@code", SqlDbType.Int);
            sc.Parameters["@code"].Direction = ParameterDirection.Output;
            sc.ExecuteNonQuery();
            int c = 0;
            c = (int)sc.Parameters["@code"].Value;
            return (int)c;
        }
    }
}