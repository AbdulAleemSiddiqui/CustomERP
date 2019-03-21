using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class ChartOfAccount
    {
        [DisplayName("ID")]
        public int COA_ID { get; set; }
        public int Code { get; set; }
        [DisplayName("Company Code")]
        public int Company_Code { get; set; }
        public int Type_ID { get; set; }
        public int Group_ID { get; set; }
        [DisplayName("Account Name")]
        public string COA_Name { get; set; }
        [DisplayName("Type")]
        public string Type_Name { get; set; }
        [DisplayName("Group")]
        public string Group_Name { get; set; }
        public void COA_Add()
        {

        }
        public void COA_Update()
        {

        }
        public void COA_Delete()
        {
            
        }
        public ChartOfAccount COA_Get_By_ID(int id)
        {
            return this;
        }
        public List<ChartOfAccount> COA_Get_All()
        {
            return null;
        }
    }
}