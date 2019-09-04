using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class Item_Category
    {
        public int IC_ID { get; set; }
        public string IC_Name { get; set; }

        public List<Item_Category> Item_Category_Get_All()
        {
            return new List<Item_Category>()
            {
                new Item_Category() {IC_ID=1,IC_Name="Row Material" },
                new Item_Category() {IC_ID=2,IC_Name="Packaging" },
                new Item_Category() {IC_ID=3,IC_Name="stationery" }
            };
        }
    }
}