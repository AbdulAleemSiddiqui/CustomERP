using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class Payment
    {
        [DisplayName("Payment ID")]
        public int Payment_ID { get; set; }
        [DisplayName("Suplier")]
        public int Suplier_ID { get; set; }
        public string Suplier_Name{ get; set; }
        public int P_No{ get; set; }
        [DisplayName("Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime P_Date { get; set; }
        public string Currency { get; set; }
        public decimal ExRate { get; set; }
        [DisplayName("Job")]
        public int Job_ID { get; set; }

   

        public string Job_Name { get; set; }
        [DataType(DataType.MultilineText)]
        public string Naration { get; set; }
        public int Created_By { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Created_Date { get; set; } = DateTime.Parse("2001/01/01");

        public string Machine_Ip { get; set; }

        public string Mac_Address { get; set; }

        public Payment()
        {
            this.Machine_Ip = Utility.GetIPAddress();
            this.Mac_Address = Utility.GetMacAddress();
        }

    
    }
}