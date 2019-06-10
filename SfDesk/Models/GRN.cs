using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class GRN
    {
        public int GRN_NO { get; set; }
        [DisplayName("Suplier")]
        public int Suplier_ID { get; set; }
        public String Suplier_Name { get; set; }
        [DisplayName("Trans. NO")]
        public int Trans_NO { get; set; }
        [DisplayName("Trans. Date")]
        [DataType(DataType.Date)]
        public DateTime Trans_Date { get; set; }
        [DisplayName("Due Date")]
        [DataType(DataType.Date)]
        public DateTime Due_Date { get; set; }
        public string Currency { get; set; }
        [DisplayName("Ref. No")]
        public int Ref_No { get; set; }
        [DisplayName("Ex. Rate")]

        public decimal Exchange_Rate { get; set; }
    }
}