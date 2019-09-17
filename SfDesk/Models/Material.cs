using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class Material
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [DisplayName("Type")]
        public string M_Type { get; set; }
        public string Unit{ get; set; }
         public string E_ID { get; set; } 
        public int Created_By { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Created_Date { get; set; } = DateTime.Parse("2001/01/01");
        public string Machine_Ip { get; set; }
        public string Mac_Address { get; set; }


        public Material()
        {
            this.Machine_Ip = Utility.GetIPAddress();
            this.Mac_Address = Utility.GetMacAddress();
        }
        public List<Material> Material_Get_All()
        {
            List<Material> lst = new List<Material>();
            SqlCommand sc = new SqlCommand("Material_Get_All", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@App_ID", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                Material u = new Material();
                u.ID = (int)sdr["M_ID"];
                u.Name = (string)sdr["M_Name"];
                u.M_Type = (string)sdr["M_Type"];
                u.Unit = (string)sdr["M_Unit"];

                u.E_ID = "M" + u.ID;
                u.Created_By = (int)sdr["CreatedBy"];
                u.Created_Date = (DateTime)sdr["CreatedDate"];
                u.Machine_Ip = (string)sdr["Machine_Ip"];
                u.Mac_Address = (string)sdr["Mac_Address"];
                lst.Add(u);
            }
            sdr.Close();
            return lst;
        }
        public List<Material> Material_Get_By_Type()
        {
            List<Material> lst = new List<Material>();

            SqlCommand sc = new SqlCommand("Material_Get_By_Type", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@M_Type", M_Type);
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
              
                Material u = new Material();
                u.ID = (int)sdr["M_ID"];
                u.E_ID = "M" + u.ID;
                u.Name = (string)sdr["M_Name"];
                u.M_Type = (string)sdr["M_Type"];
                u.Unit = (string)sdr["M_Unit"];
                u.Created_By = (int)sdr["CreatedBy"];
                u.Created_Date = (DateTime)sdr["CreatedDate"];
                u.Machine_Ip = (string)sdr["Machine_Ip"];
                u.Mac_Address = (string)sdr["Mac_Address"];
                lst.Add(u);
            }
            sdr.Close();
            return lst;
        }
        public Material Material_Get_By_ID()
        {
            Material u = new Material();
            SqlCommand sc = new SqlCommand("Material_Get_By_ID", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@M_ID", ID);
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                u.ID = (int)sdr["M_ID"];
                u.Name = (string)sdr["M_Name"];
                u.M_Type = (string)sdr["M_Type"];
                u.Unit = (string)sdr["M_Unit"];
                u.Created_By = (int)sdr["CreatedBy"];
                u.Created_Date = (DateTime)sdr["CreatedDate"];
                u.Machine_Ip = (string)sdr["Machine_Ip"];
                u.Mac_Address = (string)sdr["Mac_Address"];
            }
            sdr.Close();
            return u;
        }
        public void Material_Add()
        {
            SqlCommand sc = new SqlCommand("Material_Add", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure }; ;

            sc.Parameters.AddWithValue("@M_Name", Name);
            sc.Parameters.AddWithValue("@M_Unit", Unit);
            sc.Parameters.AddWithValue("@M_Type", M_Type);

            sc.Parameters.AddWithValue("@Machine_Ip", Machine_Ip);
            sc.Parameters.AddWithValue("@Mac_Address", Mac_Address);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);

            sc.ExecuteNonQuery();

        }
        public void Material_Update()
        {
            SqlCommand sc = new SqlCommand("Material_Update", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure }; ;

            sc.Parameters.AddWithValue("@M_ID", ID);
            sc.Parameters.AddWithValue("@M_Name", Name);
            sc.Parameters.AddWithValue("@M_Unit", Unit);
            sc.Parameters.AddWithValue("@M_Type", M_Type);
            sc.Parameters.AddWithValue("@App_ID", App.App_ID);

            sc.ExecuteNonQuery();


        }
        public void Material_Delete()
        {
            SqlCommand sc = new SqlCommand("Material_Delete", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@M_ID", ID);
            sc.Parameters.AddWithValue("@App_ID", App.App_ID);

            sc.ExecuteNonQuery();
        }
    }
}