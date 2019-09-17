﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class Receipt
    {
        public int Rec_ID { get; set; }
        public string Rec_NO { get; set; }
        public int Customer_ID { get; set; }

        public string Customer_Name { get; set; }
      
        [DataType(DataType.Date)]
        [DisplayName("Date")]
        public DateTime Date { get; set; }
     
        public string Currency { get; set; }

        public string AttachmentPath { get; set; }
      
        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }

    }
}