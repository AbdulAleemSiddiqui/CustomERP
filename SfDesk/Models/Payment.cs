using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class Payment
    {
        public int Payment_ID { get; set; }
        [DisplayName("Suplier")]
        public int Suplier_ID { get; set; }
        public string Suplier_Name { get; set; }
        public int P_No { get; set; }
        [DisplayName("Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime P_Date { get; set; }
        public string Currency { get; set; }
        public decimal ExRate { get; set; }
        [DisplayName("Job")]
        public int Job_ID { get; set; }



        public string Job_Name { get; set; }
        [DataType(DataType.MultilineText)]
        public string Naration { get; set; }
        public int Created_By { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Created_Date { get; set; } = DateTime.Parse("2001/01/01");

        public string Machine_Ip { get; set; }

        public string Mac_Address { get; set; }

        public Payment()
        {
            this.Machine_Ip = Utility.GetIPAddress();
            this.Mac_Address = Utility.GetMacAddress();
        }


        public List<Payment> Payment_Get_All()
        {
            List<Payment> lst = new List<Payment>();
            SqlCommand sc = new SqlCommand("Payment_Get_All", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@App_ID", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                Payment u = new Payment();
                u.Payment_ID = (int)sdr["Payment_ID"];
                u.Suplier_ID = (int)sdr["Suplier_ID"];
                u.Suplier_Name = (string)sdr["Suplier_Name"];
                u.P_No = (int)sdr["P_No"];
                u.P_Date = (DateTime)sdr["P_Date"];
                u.Currency = (string)sdr["Currency"];
                u.ExRate = (decimal)sdr["ExRate"];
                u.Job_ID = (int)sdr["Job_ID"];
                u.Job_Name = (string)sdr["Job_Name"];
                u.Naration = (string)sdr["Naration"];
                u.Created_By = (int)sdr["CreatedBy"];
                u.Created_Date = (DateTime)sdr["CreatedDate"];
                u.Machine_Ip = (string)sdr["Machine_Ip"];
                u.Mac_Address = (string)sdr["Mac_Address"];
                lst.Add(u);
            }
            sdr.Close();
            return lst;
        }
        public Payment Payment_Get_By_ID()
        {
            Payment u = new Payment();
            SqlCommand sc = new SqlCommand("Payment_Get_By_Payment_ID", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@Payment_ID", Payment_ID);
            sc.Parameters.AddWithValue("@App_ID", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                u.Payment_ID = (int)sdr["Payment_ID"];
                u.Suplier_ID = (int)sdr["Suplier_ID"];
                u.Suplier_Name = (string)sdr["Suplier_Name"];
                u.P_No = (int)sdr["P_No"];
                u.P_Date = (DateTime)sdr["P_Date"];
                u.Currency = (string)sdr["Currency"];
                u.ExRate = (decimal)sdr["ExRate"];
                u.Job_ID = (int)sdr["Job_ID"];
                u.Job_Name = (string)sdr["Job_Name"];
                u.Naration = (string)sdr["Naration"];
                u.Created_By = (int)sdr["CreatedBy"];
                u.Created_Date = (DateTime)sdr["CreatedDate"];
                u.Machine_Ip = (string)sdr["Machine_Ip"];
                u.Mac_Address = (string)sdr["Mac_Address"];
            }
            sdr.Close();
            return u;
        }

        public decimal  Payment_Add()
        {
            SqlCommand sc = new SqlCommand("Payment_Add", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@Suplier_ID", Suplier_ID);
            sc.Parameters.AddWithValue("@P_Date", P_Date);
            sc.Parameters.AddWithValue("@Currency", Currency);
            sc.Parameters.AddWithValue("@ExRate", ExRate);
            sc.Parameters.AddWithValue("@Job_ID", Job_ID);
            sc.Parameters.AddWithValue("@Narrations", Naration);
            sc.Parameters.AddWithValue("@Machine_Ip", Machine_Ip);
            sc.Parameters.AddWithValue("@Mac_Address", Mac_Address);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);
            object a = sc.ExecuteScalar();
            return Convert.ToInt32((decimal)a);

        }
        public void Payment_Update()
        {
            SqlCommand sc = new SqlCommand("Payment_Update", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@Payment_ID", Payment_ID);
            sc.Parameters.AddWithValue("@Suplier_ID", Suplier_ID);
            sc.Parameters.AddWithValue("@Suplier_Name", Suplier_Name);
            sc.Parameters.AddWithValue("@P_No", P_No);
            sc.Parameters.AddWithValue("@P_Date", P_Date);
            sc.Parameters.AddWithValue("@Currency", Currency);
            sc.Parameters.AddWithValue("@ExRate", ExRate);
            sc.Parameters.AddWithValue("@Job_ID", Job_ID);
            sc.Parameters.AddWithValue("@Job_Name", Job_Name);
            sc.Parameters.AddWithValue("@Naration", Naration);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);
            sc.ExecuteNonQuery();
        }
        public void Payment_Delete()
        {
            SqlCommand sc = new SqlCommand("Payment_Delete", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@Payment_ID", Payment_ID);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);
            sc.ExecuteNonQuery();
        }
    }

}

