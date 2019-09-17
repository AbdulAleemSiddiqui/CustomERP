using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class GDN
    {
        public int SO_ID { get; set; }
        public int GDN_ID { get; set; }
        public string GDN_NO { get; set; }
        [DisplayName("Customer")]
        public int Customer_ID { get; set; }
        public String Customer_Name { get; set; }
     
        [DisplayName("Trans. Date")]
        [DataType(DataType.Date)]
        public DateTime Trans_Date { get; set; }
        [DisplayName("Due Date")]
        [DataType(DataType.Date)]
        public DateTime Due_Date { get; set; }
      
        [DisplayName("SO. No")]
        public bool is_SO { get; set; }
       
        public string Narration { get; set; }
        #region default Properties
        public int Created_By { get; set; }
        public DateTime Created_Date { get; set; }
        public string Machine_Ip { get; set; }
        public string Mac_Address { get; set; }
        #endregion
        public GDN()
        {
            this.Machine_Ip = Utility.GetIPAddress();
            this.Mac_Address = Utility.GetMacAddress();
        }


        public List<GDN> GDN_Get_All()
        {
            List<GDN> lst = new List<GDN>();
            SqlCommand sc = new SqlCommand("GDN_Get_All", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                GDN u = new GDN();
                u.GDN_ID = (int)sdr["GDN_ID"];
                u.SO_ID = (int)sdr["SO_ID"];
                u.is_SO = (bool)sdr["is_SO"];
                u.GDN_NO = (string)sdr["GDN_NO"];
                u.Customer_ID = (int)sdr["Customer_ID"];
                u.Trans_Date = (DateTime)sdr["Trans_Date"];
                u.Due_Date = (DateTime)sdr["Due_Date"];
                u.Narration = (string)sdr["Naration"];
                u.Created_By = (int)sdr["CreatedBy"];
                u.Created_Date = (DateTime)sdr["CreatedDate"];
                u.Machine_Ip = (string)sdr["Machine_Ip"];
                u.Mac_Address = (string)sdr["Mac_Address"];
                lst.Add(u);
            }
            sdr.Close();
            return lst;
        }
        public GDN GDN_Get_By_ID()
        {
            GDN u = new GDN();
            SqlCommand sc = new SqlCommand("GDN_Get_By_ID", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@ID", GDN_ID);
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                u.GDN_ID = (int)sdr["ID"];
                u.Customer_ID = (int)sdr["Customer_ID"];
                u.Trans_Date = (DateTime)sdr["Trans_Date"];
                u.Due_Date = (DateTime)sdr["Due_Date"];
                u.GDN_NO = (string)sdr["GDN_NO"];

                u.Created_By = (int)sdr["CreatedBy"];
                u.Created_Date = (DateTime)sdr["CreatedDate"];
                u.Machine_Ip = (string)sdr["Machine_Ip"];
                u.Mac_Address = (string)sdr["Mac_Address"];
            }
            sdr.Close();
            return u;
        }
        public void GDN_Add()
        {
            SqlCommand sc = new SqlCommand("GDN_Add", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@SO_ID", SO_ID);
            sc.Parameters.AddWithValue("@Customer_ID", Customer_ID);
            sc.Parameters.AddWithValue("@SO_NO", is_SO);

            sc.Parameters.AddWithValue("@Trans_Date", Trans_Date);
            sc.Parameters.AddWithValue("@Due_Date", Due_Date);
            sc.Parameters.AddWithValue("@Narration", Narration);
            sc.Parameters.AddWithValue("@Machine_Ip", Machine_Ip);
            sc.Parameters.AddWithValue("@Mac_Address", Mac_Address);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);
            sc.ExecuteNonQuery();

        }
        public void GDN_Update()
        {
            SqlCommand sc = new SqlCommand("GDN_Update", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@GDN_ID", GDN_ID);
            sc.Parameters.AddWithValue("@SO_ID", SO_ID);
            sc.Parameters.AddWithValue("@Customer_ID", Customer_ID);
            sc.Parameters.AddWithValue("@Trans_Date", Trans_Date);
            sc.Parameters.AddWithValue("@Due_Date", Due_Date);
            sc.Parameters.AddWithValue("@Narration", Narration);
            sc.ExecuteNonQuery();
        }
        public void GDN_Delete()
        {
            SqlCommand sc = new SqlCommand("GDN_Delete", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@ID", GDN_ID);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);
            sc.ExecuteNonQuery();
        }
    }
}