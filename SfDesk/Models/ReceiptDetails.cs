using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class ReceiptDetails
    {
        public int RD_ID { get; set; }
        public int Rec_ID { get; set; }
        public int COA_ID { get; set; }
        public string Payment_Mode { get; set; }
        public string Account { get; set; }
        public string Bank_Name { get; set; }
        public string Instument_NO { get; set; }
        public string Instrument_Date { get; set; }
        public decimal Amount { get; set; }
        public int Created_By { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Created_Date { get; set; } = DateTime.Parse("2001/01/01");

        public string Machine_Ip { get; set; }

        public string Mac_Address { get; set; }

    }
}