using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class Recipe
    {
        public int R_ID { get; set; }

        public int P_ID { get; set; }
        public string P_Name { get; set; }
        public int M_ID { get; set; }
        public string M_Name { get; set; }
        public string Unit { get; set; }
        public string Type { get; set; }
        public string Machine_Ip { get; set; }

        public string Mac_Address { get; set; }
        public decimal Quantity { get; set; }
        static List<Recipe> lst =new List<Recipe>();

        public Recipe()
        {
            this.Machine_Ip = Utility.GetIPAddress();
            this.Mac_Address = Utility.GetMacAddress();
            
        }
        public List<Recipe> Product_Get_All()
        {
            return new List<Recipe>();
        }
        public Product Product_Get_By_ID()
        {
            return new Product();
        }

    }
}