using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class WorkOrder
    {
        public int WO_ID { get; set; }
        public string WO_NO { get; set; }
        public DateTime Date { get; set; }
        public DateTime Due_Date { get; set; }
        public double Total { get; set; }
        public int Quantity { get; set; }
        public string  Reference { get; set; }
        public List<Recipe_Detail> Input_products { get; set; }
        public List<Recipe_Detail> Output_products { get; set; }
        public List<Recipe_Expense> Account_expences { get; set; }
    }
    public class WO_Detail
    {
    
        public int WOD_ID { get; set; }

      
        public int WO_ID { get; set; }
        
        public int Item_ID { get; set; }
        
        public string Description { get; set; }
       
        public int Quantity { get; set; }
        
        public string Flag { get; set; }

        private const string Module = "";

        //Your Properties for Model Here


        public int CreatedBy { get; set; }

        public string ReturnMessage { get; set; }




    }
    public class WO_Expense
    {
        private const string Module = "";

       
        public int WOE_ID { get; set; }
       
       
        public int COA_ID { get; set; }
        public string COA_Name { get; set; }
        
        public string Description { get; set; }
        
        public decimal Amount { get; set; }
        
        public int CreatedBy { get; set; }


        //View Only Properties
        public string ReturnMessage { get; set; }



    }
}