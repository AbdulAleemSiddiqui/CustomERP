using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class SalesMan
    {

        public int S_ID { get; set; }
        public string Trading_Name { get; set; }
        public string NTN { get; set; }
        public string STRN { get; set; }
        public string Contact_Name { get; set; }
        public string Phone_Number { get; set; }
        public decimal Rate { get; set; }

        [DisplayName("Expense Account")]
        public int Exp_Acc_ID { get; set; }
        public string Exp_Acc_Name { get; set; }

        [DisplayName("Paybal Account")]
        public int Pay_Acc_ID { get; set; }
        public string Pay_Acc_Name { get; set; }
        public string Type { get; set; }
        public string Tax_Status { get; set; }
        public decimal WHT_Rate { get; set; }

        #region Default
        public int Created_By { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Created_Date { get; set; } = DateTime.Parse("2001/01/01");
        public string Machine_Ip { get; set; }
        public string Mac_Address { get; set; }
        public SalesMan()
        {
            this.Machine_Ip = Utility.GetIPAddress();
            this.Mac_Address = Utility.GetMacAddress();
        }

        #endregion


        public List<SalesMan> SalesMan_Get_All(int UserId)
        {
            List<SalesMan> lst = new List<SalesMan>();
            SqlCommand sc = new SqlCommand("SalesMan_Get_All", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                SalesMan u = new SalesMan();
                u.S_ID = (int)sdr["S_ID"];
                u.Trading_Name = (string)sdr["Trading_Name"];
                u.NTN = (string)sdr["NTN"];
                u.STRN = (string)sdr["STRN"];
                u.Contact_Name = (string)sdr["Contact_Name"];
                u.Phone_Number = (string)sdr["Phone_Number"];
                u.Exp_Acc_ID = (int)sdr["Exp_Acc_ID"];
                u.Exp_Acc_Name = (string)sdr["Exp_Acc_Name"];
                u.Pay_Acc_ID = (int)sdr["Pay_Acc_ID"];
                u.Pay_Acc_Name = (string)sdr["Pay_Acc_Name"];
                //u.Type = (string)sdr["Type"];
                //u.Tax_Status = (string)sdr["Tax_Status"];
                u.Rate = (decimal)sdr["Rate"];
                u.Created_By = (int)sdr["CreatedBy"];
                u.Created_Date = (DateTime)sdr["CreatedDate"];
                u.Machine_Ip = (string)sdr["Machine_Ip"];
                u.Mac_Address = (string)sdr["Mac_Address"];
                lst.Add(u);
            }
            sdr.Close();
            return lst;
        }
        public SalesMan SalesMan_Get_By_ID()
        {
            SalesMan u = new SalesMan();

            SqlCommand sc = new SqlCommand("SalesMan_Get_By_ID", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@S_ID", S_ID);
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                u.S_ID = (int)sdr["S_ID"];
                u.Trading_Name = (string)sdr["Trading_Name"];
                u.NTN = (string)sdr["NTN"];
                u.STRN = (string)sdr["STRN"];
                u.Contact_Name = (string)sdr["Contact_Name"];
                u.Phone_Number = (string)sdr["Phone_Number"];
                u.Rate = (decimal)sdr["Rate"];
                u.Exp_Acc_ID = (int)sdr["Exp_Acc_ID"];
                u.Exp_Acc_Name = (string)sdr["Exp_Acc_Name"];
                u.Pay_Acc_ID = (int)sdr["Pay_Acc_ID"];
                u.Pay_Acc_Name = (string)sdr["Pay_Acc_Name"];
                u.Type = (string)sdr["Type"];
                u.Tax_Status = (string)sdr["Tax_Status"];
                u.Rate = (decimal)sdr["Rate"];
                u.Created_By = (int)sdr["CreatedBy"];
                u.Created_Date = (DateTime)sdr["CreatedDate"];
                u.Machine_Ip = (string)sdr["Machine_Ip"];
                u.Mac_Address = (string)sdr["Mac_Address"];
            }
            sdr.Close();
            return u;
        }
        public List<SalesMan> SalesMan_Get_For_LOV()
        {
            List<SalesMan> lst = new List<SalesMan>();
            SqlCommand sc = new SqlCommand("SalesMan_Get_For_LOV", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                SalesMan u = new SalesMan();
                u.S_ID = (int)sdr["S_ID"];
                u.Trading_Name = (string)sdr["Trading_Name"];
                u.Rate = (decimal)sdr["Rate"];
                lst.Add(u);
            }
            sdr.Close();
            return lst;
        }
        public int SalesMan_Add()
        {
            SqlCommand sc = new SqlCommand("SalesMan_Add", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@Trading_Name", Trading_Name);
            sc.Parameters.AddWithValue("@NTN", NTN);
            sc.Parameters.AddWithValue("@STRN", STRN);
            sc.Parameters.AddWithValue("@Contact_Name", Contact_Name);
            sc.Parameters.AddWithValue("@Phone_Number", Phone_Number);
            sc.Parameters.AddWithValue("@ST_Rate", Rate);
            sc.Parameters.AddWithValue("@Exp_Acc_ID", Exp_Acc_ID);
            sc.Parameters.AddWithValue("@Pay_Acc_ID", Pay_Acc_ID);
            sc.Parameters.AddWithValue("@Type", Type);
            sc.Parameters.AddWithValue("@Tax_Status", Tax_Status);
            sc.Parameters.AddWithValue("@WHT_Rate", WHT_Rate);
            sc.Parameters.AddWithValue("@Machine_Ip", Machine_Ip);
            sc.Parameters.AddWithValue("@Mac_Address", Mac_Address);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);
            object a = sc.ExecuteScalar();
            return Convert.ToInt32((decimal)a);
        }
        public void SalesMan_Update()
        {
            SqlCommand sc = new SqlCommand("SalesMan_Update", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@S_ID", S_ID);
            sc.Parameters.AddWithValue("@Trading_Name", Trading_Name);
            sc.Parameters.AddWithValue("@NTN", NTN);
            sc.Parameters.AddWithValue("@STRN", STRN);
            sc.Parameters.AddWithValue("@Contact_Name", Contact_Name);
            sc.Parameters.AddWithValue("@Phone_Number", Phone_Number);
            sc.Parameters.AddWithValue("@ST_Rate", Rate);
            sc.Parameters.AddWithValue("@Exp_Acc_ID", Exp_Acc_ID);
            sc.Parameters.AddWithValue("@Pay_Acc_ID", Pay_Acc_ID);
            sc.Parameters.AddWithValue("@Type", Type);
            sc.Parameters.AddWithValue("@Tax_Status", Tax_Status);
            sc.Parameters.AddWithValue("@WHT_Rate", WHT_Rate);
            sc.ExecuteNonQuery();
        }
        public void SalesMan_Delete()
        {
            SqlCommand sc = new SqlCommand("SalesMan_Delete", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@S_ID", S_ID);
            sc.Parameters.AddWithValue("@App_ID", App.App_ID);
            sc.ExecuteNonQuery();
        }
    }
}