using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class Journal_Entries
    {
        public int JE_ID { get; set; }
        public string JE_NO { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; } = DateTime.Parse("2001/01/01");

        public string Reference { get; set; }
        [DataType(DataType.MultilineText)]
        public string Memo { get; set; }
        public string Attachment { get; set; }
        public List<JE_Details> details { get; set; }
    }
    public class JE_Details
    {

        public int COA_ID { get; set; }
        public string COA_Name { get; set; }
        public string Description { get; set; }
        public double Debit { get; set; }
        public double Credit { get; set; }
        public int Contact_ID { get; set; }
        public string Contact_Name { get; set; }
    }
}