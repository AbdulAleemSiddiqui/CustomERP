using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class Ledger
    {
        public int Ledger_ID { get; set; }
        public int PI_ID { get; set; }
        public int Account_ID { get; set; }
        public string Account_Name { get; set; }
        public DateTime Date { get; set; }
        public string Party_Name { get; set; }
        public string Flag { get; set; }
        public decimal Amount { get; set; }

        public List<Ledger> Ledger_Get_All()
        {
            List<Ledger> lst = new List<Ledger>();
            SqlCommand sc = new SqlCommand("Ledger_Get_All", Connection.GetConnection()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@App_Id", App.App_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                Ledger l = new Ledger();
                l.Ledger_ID = (int)sdr["Ledger_ID"];
                l.PI_ID= (int)sdr["PI_ID"];
                l.Date= (DateTime)sdr["Date"];
                l.Party_Name= (string)sdr["Party_Name"];
                l.Account_Name= (string)sdr["Account_Name"];
                l.Flag= (string)sdr["Flag"];
                l.Amount= (decimal)sdr["Amount"];
                lst.Add(l);
            }
            sdr.Close();

            return lst;
        }
    }
}