using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class Recipe
    {
        public int R_ID { get; set; }

        public int P_ID { get; set; }
        public string P_Name { get; set; }
        public int M_ID { get; set; }
        public string M_Name { get; set; }
        public string Unit { get; set; }
        public string Type { get; set; }
        public decimal Quantity { get; set; }
        #region Default
        public int Created_By { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Created_Date { get; set; } = DateTime.Parse("2001/01/01");
        public string Machine_Ip { get; set; }
        public string Mac_Address { get; set; }

        static List<Recipe> lst =new List<Recipe>();
#endregion

        public Recipe()
        {
            this.Machine_Ip = Utility.GetIPAddress();
            this.Mac_Address = Utility.GetMacAddress();
            
        }
        public List<Recipe> Recipe_Get_All()
        {
            List<Recipe> lst = new List<Recipe>();
            SqlCommand sc = new SqlCommand("Recipe_Get_All", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                Recipe u = new Recipe();
                u.R_ID = (int)sdr["R_ID"];
                u.P_ID = (int)sdr["P_ID"];
                u.P_Name = (string)sdr["P_Name"];
                u.M_ID = (int)sdr["M_ID"];
                u.M_Name = (string)sdr["M_Name"];
                u.Unit = (string)sdr["Unit"];
                u.Type = (string)sdr["Type"];
                u.Quantity = (decimal)sdr["Quantity"];

                u.Created_By = (int)sdr["CreatedBy"];
                u.Created_Date = (DateTime)sdr["CreatedDate"];
                u.Machine_Ip = (string)sdr["Machine_Ip"];
                u.Mac_Address = (string)sdr["Mac_Address"];
                lst.Add(u);
            }
            sdr.Close();
            return lst;
        }
        public Recipe Recipe_Get_By_ID()
        {
            Recipe u = new Recipe();
            SqlCommand sc = new SqlCommand("Recipe_Get_By_ID", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@R_Id", P_ID);
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                u.R_ID = (int)sdr["R_ID"];
                u.P_ID = (int)sdr["P_ID"];
                u.P_Name = (string)sdr["P_Name"];
                u.M_ID = (int)sdr["M_ID"];
                u.M_Name = (string)sdr["M_Name"];
                u.Unit = (string)sdr["M_Unit"];
                u.Type = (string)sdr["M_Type"];
                u.Quantity = (decimal)sdr["Quantity"];

                u.Created_By = (int)sdr["CreatedBy"];
                u.Created_Date = (DateTime)sdr["CreatedDate"];
                u.Machine_Ip = (string)sdr["Machine_Ip"];
                u.Mac_Address = (string)sdr["Mac_Address"];
            }
            sdr.Close();
            return u;
        }

        public void Recipe_Add()
        {
            SqlCommand sc = new SqlCommand("Recipe_Add", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@P_ID", P_ID);
            sc.Parameters.AddWithValue("@M_ID", M_ID);
            sc.Parameters.AddWithValue("@Quantity", Quantity);
            sc.Parameters.AddWithValue("@Machine_Ip", Machine_Ip);
            sc.Parameters.AddWithValue("@Mac_Address", Mac_Address);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);
            sc.ExecuteNonQuery();

        }
        public void Recipe_Update()
        {
            SqlCommand sc = new SqlCommand("Recipe_Update", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@R_ID", R_ID);
            sc.Parameters.AddWithValue("@P_ID", P_ID);
            sc.Parameters.AddWithValue("@M_ID", M_ID);
            sc.Parameters.AddWithValue("@Quantity", Quantity);
            sc.Parameters.AddWithValue("@App_ID", App.App_ID);
            sc.ExecuteNonQuery();
        }
        public void Recipe_Delete()
        {
            SqlCommand sc = new SqlCommand("Recipe_Delete", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@R_ID", R_ID);
            sc.Parameters.AddWithValue("@App_ID", App.App_ID);
            sc.ExecuteNonQuery();
        }

    }
}