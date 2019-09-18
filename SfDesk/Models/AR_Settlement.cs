using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class AR_Settlement
    {
        public bool isSelected { get; set; }
        public DateTime Date { get; set; }
        public DateTime Due_Date { get; set; }
        public string SO_NO { get; set; }
        public decimal Total_Amount { get; set; }
        public decimal Adjusted_Amount { get; set; }
        public decimal Balance_Amount { get; set; }
        public decimal Allocated_Amount { get; set; }
    }
}