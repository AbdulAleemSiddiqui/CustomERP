using System;
using System.Collections.Generic;
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
        public int F_ID { get; set; }
        public string F_Name { get; set; }
        public int A_ID { get; set; }
        public string A_Name { get; set; }


        // public string Product { get; set; }
        public List<Form> forms { get; set; }

        public void add()
        {
            foreach (Form item in forms)
            {
                this.F_ID = item.Form_ID;
                foreach (Action action in item.actions)
                {
                    if (action.isSelected)
                    {
                        this.A_ID = action.Action_ID;
                        SqlCommand sc = new SqlCommand("Role_Detail_Add", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
                        sc.Parameters.AddWithValue("@R_ID", R_ID);
                        sc.Parameters.AddWithValue("@F_ID", F_ID);
                        sc.Parameters.AddWithValue("@A_ID", A_ID);
                        sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);
                        sc.ExecuteNonQuery();
                    }
                }
            }
            
        }
    }
    public class Form
    {
        public int Form_ID { get; set; }
        public string Form_Name { get; set; }
        public List<Action> actions { get; set; }
    }
    public class Action
    {
        public int Action_ID { get; set; }
        public string Action_Name { get; set; }
        public bool isSelected { get; set; }
    }
}