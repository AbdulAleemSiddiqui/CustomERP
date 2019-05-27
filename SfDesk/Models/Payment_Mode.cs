using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class Payment_Mode
    {
        public int PM_ID { get; set; }
        public string PaymentMode { get; set; }
        public int P_ID { get; set; }
        public string P_Name { get; set; }
        public int Account_ID { get; set; }
        public string Account_Name { get; set; }
        public string Description { get; set; }
        public string CheckNO { get; set; }
        public decimal Amount { get; set; }
        public int Created_By { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Created_Date { get; set; } = DateTime.Parse("2001/01/01");

        public string Machine_Ip { get; set; }

        public string Mac_Address { get; set; }

        public Payment_Mode()
        {
            this.Machine_Ip = Utility.GetIPAddress();
            this.Mac_Address = Utility.GetMacAddress();
        }
    }
}