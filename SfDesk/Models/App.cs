using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SfDesk.Models
{
    public class App
    {
        public static int App_ID { get; set; } = 1;
        public string App_Name { get; set; }
    }
    public class Module
    {
        public static int Module_ID { get; set; } = 1;
        public string Module_Name { get; set; }
    }
}