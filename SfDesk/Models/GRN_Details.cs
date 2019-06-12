using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class GRN_Details
    {
        public int Detail_ID { get; set; }
        [DisplayName("Item Code")]
        public int Item_Code { get; set; }
        [DisplayName("Product Name")]
        public string Product_Name { get; set; } = "";
        public string Description { get; set; } = "";
       public int QTY { get; set; }

      
        public decimal Rate { get; set; }
        [DisplayName("Amount")]
        public decimal Amount { get; set; }
        public bool TAX { get; set; }
        public int location_ID { get; set; }

    }
}