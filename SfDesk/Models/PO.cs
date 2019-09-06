using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class PO
    {
        #region purchase Order master
        public List<int> PI_ID { get; set; }
        public int PO_ID { get; set; }
       
        [DisplayName("P.R #")]
        public string PR_No { get; set; }
        [DisplayName("P.O #")]
        public string PO_No { get; set; }
        [DisplayName("Invoice/Ref #")]
        public string Invoice_No { get; set; } = "0";
        public string App_Status { get; set; }
      

        [DisplayName("Item Type")]
        public List<Item_Category> Item_Categories { get; set; }
        //public int Item_Type_ID { get; set; }
        //public string Item_Type_Name { get; set; } = "";


        [DisplayName("Supllier Name")]
        public int Suplier_ID { get; set; }
        public string Suplier_Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Invoice Date")]
        public DateTime Date { get; set; } = DateTime.Parse("2001/01/01");

        public string strngDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Due Date")]
        public DateTime Due_Date { get; set; } = DateTime.Parse("2001/01/01");
        [DataType(DataType.MultilineText)]
        public string Comments { get; set; } = "";

    
        [DisplayName("Middle Man")]
        public int Middle_Man_ID { get; set; }
        public string Middle_Man_Name { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal AllocatedAmount { get; set; }
        public decimal DueAmount { get; set; }
        public string AllocatedStatus { get; set; }
        #endregion
        public List<PO_Details> details { get; set; }
      
        //[Display(Name = "attach file")]
        //[FileExtensions(Extensions = "txt,doc,docx,pdf", ErrorMessage = "Please upload valid format")]
        //public HttpPostedFileBase Attachment { get; set; }

        public string ImagePath { get; set; }
        public decimal Advance { get; set; }
        #region Default
        public int Created_By { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Created_Date { get; set; } = DateTime.Parse("2001/01/01");

        public string Machine_Ip { get; set; }

        public string Mac_Address { get; set; }
        #endregion

   


    }
}