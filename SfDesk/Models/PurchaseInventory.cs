using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class PurchaseInventory
    {
#region purchase Order master
        [DisplayName("Transaction #")]
        public int Transaction_No { get; set; }
        [DisplayName("P.O #")]
        public int PO_No { get; set; }
        [DisplayName("Invoice #")]
        public string Invoice_No { get; set; }
        [DisplayName("Purchase Type")]
        public string[] Purchase_Type { get; set; }={"","",""};
        [DisplayName("Purchase A/c")]
        public string Purchase_ac { get; set; }
        [DisplayName("Supllier Name")]
        public string Suplier_Name { get; set; }
        public DateTime Date { get; set; }
        [DisplayName("Due Date")]
        public DateTime Due_Date { get; set; }
        [DataType(DataType.MultilineText)]
        public string Comments { get; set; }
        [DisplayName("Vehicle #")]
        public string Vehicle_No { get; set; }
        [DisplayName("Transporter Name")]
        public string Transporter_Name { get; set; }
        [DisplayName("Middle Man")]
        public string Middle_Man { get; set; }
        #endregion
        #region Detail
        [DisplayName("Store / Godown")]
        public string Store { get; set; }
        [DisplayName("Item Code")]
        public int Item_Code { get; set; }
        [DisplayName("Product Name")]
        public string Product_Name { get; set; }
        [DisplayName("Product Description")]
        public string Product_Description { get; set; }
        [DisplayName("Purchase Quantitiy")]
        public int Purchase_Quantitiy { get; set; }
        [DisplayName("Received Quantitiy")]
        public int Received_Quantitiy { get; set; }
       
        public decimal Commision { get; set; }
        
        public decimal Rate { get; set; }
        [DisplayName("Gross Amount")]
        public decimal Gross_Amount { get; set; }
        public decimal Discount { get; set; }
        [DisplayName("Discount Amount")]
        public decimal Discount_Amount { get; set; }
        [DisplayName("Net Amount")]
        public decimal Net_Amount { get; set; }


        #endregion
        #region Tax
        [DisplayName("Less / Add Commision")]
        public decimal Less_add_Commision { get; set; }
     
        public decimal GST { get; set; }
        [DisplayName("Further Tax")]
        public decimal Further_tax { get; set; }
       
        #endregion
    }
}