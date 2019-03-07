using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class Module
    {
        public static int Module_ID { get; set; } = 1;
        public int M_ID { get; set; }
        public string Module_Name { get; set; }
        public int Created_By { get; set; }
        public DateTime Created_Date { get; set; }
        public string Machine_Ip { get; set; }
        public string Mac_Address { get; set; }
        public List<Form> forms { get; set; }

        public Module()
        {
            this.Machine_Ip = Utility.GetIPAddress();
            this.Mac_Address = Utility.GetMacAddress();
            forms = new List<Form>(); 
        }

        public void Module_Add()
        {
            SqlCommand sc = new SqlCommand("Module_Add", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@Module_Name", Module_Name);
            sc.Parameters.AddWithValue("@Machine_Ip", Machine_Ip);
            sc.Parameters.AddWithValue("@Mac_Address", Mac_Address);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);
            sc.ExecuteNonQuery();
        }
        public List<Form> Form_Get_By_Module(int Module_ID,int R_ID)
        {
            forms = new List<Form>();
            SqlCommand sc = new SqlCommand("Form_Get_By_Module", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@Mod_Id", Module_ID);
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);


            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                Form u = new Form();
                u.Form_ID = (int)sdr[0];
                u.Form_Name = (string)sdr[1];
                u.Module_ID = (int)sdr[2];
                u.Created_By = (int)sdr["CreatedBy"];
                u.Created_Date = (DateTime)sdr["CreatedDate"];
                u.Machine_Ip = (string)sdr["Machine_Ip"];
                u.Mac_Address = (string)sdr["Mac_Address"];

                u.actions = new Form_Actions().Action_Get_By_Form(u.Form_ID, R_ID);

                forms.Add(u);
            }
            sdr.Close();
            return forms;
        }


    }
}