using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class SaleOrder
    {   
        public int S_ID { get; set; }
        public string S_NO { get; set; }
        public int Customer_ID { get; set; }
        public string Customer_Name { get; set; }
        public int Salesman_ID { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Due Date")]
        public DateTime Date { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Due Date")]
        public DateTime Delivery_Date { get; set; }
        public string Salesman_Name { get; set; }
        public string Currency { get; set; }
        public string AttachmentPath { get; set; }
        public int Branch_ID { get; set; }

        public string Branch_Name { get; set; }
        [DataType(DataType.MultilineText)]
        public string Term { get; set; } = "";
    }
}
