using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class SalesInvoice
    {
        public int SI_ID { get; set; }
        public string SI_NO { get; set; }
        public int Customer_ID { get; set; }

        public string Customer_Name { get; set; }
        public int Salesman_ID { get; set; }


        public string Salesman_Name { get; set; }
        public int Vehicle_ID { get; set; }
        public string Vehicle_No { get; set; }
        [DisplayName("Transporter Name")]
        public int Transporter_ID { get; set; }
        public string Transporter_Name { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Date")]
        public DateTime Date { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Due Date")]
        public DateTime Delivery_Date { get; set; }
        public string Currency { get; set; }

        public string AttachmentPath { get; set; }
        public int Branch_ID { get; set; }

        public string Branch_Name { get; set; }
        [DataType(DataType.MultilineText)]
        public string Term { get; set; }
        public decimal Advance { get; set; }
        public int COA_ID { get; set; }
        public string COA_Name { get; set; }
        public string reference { get; set; }
        public decimal received { get; set; }
        public decimal Net_Amount { get; set; }
    }
}