using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class Expense
    {
        public int Ex_ID { get; set; }
        public string Ex_NO { get; set; }
        public int COA_ID { get; set; }
        public string COA_Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string Contact { get; set; }
        
        public string Reference { get; set; }
        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }
        public string Attachment { get; set; }
        public List<Expence_Detail> details { get; set; }
    }
    public class Expence_Detail
    {
        public int COA_ID { get; set; }
        public string COA_Name { get; set; }
        public string Description { get; set; }
        public Double Gross_Amount { get; set; }
        public int Tax_ID { get; set; }
        public String Tax_Name { get; set; }
        public decimal Net_Amount { get; set; }

    }
}