﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class Contractor
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string E_ID { get; set; }
        public decimal C_Amount { get; set; }
        public string Unit { get; set; }
        public int Created_By { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Created_Date { get; set; } = DateTime.Parse("2001/01/01");
        public string Machine_Ip { get; set; }
        public string Mac_Address { get; set; }

        public Contractor()
        {
            this.Machine_Ip = Utility.GetIPAddress();
            this.Mac_Address = Utility.GetMacAddress();
        }
        public List<Contractor> Contractor_Get_All()
        {
            List<Contractor> lst = new List<Contractor>();
            SqlCommand sc = new SqlCommand("Contractor_Get_All", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@App_ID", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                Contractor u = new Contractor();
                u.ID = (int)sdr["C_ID"];
                u.E_ID = "C" + u.ID;
                u.Name= (string)sdr["C_Name"];
                u.C_Amount= (decimal)sdr["C_Amount"];
                u.Unit = (string)sdr["C_Unit"];
                u.Created_By = (int)sdr["CreatedBy"];
                u.Created_Date = (DateTime)sdr["CreatedDate"];
                u.Machine_Ip = (string)sdr["Machine_Ip"];
                u.Mac_Address = (string)sdr["Mac_Address"];
                lst.Add(u);
            }
            sdr.Close();
            return lst;
        }
        public Contractor Contractor_Get_By_ID()
        {
            Contractor u = new Contractor();
            SqlCommand sc = new SqlCommand("Contractor_Get_By_ID", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@C_ID", ID);
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                u.ID = (int)sdr["C_ID"];
                u.Name = (string)sdr["C_Name"];
                u.C_Amount = (decimal)sdr["C_Amount"];
                u.Unit = (string)sdr["C_Unit"];
                u.Created_By = (int)sdr["CreatedBy"];
                u.Created_Date = (DateTime)sdr["CreatedDate"];
                u.Machine_Ip = (string)sdr["Machine_Ip"];
                u.Mac_Address = (string)sdr["Mac_Address"];
            }
            sdr.Close();
            return u;
        }
        public void Contractor_Add()
        {
            SqlCommand sc = new SqlCommand("Contractor_Add", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;

            sc.Parameters.AddWithValue("@C_Name", Name);
            sc.Parameters.AddWithValue("@C_Unit", Unit);
            sc.Parameters.AddWithValue("@C_Amount", C_Amount);

            sc.Parameters.AddWithValue("@Machine_Ip", Machine_Ip);
            sc.Parameters.AddWithValue("@Mac_Address", Mac_Address);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);

            sc.ExecuteNonQuery();

        }
        public void Contractor_Update()
        {
            SqlCommand sc = new SqlCommand("Contractor_Update", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;

            sc.Parameters.AddWithValue("@C_ID", ID);
            sc.Parameters.AddWithValue("@C_Name", Name);
            sc.Parameters.AddWithValue("@C_Unit", Unit);
            sc.Parameters.AddWithValue("@C_Amount", C_Amount);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);

            sc.ExecuteNonQuery();


        }
        public void Contractor_Delete()
        {
            SqlCommand sc = new SqlCommand("Contractor_Delete", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@C_ID", ID);
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);
            sc.ExecuteNonQuery();
        }
    }
}