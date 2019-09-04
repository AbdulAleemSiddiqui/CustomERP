using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{

    public class Item
    {
        public int Item_ID { get; set; }
        public string Item_No { get; set; }
        public string Item_Name { get; set; }
        public int IC_ID { get; set; }
        public string Cat_Name { get; set; }


        #region default Properties
        public int Created_By { get; set; }
        public DateTime Created_Date { get; set; }
        public string Machine_Ip { get; set; }
        public string Mac_Address { get; set; }
        #endregion
        public Item()
        {
            this.Machine_Ip = Utility.GetIPAddress();
            this.Mac_Address = Utility.GetMacAddress();
        }


        public List<Item> Item_Get_All()
        {
            List<Item> lst = new List<Item>();
            SqlCommand sc = new SqlCommand("Item_Get_All", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                Item u = new Item();
                u.Item_ID = (int)sdr["Item_ID"];
                u.Item_No = (string)sdr["Item_No"];
                u.Item_Name = (string)sdr["Item_Name"];
                u.IC_ID = (int)sdr["IC_ID"];
                u.Cat_Name = (string)sdr["Cat_Name"];
                u.Created_By = (int)sdr["CreatedBy"];
                u.Created_Date = (DateTime)sdr["CreatedDate"];
                u.Machine_Ip = (string)sdr["Machine_Ip"];
                u.Mac_Address = (string)sdr["Mac_Address"];
                lst.Add(u);
            }
            sdr.Close();
            return lst;
        }
        public Item Item_Get_By_ID()
        {
            Item u = new Item();
            SqlCommand sc = new SqlCommand("Item_Get_By_ID", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@Item_ID", Item_ID);
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                u.Item_ID = (int)sdr["Item_ID"];
                u.Item_No = (string)sdr["Item_No"];
                u.Item_Name = (string)sdr["Item_Name"];
                u.IC_ID = (int)sdr["IC_ID"];
                u.Cat_Name = (string)sdr["Cat_Name"];
                u.Created_By = (int)sdr["CreatedBy"];
                u.Created_Date = (DateTime)sdr["CreatedDate"];
                u.Machine_Ip = (string)sdr["Machine_Ip"];
                u.Mac_Address = (string)sdr["Mac_Address"];
            }
            sdr.Close();
            return u;
        }

        public void Item_Add()
        {
            SqlCommand sc = new SqlCommand("Item_Add", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@Item_No", Item_No);
            sc.Parameters.AddWithValue("@Item_Name", Item_Name);
            sc.Parameters.AddWithValue("@IC_ID", IC_ID);
            sc.Parameters.AddWithValue("@Machine_Ip", Machine_Ip);
            sc.Parameters.AddWithValue("@Mac_Address", Mac_Address);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);
            sc.ExecuteNonQuery();

        }
        public void Item_Update()
        {
            SqlCommand sc = new SqlCommand("Item_Update", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@Item_ID", Item_ID);
            sc.Parameters.AddWithValue("@Item_No", Item_No);
            sc.Parameters.AddWithValue("@Item_Name", Item_Name);
            sc.Parameters.AddWithValue("@IC_ID", IC_ID);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);
            sc.ExecuteNonQuery();
        }
        public void Item_Delete()
        {
            SqlCommand sc = new SqlCommand("Item_Delete", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@Item_ID", Item_ID);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);
            sc.ExecuteNonQuery();
        }
    }

}