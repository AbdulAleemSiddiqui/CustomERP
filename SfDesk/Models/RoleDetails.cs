using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    //public class RoleDetails
    //{
    //    public int R_ID { get; set; }
    //    public string R_Name { get; set; }
    //    public int F_ID { get; set; }
    //    public string F_Name { get; set; }
    //    public int A_ID { get; set; }
    //    public string A_Name { get; set; }



    //    public void RoleDetail_Add()
    //    {

    //    }
    //}
    public class RoleDetails
    {
        public int R_ID { get; set; }
        public string R_Name { get; set; }
        public int Company_Code { get; set; }
        public int F_ID { get; set; }
        public string F_Name { get; set; }
        public int A_ID { get; set; }
        public string A_Name { get; set; }


        // public string Product { get; set; }
        public List<Form> forms { get; set; }
        public RoleDetails()
        {
            forms = new List<Form>();
        }
        public void Role_Detail_Add()
        {

            SqlCommand sc = new SqlCommand("Role_Detail_Del", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@R_ID", R_ID);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);
            sc.ExecuteNonQuery();
            foreach (Form item in forms)
            {
                this.F_ID = item.Form_ID;
                foreach (Action action in item.actions)
                {
                    if (action.isSelected)
                    {
                        this.A_ID = action.Action_ID;
                      sc = new SqlCommand("Role_Detail_Add", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
                        sc.Parameters.AddWithValue("@R_ID", R_ID);
                        sc.Parameters.AddWithValue("@F_ID", F_ID);
                        sc.Parameters.AddWithValue("@A_ID", A_ID);
                        sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);
                        sc.ExecuteNonQuery();
                    }
                }
            }

        }
        public List<Form> Form_Get_By_Module(int Module_ID)
        {
            forms = new List<Form>();
            SqlCommand sc = new SqlCommand("Form_Get_By_Module", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@Mod_Id", Module.Module_ID);
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

                u.actions = new Form_Actions().Action_Get_By_Form(u.Form_ID ,R_ID);

                forms.Add(u);
            }
            sdr.Close();
            return forms;
        }

    }



    public class Form_Actions
    {
        public int F_ID { get; set; }
        public int A_ID { get; set; }


        public int Created_By { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Created_Date { get; set; } = DateTime.Parse("2001/01/01");
        public string Machine_Ip { get; set; }
        public string Mac_Address { get; set; }

        public List<Action> Action_Get_By_Form(int Form_ID,int R_ID)
        {
            List<Action> lst = new List<Action>();
            SqlCommand sc = new SqlCommand("Action_Get_By_Form", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; 
            sc.Parameters.AddWithValue("@F_ID", Form_ID);
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);
            List<int> Selected = Role_Detail_Selected_Actions(Form_ID, R_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                Action u = new Action();
                u.Action_ID = (int)sdr[0];
                u.Action_Name = (string)sdr[1];
                u.Created_By = (int)sdr[2];
                u.Created_Date = (DateTime)sdr[3];
                u.Machine_Ip = (string)sdr[5];
                u.Mac_Address = (string)sdr[6];
                u.isSelected = Selected.Contains(u.Action_ID);
                lst.Add(u);
            }
            sdr.Close();
          

            return lst;
        }
        public List<int> Role_Detail_Selected_Actions(int Form_ID, int R_ID)
        {
            List<int> lst = new List<int>();
            SqlCommand sc = new SqlCommand("Role_Detail_Selected_Actions", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@F_ID", Form_ID);
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);
            sc.Parameters.AddWithValue("@R_ID", R_ID);

            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                lst.Add((int)sdr[0]);
            }
            return lst;
        }
    }
}