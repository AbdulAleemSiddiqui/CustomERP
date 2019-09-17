using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
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

        public List<Action> Action_Get_By_Form(int Form_ID, int R_ID)
        {
            List<Action> lst = new List<Action>();
            SqlCommand sc = new SqlCommand("Action_Get_By_Form", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure };
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
            SqlCommand sc = new SqlCommand("Role_Detail_Selected_Actions", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
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

        public void Form_Actions_Add()
        {
            SqlCommand sc = new SqlCommand("Form_Action_Add", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@F_ID", F_ID);
            sc.Parameters.AddWithValue("@A_ID", A_ID);
            sc.Parameters.AddWithValue("@Machine_Ip", Machine_Ip);
            sc.Parameters.AddWithValue("@Mac_Address", Mac_Address);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);
            sc.ExecuteNonQuery();
        }
    }
}