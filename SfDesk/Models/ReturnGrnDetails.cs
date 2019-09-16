using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class ReturnGrnDetails
    {
        public int Detail_ID { get; set; }
        public int SGRN_ID { get; set; }
        [DisplayName("Item Code")]
        public int Item_Code { get; set; }

        public int Item_ID { get; set; }
        [DisplayName("Item Name")]
        public string Item_Name { get; set; } = "";
        [DisplayName("Item Desc.")]
        public string Item_Description { get; set; } = "";

        [DisplayName("Quantity")]
        public int Qty { get; set; }
        public decimal Net_Weight { get; set; }
        public decimal Gross_Weight { get; set; }

        public string action { get; set; }
    }
}