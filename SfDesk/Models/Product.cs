using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class Product
    {
        public string Machine_Ip { get; set; }

        public string Mac_Address { get; set; }

      
        public int P_ID { get; set; }
        public string P_Name { get; set; }
        public Product()
        {
            this.Machine_Ip = Utility.GetIPAddress();
            this.Mac_Address = Utility.GetMacAddress();
        }
        public List<Product> Product_Get_All()
        {
            List<Product> lst = new List<Product>();
            for (int i = 1; i < 5; i++)
            {
                  Product p = new Product();
                p.P_ID = i ;
                p.P_Name = "product" + i;
                lst.Add(p);
            }
            return  lst;
        }
        public Product Product_Get_By_ID( )
        {
            return new Product();
        }
        public void Product_Add()
        {
            SqlCommand sc = new SqlCommand("Product_Add", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            
            sc.Parameters.AddWithValue("@P_Name", P_Name);

            sc.Parameters.AddWithValue("@Machine_Ip", Machine_Ip);
            sc.Parameters.AddWithValue("@Mac_Address", Mac_Address);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);

            sc.ExecuteNonQuery();

        }
        public void Product_Update()
        {
            SqlCommand sc = new SqlCommand("Product_Update", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;

            sc.Parameters.AddWithValue("@P_ID", P_ID);
            sc.Parameters.AddWithValue("@P_Name", P_Name);

            sc.Parameters.AddWithValue("@Machine_Ip", Machine_Ip);
            sc.Parameters.AddWithValue("@Mac_Address", Mac_Address);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);

            sc.ExecuteNonQuery();


        }
        public void Product_Delete()
        {
            SqlCommand sc = new SqlCommand("Product_Delete", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@P_ID", P_ID);
            sc.ExecuteNonQuery();
        }


    }
}