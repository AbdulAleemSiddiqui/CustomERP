using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class ProductViewModel
    {
        public string Product { get; set; }
        public List<SizeColorQuantityViewModel> SizeColorQuantities { get; set; }
    }
    public class SizeColorQuantityViewModel
    {
        public string ColorId { get; set; }
        public List<SizeAndQuantity> SizeAndQuantities { get; set; }
    }
    public class SizeAndQuantity
    {
        public int SizeId { get; set; }
        public bool Quantity { get; set; }
    }
}