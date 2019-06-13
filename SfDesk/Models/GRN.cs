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
        public int GRN_NO { get; set; }
        [DisplayName("Suplier")]
        public int Suplier_ID { get; set; }
        public String Suplier_Name { get; set; }
        [DisplayName("Trans. NO")]
        public int Trans_NO { get; set; }
        [DisplayName("Trans. Date")]
        [DataType(DataType.Date)]
        public DateTime Trans_Date { get; set; }
        [DisplayName("Due Date")]
        [DataType(DataType.Date)]
        public DateTime Due_Date { get; set; }
        public string Currency { get; set; }
        [DisplayName("Ref. No")]
        public int Ref_No { get; set; }
        [DisplayName("Ex. Rate")]

        public decimal Exchange_Rate { get; set; }

            #region default Properties
            public int Created_By { get; set; }
            public DateTime Created_Date { get; set; }
            public string Machine_Ip { get; set; }
            public string Mac_Address { get; set; }
            #endregion
            public GRN()
            {
                this.Machine_Ip = Utility.GetIPAddress();
                this.Mac_Address = Utility.GetMacAddress();
            }


            public List<GRN> GRN_Get_All()
            {
                List<GRN> lst = new List<GRN>();
                SqlCommand sc = new SqlCommand("GRN_Get_All", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
                sc.Parameters.AddWithValue("@App_Id", App.App_ID);
                SqlDataReader sdr = sc.ExecuteReader();
                while (sdr.Read())
                {
                    GRN u = new GRN();
                    u.GRN_NO = (int)sdr["ID"];
                    u.Suplier_ID = (int)sdr["Suplier_ID"];
                    u.Trans_NO = (int)sdr["Trans_NO"];
                    u.Trans_Date = (DateTime)sdr["Trans_Date"];
                    u.Due_Date = (DateTime)sdr["Due_Date"];
                    u.Currency = (string)sdr["Currency"];
                    u.Ref_No = (int)sdr["Ref_No"];
                    u.Exchange_Rate = (decimal)sdr["Exchange_Rate"];
                    u.Created_By = (int)sdr["CreatedBy"];
                    u.Created_Date = (DateTime)sdr["CreatedDate"];
                    u.Machine_Ip = (string)sdr["Machine_Ip"];
                    u.Mac_Address = (string)sdr["Mac_Address"];
                    lst.Add(u);
                }
                sdr.Close();
                return lst;
            }
            public GRN GRN_Get_By_ID()
            {
                GRN u = new GRN();
                SqlCommand sc = new SqlCommand("GRN_Get_By_ID", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
                sc.Parameters.AddWithValue("@ID", GRN_NO);
                sc.Parameters.AddWithValue("@App_Id", App.App_ID);
                SqlDataReader sdr = sc.ExecuteReader();
                while (sdr.Read())
                {
                u.GRN_NO = (int)sdr["ID"];
                u.Suplier_ID = (int)sdr["Suplier_ID"];
                u.Trans_NO = (int)sdr["Trans_NO"];
                u.Trans_Date = (DateTime)sdr["Trans_Date"];
                u.Due_Date = (DateTime)sdr["Due_Date"];
                u.Currency = (string)sdr["Currency"];
                u.Ref_No = (int)sdr["Ref_No"];
                u.Exchange_Rate = (decimal)sdr["Exchange_Rate"];
                u.Created_By = (int)sdr["CreatedBy"];
                u.Created_Date = (DateTime)sdr["CreatedDate"];
                u.Machine_Ip = (string)sdr["Machine_Ip"];
                u.Mac_Address = (string)sdr["Mac_Address"];
            }
                sdr.Close();
                return u;
            }

            public void GRN_Add()
            {
                SqlCommand sc = new SqlCommand("GRN_Add", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
                sc.Parameters.AddWithValue("@Suplier_ID", Suplier_ID);
                sc.Parameters.AddWithValue("@Trans_NO", Trans_NO);
                sc.Parameters.AddWithValue("@Trans_Date", Trans_Date);
                sc.Parameters.AddWithValue("@Due_Date", Due_Date);
                sc.Parameters.AddWithValue("@Currency", Currency);
                sc.Parameters.AddWithValue("@Ref_No", Ref_No);
                sc.Parameters.AddWithValue("@Machine_Ip", Machine_Ip);
                sc.Parameters.AddWithValue("@Mac_Address", Mac_Address);
                sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);
                sc.ExecuteNonQuery();

            }
            public void GRN_Update()
            {
                SqlCommand sc = new SqlCommand("GRN_Update", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
                sc.Parameters.AddWithValue("@ID", GRN_NO);
                sc.Parameters.AddWithValue("@Suplier_ID", Suplier_ID);
                sc.Parameters.AddWithValue("@Trans_NO", Trans_NO);
                sc.Parameters.AddWithValue("@Trans_Date", Trans_Date);
                sc.Parameters.AddWithValue("@Due_Date", Due_Date);
                sc.Parameters.AddWithValue("@Currency", Currency);
                sc.Parameters.AddWithValue("@Ref_No", Ref_No);
                sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);
                sc.ExecuteNonQuery();
            }
            public void GRN_Delete()
            {
                SqlCommand sc = new SqlCommand("GRN_Delete", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
                sc.Parameters.AddWithValue("@ID", GRN_NO    );
                sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);
                sc.ExecuteNonQuery();
            }
        }   
    }
