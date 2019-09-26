using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class GRN
    {
        public int PO_ID { get; set; }
        public int GRN_ID { get; set; }
        public string GRN_NO { get; set; }
        [DisplayName("Suplier")]
        public int Suplier_ID { get; set; }
        public String Suplier_Name { get; set; }

        [DisplayName("Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Now;

        [DisplayName("Ref. No")]
        public string Ref_No { get; set; }
        [DisplayName("Vehicle #")]
        public int Vehicle_ID { get; set; }
        public string Vehicle_No { get; set; }
        [DisplayName("Transporter Name")]
        public int Transporter_ID { get; set; }
        public string Transporter_Name { get; set; }
        #region default Properties
        public int Created_By { get; set; }
        public DateTime Created_Date { get; set; }
        public string Machine_Ip { get; set; }
        public string Mac_Address { get; set; }
        #endregion


        #region comment
        //public List<GRN> GRN_Get_All()
        //{
        //    List<GRN> lst = new List<GRN>();
        //    SqlCommand sc = new SqlCommand("GRN_Get_All", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
        //    sc.Parameters.AddWithValue("@App_Id", App.App_ID);
        //    SqlDataReader sdr = sc.ExecuteReader();
        //    while (sdr.Read())
        //    {
        //        GRN u = new GRN();
        //       // u.GRN_NO = (int)sdr["ID"];
        //        u.Suplier_ID = (int)sdr["Suplier_ID"];
        //        u.Trans_NO = (int)sdr["Trans_NO"];
        //        u.Trans_Date = (DateTime)sdr["Trans_Date"];
        //        u.Due_Date = (DateTime)sdr["Due_Date"];
        //        u.Currency_ID = (string)sdr["Currency_ID"];
        //        u.Ref_No = (int)sdr["Ref_No"];
        //        u.Exchange_Rate = (decimal)sdr["Exchange_Rate"];
        //        u.Created_By = (int)sdr["CreatedBy"];
        //        u.Created_Date = (DateTime)sdr["CreatedDate"];
        //        u.Machine_Ip = (string)sdr["Machine_Ip"];
        //        u.Mac_Address = (string)sdr["Mac_Address"];
        //        lst.Add(u);
        //    }
        //    sdr.Close();
        //    return lst;
        //}
        //public GRN GRN_Get_By_ID()
        //{
        //    GRN u = new GRN();
        //    SqlCommand sc = new SqlCommand("GRN_Get_By_ID", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
        //    sc.Parameters.AddWithValue("@ID", GRN_NO);
        //    sc.Parameters.AddWithValue("@App_Id", App.App_ID);
        //    SqlDataReader sdr = sc.ExecuteReader();
        //    while (sdr.Read())
        //    {
        //        u.GRN_NO = (int)sdr["ID"];
        //        u.Suplier_ID = (int)sdr["Suplier_ID"];
        //        u.Trans_NO = (int)sdr["Trans_NO"];
        //        u.Trans_Date = (DateTime)sdr["Trans_Date"];
        //        u.Due_Date = (DateTime)sdr["Due_Date"];
        //        u.Currency_ID = (string)sdr["Currency_ID"];
        //        u.Ref_No = (int)sdr["Ref_No"];
        //        u.Exchange_Rate = (decimal)sdr["Exchange_Rate"];
        //        u.Created_By = (int)sdr["CreatedBy"];
        //        u.Created_Date = (DateTime)sdr["CreatedDate"];
        //        u.Machine_Ip = (string)sdr["Machine_Ip"];
        //        u.Mac_Address = (string)sdr["Mac_Address"];
        //    }
        //    sdr.Close();
        //    return u;
        //}
        //public void GRN_Add()
        //{
        //    SqlCommand sc = new SqlCommand("GRN_Add", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
        //    sc.Parameters.AddWithValue("@PI_ID", PO_ID);
        //    sc.Parameters.AddWithValue("@Suplier_ID", Suplier_ID);
        //    sc.Parameters.AddWithValue("@Trans_NO", Trans_NO);
        //    sc.Parameters.AddWithValue("@Trans_Date", Trans_Date);
        //    sc.Parameters.AddWithValue("@Due_Date", Due_Date);
        //    sc.Parameters.AddWithValue("@Currency_ID", Currency_ID);
        //    sc.Parameters.AddWithValue("@Ref_No", Ref_No);
        //    sc.Parameters.AddWithValue("@Exchange_Rate", Exchange_Rate);
        //    sc.Parameters.AddWithValue("@Narration",  Narration);
        //    sc.Parameters.AddWithValue("@Machine_Ip", Machine_Ip);
        //    sc.Parameters.AddWithValue("@Mac_Address", Mac_Address);
        //    sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);
        //    sc.ExecuteNonQuery();

        //}
        //public void GRN_Update()
        //{
        //    SqlCommand sc = new SqlCommand("GRN_Update", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
        //    sc.Parameters.AddWithValue("@GRN_ID", GRN_NO);
        //    sc.Parameters.AddWithValue("@PI_ID", PO_ID);
        //    sc.Parameters.AddWithValue("@Suplier_ID", Suplier_ID);
        //    sc.Parameters.AddWithValue("@Trans_NO", Trans_NO);
        //    sc.Parameters.AddWithValue("@Trans_Date", Trans_Date);
        //    sc.Parameters.AddWithValue("@Due_Date", Due_Date);
        //    sc.Parameters.AddWithValue("@Currency_ID", Currency_ID);
        //    sc.Parameters.AddWithValue("@Ref_No", Ref_No);
        //    sc.Parameters.AddWithValue("@Exchange_Rate", Exchange_Rate);
        //    sc.Parameters.AddWithValue("@Narration", Narration);
        //    sc.ExecuteNonQuery();
        //}
        //public void GRN_Delete()
        //{
        //    SqlCommand sc = new SqlCommand("GRN_Delete", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
        //    sc.Parameters.AddWithValue("@ID", GRN_NO);
        //    sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);
        //    sc.ExecuteNonQuery();
        //}
        #endregion
    }
}
