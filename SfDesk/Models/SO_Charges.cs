using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class SO_Charges
    {
        public int SO_Charge_ID { get; set; }
        public int SO_ID { get; set; }
        public int SalesTax_ID { get; set; }
        public string SalesTax_Name { get; set; }
        public decimal Rate { get; set; }
        public decimal Total { get; set; }
        public string action { get; set; }
        #region default Properties
        public int Created_By { get; set; }
        public DateTime Created_Date { get; set; }
        public string Machine_Ip { get; set; }
        public string Mac_Address { get; set; }
        #endregion
    }
}