using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class Action
    {
        public int Action_ID { get; set; }
        public string Action_Name { get; set; }
        public bool isSelected { get; set; }
        public int Created_By { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Created_Date { get; set; } = DateTime.Parse("2001/01/01");
        public string Machine_Ip { get; set; }
        public string Mac_Address { get; set; }
        //public Action()
        //{
        //    this.Machine_Ip = Utility.GetIPAddress();
        //    this.Mac_Address = Utility.GetMacAddress();
        //}
        public void Action_Add()
        {
            SqlCommand sc = new SqlCommand("Action_Add", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@Action_Name", Action_Name);
            sc.Parameters.AddWithValue("@Machine_Ip", Machine_Ip);
            sc.Parameters.AddWithValue("@Mac_Address", Mac_Address);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);
            sc.ExecuteNonQuery();
        }
    }
        
}