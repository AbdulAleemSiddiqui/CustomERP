using DatabaseTVP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class Item_Category
    {
        [TVP]
        public int Cat_ID { get; set; }
        [TVP]
        public string Cat_Name { get; set; }
        [TVP]
        public int CreatedBy{ get; set; }

        public List<Item_Category> Item_Category_Get_All()
        {
            return new List<Item_Category>()
            {
                new Item_Category() {Cat_ID=1,Cat_Name="Row Material" },
                new Item_Category() {Cat_ID=2,Cat_Name="Packaging" },
                new Item_Category() {Cat_ID=3,Cat_Name="stationery" }
            };
        }
    }
}