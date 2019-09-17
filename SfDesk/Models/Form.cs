using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class Form
    {
        #region Property

        public int Form_ID { get; set; }
        public string Form_Name { get; set; }
        public string Text { get; set; }
        public int Parent_ID { get; set; }
        public bool isDisable { get; set; }
        public bool isDisplay { get; set; }
        public string RedirectController { get; set; }
        public string RedirectAction { get; set; }
        public int Module_ID { get; set; }

        public bool isSelected { get; set; }

        public int Created_By { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Created_Date { get; set; } = DateTime.Parse("2001/01/01");
        public string Machine_Ip { get; set; }
        public string Mac_Address { get; set; }


        //public Form()
        //{
        //    this.Machine_Ip = Utility.GetIPAddress();
        //    this.Mac_Address = Utility.GetMacAddress();

        //}
       #endregion

        public List<Action> actions { get; set; }
        public void Form_Add()
        {
            SqlCommand sc = new SqlCommand("Form_Add", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@Form_Name", Form_Name);
            sc.Parameters.AddWithValue("@Module_ID", Module_ID);
            sc.Parameters.AddWithValue("@Machine_Ip", Machine_Ip);  
            sc.Parameters.AddWithValue("@Mac_Address", Mac_Address);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);
            sc.ExecuteNonQuery();
        }
        public List<Form> Get_All_Menu(int id)
        {
            List<Form> lst = new List<Form>();

            SqlCommand sc = new SqlCommand("Menu_Get_All", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@U_ID", id);
            sc.Parameters.AddWithValue("@App_ID", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                Form u = new Form();
                u.Form_ID = (int)sdr[0];
                u.Form_Name = (string)sdr[1];
                u.Text = (string)sdr[2];
                u.Parent_ID = (int)sdr[3];
                u.isDisable = (bool)sdr[4];
                u.isDisplay = (bool)sdr[5];
                u.RedirectController = (string)sdr[6];
                u.RedirectAction = (string)sdr[7];
                u.Module_ID = (int)sdr[8];
                lst.Add(u);
            }
            sdr.Close();
            return lst;
        }

        public List<Form> Get_All_Menu()
        {
            List<Form> lst = new List<Form>();

            SqlCommand sc = new SqlCommand("Menu_Get_All", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@U_ID", ((user)HttpContext.Current.Session["ID"]).U_Id);
            sc.Parameters.AddWithValue("@App_ID", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                Form u = new Form();
                u.Form_ID = (int)sdr[0];
                u.Form_Name = (string)sdr[1];
                u.Text = (string)sdr[2];
                u.Parent_ID = (int)sdr[3];
                u.isDisable = (bool)sdr[4];
                u.isDisplay = (bool)sdr[5];
                u.RedirectController = (string)sdr[6];
                u.RedirectAction = (string)sdr[7];
                u.Module_ID = (int)sdr[8];
                lst.Add(u);
            }
            sdr.Close();
            return lst;
        }

    }

}