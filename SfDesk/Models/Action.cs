using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class Action
    {
        public int Action_ID { get; set; }
        public string Action_Name { get; set; }
        public bool isSelected { get; set; }
        public int Created_By { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Created_Date { get; set; } = DateTime.Parse("2001/01/01");
        public string Machine_Ip { get; set; }
        public string Mac_Address { get; set; }


    }
        
}