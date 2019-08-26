using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class SO_Details
    {
           #region Detail
        public int SO_ID { get; set; }
        public int Detail_ID { get; set; }
        [DisplayName("Store / Godown")]
        public string Store { get; set; } = "";
        [DisplayName("Item Code")]
        public int Item_Code { get; set; }
        [DisplayName("Product Name")]
        public string Product_Name { get; set; } = "";
        [DisplayName("Product Description")]
        public string Product_Description { get; set; } = "";
        [DisplayName("Purchase Quantitiy")]
        public int Quantitiy { get; set; }
        [DisplayName("Received Quantitiy")]
        public int Dispatch_Quantitiy { get; set; }
        public decimal Rate { get; set; }
        [DisplayName("Gross Amount")]
        public decimal Gross_Amount { get; set; }
        public decimal Discount { get; set; }
        [DisplayName("Discount Amount")]
        public decimal Discount_Amount { get; set; }
        [DisplayName("Net Amount")]
        public decimal Net_Amount { get; set; }
        public string action { get; set; }

    



        #endregion
        #region Default
        public int Created_By { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Created_Date { get; set; } = DateTime.Parse("2001/01/01");

        public string Machine_Ip { get; set; }

        public string Mac_Address { get; set; }
        #endregion
    }
}