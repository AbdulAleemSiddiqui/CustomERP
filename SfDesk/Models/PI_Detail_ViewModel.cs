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
        public int  Item_ID { get; set; }
        public string Item_Name { get; set; }
        public int Quantity { get; set; }
        public bool is_Selected { get; set; }
        public int PRD_ID { get; set; }


        public List<PI_Detail_ViewModel> PI_Detail_Get_All(int Cat_ID)
        {
            return new List<PI_Detail_ViewModel>()
            {
                new PI_Detail_ViewModel() {Item_ID=1,PRD_ID=1,PR_No="123",PR_Date=DateTime.Now,Department_Name="Sales",Item_Name="Item 1",Quantity=23},
                new PI_Detail_ViewModel() {Item_ID=2,PRD_ID=2,PR_No="123",PR_Date=DateTime.Now,Department_Name="Accounts",Item_Name="Item 2",Quantity=54},
                new PI_Detail_ViewModel() {Item_ID=3,PRD_ID=3,PR_No="123",PR_Date=DateTime.Now,Department_Name="Store",Item_Name="Item 3",Quantity=76},
                new PI_Detail_ViewModel() {Item_ID=4,PRD_ID=4,PR_No="123",PR_Date=DateTime.Now,Department_Name="Finance",Item_Name="Item 4",Quantity=76}
            };
        }
    }
}