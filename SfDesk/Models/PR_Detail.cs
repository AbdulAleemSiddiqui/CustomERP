using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class PR_Details
    {
        #region Detail
        public int PR_ID { get; set; }
        public int Detail_ID { get; set; }
        [DisplayName("Store / Godown")]
        public string Store { get; set; } = "";
        [DisplayName("Item Code")]
        public int Item_Code { get; set; }
        [DisplayName("Product Name")]
        public string Product_Name { get; set; } = "";
        [DisplayName("Product Description")]
        public string Product_Description { get; set; } = "";
        [DisplayName("Quantitiy")]
        public int Quantitiy { get; set; }
       
        public string action { get; set; }

        public void PR_Detail_Update()
        {
            SqlCommand sc = new SqlCommand("PR_Detail_Update", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;

            sc.Parameters.AddWithValue("@Detail_ID", Detail_ID);
            sc.Parameters.AddWithValue("@Item_Code", Item_Code);
            sc.Parameters.AddWithValue("@Product_Name", Product_Name);
            sc.Parameters.AddWithValue("@Description", Product_Description);
            sc.Parameters.AddWithValue("@P_Quantity", Quantitiy);
            sc.Parameters.AddWithValue("@App_ID", App.App_ID);
            sc.ExecuteNonQuery();
        }
        public void PR_Detail_Delete()
        {
            SqlCommand sc = new SqlCommand("PR_Detail_Delete", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;

            sc.Parameters.AddWithValue("@Detail_ID", Detail_ID);
            sc.Parameters.AddWithValue("@App_ID", App.App_ID);
            sc.ExecuteNonQuery();
        }
        public List<PR_Details> PR_Detail_Get_All()
        {

            List<PR_Details> ls = new List<PR_Details>();
            SqlCommand sc = new SqlCommand("PR_Detail_Get_All", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);
            sc.Parameters.AddWithValue("@PI_ID", PR_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                PR_Details u = new PR_Details();
              
                u.Detail_ID = (int)sdr["Detail_ID"];
                u.Store = (string)sdr["Store"];
                u.Item_Code = (int)sdr["Item_Code"];
                u.Product_Name = (string)sdr["Product_Name"];
                u.Product_Description = (string)sdr["Description"];
             

                u.Created_By = (int)sdr["CreatedBy"];
                u.Created_Date = (DateTime)sdr["CreatedDate"];
                u.Machine_Ip = (string)sdr["Machine_Ip"];
                u.Mac_Address = (string)sdr["Mac_Address"];
                ls.Add(u);
            }
            sdr.Close();
            return ls;
        }
        public int PR_Detail_Add()
        {
            SqlCommand sc = new SqlCommand("PR_Detail_Add", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;

            sc.Parameters.AddWithValue("@PI_ID", PR_ID);
            sc.Parameters.AddWithValue("@Store", Store);
            sc.Parameters.AddWithValue("@Item_Code", Item_Code);
            sc.Parameters.AddWithValue("@Product_Name", Product_Name);
            sc.Parameters.AddWithValue("@Description", Product_Description);
            sc.Parameters.AddWithValue("@P_Quantity", Quantitiy);
           
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


        #endregion
        #region Default
        public int Created_By { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Created_Date { get; set; } = DateTime.Parse("2001/01/01");

        public string Machine_Ip { get; set; }

        public string Mac_Address { get; set; }
        #endregion
    }
}