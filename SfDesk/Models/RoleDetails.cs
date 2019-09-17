using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
  
    public class RoleDetails
    {
        public int R_ID { get; set; }
        public string R_Name { get; set; }
        public int Company_Code { get; set; }
        public int F_ID { get; set; }
        public string F_Name { get; set; }
        public int A_ID { get; set; }
        public string A_Name { get; set; }
        public string Machine_Ip { get; set; }
        public string Mac_Address { get; set; }
        public RoleDetails()
        {
            this.Machine_Ip = Utility.GetIPAddress();
            this.Mac_Address = Utility.GetMacAddress();
            modules = new List<Module>();
        }
        // public string Product { get; set; }
        public List<Module> modules { get; set; } 

        public void Role_Detail_Add()
        {

            SqlCommand sc = new SqlCommand("Menu_Role_Del", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@R_ID", R_ID);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);
            sc.ExecuteNonQuery();
            foreach (Module module in modules)
            {
                foreach (Form item in module.forms.FindAll(x=>x.isSelected==true))
                {
                    SqlCommand dc = new SqlCommand("Menu_Role_Add", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
                    dc.Parameters.AddWithValue("@R_ID", R_ID);
                    dc.Parameters.AddWithValue("@M_ID", item.Form_ID);
                    dc.Parameters.AddWithValue("@Machine_Ip", Machine_Ip);
                   dc.Parameters.AddWithValue("@Mac_Address", Mac_Address);
                    dc.Parameters.AddWithValue("@CreatedBy", App.App_ID);
                    dc.ExecuteNonQuery();
                }

            }
        }
        //public List<Form> Form_Get_By_Module(int Module_ID)
        //{
        //    forms = new List<Form>();
        //    SqlCommand sc = new SqlCommand("Form_Get_By_Module", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
        //    sc.Parameters.AddWithValue("@Mod_Id", Module.Module_ID);
        //    sc.Parameters.AddWithValue("@App_Id", App.App_ID);


        //    SqlDataReader sdr = sc.ExecuteReader();
        //    while (sdr.Read())
        //    {
        //        Form u = new Form();
        //        u.Form_ID = (int)sdr[0];
        //        u.Form_Name = (string)sdr[1];
        //        u.Module_ID = (int)sdr[2];
        //        u.Created_By = (int)sdr["CreatedBy"];
        //        u.Created_Date = (DateTime)sdr["CreatedDate"];
        //        u.Machine_Ip = (string)sdr["Machine_Ip"];
        //        u.Mac_Address = (string)sdr["Mac_Address"];

        //        u.actions = new Form_Actions().Action_Get_By_Form(u.Form_ID ,R_ID);

        //        forms.Add(u);
        //    }
        //    sdr.Close();
        //    return forms;
        //}
        public List<Module> Role_Detail_Get_All()
        {
            // it will get all the modules 
            // than we find each module FORMS
            // than for each form we find its action
            modules = new List<Module>();
            SqlCommand sc = new SqlCommand("Module_Get_All", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                Module u = new Module();
                u.M_ID = (int)sdr[0];
                u.Module_Name = (string)sdr[1];
                u.Created_By = (int)sdr["CreatedBy"];
                u.Created_Date = (DateTime)sdr["CreatedDate"];
                u.Machine_Ip = (string)sdr["Machine_Ip"];
                u.Mac_Address = (string)sdr["Mac_Address"];
                u.forms= new Module().Form_Get_By_Module(u.M_ID,R_ID);
                modules.Add(u);
            }
            sdr.Close();
            return modules;
        }
    }

    
}