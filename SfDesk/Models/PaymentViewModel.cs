using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class PaymentViewModel
    {
        public int id { get; set; }
        public List<Payment_Mode> mode { get; set; }
        public List<Payment_Detail> detail { get; set; }

    }
}