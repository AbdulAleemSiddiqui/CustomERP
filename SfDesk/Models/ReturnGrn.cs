using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class ReturnGrn
    {
         public int SGRN_ID { get; set; }
        public string SGRN_NO { get; set; }
        [DisplayName("Customer")]
        public int Customer_ID { get; set; }
        public String Customer_Name { get; set; }
        public int Store_ID { get; set; }
        public String Store_Name { get; set; }

        [DisplayName("Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string Currency { get; set; }

        public string AttachmentPath { get; set; }
        public int Branch_ID { get; set; }

        public string Branch_Name { get; set; }
        [DisplayName("Vehicle #")]
        public int Vehicle_ID { get; set; }
        public string Vehicle_No { get; set; }
        [DisplayName("Transporter Name")]
        public int Transporter_ID { get; set; }
        public string Transporter_Name { get; set; }

        public string Comments { get; set; }
        #region default Properties
        public int Created_By { get; set; }
        public DateTime Created_Date { get; set; }
        public string Machine_Ip { get; set; }
        public string Mac_Address { get; set; }
        #endregion
    }
}