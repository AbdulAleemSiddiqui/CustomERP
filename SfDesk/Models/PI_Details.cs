using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class PI_Details
    {
        public PI_Details()
        {
            this.Machine_Ip = Utility.GetIPAddress();
            this.Mac_Address = Utility.GetMacAddress();
        }
        #region Detail
        public int PI_ID { get; set; }
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
        public int Purchase_Quantitiy { get; set; }
        [DisplayName("Received Quantitiy")]
        public int Received_Quantitiy { get; set; }

        public decimal Commision { get; set; }

        public decimal Rate { get; set; }
        [DisplayName("Gross Amount")]
        public decimal Gross_Amount { get; set; }
        public decimal Discount { get; set; }
        [DisplayName("Discount Amount")]
        public decimal Discount_Amount { get; set; }
        [DisplayName("Net Amount")]
        public decimal Net_Amount { get; set; }
        public string action { get; set; }

        public void PI_Detail_Update()
        {
            SqlCommand sc = new SqlCommand("PI_Detail_Update", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;

            sc.Parameters.AddWithValue("@Detail_ID", Detail_ID);
            sc.Parameters.AddWithValue("@Item_Code", Item_Code);
            sc.Parameters.AddWithValue("@Product_Name", Product_Name);
            sc.Parameters.AddWithValue("@Description", Product_Description);
            sc.Parameters.AddWithValue("@P_Quantity", Purchase_Quantitiy);
            sc.Parameters.AddWithValue("@R_Quantity", Received_Quantitiy);
            sc.Parameters.AddWithValue("@Commision", Commision);
            sc.Parameters.AddWithValue("@Rate", Rate);
            sc.Parameters.AddWithValue("@Gross_Amount", Gross_Amount);
            sc.Parameters.AddWithValue("@Discount", Discount);
            sc.Parameters.AddWithValue("@Discount_Amount", Discount_Amount);
            sc.Parameters.AddWithValue("@Net_Amount", Net_Amount);
            sc.Parameters.AddWithValue("@App_ID", App.App_ID);
            sc.ExecuteNonQuery();
        }
        public void PI_Detail_Delete()
        {
            SqlCommand sc = new SqlCommand("PI_Detail_Delete", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;

            sc.Parameters.AddWithValue("@Detail_ID", Detail_ID);
            sc.Parameters.AddWithValue("@App_ID", App.App_ID);
            sc.ExecuteNonQuery();
        }
        public List<PI_Details> PI_Detail_Get_All()
        {

            List<PI_Details> ls = new List<PI_Details>();
            SqlCommand sc = new SqlCommand("PI_Detail_Get_All", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);
            sc.Parameters.AddWithValue("@PI_ID", PI_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                PI_Details u = new PI_Details();
                u.PI_ID = (int)sdr["PI_ID"];
                u.Detail_ID = (int)sdr["Detail_ID"];
                u.Store = (string)sdr["Store"];
                u.Item_Code = (int)sdr["Item_Code"];
                u.Product_Name = (string)sdr["Product_Name"];
                u.Product_Description = (string)sdr["Description"];
                u.Purchase_Quantitiy = (int)sdr["Purchase_Quantity"];
                u.Received_Quantitiy = (int)sdr["Received_Quantity"];
                u.Commision = (decimal)sdr["Commision"];
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



        #endregion
        #region Default
        public int Created_By { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Created_Date { get; set; } = DateTime.Parse("2001/01/01");

        public string Machine_Ip { get; set; }

        public string Mac_Address { get; set; }
        #endregion
        public int PI_Detail_Add()
        {
            SqlCommand sc = new SqlCommand("PI_Detail_Add", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;

            sc.Parameters.AddWithValue("@PI_ID", PI_ID);
            sc.Parameters.AddWithValue("@Store", Store);
            sc.Parameters.AddWithValue("@Item_Code", Item_Code);
            sc.Parameters.AddWithValue("@Product_Name", Product_Name);
            sc.Parameters.AddWithValue("@Description", Product_Description);
            sc.Parameters.AddWithValue("@P_Quantity", Purchase_Quantitiy);
            sc.Parameters.AddWithValue("@R_Quantity", Received_Quantitiy);
            sc.Parameters.AddWithValue("@Commision", Commision);
            sc.Parameters.AddWithValue("@Rate", Rate);
            sc.Parameters.AddWithValue("@Gross_Amount", Gross_Amount);
            sc.Parameters.AddWithValue("@Discount", Discount);
            sc.Parameters.AddWithValue("@Discount_Amount", Discount_Amount);
            sc.Parameters.AddWithValue("@Net_Amount", Net_Amount);
            sc.Parameters.AddWithValue("@Machine_Ip", Machine_Ip);
            sc.Parameters.AddWithValue("@Mac_Address", Mac_Address);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);


            //u.Created_Date = (DateTime)sdr["CreatedDate"];


            return Convert.ToInt32((decimal)sc.ExecuteScalar());
        }
    }
}