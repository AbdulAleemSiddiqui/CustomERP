using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class Product_Assembly
    {
        [DisplayName("ID")]
        public int P_ID { get; set; }
        [DisplayName("Name")]
        public string P_Name { get; set; }
        public string P_Desc { get; set; }
        public decimal Quantity { get; set; }
        public List<Product_Assembly> Input_products { get; set; }
        public List<Product_Assembly> Output_products { get; set; }
        public List<ChartOfAccount> Account_expences { get; set; }


    }
}