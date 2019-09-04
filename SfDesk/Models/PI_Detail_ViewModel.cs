using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class PI_Detail_ViewModel
    {
        public string PR_No { get; set; }
        public DateTime PR_Date { get; set; }
        public string Department_Name { get; set; }
        public string Item_Name { get; set; }
        public int Quantity { get; set; }
        public bool is_Selected { get; set; }


        
    }
}