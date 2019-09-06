using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class PO_Details
    {
      
        #region Detail
        public int PO_ID { get; set; }
        public int POD_ID { get; set; }
        public string PI_NO { get; set; }
        public int PI_ID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PI_Date { get; set; }
        [DisplayName("Item Code")]
        public int Item_Code { get; set; }
        [DisplayName("Item Name")]
        public string Item_Name { get; set; } = "";
        [DisplayName("Item Desc.")]
        public string Item_Description { get; set; } = "";
        [DisplayName("PI Quantitiy")]
        public int PI_Qty { get; set; }
        [DisplayName("PO Quantitiy")]
        public int PO_Qty { get; set; }

        public string action { get; set; }
        public int Item_Cat_ID { get; set; }

        public void PO_Detail_Update()
        {
            SqlCommand sc = new SqlCommand("PO_Detail_Update", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;

            sc.Parameters.AddWithValue("@POD_ID", POD_ID);
            sc.Parameters.AddWithValue("@Item_Code", Item_Code);
            sc.Parameters.AddWithValue("@Item_Name", Item_Name);
            sc.Parameters.AddWithValue("@Quantity", PO_Qty);
           
            sc.Parameters.AddWithValue("@App_ID", App.App_ID);
            sc.ExecuteNonQuery();
        }
        public void PO_Detail_Delete()
        {
            SqlCommand sc = new SqlCommand("PO_Detail_Delete", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;

            sc.Parameters.AddWithValue("@POD_ID", POD_ID);
            sc.Parameters.AddWithValue("@App_ID", App.App_ID);
            sc.ExecuteNonQuery();
        }
        public List<PO_Details> PO_Detail_Get_All()
        {

            List<PO_Details> ls = new List<PO_Details>();
            SqlCommand sc = new SqlCommand("PO_Detail_Get_All", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);
            sc.Parameters.AddWithValue("@PO_ID", PO_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                PO_Details u = new PO_Details();
                u.PO_ID = (int)sdr["PO_ID"];
                u.POD_ID = (int)sdr["POD_ID"];
               
                u.Item_Code = (int)sdr["Item_Code"];
                u.Item_Name = (string)sdr["Item_Name"];
              PO_Qty = (int)sdr["Quantity"];
                
                u.Created_By = (int)sdr["CreatedBy"];
                u.Created_Date = (DateTime)sdr["CreatedDate"];
                u.Machine_Ip = (string)sdr["Machine_Ip"];
                u.Mac_Address = (string)sdr["Mac_Address"];
                ls.Add(u);
            }
            sdr.Close();
            return ls;
        }
        public int PO_Detail_Add()
        {
            SqlCommand sc = new SqlCommand("PO_Detail_Add", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;

            sc.Parameters.AddWithValue("@PO_ID", PO_ID);
           
            sc.Parameters.AddWithValue("@Item_Code", Item_Code);
            sc.Parameters.AddWithValue("@Item_Name", Item_Name);
           
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