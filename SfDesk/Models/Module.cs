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


        public List<Form> forms = new List<Form>();


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