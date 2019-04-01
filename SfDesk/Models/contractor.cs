using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class Contractor
    {
        public int C_ID { get; set; }
        public string C_Name { get; set; }
        public decimal C_Amount { get; set; }
        public string C_Unit { get; set; }
        public string Machine_Ip { get; set; }

        public string Mac_Address { get; set; }

        public Contractor()
        {
            this.Machine_Ip = Utility.GetIPAddress();
            this.Mac_Address = Utility.GetMacAddress();
        }
        public List<Contractor> Contractor_Get_All()
        {
            return new List<Contractor>();
        }
        public Contractor Contractor_Get_By_ID()
        {
            return new Contractor();
        }
        public void Contractor_Add()
        {
            SqlCommand sc = new SqlCommand("Contractor_Add", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;

            sc.Parameters.AddWithValue("@C_Name", C_Name);
            sc.Parameters.AddWithValue("@C_Unit", C_Unit);
            sc.Parameters.AddWithValue("@C_Amount", C_Amount);

            sc.Parameters.AddWithValue("@Machine_Ip", Machine_Ip);
            sc.Parameters.AddWithValue("@Mac_Address", Mac_Address);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);

            sc.ExecuteNonQuery();

        }
        public void Contractor_Update()
        {
            SqlCommand sc = new SqlCommand("Contractor_Update", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;

            sc.Parameters.AddWithValue("@C_ID", C_ID);
            sc.Parameters.AddWithValue("@C_Name", C_Name);
            sc.Parameters.AddWithValue("@C_Unit", C_Unit);
            sc.Parameters.AddWithValue("@C_Amount", C_Amount);
            sc.Parameters.AddWithValue("@Machine_Ip", Machine_Ip);
            sc.Parameters.AddWithValue("@Mac_Address", Mac_Address);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);

            sc.ExecuteNonQuery();


        }
        public void Contractor_Delete()
        {
            SqlCommand sc = new SqlCommand("Contractor_Delete", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@C_ID", C_ID);
            sc.ExecuteNonQuery();
        }
    }
}