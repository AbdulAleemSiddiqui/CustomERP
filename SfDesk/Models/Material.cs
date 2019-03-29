using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class Material
    {
        public int M_ID { get; set; }
        public string M_Name { get; set; }
        public string M_Type { get; set; }
        public string M_Unit{ get; set; }
        public string Machine_Ip { get; set; }

        public string Mac_Address { get; set; }

        public Material()
        {
            this.Machine_Ip = Utility.GetIPAddress();
            this.Mac_Address = Utility.GetMacAddress();
        }
        public List<Material> Material_Get_All()
        {
            return new List<Material>();
        }
        public Material Material_Get_By_ID()
        {
            return new Material();
        }
        public void Material_Add()
        {
            SqlCommand sc = new SqlCommand("Material_Add", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;

            sc.Parameters.AddWithValue("@M_Name", M_Name);
            sc.Parameters.AddWithValue("@M_Unit", M_Unit);
            sc.Parameters.AddWithValue("@M_Type", M_Type);

            sc.Parameters.AddWithValue("@Machine_Ip", Machine_Ip);
            sc.Parameters.AddWithValue("@Mac_Address", Mac_Address);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);

            sc.ExecuteNonQuery();

        }
        public void Material_Update()
        {
            SqlCommand sc = new SqlCommand("Material_Update", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;

            sc.Parameters.AddWithValue("@M_ID", M_ID);
            sc.Parameters.AddWithValue("@M_Name", M_Name);
            sc.Parameters.AddWithValue("@M_Unit", M_Unit);
            sc.Parameters.AddWithValue("@M_Type", M_Type);
            sc.Parameters.AddWithValue("@Machine_Ip", Machine_Ip);
            sc.Parameters.AddWithValue("@Mac_Address", Mac_Address);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);

            sc.ExecuteNonQuery();


        }
        public void Material_Delete()
        {
            SqlCommand sc = new SqlCommand("Material_Delete", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@M_ID", M_ID);
            sc.ExecuteNonQuery();
        }
    }
}