using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class SaleOrder
    {
        #region Sales Order master
        [DisplayName("S ID #")]
        public int SO_ID { get; set; }
        [DisplayName("S.O #")]
        public int SO_No { get; set; }
        [DisplayName("PR #")]
        public string PR_No { get; set; }
        [DisplayName("Sale Mode")]
        public string[] Sale_Mode { get; set; }
        public int Sale_Account_ID { get; set; }
        [DisplayName("Sale A/c")]
        public string Sale_ac { get; set; }
        public int Customer_ID { get; set; }
        [DisplayName("Customer Name")]
        public string Customer_Name { get; set; }
        public DateTime Date { get; set; }
        [DisplayName("Due Date")]
        public DateTime Due_Date { get; set; }
        [DataType(DataType.MultilineText)]
        public string Comments { get; set; }

        [DisplayName("Vehicle #")]
        public int Vehicle_ID { get; set; }
        public string Vehicle_No { get; set; }
        [DisplayName("Transporter Name")]
        public int Transporter_ID { get; set; }
        public string Transporter_Name { get; set; }
        [DisplayName("Sales Man")]
        public int Sales_Man_ID { get; set; }
        public string Sales_Man_Name { get; set; }
        #endregion
 
        #region Tax
        [DisplayName("Less / Add Commision")]
        public decimal Less_add_Commision { get; set; }

        public decimal GST { get; set; }
        [DisplayName("Further Tax")]
        public decimal Further_tax { get; set; }

        #endregion
    }
}