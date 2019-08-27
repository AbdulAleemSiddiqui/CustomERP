using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class SO_Details
    {
           #region Detail
        public int SO_ID { get; set; }
        public int Detail_ID { get; set; }
        [DisplayName("Store / Godown")]
        public string Store { get; set; } = "";
        [DisplayName("Item Code")]
        public int Item_Code { get; set; }
        [DisplayName("Product Name")]
        public string Product_Name { get; set; } = "";
        [DisplayName("Product Description")]
        public string Product_Description { get; set; } = "";
        [DisplayName("Purchase Quantitiy")]
        public int Quantity { get; set; }
        [DisplayName("Received Quantitiy")]
        public int Dispatch_Quantitiy { get; set; }
        public decimal Rate { get; set; }
        [DisplayName("Gross Amount")]
        public decimal Gross_Amount { get; set; }
        public decimal Discount { get; set; }
        [DisplayName("Discount Amount")]
        public decimal Discount_Amount { get; set; }
        [DisplayName("Net Amount")]
        public decimal Net_Amount { get; set; }
        public string action { get; set; }

    



        #endregion
        #region Default
        public int Created_By { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Created_Date { get; set; } = DateTime.Parse("2001/01/01");

        public string Machine_Ip { get; set; }

        public string Mac_Address { get; set; }
        #endregion
        public void SO_Detail_Update()
        {
            SqlCommand sc = new SqlCommand("SO_Detail_Update", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;

            sc.Parameters.AddWithValue("@Detail_ID", Detail_ID);
            sc.Parameters.AddWithValue("@Item_Code", Item_Code);
            sc.Parameters.AddWithValue("@Product_Name", Product_Name);
            sc.Parameters.AddWithValue("@Description", Product_Description);
            sc.Parameters.AddWithValue("@P_Quantity", Quantity);
            sc.Parameters.AddWithValue("@R_Quantity", Dispatch_Quantitiy);
            sc.Parameters.AddWithValue("@Rate", Rate);
            sc.Parameters.AddWithValue("@Gross_Amount", Gross_Amount);
            sc.Parameters.AddWithValue("@Discount", Discount);
            sc.Parameters.AddWithValue("@Discount_Amount", Discount_Amount);
            sc.Parameters.AddWithValue("@Net_Amount", Net_Amount);
            sc.Parameters.AddWithValue("@App_ID", App.App_ID);
            sc.ExecuteNonQuery();
        }
        public void SO_Detail_Delete()
        {
            SqlCommand sc = new SqlCommand("SO_Detail_Delete", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;

            sc.Parameters.AddWithValue("@Detail_ID", Detail_ID);
            sc.Parameters.AddWithValue("@App_ID", App.App_ID);
            sc.ExecuteNonQuery();
        }
        public List<SO_Details> SO_Detail_Get_All()
        {

            List<SO_Details> ls = new List<SO_Details>();
            SqlCommand sc = new SqlCommand("SO_Detail_Get_All", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);
            sc.Parameters.AddWithValue("@SO_ID", SO_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                SO_Details u = new SO_Details();
                u.SO_ID = (int)sdr["SO_ID"];
                u.Detail_ID = (int)sdr["Detail_ID"];
                u.Store = (string)sdr["Store"];
                u.Item_Code = (int)sdr["Item_Code"];
                u.Product_Name = (string)sdr["Product_Name"];
                u.Product_Description = (string)sdr["Description"];
                u.Quantity = (int)sdr["Purchase_Quantity"];
                u.Dispatch_Quantitiy = (int)sdr["Dispatch_Quantitiy"];
                u.Rate = (decimal)sdr["Rate"];
                u.Gross_Amount = (decimal)sdr["Gross_Amount"];
                u.Discount = (decimal)sdr["Discount"];
                u.Discount_Amount = (decimal)sdr["Discount_Amount"];
                u.Net_Amount = (decimal)sdr["Net_Amount"];

                u.Created_By = (int)sdr["CreatedBy"];
                u.Created_Date = (DateTime)sdr["CreatedDate"];
                u.Machine_Ip = (string)sdr["Machine_Ip"];
                u.Mac_Address = (string)sdr["Mac_Address"];
                ls.Add(u);
            }
            sdr.Close();
            return ls;
        }
        public int SO_Detail_Add()
        {
            SqlCommand sc = new SqlCommand("SO_Detail_Add", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;

            sc.Parameters.AddWithValue("@SO_ID", SO_ID);
            sc.Parameters.AddWithValue("@Store", Store);
            sc.Parameters.AddWithValue("@Item_Code", Item_Code);
            sc.Parameters.AddWithValue("@Product_Name", Product_Name);
            sc.Parameters.AddWithValue("@Description", Product_Description);
            sc.Parameters.AddWithValue("@P_Quantity", Quantity);
            sc.Parameters.AddWithValue("@R_Quantity", Dispatch_Quantitiy);
            sc.Parameters.AddWithValue("@Rate", Rate);
            sc.Parameters.AddWithValue("@Gross_Amount", Gross_Amount);
            sc.Parameters.AddWithValue("@Discount", Discount);
            sc.Parameters.AddWithValue("@Discount_Amount", Discount_Amount);
            sc.Parameters.AddWithValue("@Net_Amount", Net_Amount);
            sc.Parameters.AddWithValue("@Machine_Ip", Machine_Ip);
            sc.Parameters.AddWithValue("@Mac_Address", Mac_Address);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);


            //u.Created_Date = (DateTime)sdr["CreatedDate"];


            object a = sc.ExecuteScalar();
            if (typeof(int) == a.GetType())
            {
                return (int)a;
            }
            else if (typeof(decimal) == a.GetType())
            {
                return Convert.ToInt32((decimal)a);
            }
            return 0;
        }
    }
}