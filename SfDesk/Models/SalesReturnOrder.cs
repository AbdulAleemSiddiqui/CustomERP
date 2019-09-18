using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class SalesReturnOrder
    {
        public int SRO_ID { get; set; }
        public string SRO_NO { get; set; }
        public int Customer_ID { get; set; }

        public string Customer_Name { get; set; }
        public string Ref_No { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Date")]
        public DateTime Date { get; set; }
        public int Vehicle_ID { get; set; }
        public string Vehicle_No { get; set; }
        [DisplayName("Transporter Name")]
        public int Transporter_ID { get; set; }
        public string Transporter_Name { get; set; }
        public string Currency { get; set; }

        public string AttachmentPath { get; set; }
        public int Branch_ID { get; set; }

        public string Branch_Name { get; set; }
            [DataType(DataType.MultilineText)]
            public string Term { get; set; } = "";
    }
}