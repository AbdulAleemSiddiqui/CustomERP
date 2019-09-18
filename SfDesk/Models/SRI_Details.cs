﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class SRI_Details
    {
        public int SI_ID { get; set; }
        public int SI_DID { get; set; }
        public string Product_ID { get; set; }
        public string Product_Code { get; set; }
        public string Product_Name { get; set; }
        public string Description { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal Tax { get; set; }
        public decimal Amount { get; set; }
    }
}