using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class GRN
    {
        public int GRN_NO { get; set; }
        public int Suplier_ID { get; set; }
        public String Suplier_Name { get; set; }
        public DateTime Trans_Date { get; set; }
        public DateTime Due_Date { get; set; }
        public int Ref_No { get; set; }
        public string Narration { get; set; }
        public int PI_ID{ get; set; }
    }
}