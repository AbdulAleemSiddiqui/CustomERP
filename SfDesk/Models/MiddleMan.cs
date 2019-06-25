using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class MiddleMan
    {
        public int MM_ID { get; set; }
        public string Trading_Name{ get; set; }
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


        #region Default
        public int Created_By { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Created_Date { get; set; } = DateTime.Parse("2001/01/01");
        public string Machine_Ip { get; set; }
        public string Mac_Address { get; set; }

        #endregion


        public List<MiddleMan> MiddleMan_Get_All()
        {
            List<MiddleMan> lst = new List<MiddleMan>();
            SqlCommand sc = new SqlCommand("MiddleMan_Get_All", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                MiddleMan u = new MiddleMan();
                u.MM_ID = (int)sdr["MM_ID"];
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
                u.Created_By = (int)sdr["CreatedBy"];
                u.Created_Date = (DateTime)sdr["CreatedDate"];
                u.Machine_Ip = (string)sdr["Machine_Ip"];
                u.Mac_Address = (string)sdr["Mac_Address"];
                lst.Add(u);
            }
            sdr.Close();
            return lst;
        }
        public List<MiddleMan> MiddleMan_Get_For_LOV()
        {
            List<MiddleMan> lst = new List<MiddleMan>();
            SqlCommand sc = new SqlCommand("MiddleMan_Get_For_LOV", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                MiddleMan u = new MiddleMan();
                u.MM_ID = (int)sdr["MM_ID"];
                u.Trading_Name = (string)sdr["Trading_Name"];
                lst.Add(u);
            }
            sdr.Close();
            return lst;
        }
        public void MiddleMan_Add()
        {
            SqlCommand sc = new SqlCommand("MiddleMan_Add", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@Trading_Name", Trading_Name);
            sc.Parameters.AddWithValue("@NTN", NTN);
            sc.Parameters.AddWithValue("@STRN", STRN);
            sc.Parameters.AddWithValue("@Contact_Name", Contact_Name);
            sc.Parameters.AddWithValue("@Phone_Number", Phone_Number);
            sc.Parameters.AddWithValue("@Rate", Rate);
            sc.Parameters.AddWithValue("@Exp_Acc_ID", Exp_Acc_ID);
            sc.Parameters.AddWithValue("@Pay_Acc_ID", Pay_Acc_ID);
            sc.Parameters.AddWithValue("@Machine_Ip", Machine_Ip);
            sc.Parameters.AddWithValue("@Mac_Address", Mac_Address);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);
            sc.ExecuteNonQuery();

        }
        public void MiddleMan_Update()
        {
            SqlCommand sc = new SqlCommand("MiddleMan_Update", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@MM_ID", MM_ID);
            sc.Parameters.AddWithValue("@Trading_Name", Trading_Name);
            sc.Parameters.AddWithValue("@NTN", NTN);
            sc.Parameters.AddWithValue("@STRN", STRN);
            sc.Parameters.AddWithValue("@Contact_Name", Contact_Name);
            sc.Parameters.AddWithValue("@Phone_Number", Phone_Number);
            sc.Parameters.AddWithValue("@Rate", Rate);
            sc.Parameters.AddWithValue("@Exp_Acc_ID", Exp_Acc_ID);
            sc.Parameters.AddWithValue("@Pay_Acc_ID", Pay_Acc_ID);
            sc.ExecuteNonQuery();
        }
        public void MiddleMan_Delete()
        {
            SqlCommand sc = new SqlCommand("MiddleMan_Delete", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@MM_ID", MM_ID);
            sc.Parameters.AddWithValue("@App_ID", App.App_ID);
            sc.ExecuteNonQuery();
        }
    }
}