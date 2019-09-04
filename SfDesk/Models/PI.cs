using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{


    public class PI
    {
        public int PI_ID { get; set; }
        public string PI_No { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int Item_Cat_Id { get; set; }
        public string Item_Cat_Name { get; set; }

        public List<PI_Detail_ViewModel> PI_Details { get; set; }
        #region default Properties
        public int Created_By { get; set; }
        public DateTime Created_Date { get; set; }
        public string Machine_Ip { get; set; }
        public string Mac_Address { get; set; }
        #endregion
        public PI()
        {
            this.Machine_Ip = Utility.GetIPAddress();
            this.Mac_Address = Utility.GetMacAddress();
        }


        public List<PI> PI_Get_All()
        {
            List<PI> lst = new List<PI>();
            SqlCommand sc = new SqlCommand("PI_Get_All", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                PI u = new PI();
                u.PI_ID = (int)sdr["PI_ID"];
                u.PI_No = (string)sdr["PI_No"];
                u.Date = (DateTime)sdr["Date"];
                u.Description = (string)sdr["Description"];
                u.Item_Cat_Id = (int)sdr["Item_Cat_Id"];
                u.Item_Cat_Name = (string)sdr["Item_Cat_Name"];
             
                u.Created_By = (int)sdr["CreatedBy"];
                u.Created_Date = (DateTime)sdr["CreatedDate"];
                u.Machine_Ip = (string)sdr["Machine_Ip"];
                u.Mac_Address = (string)sdr["Mac_Address"];
                lst.Add(u);
            }
            sdr.Close();
            return lst;
        }
        public PI PI_Get_By_ID()
        {
            PI u = new PI();
            SqlCommand sc = new SqlCommand("PI_Get_By_ID", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@PI_ID", PI_ID);
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                u.PI_ID = (int)sdr["PI_ID"];
                u.PI_No = (string)sdr["PI_No"];
                u.Date = (DateTime)sdr["Date"];
                u.Description = (string)sdr["Description"];
                u.Item_Cat_Id = (int)sdr["Item_Cat_Id"];
                u.Item_Cat_Name = (string)sdr["Item_Cat_Name"];
                
                u.Created_By = (int)sdr["CreatedBy"];
                u.Created_Date = (DateTime)sdr["CreatedDate"];
                u.Machine_Ip = (string)sdr["Machine_Ip"];
                u.Mac_Address = (string)sdr["Mac_Address"];
            }
            sdr.Close();
            return u;
        }

        public void PI_Add()
        {
            SqlCommand sc = new SqlCommand("PI_Add", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@PI_No", PI_No);
            sc.Parameters.AddWithValue("@Date", Date);
            sc.Parameters.AddWithValue("@Description", Description);
            sc.Parameters.AddWithValue("@Item_Cat_Id", Item_Cat_Id);
            sc.Parameters.AddWithValue("@Item_Cat_Name", Item_Cat_Name);
            sc.Parameters.AddWithValue("@Machine_Ip", Machine_Ip);
            sc.Parameters.AddWithValue("@Mac_Address", Mac_Address);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);
            sc.ExecuteNonQuery();

        }
        public void PI_Update()
        {
            SqlCommand sc = new SqlCommand("PI_Update", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@PI_ID", PI_ID);
            sc.Parameters.AddWithValue("@PI_No", PI_No);
            sc.Parameters.AddWithValue("@Date", Date);
            sc.Parameters.AddWithValue("@Description", Description);
            sc.Parameters.AddWithValue("@Item_Cat_Id", Item_Cat_Id);
            sc.Parameters.AddWithValue("@Item_Cat_Name", Item_Cat_Name);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);
            sc.ExecuteNonQuery();
        }
        public void PI_Delete()
        {
            SqlCommand sc = new SqlCommand("PI_Delete", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@PI_ID", PI_ID);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);
            sc.ExecuteNonQuery();
        }
    }

}