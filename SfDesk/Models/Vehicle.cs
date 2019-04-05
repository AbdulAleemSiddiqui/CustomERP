using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class Vehicle
    {

        #region Properties
        [DisplayName("Vehicle ID")]
        public int V_ID { get; set; }
        [DisplayName("Vehicle Type")]
        public string Vehicle_Type { get; set; }
        [DisplayName("Vehicle #")]
        public string Vehicle_No { get; set; }
        [DisplayName("Rate")]
        public decimal Rate{ get; set; }

        public int T_ID { get; set; }
        [DisplayName("Transporter")]

        public int T_Name { get; set; }
        #region Default
        public int Created_By { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Created_Date { get; set; } = DateTime.Parse("2001/01/01");
        public string Machine_Ip { get; set; }
        public string Mac_Address { get; set; }
        public string[] Type { get; set; } = { "Car Type 1", "Car Type 2", "Car Type 3" };

        #endregion
        #endregion

        public Vehicle()
        {
            this.Machine_Ip = Utility.GetIPAddress();
            this.Mac_Address = Utility.GetMacAddress();
        }
        public List<Vehicle> Vehcile_Get_By_Transporter()
        {
            List<Vehicle> lst = new List<Vehicle>();
            SqlCommand sc = new SqlCommand("Vehcile_Get_By_Transporter", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@T_ID", T_ID);
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                Vehicle u = new Vehicle();
                u.V_ID = (int)sdr["V_ID"];
                u.Vehicle_Type= (string)sdr["Vehicle_Type"];
                u.Vehicle_No = (string)sdr["Vehicle_No"];
                u.Rate = (decimal)sdr["Rate"];
                u.T_ID = (int)sdr["T_ID"];
                u.Created_By = (int)sdr["CreatedBy"];
                u.Created_Date = (DateTime)sdr["CreatedDate"];
                u.Machine_Ip = (string)sdr["Machine_Ip"];
                u.Mac_Address = (string)sdr["Mac_Address"];
                lst.Add(u);
            }
            sdr.Close();
            return lst;
        }
        public int Vehcile_Add()
        {
            SqlCommand sc = new SqlCommand("Vehicle_Add", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;

            sc.Parameters.AddWithValue("@Vehicle_Type", Vehicle_Type);
            sc.Parameters.AddWithValue("@Vehicle_N", Vehicle_No);
            sc.Parameters.AddWithValue("@Rate", Rate);
            sc.Parameters.AddWithValue("@T_ID", T_ID);
            sc.Parameters.AddWithValue("@Machine_Ip", Machine_Ip);
            sc.Parameters.AddWithValue("@Mac_Address", Mac_Address);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);

            object a = sc.ExecuteScalar();
            return Convert.ToInt32((decimal)a);
        }


    }
}