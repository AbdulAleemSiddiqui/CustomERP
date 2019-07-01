using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class Transporter
    {
        #region Properties
        [DisplayName("ID")]
        public int T_ID { get; set; }
        [DisplayName("Trading Name")]
        public string Trading_Name { get; set; }
        public string NTN { get; set; }
        public string STRN { get; set; }
        [DisplayName("Contact Name")]
        public string Contact_Name { get; set; }
        [DisplayName("Phone #")]
        public string Phone_Number { get; set; }

        [DisplayName("Expense Account")]
        public int Exp_Acc_ID { get; set; }
        public string Exp_Acc_Name { get; set; }

        [DisplayName("Paybal Account")]
        public int Pay_Acc_ID { get; set; }
        public string Pay_Acc_Name { get; set; }
        #endregion
        #region Default
        public int Created_By { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Created_Date { get; set; } = DateTime.Parse("2001/01/01");
        public string Machine_Ip { get; set; }
        public string Mac_Address { get; set; }

        #endregion
        public Transporter()
        {
            this.Machine_Ip = Utility.GetIPAddress();
            this.Mac_Address = Utility.GetMacAddress();
        }

        public List<Vehicle>  vehiles{ get; set; }



        public List<Transporter> Transporter_Get_All()
        {
            List<Transporter> lst = new List<Transporter>();
            SqlCommand sc = new SqlCommand("Transporter_Get_All", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                Transporter u = new Transporter();
                u.T_ID = (int)sdr["T_ID"];
                u.Trading_Name = (string)sdr["Trading_Name"];
                u.NTN = (string)sdr["NTN"];
                u.STRN = (string)sdr["STRN"];
                u.Contact_Name = (string)sdr["Contact_Name"];
                u.Phone_Number = (string)sdr["Phone_Number"];
                u.Exp_Acc_ID = (int)sdr["Exp_Acc_ID"];
                u.Exp_Acc_Name = (string)sdr["Exp_Acc_Name"];
                u.Pay_Acc_ID = (int)sdr["Pay_Acc_ID"];
                u.Pay_Acc_Name = (string)sdr["Pay_Acc_Name"];
                u.Created_By = (int)sdr["CreatedBy"];
                u.Created_Date = (DateTime)sdr["CreatedDate"];
                u.Machine_Ip = (string)sdr["Machine_Ip"];
                u.Mac_Address = (string)sdr["Mac_Address"];
                lst.Add(u);
            }
            sdr.Close();
            return lst;
        }
        public Transporter Transporter_Get_By_ID()
        {
            Transporter u= new Transporter();
            SqlCommand sc = new SqlCommand("Transporter_Get_By_ID", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);
            sc.Parameters.AddWithValue("@T_ID", T_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                u.T_ID = (int)sdr["T_ID"];
                u.Trading_Name = (string)sdr["Trading_Name"];
                u.NTN = (string)sdr["NTN"];
                u.STRN = (string)sdr["STRN"];
                u.Contact_Name = (string)sdr["Contact_Name"];
                u.Phone_Number = (string)sdr["Phone_Number"];
                u.Exp_Acc_ID = (int)sdr["Exp_Acc_ID"];
                u.Exp_Acc_Name = (string)sdr["Exp_Acc_Name"];
                u.Pay_Acc_ID = (int)sdr["Pay_Acc_ID"];
                u.Pay_Acc_Name = (string)sdr["Pay_Acc_Name"];
                u.Created_By = (int)sdr["CreatedBy"];
                u.Created_Date = (DateTime)sdr["CreatedDate"];
                u.Machine_Ip = (string)sdr["Machine_Ip"];
                u.Mac_Address = (string)sdr["Mac_Address"];
            }
            sdr.Close();
            return u;
        }

        public int Transporter_Add()
        {
            SqlCommand sc = new SqlCommand("Transporter_Add", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;

            sc.Parameters.AddWithValue("@Trading_Name", Trading_Name);
            sc.Parameters.AddWithValue("@NTN", NTN);
            sc.Parameters.AddWithValue("@STRN", STRN);
            sc.Parameters.AddWithValue("@Contact_Name", Contact_Name);
            sc.Parameters.AddWithValue("@Phone_Number", Phone_Number);
            sc.Parameters.AddWithValue("@Exp_Acc_ID", Exp_Acc_ID);
            sc.Parameters.AddWithValue("@Pay_Acc_ID", Pay_Acc_ID);
            sc.Parameters.AddWithValue("@Machine_Ip", Machine_Ip);
            sc.Parameters.AddWithValue("@Mac_Address", Mac_Address);
            sc.Parameters.AddWithValue("@CreatedBy", App.App_ID);

            object a = sc.ExecuteScalar();
            return Convert.ToInt32((decimal)a);

        }
        public void Transporter_Update()
        {
            SqlCommand sc = new SqlCommand("Transporter_Update", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@T_ID", T_ID);
            sc.Parameters.AddWithValue("@Trading_Name", Trading_Name);
            sc.Parameters.AddWithValue("@NTN", NTN);
            sc.Parameters.AddWithValue("@STRN", STRN);
            sc.Parameters.AddWithValue("@Contact_Name", Contact_Name);
            sc.Parameters.AddWithValue("@Phone_Number", Phone_Number);
            sc.Parameters.AddWithValue("@Exp_Acc_ID", Exp_Acc_ID);
            sc.Parameters.AddWithValue("@Pay_Acc_ID", Pay_Acc_ID);
            sc.Parameters.AddWithValue("@App_ID", App.App_ID);
            sc.ExecuteNonQuery(); 


        }
        public void Transporter_Delete()
        {
            SqlCommand sc = new SqlCommand("Transporter_Delete", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@T_ID", T_ID);
            sc.Parameters.AddWithValue("@App_ID", App.App_ID);
            sc.ExecuteNonQuery();

        }


    }
}