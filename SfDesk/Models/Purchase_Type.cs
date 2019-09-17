using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class Purchase_Type
    {
        public int PT_ID { get; set; }
        public string PT_Name { get; set; }
        #region Default
        public int Created_By { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Created_Date { get; set; } = DateTime.Parse("2001/01/01");
        public string Machine_Ip { get; set; }
        public string Mac_Address { get; set; }

        #endregion

        public List<Purchase_Type> Purchase_Type_Get_All()
        {
            List<Purchase_Type> lst = new List<Purchase_Type>();
            SqlCommand sc = new SqlCommand("Purchase_Type_Get_All", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                Purchase_Type u = new Purchase_Type();
                u.PT_ID = (int)sdr["PT_ID"];
                u.PT_Name = (string)sdr["PT_Name"];

                //u.Created_By = (int)sdr["CreatedBy"];
                //u.Created_Date = (DateTime)sdr["CreatedDate"];
                //u.Machine_Ip = (string)sdr["Machine_Ip"];
                //u.Mac_Address = (string)sdr["Mac_Address"];
                lst.Add(u);
            }
            sdr.Close();
            return lst;
        }
    }
}